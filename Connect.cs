using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketClient
{
    public partial class Connect : Form
    {
        public Connect()
        {
            InitializeComponent();
            try
            {
                Icon = Icon.FromHandle(Properties.Resources.plug.GetHicon());
            }
            catch { }
            //string[] names = { "Red", "Blue", "Green", "Purple", "Yellow", "Magenta", "Turquoise", "Black", "White" };
            //names = new string[] { "", "" };
            //Random random = new Random();
            //txtNick.Text = names[random.Next(names.Length)];
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtIP.Text) || string.IsNullOrEmpty(txtNick.Text) || string.IsNullOrEmpty(txtPort.Text))
            {
                MessageBox.Show(this, "All fields must be filled out before connecting to the server.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Tag = string.Format("{0},{1},{2}", txtIP.Text, txtPort.Text, txtNick.Text);
            Close();
        }
    }
}
