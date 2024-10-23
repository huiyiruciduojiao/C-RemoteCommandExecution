namespace TCPConsole {
    partial class ShowRemoteFile {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowRemoteFile));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.PanelToPanel = new System.Windows.Forms.Panel();
            this.TreeViewFileTreeView = new System.Windows.Forms.TreeView();
            this.ListViewFileListView = new System.Windows.Forms.ListView();
            this.FilePath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileEditTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DownLoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AdjustmentBar = new System.Windows.Forms.Panel();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelToPanel
            // 
            this.PanelToPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelToPanel.Location = new System.Drawing.Point(0, 0);
            this.PanelToPanel.Name = "PanelToPanel";
            this.PanelToPanel.Size = new System.Drawing.Size(1077, 61);
            this.PanelToPanel.TabIndex = 0;
            // 
            // TreeViewFileTreeView
            // 
            this.TreeViewFileTreeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.TreeViewFileTreeView.Location = new System.Drawing.Point(0, 61);
            this.TreeViewFileTreeView.Name = "TreeViewFileTreeView";
            this.TreeViewFileTreeView.Size = new System.Drawing.Size(180, 706);
            this.TreeViewFileTreeView.TabIndex = 1;
            // 
            // ListViewFileListView
            // 
            this.ListViewFileListView.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.ListViewFileListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListViewFileListView.BackColor = System.Drawing.Color.Gainsboro;
            this.ListViewFileListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FilePath,
            this.FileSize,
            this.FileType,
            this.FileEditTime});
            this.ListViewFileListView.FullRowSelect = true;
            this.ListViewFileListView.HideSelection = false;
            this.ListViewFileListView.Location = new System.Drawing.Point(182, 61);
            this.ListViewFileListView.Name = "ListViewFileListView";
            this.ListViewFileListView.Size = new System.Drawing.Size(895, 706);
            this.ListViewFileListView.TabIndex = 2;
            this.ListViewFileListView.UseCompatibleStateImageBehavior = false;
            this.ListViewFileListView.View = System.Windows.Forms.View.Details;
            this.ListViewFileListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListViewFileListView_ColumnClick);
            this.ListViewFileListView.ItemActivate += new System.EventHandler(this.ListViewFileListView_ItemActivate);
            this.ListViewFileListView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ListViewFileListView_MouseUp);
            this.ListViewFileListView.Resize += new System.EventHandler(this.ListViewFileListView_Resize);
            // 
            // FilePath
            // 
            this.FilePath.Text = "文件路径";
            // 
            // FileSize
            // 
            this.FileSize.Text = "文件大小";
            // 
            // FileType
            // 
            this.FileType.DisplayIndex = 3;
            this.FileType.Text = "类型";
            // 
            // FileEditTime
            // 
            this.FileEditTime.DisplayIndex = 2;
            this.FileEditTime.Text = "修改时间";
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteToolStripMenuItem,
            this.DownLoadToolStripMenuItem,
            this.ReNameToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(133, 70);
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.DeleteToolStripMenuItem.Text = "删除&(R)";
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // DownLoadToolStripMenuItem
            // 
            this.DownLoadToolStripMenuItem.Name = "DownLoadToolStripMenuItem";
            this.DownLoadToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.DownLoadToolStripMenuItem.Text = "下载&(D)";
            this.DownLoadToolStripMenuItem.Click += new System.EventHandler(this.DownLoadToolStripMenuItem_Click);
            // 
            // ReNameToolStripMenuItem
            // 
            this.ReNameToolStripMenuItem.Name = "ReNameToolStripMenuItem";
            this.ReNameToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.ReNameToolStripMenuItem.Text = "重命名&(M)";
            this.ReNameToolStripMenuItem.Click += new System.EventHandler(this.ReNameToolStripMenuItem_Click);
            // 
            // AdjustmentBar
            // 
            this.AdjustmentBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.AdjustmentBar.BackColor = System.Drawing.Color.Gainsboro;
            this.AdjustmentBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AdjustmentBar.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.AdjustmentBar.Location = new System.Drawing.Point(178, 61);
            this.AdjustmentBar.Name = "AdjustmentBar";
            this.AdjustmentBar.Size = new System.Drawing.Size(5, 706);
            this.AdjustmentBar.TabIndex = 3;
            this.AdjustmentBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AdjustmentBar_MouseDown);
            this.AdjustmentBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AdjustmentBar_MouseMove);
            this.AdjustmentBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AdjustmentBar_MouseUp);
            // 
            // ShowRemoteFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 767);
            this.Controls.Add(this.AdjustmentBar);
            this.Controls.Add(this.ListViewFileListView);
            this.Controls.Add(this.TreeViewFileTreeView);
            this.Controls.Add(this.PanelToPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShowRemoteFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShowRemoteFile";
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Panel PanelToPanel;
        private System.Windows.Forms.TreeView TreeViewFileTreeView;
        private System.Windows.Forms.ListView ListViewFileListView;
        private System.Windows.Forms.ColumnHeader FilePath;
        private System.Windows.Forms.ColumnHeader FileSize;
        private System.Windows.Forms.ColumnHeader FileEditTime;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DownLoadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReNameToolStripMenuItem;
        private System.Windows.Forms.Panel AdjustmentBar;
        private System.Windows.Forms.ColumnHeader FileType;
    }
}