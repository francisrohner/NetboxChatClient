namespace SocketClient
{
    partial class DownloadWindow
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
            if (disposing && (components != null))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadWindow));
            this.dgDownloads = new System.Windows.Forms.DataGridView();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.tmrUI = new System.Windows.Forms.Timer(this.components);
            this.Col_FilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Progress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Cancel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Col_Open = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgDownloads)).BeginInit();
            this.SuspendLayout();
            // 
            // dgDownloads
            // 
            this.dgDownloads.AllowUserToAddRows = false;
            this.dgDownloads.AllowUserToDeleteRows = false;
            this.dgDownloads.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgDownloads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDownloads.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Col_FilePath,
            this.Col_Progress,
            this.Col_Cancel,
            this.Col_Open});
            this.dgDownloads.Location = new System.Drawing.Point(13, 17);
            this.dgDownloads.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgDownloads.Name = "dgDownloads";
            this.dgDownloads.ReadOnly = true;
            this.dgDownloads.RowHeadersVisible = false;
            this.dgDownloads.ShowRowErrors = false;
            this.dgDownloads.Size = new System.Drawing.Size(622, 259);
            this.dgDownloads.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(404, 284);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(231, 46);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClear.Location = new System.Drawing.Point(13, 284);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(231, 46);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // tmrUI
            // 
            this.tmrUI.Enabled = true;
            this.tmrUI.Interval = 1000;
            // 
            // Col_FilePath
            // 
            this.Col_FilePath.HeaderText = "File Path";
            this.Col_FilePath.Name = "Col_FilePath";
            this.Col_FilePath.ReadOnly = true;
            this.Col_FilePath.Width = 350;
            // 
            // Col_Progress
            // 
            this.Col_Progress.HeaderText = "Progress";
            this.Col_Progress.Name = "Col_Progress";
            this.Col_Progress.ReadOnly = true;
            // 
            // Col_Cancel
            // 
            this.Col_Cancel.HeaderText = "Cancel";
            this.Col_Cancel.Name = "Col_Cancel";
            this.Col_Cancel.ReadOnly = true;
            this.Col_Cancel.Text = "Cancel";
            // 
            // Col_Open
            // 
            this.Col_Open.HeaderText = "Open";
            this.Col_Open.Name = "Col_Open";
            this.Col_Open.ReadOnly = true;
            this.Col_Open.Text = "Open";
            // 
            // DownloadWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 343);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dgDownloads);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DownloadWindow";
            this.Text = "Download Manager";
            ((System.ComponentModel.ISupportInitialize)(this.dgDownloads)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgDownloads;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Timer tmrUI;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_FilePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Progress;
        private System.Windows.Forms.DataGridViewButtonColumn Col_Cancel;
        private System.Windows.Forms.DataGridViewButtonColumn Col_Open;
    }
}