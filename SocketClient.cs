using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketClient
{
    public partial class SocketClient : Form
    {
        private Socket socket;
        Thread listenThread;
        private bool listen = true;
        private List<Tuple<string, string>> conversationLines = new List<Tuple<string, string>>();
        private int MAX_CONVERSATION_LINES = 300;
        private string nick;
        Dictionary<string, string> emojii_b64;
        long MAX_WAIT_TIME = 10000;

        public SocketClient()
        {
            InitializeComponent();
            Panel notConnectedPanel = new Panel();
            notConnectedPanel.Name = "pnlNotConnected";
            Label lblNotConnected = new Label();
            lblNotConnected.Text = "Please Connect First (File > Connect)";

            Button btnConnect = new Button();
            btnConnect.Text = "Connect";
            btnConnect.Font = Font;
            btnConnect.Width = 200;
            btnConnect.Height = 100;
            btnConnect.TextAlign = ContentAlignment.MiddleCenter;
            //notConnectedPanel.Controls.Add(lblNotConnected);
            notConnectedPanel.Controls.Add(btnConnect);
            lblNotConnected.Dock = DockStyle.Fill;
            lblNotConnected.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(notConnectedPanel);
            notConnectedPanel.Dock = DockStyle.Fill;
            btnConnect.Location = new Point((notConnectedPanel.Width / 2) - (btnConnect.Width / 2), (notConnectedPanel.Height / 2) - (btnConnect.Height / 2));
            //btnConnect.Click += (se, ev) => { };
            btnConnect.Click += tsiConnect_Click;
            notConnectedPanel.BringToFront();
            socket = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            StringBuilder htmlBuilder = new StringBuilder();
            htmlBuilder.AppendLine("<htm>");
            htmlBuilder.AppendLine("<body>");
            htmlBuilder.AppendLine("<footer></footer>");
            htmlBuilder.AppendLine("</body>");
            htmlBuilder.AppendLine("</html>");
            wbConversation.DocumentText = htmlBuilder.ToString();
            wbConversation.DocumentCompleted += WbConversation_DocumentCompleted;
            wbConversation.Navigated += WbConversation_Navigated;

            emojii_b64 = new Dictionary<string, string>();
            string[] lines = File.ReadAllLines("base64_strings.txt");
            for (int i = 0; i < lines.Length; i += 3)
                emojii_b64.Add(lines[i], lines[i + 1]);


            wbConversation.ContextMenuStrip = new ContextMenuStrip();
            wbConversation.ContextMenuStrip.Items.Add("View");
            wbConversation.ContextMenuStrip.Items.Add("Save");
            foreach (ToolStripMenuItem tsmi in wbConversation.ContextMenuStrip.Items)
                tsmi.Click += Tsmi_Click;

            wbConversation.ContextMenuStrip.Opening += ContextMenuStrip_Opening;
        }

        private void Tsmi_Click(object sender, EventArgs e)
        {
            string senderText = ((ToolStripMenuItem)sender).Text.ToLower();
            if (senderText.Equals("save"))
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PNG Image|*.png|JPG Image|*.jpg|BMP Image|*.bmp";
                sfd.ShowDialog();
                if (String.IsNullOrEmpty(sfd.FileName)) return;
                Image img = ParseBase64Image(wbConversation.ContextMenuStrip.Tag.ToString());
                img.Save(sfd.FileName);
            }
            else if (senderText.Equals("view"))
            {
                ShowPreview(wbConversation.ContextMenuStrip.Tag.ToString());
            }
        }

        bool ready = false;
        private void ContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {            
            e.Cancel = !ready;
        }

        private void WbConversation_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            var elements = wbConversation.Document.Body.GetElementsByTagName("footer");
            if (elements.Count > 0)
                elements[0].ScrollIntoView(false);
        }

        private void WbConversation_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var elements = wbConversation.Document.Body.GetElementsByTagName("footer");
            if (elements.Count > 0)
                elements[0].ScrollIntoView(false);
            for (int i = 0; i < wbConversation.Document.Images.Count; i++)
            {
                wbConversation.Document.Images[i].DoubleClick += new HtmlElementEventHandler(LinkClick);
                wbConversation.Document.Images[i].MouseUp += new HtmlElementEventHandler(LinkMouseUp);
            }
        }

        void LinkMouseUp(object sender, HtmlElementEventArgs e)
        {
            HtmlElement element = ((HtmlElement)sender);
            if (e.MouseButtonsPressed == MouseButtons.Right)
            {
                ready = true;
                //wbConversation.ContextMenuStrip.Tag = element.GetAttribute("src");
                wbConversation.ContextMenuStrip.Tag = element.GetAttribute("href").Trim();
                wbConversation.ContextMenuStrip.Show(e.ClientMousePosition);
                ready = false;
            }
        }
        public string FixBase64ForImage(string Image)
        {
            StringBuilder sbText = new StringBuilder(Image, Image.Length);
            sbText.Replace("\r\n", String.Empty); sbText.Replace(" ", String.Empty);
            return sbText.ToString();
        }
        void ShowPreview(string b64)
        {
            Form frm = new Form();
            PictureBox prevBox = new PictureBox();
            b64 = b64.Trim();
            b64 = FixBase64ForImage(b64);
            prevBox.Image = ParseBase64Image(b64);
            frm.Controls.Add(prevBox);
            prevBox.Dock = DockStyle.Fill;
            prevBox.SizeMode = PictureBoxSizeMode.StretchImage;
            frm.Width = 500;
            frm.ShowIcon = false;
            frm.Height = 500;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show(this);
        }

        void LinkClick(object sender, HtmlElementEventArgs e)
        {
            HtmlElement element = ((HtmlElement)sender);
            string id = element.Id;
            string href = element.GetAttribute("href");
            ShowPreview(href);

        }

        private string ParseMessage(byte[] data)
        {
            if (data == null || data.Length < 1)
                return string.Empty;
            byte[] trunk = new byte[data.Length - 1];
            Array.Copy(data, 1, trunk, 0, trunk.Length);
            return Encoding.ASCII.GetString(trunk).Replace("<<EOT>>", "");
        }

        private byte[] PrepareMessageForTransit(string msg)
        {
            string eotData = "<<EOT>>";
            byte[] eotBytes = Encoding.ASCII.GetBytes(eotData);
            byte[] msgBytes = Encoding.ASCII.GetBytes(msg);


            byte[] bytesOut = new byte[eotBytes.Length + msgBytes.Length + 1];
            bytesOut[0] = 0;
            Array.Copy(msgBytes, 0, bytesOut, 1, msgBytes.Length);
            Array.Copy(eotBytes, 0, bytesOut, 1 + msgBytes.Length, eotBytes.Length);
            return bytesOut;

        }

        private int LocateEOT(byte[] data)
        {
            int eotStartIndex = -1;
            int eotIndex = 0;
            string eotData = "<<EOT>>";
            byte[] eotBytes = Encoding.ASCII.GetBytes(eotData);
            for (int i = 0; i < data.Length && eotIndex < eotData.Length; i++)
            {
                if (data[i] == eotBytes[eotIndex++])
                {
                    if (eotIndex == 1) //Previous index was 0 and it matched, set start
                        eotStartIndex = i;
                }
                else
                {
                    eotIndex = 0;
                    eotStartIndex = -1;
                }
            }
            return eotStartIndex;
        }

        private bool HasEOT(byte[] data)
        {
            return LocateEOT(data) != -1;
            //Match Java method
            /**
            int bytesMatched = 0;
            string eotData = "<<EOT>>";
            byte[] eotBytes = Encoding.ASCII.GetBytes(eotData);
            if (data.Length < eotBytes.Length) return false;
            for(int i = 0; i < data.Length; i++)
            {
                if (data[i] == eotBytes[bytesMatched])
                    ++bytesMatched;
                if (bytesMatched == eotData.Length) break;
            }
            return bytesMatched == eotData.Length;
            */
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsiConnect_Click(object sender, EventArgs e)
        {

            Connect quickLogin = new Connect();
            quickLogin.ShowDialog(this);
            if (quickLogin.Tag == null)
            {
                MessageBox.Show(this, "Cancelled connection.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            bool success = true;
            try
            {
                socket.Connect(quickLogin.Tag.ToString().Split(',')[0], int.Parse(quickLogin.Tag.ToString().Split(',')[1]));
            }
            catch { success = false; }
            if (success) success = socket.Connected;
            if (!success)
            {
                MessageBox.Show(this, "Unable to connect to server.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            listenThread = new Thread(new ThreadStart(() =>
                {
                    while (listen && socket.Connected)
                    {
                        if (socket.Available > 0)
                        {
                            byte[] buffer = null;
                            List<byte> lstBytes = new List<byte>();
                            int readAmt = 0;
                            while (!HasEOT(lstBytes.ToArray()) && socket.Available > 0)
                            {
                                buffer = new byte[2048];
                                readAmt = socket.Receive(buffer);
                                for (int i = 0; i < readAmt; i++)
                                    lstBytes.Add(buffer[i]);

                            }
                            lstUpdateUI.Add(ParseMessage(lstBytes.ToArray()));
                        }
                        Thread.Sleep(100);
                    }
                }
            ));
            listenThread.Start();

            Control[] controls = Controls.Find("pnlNotConnected", true);
            if (controls.Length < 1)
                return;
            Control purge = controls.First();
            Control lblPurge = purge.Controls[0];
            purge.Controls.RemoveAt(0);
            lblPurge.Dispose();
            Controls.Remove(purge);
            purge.Dispose();
            nick = quickLogin.Tag.ToString().Split(',')[2]; ;
            this.nick = quickLogin.Tag.ToString().Split(',')[2];
            SendMsg("set nick " + nick);
            Thread.Sleep(500);
            SendMsg("list users");

        }

        void SendMsg(string msg, bool wait = false)
        {
            if (!socket.Connected)
                return;
            Thread sendThread = new Thread(new ThreadStart(() =>
            {
                byte[] data = PrepareMessageForTransit(msg);
                Stopwatch waitWatch = new Stopwatch();
                waitWatch.Start();
                while (socket.Available > 0 && waitWatch.ElapsedMilliseconds < MAX_WAIT_TIME) ;
                socket.Send(data);
            }));
            sendThread.Start();
            if (wait)
                while (sendThread.IsAlive) ;

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMsg(rtbSend.Text);
            rtbSend.Clear();
        }
        private List<string> lstUpdateUI = new List<string>();
        private bool FLAG_PROCESSING_UI = false;
        private void tmrUI_Tick(object sender, EventArgs e)
        {
            if (FLAG_PROCESSING_UI) return;
            FLAG_PROCESSING_UI = true;
            while (lstUpdateUI.Count > 0)
            {
                string cur = lstUpdateUI[0];
                Console.WriteLine("Processing {0}", cur);
                lstUpdateUI.RemoveAt(0);
                if (string.IsNullOrEmpty(cur)) continue; //nothing to process
                if (cur.Contains("<<") && cur.Contains(">>"))
                {
                    if (cur.Contains("<<Users>>"))
                    {
                        dgUsers.Rows.Clear();
                        string[] users = cur.Replace("\r", "").Split('\n');
                        foreach (string user in users)
                        {
                            if (String.IsNullOrEmpty(user)) continue;
                            if (user.Contains("<<Initiate>>") || user.Contains("<<Users>>")) continue;
                            int rowID = dgUsers.Rows.Add();
                            dgUsers.Rows[rowID].Cells[1].Value = user;
                            dgUsers.Rows[rowID].Cells[0].Value = new Bitmap(Properties.Resources.user_online, 16, 16);

                        }
                    }
                    else if (cur.Contains("<<Join>>") || cur.Contains("<<Left>>"))
                        SendMsg("list users");
                }
                else
                {
                    if (cur.IndexOf(":") == -1) continue;
                    string name = cur.Substring(0, cur.IndexOf(":"));
                    string msg = cur.Substring(cur.IndexOf(":") + 1);

                    conversationLines.Add(new Tuple<string, string>(name, msg));
                    if (conversationLines.Count > MAX_CONVERSATION_LINES)
                        conversationLines.RemoveAt(0);
                    StringBuilder htmlBuilder = new StringBuilder();
                    htmlBuilder.AppendLine("<html>");
                    htmlBuilder.AppendLine("<head><style> h2 { margin:0; }</style></head>");
                    htmlBuilder.AppendLine("<body>");
                    foreach (Tuple<string, string> line in conversationLines)
                    {
                        string msgLine = string.Format("<h2><span style='color:{2};'>{0}: </span>{1}</h2>", line.Item1, line.Item2.Replace("\n", "</br>"),
                            line.Item1.Equals(nick) ? "red" : "blue");
                        if (msgLine.Count(c => c == ':') > 2) //emoji
                        {
                            foreach (string emoji in emojii_b64.Keys)
                                if (msgLine.Contains(":" + emoji + ":"))
                                    msgLine = msgLine.Replace(":" + emoji + ":", GetEmoji(emoji));
                        }
                        if (line.Item2.Contains("image:"))
                        {
                            string type = line.Item2.Replace("image:", "").Split(':')[0].Trim();
                            string b64 = line.Item2.Replace("image:", "").Replace(type + ":", "");
                            //Image img = ParseBase64Image(msgLine.Replace("image:", ""));
                            msgLine = string.Format("<h2><span style='color:{1};'>{0}:</span></h2>", line.Item1,
                           line.Item1.Equals(nick) ? "red" : "blue");
                            msgLine += "</br>";
                            msgLine += BuildB64Img(b64, type, 400, 400, true);

                        }
                        htmlBuilder.AppendLine(msgLine);
                    }
                    htmlBuilder.AppendLine("<footer></footer>");
                    htmlBuilder.AppendLine("</body>");
                    htmlBuilder.AppendLine("</html>");
                    wbConversation.DocumentText = htmlBuilder.ToString();
                }
            }
            FLAG_PROCESSING_UI = false;

        }

        string GetEmoji(string strEmoji, int width = 24, int height = 24)
        {
            if (!emojii_b64.ContainsKey(strEmoji))
                return ":" + strEmoji + ":";
            string b64 = emojii_b64[strEmoji];
            return BuildB64Img(b64, "png", width, height);
        }
        string BuildB64Img(string b64, string format, int width, int height, bool withHref = false)
        {
            string strFormat = string.Format("data:image/{0};base64,", format);
            string href = string.Empty;
            if (withHref)
                href = string.Format("href='{0}'", b64);
            string imgElement = string.Format("<img style='width:{2};height:{3}' src='{0}{1}' {4}></img>", strFormat, b64, width, height, href);
            return imgElement;
        }

        private void SocketClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                listen = false;
                if (socket.Connected)
                {
                    SendMsg("<<Left>>", true);
                    socket.Close();
                }
            }
            catch { }
        }

        private void rtbSend_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Shift)
            {
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Enter)
            {
                rtbSend.Text = rtbSend.Text.TrimEnd('\r').TrimEnd('\n');
                btnSend.PerformClick();
                e.Handled = true;
            }
        }
        string ImageToB64(string imagePath)
        {
            using (Image image = Image.FromFile(imagePath))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();
                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
        }
        private void base64ConvertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult dr = fbd.ShowDialog();
            if (dr == DialogResult.Cancel) return;
            string[] files = Directory.GetFiles(fbd.SelectedPath);
            StringBuilder outBuilder = new StringBuilder();
            string[] imgExt = { ".png", ".bmp", ".jpg", ".jpeg" };

            foreach (string file in files)
            {
                if (imgExt.Any(ext => file.ToLower().EndsWith(ext)))
                {
                    string cleanName = file;
                    if (cleanName.Contains(@"\"))
                        cleanName = cleanName.Substring(cleanName.LastIndexOf(@"\") + 1).Split('.')[0];

                    outBuilder.AppendLine(cleanName);
                    outBuilder.AppendLine(ImageToB64(file));
                }
            }
            File.WriteAllText("base64_strings.txt", outBuilder.ToString());
            Process.Start("base64_strings.txt");
        }

        public Image ParseBase64Image(string str)
        {
            try
            {
                //str = str + "=";
                //str = System.Net.WebUtility.UrlDecode(str);
                Byte[] bitmapData = Convert.FromBase64String(str);
                MemoryStream streamBitmap = new MemoryStream(bitmapData);
                Image img = Image.FromStream(streamBitmap);
                return img;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Parse error");
                return null;
            }
        }

        private void emojiGuideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new Form();
            try
            {
                Image img = ParseBase64Image(emojii_b64["happy"]);
                Bitmap bmp = (Bitmap)img;
                form.Icon = Icon.FromHandle(bmp.GetHicon());
            }
            catch { }
            form.Text = "Emoji Guide";
            form.Controls.Add(new WebBrowser());
            WebBrowser wbContr = (WebBrowser)form.Controls[0];
            wbContr.Dock = DockStyle.Fill;
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("<html>");
            builder.AppendLine("<body>");
            foreach (string emoji in emojii_b64.Keys)
                builder.AppendLine("<h2 style='margin:0'>:" + emoji + ": " + GetEmoji(emoji) + "</h2></br>");

            builder.AppendLine("</body>");
            builder.AppendLine("</html>");

            form.Width = 500;
            form.Height = 500;

            wbContr.DocumentText = builder.ToString();


            form.Controls.Add(wbContr);
            form.Show(this);
        }

        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            string[] imgExt = { ".png", ".bmp", ".jpg", ".jpeg" };
            ofd.Filter = "PNG Image|*.png|JPG Image|*.jpg|BMP Image|*.bmp";
            ofd.ShowDialog(this);
            if (String.IsNullOrEmpty(ofd.FileName)) return;
            if (!ofd.CheckFileExists) return;
            string b64 = ImageToB64(ofd.FileName);
            string imgMsg = string.Format("image:{0}:{1}", ofd.FileName.Substring(ofd.FileName.LastIndexOf(".") + 1), b64);
            SendMsg(imgMsg);
        }
    }

}
