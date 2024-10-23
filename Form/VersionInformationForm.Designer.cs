namespace TCPConsole {
    partial class VersionInformationForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VersionInformationForm));
            this.linkLabelURLHome = new System.Windows.Forms.LinkLabel();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.labelEdition = new System.Windows.Forms.Label();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.backgroundWorker4 = new System.ComponentModel.BackgroundWorker();
            this.pictureBoxCopyright = new System.Windows.Forms.PictureBox();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.linkLabelSponsor = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCopyright)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabelURLHome
            // 
            this.linkLabelURLHome.AutoSize = true;
            this.linkLabelURLHome.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabelURLHome.Location = new System.Drawing.Point(93, 133);
            this.linkLabelURLHome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabelURLHome.Name = "linkLabelURLHome";
            this.linkLabelURLHome.Size = new System.Drawing.Size(430, 33);
            this.linkLabelURLHome.TabIndex = 2;
            this.linkLabelURLHome.Text = "TCP控制台——IT资源网产品";
            this.linkLabelURLHome.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelURLHome_LinkClicked);
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Font = new System.Drawing.Font("华文行楷", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelAuthor.Location = new System.Drawing.Point(208, 182);
            this.labelAuthor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(132, 25);
            this.labelAuthor.TabIndex = 3;
            this.labelAuthor.Text = "李传玖开发";
            // 
            // labelEdition
            // 
            this.labelEdition.AutoSize = true;
            this.labelEdition.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEdition.Location = new System.Drawing.Point(187, 212);
            this.labelEdition.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEdition.Name = "labelEdition";
            this.labelEdition.Size = new System.Drawing.Size(77, 12);
            this.labelEdition.TabIndex = 4;
            this.labelEdition.Text = "版本号:2.2.1";
            // 
            // labelCopyright
            // 
            this.labelCopyright.AutoSize = true;
            this.labelCopyright.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelCopyright.Location = new System.Drawing.Point(320, 212);
            this.labelCopyright.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(41, 12);
            this.labelCopyright.TabIndex = 5;
            this.labelCopyright.Text = "李传玖";
            // 
            // pictureBoxCopyright
            // 
            this.pictureBoxCopyright.Image = global::TCPConsole.Properties.Resources.Copyright;
            this.pictureBoxCopyright.Location = new System.Drawing.Point(305, 212);
            this.pictureBoxCopyright.Name = "pictureBoxCopyright";
            this.pictureBoxCopyright.Size = new System.Drawing.Size(12, 12);
            this.pictureBoxCopyright.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCopyright.TabIndex = 6;
            this.pictureBoxCopyright.TabStop = false;
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxIcon.Image = global::TCPConsole.Properties.Resources.icon;
            this.pictureBoxIcon.Location = new System.Drawing.Point(16, 116);
            this.pictureBoxIcon.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(69, 50);
            this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxIcon.TabIndex = 1;
            this.pictureBoxIcon.TabStop = false;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxLogo.Image = global::TCPConsole.Properties.Resources.logo;
            this.pictureBoxLogo.Location = new System.Drawing.Point(13, 6);
            this.pictureBoxLogo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(519, 104);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            this.pictureBoxLogo.Click += new System.EventHandler(this.pictureBoxLogo_Click);
            // 
            // linkLabelSponsor
            // 
            this.linkLabelSponsor.AutoSize = true;
            this.linkLabelSponsor.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabelSponsor.Location = new System.Drawing.Point(248, 234);
            this.linkLabelSponsor.Name = "linkLabelSponsor";
            this.linkLabelSponsor.Size = new System.Drawing.Size(53, 12);
            this.linkLabelSponsor.TabIndex = 7;
            this.linkLabelSponsor.TabStop = true;
            this.linkLabelSponsor.Text = "赞助开发";
            this.linkLabelSponsor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSponsor_LinkClicked);
            // 
            // VersionInformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 277);
            this.Controls.Add(this.linkLabelSponsor);
            this.Controls.Add(this.pictureBoxCopyright);
            this.Controls.Add(this.labelCopyright);
            this.Controls.Add(this.labelEdition);
            this.Controls.Add(this.labelAuthor);
            this.Controls.Add(this.linkLabelURLHome);
            this.Controls.Add(this.pictureBoxIcon);
            this.Controls.Add(this.pictureBoxLogo);
            this.Font = new System.Drawing.Font("宋体", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VersionInformationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "关于我们";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCopyright)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.LinkLabel linkLabelURLHome;
        private System.Windows.Forms.Label labelAuthor;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Label labelEdition;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.Windows.Forms.Label labelCopyright;
        private System.ComponentModel.BackgroundWorker backgroundWorker4;
        private System.Windows.Forms.PictureBox pictureBoxCopyright;
        private System.Windows.Forms.LinkLabel linkLabelSponsor;
    }
}