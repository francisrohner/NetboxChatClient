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
    public partial class DownloadWindow : Form
    {
        public DownloadWindow()
        {
            InitializeComponent();
            AddRow();
        }
        void AddRow()
        {
            
            int rowIndex = dgDownloads.Rows.Add(new string[] { @"C:\Debug.png", "0%", "Cancel", "Open"} );
            dgDownloads.Rows[rowIndex].Height = 30;
            //((Button)dgDownloads.Rows[rowIndex].Cells[2].Value).Click += DownloadWindow_Click;
            dgDownloads.CellClick += DgDownloads_CellClick;
        }

        private void DgDownloads_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 2) //Cancel
            {
                MessageBox.Show("Cancel");
            }
            else if(e.ColumnIndex == 3) //Open
            {
                MessageBox.Show("Open");
            }
        }

        private void DownloadWindow_Click(object sender, EventArgs e)
        {
            MessageBox.Show("dbg");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
