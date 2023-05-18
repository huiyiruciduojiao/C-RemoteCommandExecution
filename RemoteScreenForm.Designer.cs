namespace TCPConsole {
    partial class RemoteScreenForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoteScreenForm));
            this.pictureBoxShowRemoteScreen = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShowRemoteScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxShowRemoteScreen
            // 
            this.pictureBoxShowRemoteScreen.BackgroundImage = global::TCPConsole.Properties.Resources.defaultImage;
            this.pictureBoxShowRemoteScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxShowRemoteScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxShowRemoteScreen.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxShowRemoteScreen.Name = "pictureBoxShowRemoteScreen";
            this.pictureBoxShowRemoteScreen.Size = new System.Drawing.Size(800, 450);
            this.pictureBoxShowRemoteScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxShowRemoteScreen.TabIndex = 0;
            this.pictureBoxShowRemoteScreen.TabStop = false;
            // 
            // RemoteScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBoxShowRemoteScreen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RemoteScreenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "远程画面显示";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RemoteScreenForm_FormClosing);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RemoteScreenForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShowRemoteScreen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxShowRemoteScreen;
    }
}