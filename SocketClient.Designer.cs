namespace SocketClient
{
    partial class SocketClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SocketClient));
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsdFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsiConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsdSend = new System.Windows.Forms.ToolStripDropDownButton();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsdDev = new System.Windows.Forms.ToolStripDropDownButton();
            this.base64ConvertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsdHelp = new System.Windows.Forms.ToolStripDropDownButton();
            this.emojiGuideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splMain = new System.Windows.Forms.SplitContainer();
            this.dgUsers = new System.Windows.Forms.DataGridView();
            this.ColImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.Col_Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splMessage = new System.Windows.Forms.SplitContainer();
            this.wbConversation = new System.Windows.Forms.WebBrowser();
            this.btnSend = new System.Windows.Forms.Button();
            this.rtbSend = new System.Windows.Forms.RichTextBox();
            this.tmrUI = new System.Windows.Forms.Timer(this.components);
            this.tsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).BeginInit();
            this.splMain.Panel1.SuspendLayout();
            this.splMain.Panel2.SuspendLayout();
            this.splMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splMessage)).BeginInit();
            this.splMessage.Panel1.SuspendLayout();
            this.splMessage.Panel2.SuspendLayout();
            this.splMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsdFile,
            this.tsdSend,
            this.tsdDev,
            this.tsdHelp});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tsMain.Size = new System.Drawing.Size(783, 25);
            this.tsMain.TabIndex = 0;
            this.tsMain.Text = "toolStrip1";
            // 
            // tsdFile
            // 
            this.tsdFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsdFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiConnect,
            this.tsiExit});
            this.tsdFile.Image = ((System.Drawing.Image)(resources.GetObject("tsdFile.Image")));
            this.tsdFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsdFile.Name = "tsdFile";
            this.tsdFile.Size = new System.Drawing.Size(38, 22);
            this.tsdFile.Text = "&File";
            // 
            // tsiConnect
            // 
            this.tsiConnect.Name = "tsiConnect";
            this.tsiConnect.Size = new System.Drawing.Size(119, 22);
            this.tsiConnect.Text = "&Connect";
            this.tsiConnect.Click += new System.EventHandler(this.tsiConnect_Click);
            // 
            // tsiExit
            // 
            this.tsiExit.Name = "tsiExit";
            this.tsiExit.Size = new System.Drawing.Size(119, 22);
            this.tsiExit.Text = "&Exit";
            this.tsiExit.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // tsdSend
            // 
            this.tsdSend.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageToolStripMenuItem,
            this.fileToolStripMenuItem});
            this.tsdSend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsdSend.Name = "tsdSend";
            this.tsdSend.Size = new System.Drawing.Size(46, 22);
            this.tsdSend.Text = "Send";
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.Image = global::SocketClient.Properties.Resources.picture;
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.imageToolStripMenuItem.Text = "Image";
            this.imageToolStripMenuItem.Click += new System.EventHandler(this.imageToolStripMenuItem_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Image = global::SocketClient.Properties.Resources.file;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // tsdDev
            // 
            this.tsdDev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsdDev.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.base64ConvertToolStripMenuItem});
            this.tsdDev.Image = ((System.Drawing.Image)(resources.GetObject("tsdDev.Image")));
            this.tsdDev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsdDev.Name = "tsdDev";
            this.tsdDev.Size = new System.Drawing.Size(40, 22);
            this.tsdDev.Text = "Dev";
            // 
            // base64ConvertToolStripMenuItem
            // 
            this.base64ConvertToolStripMenuItem.Name = "base64ConvertToolStripMenuItem";
            this.base64ConvertToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.base64ConvertToolStripMenuItem.Text = "Base64 Convert";
            this.base64ConvertToolStripMenuItem.Click += new System.EventHandler(this.base64ConvertToolStripMenuItem_Click);
            // 
            // tsdHelp
            // 
            this.tsdHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsdHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emojiGuideToolStripMenuItem});
            this.tsdHelp.Image = ((System.Drawing.Image)(resources.GetObject("tsdHelp.Image")));
            this.tsdHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsdHelp.Name = "tsdHelp";
            this.tsdHelp.Size = new System.Drawing.Size(45, 22);
            this.tsdHelp.Text = "Help";
            // 
            // emojiGuideToolStripMenuItem
            // 
            this.emojiGuideToolStripMenuItem.Name = "emojiGuideToolStripMenuItem";
            this.emojiGuideToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.emojiGuideToolStripMenuItem.Text = "Emoji Guide";
            this.emojiGuideToolStripMenuItem.Click += new System.EventHandler(this.emojiGuideToolStripMenuItem_Click);
            // 
            // splMain
            // 
            this.splMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splMain.Location = new System.Drawing.Point(0, 25);
            this.splMain.Margin = new System.Windows.Forms.Padding(4);
            this.splMain.Name = "splMain";
            // 
            // splMain.Panel1
            // 
            this.splMain.Panel1.Controls.Add(this.dgUsers);
            // 
            // splMain.Panel2
            // 
            this.splMain.Panel2.Controls.Add(this.splMessage);
            this.splMain.Size = new System.Drawing.Size(783, 414);
            this.splMain.SplitterDistance = 200;
            this.splMain.SplitterWidth = 6;
            this.splMain.TabIndex = 1;
            // 
            // dgUsers
            // 
            this.dgUsers.AllowUserToAddRows = false;
            this.dgUsers.AllowUserToDeleteRows = false;
            this.dgUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColImage,
            this.Col_Username});
            this.dgUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgUsers.Location = new System.Drawing.Point(0, 0);
            this.dgUsers.Margin = new System.Windows.Forms.Padding(4);
            this.dgUsers.Name = "dgUsers";
            this.dgUsers.ReadOnly = true;
            this.dgUsers.RowHeadersVisible = false;
            this.dgUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgUsers.ShowEditingIcon = false;
            this.dgUsers.ShowRowErrors = false;
            this.dgUsers.Size = new System.Drawing.Size(200, 414);
            this.dgUsers.TabIndex = 0;
            // 
            // ColImage
            // 
            this.ColImage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColImage.HeaderText = "";
            this.ColImage.Name = "ColImage";
            this.ColImage.ReadOnly = true;
            this.ColImage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColImage.Width = 32;
            // 
            // Col_Username
            // 
            this.Col_Username.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Col_Username.HeaderText = "Username";
            this.Col_Username.Name = "Col_Username";
            this.Col_Username.ReadOnly = true;
            this.Col_Username.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // splMessage
            // 
            this.splMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splMessage.Location = new System.Drawing.Point(0, 0);
            this.splMessage.Margin = new System.Windows.Forms.Padding(4);
            this.splMessage.Name = "splMessage";
            this.splMessage.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splMessage.Panel1
            // 
            this.splMessage.Panel1.Controls.Add(this.wbConversation);
            // 
            // splMessage.Panel2
            // 
            this.splMessage.Panel2.Controls.Add(this.btnSend);
            this.splMessage.Panel2.Controls.Add(this.rtbSend);
            this.splMessage.Size = new System.Drawing.Size(577, 414);
            this.splMessage.SplitterDistance = 300;
            this.splMessage.SplitterWidth = 5;
            this.splMessage.TabIndex = 0;
            // 
            // wbConversation
            // 
            this.wbConversation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbConversation.IsWebBrowserContextMenuEnabled = false;
            this.wbConversation.Location = new System.Drawing.Point(0, 0);
            this.wbConversation.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbConversation.Name = "wbConversation";
            this.wbConversation.Size = new System.Drawing.Size(577, 300);
            this.wbConversation.TabIndex = 0;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(449, 4);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(123, 96);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // rtbSend
            // 
            this.rtbSend.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbSend.Location = new System.Drawing.Point(4, 4);
            this.rtbSend.Margin = new System.Windows.Forms.Padding(4);
            this.rtbSend.Name = "rtbSend";
            this.rtbSend.Size = new System.Drawing.Size(433, 94);
            this.rtbSend.TabIndex = 0;
            this.rtbSend.Text = "";
            this.rtbSend.KeyUp += new System.Windows.Forms.KeyEventHandler(this.rtbSend_KeyUp);
            // 
            // tmrUI
            // 
            this.tmrUI.Enabled = true;
            this.tmrUI.Interval = 1000;
            this.tmrUI.Tick += new System.EventHandler(this.tmrUI_Tick);
            // 
            // SocketClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 439);
            this.Controls.Add(this.splMain);
            this.Controls.Add(this.tsMain);
            this.Font = new System.Drawing.Font("Arial", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SocketClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SocketChat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SocketClient_FormClosing);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.splMain.Panel1.ResumeLayout(false);
            this.splMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).EndInit();
            this.splMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgUsers)).EndInit();
            this.splMessage.Panel1.ResumeLayout(false);
            this.splMessage.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splMessage)).EndInit();
            this.splMessage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripDropDownButton tsdFile;
        private System.Windows.Forms.ToolStripMenuItem tsiExit;
        private System.Windows.Forms.SplitContainer splMain;
        private System.Windows.Forms.DataGridView dgUsers;
        private System.Windows.Forms.SplitContainer splMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.RichTextBox rtbSend;
        private System.Windows.Forms.ToolStripMenuItem tsiConnect;
        private System.Windows.Forms.ToolStripDropDownButton tsdSend;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Timer tmrUI;
        private System.Windows.Forms.DataGridViewImageColumn ColImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Username;
        private System.Windows.Forms.WebBrowser wbConversation;
        private System.Windows.Forms.ToolStripDropDownButton tsdDev;
        private System.Windows.Forms.ToolStripMenuItem base64ConvertToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton tsdHelp;
        private System.Windows.Forms.ToolStripMenuItem emojiGuideToolStripMenuItem;
    }
}

