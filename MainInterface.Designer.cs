namespace TCPConsole {
    partial class MainInterface {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainInterface));
            this.textIP = new System.Windows.Forms.TextBox();
            this.textPort = new System.Windows.Forms.TextBox();
            this.richResultsOfEnforcement = new System.Windows.Forms.RichTextBox();
            this.labelIP = new System.Windows.Forms.Label();
            this.labelPort = new System.Windows.Forms.Label();
            this.textResult = new System.Windows.Forms.Label();
            this.labelCommand = new System.Windows.Forms.Label();
            this.textBoxCommandInput = new System.Windows.Forms.TextBox();
            this.buttonAddFontSize = new System.Windows.Forms.Button();
            this.buttonReduceFontSize = new System.Windows.Forms.Button();
            this.textBoxFontSizeShow = new System.Windows.Forms.TextBox();
            this.labelFrequency = new System.Windows.Forms.Label();
            this.textBoxFrequencyShow = new System.Windows.Forms.TextBox();
            this.buttonAddFrequency = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonStartCommand = new System.Windows.Forms.Button();
            this.buttonStopCommand = new System.Windows.Forms.Button();
            this.labelFilePort = new System.Windows.Forms.Label();
            this.labelFileIP = new System.Windows.Forms.Label();
            this.textBoxFilePort = new System.Windows.Forms.TextBox();
            this.textBoxFileIP = new System.Windows.Forms.TextBox();
            this.buttonBrowseFiles = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.textBoxFileNotLocated = new System.Windows.Forms.TextBox();
            this.textBoxDestinationFileLocation = new System.Windows.Forms.TextBox();
            this.labelFilePath = new System.Windows.Forms.Label();
            this.LabelLongRange = new System.Windows.Forms.Label();
            this.progressBarFileTransfer = new System.Windows.Forms.ProgressBar();
            this.labelFileTransferSpeedOfProgress = new System.Windows.Forms.Label();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.SetingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PreferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.常用功能TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoteCommandsRestRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SponsorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelTotalFileSize = new System.Windows.Forms.Label();
            this.contextMenuStripRemoteScreen = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.IndependentDisplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FullScreenDisplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DisconnectCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxRemoteScreenIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxRemoteScreenPort = new System.Windows.Forms.TextBox();
            this.buttonRemoteScreenStart = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripTrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenMainFormVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitAppEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBoxRemoteScreen = new System.Windows.Forms.PictureBox();
            this.menuStripMain.SuspendLayout();
            this.contextMenuStripRemoteScreen.SuspendLayout();
            this.contextMenuStripTrayMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRemoteScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // textIP
            // 
            this.textIP.Font = new System.Drawing.Font("宋体", 14F);
            this.textIP.Location = new System.Drawing.Point(54, 28);
            this.textIP.MaxLength = 300;
            this.textIP.Name = "textIP";
            this.textIP.Size = new System.Drawing.Size(164, 29);
            this.textIP.TabIndex = 0;
            this.textIP.Leave += new System.EventHandler(this.textIP_Leave);
            // 
            // textPort
            // 
            this.textPort.Font = new System.Drawing.Font("宋体", 14F);
            this.textPort.Location = new System.Drawing.Point(273, 28);
            this.textPort.Name = "textPort";
            this.textPort.Size = new System.Drawing.Size(100, 29);
            this.textPort.TabIndex = 1;
            this.textPort.Leave += new System.EventHandler(this.textPort_Leave);
            // 
            // richResultsOfEnforcement
            // 
            this.richResultsOfEnforcement.BackColor = System.Drawing.Color.White;
            this.richResultsOfEnforcement.Font = new System.Drawing.Font("宋体", 10F);
            this.richResultsOfEnforcement.HideSelection = false;
            this.richResultsOfEnforcement.Location = new System.Drawing.Point(450, 28);
            this.richResultsOfEnforcement.Name = "richResultsOfEnforcement";
            this.richResultsOfEnforcement.ReadOnly = true;
            this.richResultsOfEnforcement.Size = new System.Drawing.Size(702, 661);
            this.richResultsOfEnforcement.TabIndex = 2;
            this.richResultsOfEnforcement.Text = "";
            this.richResultsOfEnforcement.WordWrap = false;
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.labelIP.Location = new System.Drawing.Point(5, 33);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(43, 20);
            this.labelIP.TabIndex = 3;
            this.labelIP.Text = "地址:";
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.labelPort.Location = new System.Drawing.Point(224, 33);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(43, 20);
            this.labelPort.TabIndex = 4;
            this.labelPort.Text = "端口:";
            // 
            // textResult
            // 
            this.textResult.AutoSize = true;
            this.textResult.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.textResult.Location = new System.Drawing.Point(398, 33);
            this.textResult.Name = "textResult";
            this.textResult.Size = new System.Drawing.Size(46, 21);
            this.textResult.TabIndex = 5;
            this.textResult.Text = "结果:";
            // 
            // labelCommand
            // 
            this.labelCommand.AutoSize = true;
            this.labelCommand.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.labelCommand.Location = new System.Drawing.Point(5, 81);
            this.labelCommand.Name = "labelCommand";
            this.labelCommand.Size = new System.Drawing.Size(43, 20);
            this.labelCommand.TabIndex = 6;
            this.labelCommand.Text = "命令:";
            // 
            // textBoxCommandInput
            // 
            this.textBoxCommandInput.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.textBoxCommandInput.Location = new System.Drawing.Point(54, 78);
            this.textBoxCommandInput.MaxLength = 300;
            this.textBoxCommandInput.Multiline = true;
            this.textBoxCommandInput.Name = "textBoxCommandInput";
            this.textBoxCommandInput.Size = new System.Drawing.Size(319, 125);
            this.textBoxCommandInput.TabIndex = 7;
            this.textBoxCommandInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxCommandInput_KeyDown);
            this.textBoxCommandInput.Leave += new System.EventHandler(this.textBoxCommandInput_Leave);
            // 
            // buttonAddFontSize
            // 
            this.buttonAddFontSize.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonAddFontSize.Location = new System.Drawing.Point(379, 78);
            this.buttonAddFontSize.Name = "buttonAddFontSize";
            this.buttonAddFontSize.Size = new System.Drawing.Size(65, 40);
            this.buttonAddFontSize.TabIndex = 8;
            this.buttonAddFontSize.Text = "+";
            this.buttonAddFontSize.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonAddFontSize.UseVisualStyleBackColor = true;
            this.buttonAddFontSize.Click += new System.EventHandler(this.buttonAddFontSize_Click);
            // 
            // buttonReduceFontSize
            // 
            this.buttonReduceFontSize.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonReduceFontSize.Location = new System.Drawing.Point(379, 163);
            this.buttonReduceFontSize.Name = "buttonReduceFontSize";
            this.buttonReduceFontSize.Size = new System.Drawing.Size(65, 40);
            this.buttonReduceFontSize.TabIndex = 9;
            this.buttonReduceFontSize.Text = "-";
            this.buttonReduceFontSize.UseVisualStyleBackColor = true;
            this.buttonReduceFontSize.Click += new System.EventHandler(this.buttonReduceFontSize_Click);
            // 
            // textBoxFontSizeShow
            // 
            this.textBoxFontSizeShow.Font = new System.Drawing.Font("宋体", 14F);
            this.textBoxFontSizeShow.Location = new System.Drawing.Point(379, 124);
            this.textBoxFontSizeShow.Name = "textBoxFontSizeShow";
            this.textBoxFontSizeShow.Size = new System.Drawing.Size(65, 29);
            this.textBoxFontSizeShow.TabIndex = 10;
            this.textBoxFontSizeShow.TextChanged += new System.EventHandler(this.textBoxFontSizeShow_TextChanged);
            this.textBoxFontSizeShow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxFontSizeShow_KeyPress);
            // 
            // labelFrequency
            // 
            this.labelFrequency.AutoSize = true;
            this.labelFrequency.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.labelFrequency.Location = new System.Drawing.Point(5, 216);
            this.labelFrequency.Name = "labelFrequency";
            this.labelFrequency.Size = new System.Drawing.Size(43, 20);
            this.labelFrequency.TabIndex = 11;
            this.labelFrequency.Text = "次数:";
            // 
            // textBoxFrequencyShow
            // 
            this.textBoxFrequencyShow.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxFrequencyShow.Font = new System.Drawing.Font("宋体", 14F);
            this.textBoxFrequencyShow.Location = new System.Drawing.Point(107, 216);
            this.textBoxFrequencyShow.Name = "textBoxFrequencyShow";
            this.textBoxFrequencyShow.Size = new System.Drawing.Size(47, 29);
            this.textBoxFrequencyShow.TabIndex = 12;
            this.textBoxFrequencyShow.Text = "1";
            this.textBoxFrequencyShow.TextChanged += new System.EventHandler(this.textBoxFrequencyShow_TextChanged);
            this.textBoxFrequencyShow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxFrequencyShow_KeyPress);
            this.textBoxFrequencyShow.Leave += new System.EventHandler(this.textBoxFrequencyShow_Leave);
            // 
            // buttonAddFrequency
            // 
            this.buttonAddFrequency.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.buttonAddFrequency.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonAddFrequency.Location = new System.Drawing.Point(53, 215);
            this.buttonAddFrequency.Name = "buttonAddFrequency";
            this.buttonAddFrequency.Size = new System.Drawing.Size(48, 30);
            this.buttonAddFrequency.TabIndex = 13;
            this.buttonAddFrequency.Text = "+";
            this.buttonAddFrequency.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonAddFrequency.UseVisualStyleBackColor = true;
            this.buttonAddFrequency.Click += new System.EventHandler(this.buttonAddFrequency_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(160, 215);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 30);
            this.button1.TabIndex = 14;
            this.button1.Text = "-";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonReduceFrequency_Click);
            // 
            // buttonStartCommand
            // 
            this.buttonStartCommand.Location = new System.Drawing.Point(228, 216);
            this.buttonStartCommand.Name = "buttonStartCommand";
            this.buttonStartCommand.Size = new System.Drawing.Size(65, 30);
            this.buttonStartCommand.TabIndex = 15;
            this.buttonStartCommand.Text = "开始";
            this.buttonStartCommand.UseVisualStyleBackColor = true;
            this.buttonStartCommand.Click += new System.EventHandler(this.buttonStartCommand_Click);
            // 
            // buttonStopCommand
            // 
            this.buttonStopCommand.Location = new System.Drawing.Point(308, 216);
            this.buttonStopCommand.Name = "buttonStopCommand";
            this.buttonStopCommand.Size = new System.Drawing.Size(65, 30);
            this.buttonStopCommand.TabIndex = 16;
            this.buttonStopCommand.Text = "停止";
            this.buttonStopCommand.UseVisualStyleBackColor = true;
            this.buttonStopCommand.Click += new System.EventHandler(this.buttonStopCommand_Click);
            // 
            // labelFilePort
            // 
            this.labelFilePort.AutoSize = true;
            this.labelFilePort.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.labelFilePort.Location = new System.Drawing.Point(224, 277);
            this.labelFilePort.Name = "labelFilePort";
            this.labelFilePort.Size = new System.Drawing.Size(43, 20);
            this.labelFilePort.TabIndex = 20;
            this.labelFilePort.Text = "端口:";
            // 
            // labelFileIP
            // 
            this.labelFileIP.AutoSize = true;
            this.labelFileIP.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.labelFileIP.Location = new System.Drawing.Point(5, 277);
            this.labelFileIP.Name = "labelFileIP";
            this.labelFileIP.Size = new System.Drawing.Size(43, 20);
            this.labelFileIP.TabIndex = 19;
            this.labelFileIP.Text = "地址:";
            // 
            // textBoxFilePort
            // 
            this.textBoxFilePort.Font = new System.Drawing.Font("宋体", 14F);
            this.textBoxFilePort.Location = new System.Drawing.Point(273, 272);
            this.textBoxFilePort.Name = "textBoxFilePort";
            this.textBoxFilePort.Size = new System.Drawing.Size(100, 29);
            this.textBoxFilePort.TabIndex = 18;
            this.textBoxFilePort.Leave += new System.EventHandler(this.textBoxFilePort_Leave);
            // 
            // textBoxFileIP
            // 
            this.textBoxFileIP.Font = new System.Drawing.Font("宋体", 14F);
            this.textBoxFileIP.Location = new System.Drawing.Point(54, 272);
            this.textBoxFileIP.MaxLength = 300;
            this.textBoxFileIP.Name = "textBoxFileIP";
            this.textBoxFileIP.Size = new System.Drawing.Size(164, 29);
            this.textBoxFileIP.TabIndex = 17;
            this.textBoxFileIP.Leave += new System.EventHandler(this.textBoxFileIP_Leave);
            // 
            // buttonBrowseFiles
            // 
            this.buttonBrowseFiles.Location = new System.Drawing.Point(379, 308);
            this.buttonBrowseFiles.Name = "buttonBrowseFiles";
            this.buttonBrowseFiles.Size = new System.Drawing.Size(65, 30);
            this.buttonBrowseFiles.TabIndex = 21;
            this.buttonBrowseFiles.Text = "浏览";
            this.buttonBrowseFiles.UseVisualStyleBackColor = true;
            this.buttonBrowseFiles.Click += new System.EventHandler(this.buttonBrowseFiles_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(379, 346);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(65, 30);
            this.buttonSend.TabIndex = 22;
            this.buttonSend.Text = "发送";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // textBoxFileNotLocated
            // 
            this.textBoxFileNotLocated.AllowDrop = true;
            this.textBoxFileNotLocated.Font = new System.Drawing.Font("宋体", 14F);
            this.textBoxFileNotLocated.Location = new System.Drawing.Point(54, 309);
            this.textBoxFileNotLocated.MaxLength = 300;
            this.textBoxFileNotLocated.Name = "textBoxFileNotLocated";
            this.textBoxFileNotLocated.Size = new System.Drawing.Size(318, 29);
            this.textBoxFileNotLocated.TabIndex = 23;
            this.textBoxFileNotLocated.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxFileNotLocated_DragDrop);
            this.textBoxFileNotLocated.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxFileNotLocated_DragEnter);
            // 
            // textBoxDestinationFileLocation
            // 
            this.textBoxDestinationFileLocation.Font = new System.Drawing.Font("宋体", 14F);
            this.textBoxDestinationFileLocation.Location = new System.Drawing.Point(54, 346);
            this.textBoxDestinationFileLocation.MaxLength = 300;
            this.textBoxDestinationFileLocation.Name = "textBoxDestinationFileLocation";
            this.textBoxDestinationFileLocation.Size = new System.Drawing.Size(318, 29);
            this.textBoxDestinationFileLocation.TabIndex = 24;
            this.textBoxDestinationFileLocation.Leave += new System.EventHandler(this.textBoxDestinationFileLocation_Leave);
            // 
            // labelFilePath
            // 
            this.labelFilePath.AutoSize = true;
            this.labelFilePath.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.labelFilePath.Location = new System.Drawing.Point(5, 313);
            this.labelFilePath.Name = "labelFilePath";
            this.labelFilePath.Size = new System.Drawing.Size(43, 20);
            this.labelFilePath.TabIndex = 25;
            this.labelFilePath.Text = "文件:";
            // 
            // LabelLongRange
            // 
            this.LabelLongRange.AutoSize = true;
            this.LabelLongRange.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.LabelLongRange.Location = new System.Drawing.Point(5, 349);
            this.LabelLongRange.Name = "LabelLongRange";
            this.LabelLongRange.Size = new System.Drawing.Size(43, 20);
            this.LabelLongRange.TabIndex = 26;
            this.LabelLongRange.Text = "远程:";
            // 
            // progressBarFileTransfer
            // 
            this.progressBarFileTransfer.Location = new System.Drawing.Point(694, 692);
            this.progressBarFileTransfer.Maximum = 10000;
            this.progressBarFileTransfer.Name = "progressBarFileTransfer";
            this.progressBarFileTransfer.Size = new System.Drawing.Size(458, 10);
            this.progressBarFileTransfer.TabIndex = 27;
            // 
            // labelFileTransferSpeedOfProgress
            // 
            this.labelFileTransferSpeedOfProgress.AutoSize = true;
            this.labelFileTransferSpeedOfProgress.Font = new System.Drawing.Font("微软雅黑", 7F);
            this.labelFileTransferSpeedOfProgress.Location = new System.Drawing.Point(562, 689);
            this.labelFileTransferSpeedOfProgress.Name = "labelFileTransferSpeedOfProgress";
            this.labelFileTransferSpeedOfProgress.Size = new System.Drawing.Size(13, 16);
            this.labelFileTransferSpeedOfProgress.TabIndex = 28;
            this.labelFileTransferSpeedOfProgress.Text = "0";
            // 
            // menuStripMain
            // 
            this.menuStripMain.AutoSize = false;
            this.menuStripMain.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SetingToolStripMenuItem,
            this.常用功能TToolStripMenuItem,
            this.xToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStripMain.Size = new System.Drawing.Size(1157, 28);
            this.menuStripMain.TabIndex = 29;
            // 
            // SetingToolStripMenuItem
            // 
            this.SetingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PreferencesToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.SetingToolStripMenuItem.Name = "SetingToolStripMenuItem";
            this.SetingToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.SetingToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.SetingToolStripMenuItem.Text = "系统设置(&S)";
            // 
            // PreferencesToolStripMenuItem
            // 
            this.PreferencesToolStripMenuItem.Image = global::TCPConsole.Properties.Resources.setting;
            this.PreferencesToolStripMenuItem.Name = "PreferencesToolStripMenuItem";
            this.PreferencesToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.PreferencesToolStripMenuItem.Text = "首选项(&P)";
            this.PreferencesToolStripMenuItem.Click += new System.EventHandler(this.PreferencesToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Image = global::TCPConsole.Properties.Resources.exit;
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.ExitToolStripMenuItem.Text = "退出(&E)";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // 常用功能TToolStripMenuItem
            // 
            this.常用功能TToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SToolStripMenuItem,
            this.RToolStripMenuItem,
            this.BToolStripMenuItem,
            this.CToolStripMenuItem,
            this.TToolStripMenuItem,
            this.RemoteCommandsRestRToolStripMenuItem});
            this.常用功能TToolStripMenuItem.Name = "常用功能TToolStripMenuItem";
            this.常用功能TToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.常用功能TToolStripMenuItem.Text = "常用功能(&T)";
            // 
            // SToolStripMenuItem
            // 
            this.SToolStripMenuItem.Image = global::TCPConsole.Properties.Resources.Shutdown;
            this.SToolStripMenuItem.Name = "SToolStripMenuItem";
            this.SToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.SToolStripMenuItem.Text = "关机(&S)";
            this.SToolStripMenuItem.Click += new System.EventHandler(this.SToolStripMenuItem_Click);
            // 
            // RToolStripMenuItem
            // 
            this.RToolStripMenuItem.Image = global::TCPConsole.Properties.Resources.reboot;
            this.RToolStripMenuItem.Name = "RToolStripMenuItem";
            this.RToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.RToolStripMenuItem.Text = "重启(&R)";
            this.RToolStripMenuItem.Click += new System.EventHandler(this.RToolStripMenuItem_Click);
            // 
            // BToolStripMenuItem
            // 
            this.BToolStripMenuItem.Image = global::TCPConsole.Properties.Resources.BlueScreen;
            this.BToolStripMenuItem.Name = "BToolStripMenuItem";
            this.BToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.BToolStripMenuItem.Text = "蓝屏(&B)";
            this.BToolStripMenuItem.Click += new System.EventHandler(this.BToolStripMenuItem_Click);
            // 
            // CToolStripMenuItem
            // 
            this.CToolStripMenuItem.Image = global::TCPConsole.Properties.Resources.clear;
            this.CToolStripMenuItem.Name = "CToolStripMenuItem";
            this.CToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.CToolStripMenuItem.Text = "清空结果(&C)";
            this.CToolStripMenuItem.Click += new System.EventHandler(this.CToolStripMenuItem_Click);
            // 
            // TToolStripMenuItem
            // 
            this.TToolStripMenuItem.Image = global::TCPConsole.Properties.Resources.Terminal;
            this.TToolStripMenuItem.Name = "TToolStripMenuItem";
            this.TToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.TToolStripMenuItem.Text = "本地终端(&T)";
            this.TToolStripMenuItem.Click += new System.EventHandler(this.TToolStripMenuItem_Click);
            // 
            // RemoteCommandsRestRToolStripMenuItem
            // 
            this.RemoteCommandsRestRToolStripMenuItem.Image = global::TCPConsole.Properties.Resources.RemoteReboot;
            this.RemoteCommandsRestRToolStripMenuItem.Name = "RemoteCommandsRestRToolStripMenuItem";
            this.RemoteCommandsRestRToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.RemoteCommandsRestRToolStripMenuItem.Text = "远程执行重启(&R)";
            this.RemoteCommandsRestRToolStripMenuItem.Click += new System.EventHandler(this.RemoteCommandsRestRToolStripMenuItem_Click);
            // 
            // xToolStripMenuItem
            // 
            this.xToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.versionInformationToolStripMenuItem,
            this.SponsorToolStripMenuItem});
            this.xToolStripMenuItem.Name = "xToolStripMenuItem";
            this.xToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.xToolStripMenuItem.Text = "关于(&A)";
            // 
            // versionInformationToolStripMenuItem
            // 
            this.versionInformationToolStripMenuItem.Image = global::TCPConsole.Properties.Resources.VersionInformation;
            this.versionInformationToolStripMenuItem.Name = "versionInformationToolStripMenuItem";
            this.versionInformationToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.versionInformationToolStripMenuItem.Text = "版本信息(&E)";
            this.versionInformationToolStripMenuItem.Click += new System.EventHandler(this.versionInformationToolStripMenuItem_Click);
            // 
            // SponsorToolStripMenuItem
            // 
            this.SponsorToolStripMenuItem.Image = global::TCPConsole.Properties.Resources.Sponsor;
            this.SponsorToolStripMenuItem.Name = "SponsorToolStripMenuItem";
            this.SponsorToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.SponsorToolStripMenuItem.Text = "赞助开发(&S)";
            this.SponsorToolStripMenuItem.Click += new System.EventHandler(this.SponsorToolStripMenuItem_Click);
            // 
            // labelTotalFileSize
            // 
            this.labelTotalFileSize.AutoSize = true;
            this.labelTotalFileSize.Font = new System.Drawing.Font("微软雅黑", 7F);
            this.labelTotalFileSize.Location = new System.Drawing.Point(448, 689);
            this.labelTotalFileSize.Name = "labelTotalFileSize";
            this.labelTotalFileSize.Size = new System.Drawing.Size(13, 16);
            this.labelTotalFileSize.TabIndex = 30;
            this.labelTotalFileSize.Text = "0";
            this.labelTotalFileSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // contextMenuStripRemoteScreen
            // 
            this.contextMenuStripRemoteScreen.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.contextMenuStripRemoteScreen.BackColor = System.Drawing.SystemColors.Control;
            this.contextMenuStripRemoteScreen.ImeMode = System.Windows.Forms.ImeMode.On;
            this.contextMenuStripRemoteScreen.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IndependentDisplayToolStripMenuItem,
            this.FullScreenDisplayToolStripMenuItem,
            this.DisconnectCToolStripMenuItem});
            this.contextMenuStripRemoteScreen.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.contextMenuStripRemoteScreen.Name = "contextMenuStripRemoteScreen";
            this.contextMenuStripRemoteScreen.ShowImageMargin = false;
            this.contextMenuStripRemoteScreen.Size = new System.Drawing.Size(116, 70);
            // 
            // IndependentDisplayToolStripMenuItem
            // 
            this.IndependentDisplayToolStripMenuItem.Name = "IndependentDisplayToolStripMenuItem";
            this.IndependentDisplayToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.IndependentDisplayToolStripMenuItem.Text = "独立显示(&I)";
            this.IndependentDisplayToolStripMenuItem.Click += new System.EventHandler(this.IndependentDisplayToolStripMenuItem_Click);
            // 
            // FullScreenDisplayToolStripMenuItem
            // 
            this.FullScreenDisplayToolStripMenuItem.Name = "FullScreenDisplayToolStripMenuItem";
            this.FullScreenDisplayToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.FullScreenDisplayToolStripMenuItem.Text = "全屏显示(&F)";
            this.FullScreenDisplayToolStripMenuItem.Click += new System.EventHandler(this.FullScreenDisplayToolStripMenuItem_Click);
            // 
            // DisconnectCToolStripMenuItem
            // 
            this.DisconnectCToolStripMenuItem.Name = "DisconnectCToolStripMenuItem";
            this.DisconnectCToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.DisconnectCToolStripMenuItem.Text = "连接画面(&C)";
            this.DisconnectCToolStripMenuItem.Click += new System.EventHandler(this.DisconnectCToolStripMenuItem_Click);
            // 
            // textBoxRemoteScreenIP
            // 
            this.textBoxRemoteScreenIP.Font = new System.Drawing.Font("宋体", 14F);
            this.textBoxRemoteScreenIP.Location = new System.Drawing.Point(54, 397);
            this.textBoxRemoteScreenIP.MaxLength = 300;
            this.textBoxRemoteScreenIP.Name = "textBoxRemoteScreenIP";
            this.textBoxRemoteScreenIP.Size = new System.Drawing.Size(164, 29);
            this.textBoxRemoteScreenIP.TabIndex = 32;
            this.textBoxRemoteScreenIP.Leave += new System.EventHandler(this.textBoxRemoteScreenIP_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label1.Location = new System.Drawing.Point(5, 400);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 33;
            this.label1.Text = "地址:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label2.Location = new System.Drawing.Point(224, 400);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 34;
            this.label2.Text = "端口:";
            // 
            // textBoxRemoteScreenPort
            // 
            this.textBoxRemoteScreenPort.Font = new System.Drawing.Font("宋体", 14F);
            this.textBoxRemoteScreenPort.Location = new System.Drawing.Point(272, 397);
            this.textBoxRemoteScreenPort.Name = "textBoxRemoteScreenPort";
            this.textBoxRemoteScreenPort.Size = new System.Drawing.Size(100, 29);
            this.textBoxRemoteScreenPort.TabIndex = 35;
            this.textBoxRemoteScreenPort.Leave += new System.EventHandler(this.textBoxRemoteScreenPort_Leave);
            // 
            // buttonRemoteScreenStart
            // 
            this.buttonRemoteScreenStart.Location = new System.Drawing.Point(378, 396);
            this.buttonRemoteScreenStart.Name = "buttonRemoteScreenStart";
            this.buttonRemoteScreenStart.Size = new System.Drawing.Size(65, 30);
            this.buttonRemoteScreenStart.TabIndex = 36;
            this.buttonRemoteScreenStart.Text = "连接";
            this.buttonRemoteScreenStart.UseVisualStyleBackColor = true;
            this.buttonRemoteScreenStart.Click += new System.EventHandler(this.buttonRemoteScreenStart_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStripTrayMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "TCP控制台2.3";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // contextMenuStripTrayMenu
            // 
            this.contextMenuStripTrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenMainFormVToolStripMenuItem,
            this.ExitAppEToolStripMenuItem});
            this.contextMenuStripTrayMenu.Name = "contextMenuStripTrayMenu";
            this.contextMenuStripTrayMenu.Size = new System.Drawing.Size(153, 48);
            // 
            // OpenMainFormVToolStripMenuItem
            // 
            this.OpenMainFormVToolStripMenuItem.Image = global::TCPConsole.Properties.Resources.icon;
            this.OpenMainFormVToolStripMenuItem.Name = "OpenMainFormVToolStripMenuItem";
            this.OpenMainFormVToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.OpenMainFormVToolStripMenuItem.Text = "打开主界面(&V)";
            this.OpenMainFormVToolStripMenuItem.Click += new System.EventHandler(this.OpenMainFormVToolStripMenuItem_Click);
            // 
            // ExitAppEToolStripMenuItem
            // 
            this.ExitAppEToolStripMenuItem.Image = global::TCPConsole.Properties.Resources.exit;
            this.ExitAppEToolStripMenuItem.Name = "ExitAppEToolStripMenuItem";
            this.ExitAppEToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ExitAppEToolStripMenuItem.Text = "退出程序(&E)";
            this.ExitAppEToolStripMenuItem.Click += new System.EventHandler(this.ExitAppEToolStripMenuItem_Click);
            // 
            // pictureBoxRemoteScreen
            // 
            this.pictureBoxRemoteScreen.ContextMenuStrip = this.contextMenuStripRemoteScreen;
            this.pictureBoxRemoteScreen.Image = global::TCPConsole.Properties.Resources.defaultImage;
            this.pictureBoxRemoteScreen.Location = new System.Drawing.Point(9, 445);
            this.pictureBoxRemoteScreen.Name = "pictureBoxRemoteScreen";
            this.pictureBoxRemoteScreen.Size = new System.Drawing.Size(435, 244);
            this.pictureBoxRemoteScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxRemoteScreen.TabIndex = 31;
            this.pictureBoxRemoteScreen.TabStop = false;
            // 
            // MainInterface
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 705);
            this.Controls.Add(this.buttonRemoteScreenStart);
            this.Controls.Add(this.textBoxRemoteScreenPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxRemoteScreenIP);
            this.Controls.Add(this.pictureBoxRemoteScreen);
            this.Controls.Add(this.labelTotalFileSize);
            this.Controls.Add(this.menuStripMain);
            this.Controls.Add(this.labelFileTransferSpeedOfProgress);
            this.Controls.Add(this.progressBarFileTransfer);
            this.Controls.Add(this.LabelLongRange);
            this.Controls.Add(this.labelFilePath);
            this.Controls.Add(this.textBoxDestinationFileLocation);
            this.Controls.Add(this.textBoxFileNotLocated);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.buttonBrowseFiles);
            this.Controls.Add(this.labelFilePort);
            this.Controls.Add(this.labelFileIP);
            this.Controls.Add(this.textBoxFilePort);
            this.Controls.Add(this.textBoxFileIP);
            this.Controls.Add(this.buttonStopCommand);
            this.Controls.Add(this.buttonStartCommand);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonAddFrequency);
            this.Controls.Add(this.textBoxFrequencyShow);
            this.Controls.Add(this.labelFrequency);
            this.Controls.Add(this.textBoxFontSizeShow);
            this.Controls.Add(this.buttonReduceFontSize);
            this.Controls.Add(this.buttonAddFontSize);
            this.Controls.Add(this.textBoxCommandInput);
            this.Controls.Add(this.labelCommand);
            this.Controls.Add(this.textResult);
            this.Controls.Add(this.labelPort);
            this.Controls.Add(this.labelIP);
            this.Controls.Add(this.richResultsOfEnforcement);
            this.Controls.Add(this.textPort);
            this.Controls.Add(this.textIP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.MaximizeBox = false;
            this.Name = "MainInterface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TCP控制台重制版";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainInterface_FormClosing);
            this.Load += new System.EventHandler(this.MainInterface_Load);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.contextMenuStripRemoteScreen.ResumeLayout(false);
            this.contextMenuStripTrayMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRemoteScreen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textIP;
        private System.Windows.Forms.TextBox textPort;
        private System.Windows.Forms.RichTextBox richResultsOfEnforcement;
        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.Label textResult;
        private System.Windows.Forms.Label labelCommand;
        private System.Windows.Forms.TextBox textBoxCommandInput;
        private System.Windows.Forms.Button buttonAddFontSize;
        private System.Windows.Forms.Button buttonReduceFontSize;
        private System.Windows.Forms.TextBox textBoxFontSizeShow;
        private System.Windows.Forms.Label labelFrequency;
        private System.Windows.Forms.TextBox textBoxFrequencyShow;
        private System.Windows.Forms.Button buttonAddFrequency;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonStartCommand;
        private System.Windows.Forms.Button buttonStopCommand;
        private System.Windows.Forms.Label labelFilePort;
        private System.Windows.Forms.Label labelFileIP;
        private System.Windows.Forms.TextBox textBoxFilePort;
        private System.Windows.Forms.TextBox textBoxFileIP;
        private System.Windows.Forms.Button buttonBrowseFiles;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textBoxFileNotLocated;
        private System.Windows.Forms.TextBox textBoxDestinationFileLocation;
        private System.Windows.Forms.Label labelFilePath;
        private System.Windows.Forms.Label LabelLongRange;
        private System.Windows.Forms.ProgressBar progressBarFileTransfer;
        private System.Windows.Forms.Label labelFileTransferSpeedOfProgress;
        private System.Windows.Forms.ToolStripMenuItem SetingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PreferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 常用功能TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SponsorToolStripMenuItem;
        private System.Windows.Forms.Label labelTotalFileSize;
        private System.Windows.Forms.ToolStripMenuItem CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoteCommandsRestRToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBoxRemoteScreen;
        private System.Windows.Forms.TextBox textBoxRemoteScreenIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxRemoteScreenPort;
        private System.Windows.Forms.Button buttonRemoteScreenStart;
        private System.Windows.Forms.ToolStripMenuItem IndependentDisplayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FullScreenDisplayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DisconnectCToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripRemoteScreen;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTrayMenu;
        private System.Windows.Forms.ToolStripMenuItem OpenMainFormVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitAppEToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}

