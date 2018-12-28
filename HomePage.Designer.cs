namespace YUVDecoder
{
    partial class HomePage
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openFile = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.playButton = new System.Windows.Forms.ToolStripMenuItem();
            this.settings = new System.Windows.Forms.ToolStripMenuItem();
            this.fileName = new System.Windows.Forms.Label();
            this.yuvFormatLabel = new System.Windows.Forms.Label();
            this.frameSizeLabel = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.playButton,
            this.settings});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(806, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFile,
            this.saveFile});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // openFile
            // 
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(180, 22);
            this.openFile.Text = "Open";
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // saveFile
            // 
            this.saveFile.Enabled = false;
            this.saveFile.Name = "saveFile";
            this.saveFile.Size = new System.Drawing.Size(180, 22);
            this.saveFile.Text = "Save";
            this.saveFile.Click += new System.EventHandler(this.saveFile_Click);
            // 
            // playButton
            // 
            this.playButton.Enabled = false;
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(41, 20);
            this.playButton.Text = "Play";
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // settings
            // 
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(61, 20);
            this.settings.Text = "Settings";
            this.settings.Click += new System.EventHandler(this.settings_Click);
            // 
            // fileName
            // 
            this.fileName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.fileName.Location = new System.Drawing.Point(128, 24);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(545, 36);
            this.fileName.TabIndex = 2;
            this.fileName.Text = "Select a File.";
            this.fileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // yuvFormatLabel
            // 
            this.yuvFormatLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.yuvFormatLabel.Location = new System.Drawing.Point(12, 35);
            this.yuvFormatLabel.Name = "yuvFormatLabel";
            this.yuvFormatLabel.Size = new System.Drawing.Size(182, 23);
            this.yuvFormatLabel.TabIndex = 3;
            this.yuvFormatLabel.Text = "4:2:0 8-bit";
            // 
            // frameSizeLabel
            // 
            this.frameSizeLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.frameSizeLabel.Location = new System.Drawing.Point(612, 35);
            this.frameSizeLabel.Name = "frameSizeLabel";
            this.frameSizeLabel.Size = new System.Drawing.Size(182, 23);
            this.frameSizeLabel.TabIndex = 4;
            this.frameSizeLabel.Text = "176x144";
            this.frameSizeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox.Location = new System.Drawing.Point(12, 61);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(782, 444);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 5;
            this.pictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(357, 264);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Lütfen bekleyin...";
            this.label1.Visible = false;
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 517);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.frameSizeLabel);
            this.Controls.Add(this.yuvFormatLabel);
            this.Controls.Add(this.fileName);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "HomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home Page";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openFile;
        private System.Windows.Forms.ToolStripMenuItem saveFile;
        private System.Windows.Forms.ToolStripMenuItem playButton;
        private System.Windows.Forms.ToolStripMenuItem settings;
        private System.Windows.Forms.Label fileName;
        private System.Windows.Forms.Label yuvFormatLabel;
        private System.Windows.Forms.Label frameSizeLabel;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label1;
    }
}

