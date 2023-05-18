using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCPConsole {
    public partial class MainInterface : Form {
        #region 基本属性定义
        //创建一个命令配置对象
        private CommandExecutionConfiguration commandExecutionConfiguration = new CommandExecutionConfiguration();
        //创建一个工具对象
        private Tools tools = new Tools();
        //UI线程的同步上下文
        public SynchronizationContext SyncContext = null;
        //本地控制台执行器
        public Command commandLocal = new Command();
        //命令执行器
        //创建一个命令执行器
        private CommandExecutor commandExecutor = new CommandExecutor();
        //创建远程画面连接对象
        private GetRemoteScreen remoteScreen = new GetRemoteScreen();
        //创建远程画面独立显示窗体
        private RemoteScreenForm remoteScreenForm = new RemoteScreenForm();
        //创建一个配置文件工具对象
        private ConfigurationTools configurationTools = new ConfigurationTools("./config.ini");

        public static MainInterface MainInterfaceUi;
        //创建一个设置对象
        private Setting setting = null;
        //字体大小变量
        private int fontSize = 12;
        //命令结果做大显示行数变量
        private int commandMaxLine = 10000;
        //标记本地命令是否退出
        private bool isExit = false;
        #endregion
        #region 窗体初始化处理
        public MainInterface() {
            InitializeComponent();
            SyncContext = SynchronizationContext.Current;
            MainInterfaceUi = this;
            //Application.DoEvents();
        }
        //窗体加载时执行的操作
        private void MainInterface_Load(object sender, EventArgs e) {
            //初始化本地命令执行器
            reSetCommandLocal();
            //执行初始化操作
            Initialization();
            //隐藏文件传输进度条
            this.progressBarFileTransfer.Visible = false;

            //隐藏文件传输文字百分比
            this.labelFileTransferSpeedOfProgress.Visible = false;
            //隐藏文件总大小
            this.labelTotalFileSize.Visible = false;
            //不再捕获错误线程调用异常
            Control.CheckForIllegalCrossThreadCalls = false;

            GC.Collect();
        }

        private void Initialization() {

            //加载配置文件设置
            LoadProfile();
            //将数据保存到命令执行配置器中
            SaveToCommandExecutionConfigurationObject();
            //将数据显示到窗体
            ShowDataWindow();

        }
        #endregion
        #region 配置文件处理
        /// <summary>
        /// 加载配置文件内容
        /// </summary>
        public void LoadProfile() {
            String defalutSetting = "Defalut";
            setting = new Setting();
            setting.DefalutCommandAddress = configurationTools.GetSetting(defalutSetting, "DefalutCommandAddress");
            setting.DefalutCommandPort = configurationTools.GetSetting(defalutSetting, "DefalutCommandPort");
            setting.DefalutCommandFrequency = configurationTools.GetSetting(defalutSetting, "DefalutCommandFrequency");
            setting.DefalutCommandInputTextFontSize = configurationTools.GetSetting(defalutSetting, "DefalutCommandInputTextFontSize");
            setting.CommandResultMaxLine = configurationTools.GetSetting(defalutSetting, "CommandResultMaxLine");
            setting.DefalutFileSendAddress = configurationTools.GetSetting(defalutSetting, "DefalutFileSendAddress");
            setting.DefalutFileSendPort = configurationTools.GetSetting(defalutSetting, "DefalutFileSendPort");
            setting.DefalutFileRemoteSaveAddress = configurationTools.GetSetting(defalutSetting, "DefalutFileRemoteSaveAddress");
            setting.CommandResultMaxLine = configurationTools.GetSetting(defalutSetting, "CommandResultMaxLine");
            setting.DefalutRemoteScreenAddress = configurationTools.GetSetting(defalutSetting, "DefaultRemoteScreenAddress");
            setting.DefalutRemoteScreenPort = configurationTools.GetSetting(defalutSetting, "DefaultRemoteScreenPort");

        }
        /// <summary>
        /// 将数据添加到窗体显示
        /// </summary>
        public void ShowDataWindow() {
            //命令域
            {
                textIP.Text = setting.DefalutCommandAddress;
                textPort.Text = setting.DefalutCommandPort;
                //字体大小
                textBoxFontSizeShow.Text = setting.DefalutCommandInputTextFontSize;
                //使字体大小生效
                fontSize = int.Parse(setting.DefalutCommandInputTextFontSize);
                textBoxCommandInput.Font = new Font("微软雅黑", fontSize);
                //执行次数
                textBoxFrequencyShow.Text = setting.DefalutCommandFrequency;

            }
            //文件域
            {
                textBoxFileIP.Text = setting.DefalutFileSendAddress;
                textBoxFilePort.Text = setting.DefalutFileSendPort;
                textBoxDestinationFileLocation.Text = setting.DefalutFileRemoteSaveAddress;
            }
            //画面域
            {
                textBoxRemoteScreenIP.Text = setting.DefalutRemoteScreenAddress;
                textBoxRemoteScreenPort.Text = setting.DefalutRemoteScreenPort;
            }
            //最大显示行数
            {
                this.commandMaxLine = int.Parse(setting.CommandResultMaxLine);
            }
        }
        /// <summary>
        /// 将数据保存到命令执行配置对象中
        /// </summary>
        public void SaveToCommandExecutionConfigurationObject() {
            commandExecutionConfiguration.Address = setting.DefalutCommandAddress;
            commandExecutionConfiguration.Port = tools.IsNum(setting.DefalutCommandPort);
            commandExecutionConfiguration.Frequency = tools.IsNum(setting.DefalutCommandFrequency);
            commandExecutionConfiguration.FileAddress = setting.DefalutFileSendAddress;
            commandExecutionConfiguration.FilePort = tools.IsNum(setting.DefalutFileSendPort);
            commandExecutionConfiguration.RemoteFilePath = setting.DefalutFileRemoteSaveAddress;
        }
        /// <summary>
        /// 初始化本地命令执行器
        /// </summary>
        private void reSetCommandLocal() {
            //给本地命令执行器绑定事件
            commandLocal.Output += Command_Output;
            commandLocal.Error += Command_Error;
            commandLocal.Exited += Command_Exited;
            //将本地命令执行器传入命令配置对象
            commandExecutionConfiguration.commandLocal = commandLocal;
        }
        #endregion

        #region 命令域控件事件事件监听处理
        //当命令域IP输入框焦点消失时
        private void textIP_Leave(object sender, EventArgs e) {
            string strAddress = tools.RemoveSpaces(this.textIP.Text);
            if (!tools.ItIsNull(strAddress, true)) {
                //判断输入的内容是IP还是域名
                if (tools.IsItIP(strAddress)) {
                    //如果是IP直接交给命令配置对象
                    commandExecutionConfiguration.Address = strAddress;
                } else if (tools.IsDomain(strAddress)) {
                    //如果是域名，调用方法解析域名，如果解析失败，提示
                    Task task = new Task(() => {
                        commandExecutionConfiguration.DomainNameSystemStatus = true;
                        SyncContext.Post(richResultsOfEnforcementAppendText, new RichTextBoxStyle("正在尝试解析域名: " + strAddress + "!", Color.Black, true));
                        IPAddress[] iPAddresses = tools.DomainNameResolution(strAddress);
                        if (iPAddresses != null && iPAddresses.Length > 0) {
                            commandExecutionConfiguration.Address = iPAddresses[0].ToString();
                            SyncContext.Post(richResultsOfEnforcementAppendText, new RichTextBoxStyle("域名:'" + strAddress + "'解析成功!配置地址设置为:  " + commandExecutionConfiguration.Address, Color.Green, true));
                        } else {
                            SyncContext.Post(richResultsOfEnforcementAppendText, new RichTextBoxStyle("尝试解析域名:'" + strAddress + "'失败!请检查后域名后重试!", Color.Red, true));
                        }
                        commandExecutionConfiguration.DomainNameSystemStatus = false;
                    });
                    task.Start();
                } else {
                    richResultsOfEnforcementAppendText("输入的地址错误！请输入一个IPv4地址或一个域名!", Color.Red, Color.White, true);
                }
            }
        }
        //当命令域IP输入框焦点消失时
        private void textPort_Leave(object sender, EventArgs e) {
            String textPort = this.textPort.Text;
            //判断输入是否为空
            if (!tools.ItIsNull(textPort, true)) {
                //判断输入是否为一个端口
                if (tools.IsItPort(textPort)) {
                    //将当前配置添加到命令配置对象
                    commandExecutionConfiguration.Port = tools.IsNum(textPort);
                } else {
                    richResultsOfEnforcementAppendText("端口输入错误，请输入一个合法的端口", Color.Red, Color.White, true);
                }
            }
        }
        //当命令输入文本域焦点消失时执行
        private void textBoxCommandInput_Leave(object sender, EventArgs e) {
            TextBoxCommandInputSet();
        }
        //将命令输入框中的命令加载到命令执行配置对象中
        private void TextBoxCommandInputSet() {
            String cmd = this.textBoxCommandInput.Text;
            //判断是否为空
            if (!tools.ItIsNull(cmd, true)) {
                //判断是否在本地执行
                bool temp = tools.WhetherToExecuteLocally(ref cmd);
                commandExecutionConfiguration.Command = cmd;
                commandExecutionConfiguration.IsItLocal = temp;
            }
        }
        //命令输入框屏蔽回车键换行，并在回车后执行命令
        private void textBoxCommandInput_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter) {
                e.SuppressKeyPress = true;
                textBoxCommandInput.ScrollToCaret();
                TextBoxCommandInputSet();
                startCommand();
            }
        }
        //字体大小变大
        private void buttonAddFontSize_Click(object sender, EventArgs e) {
            fontSize++;
            textBoxCommandInput.Font = new Font("微软雅黑", fontSize);
            textBoxFontSizeShow.Text = fontSize.ToString();
        }
        //字体大小变小
        private void buttonReduceFontSize_Click(object sender, EventArgs e) {
            if (fontSize > 1) {
                fontSize--;
                textBoxCommandInput.Font = new Font("微软雅黑", fontSize);
                textBoxFontSizeShow.Text = fontSize.ToString();
            }

        }
        //设置字体大小只能输入数值
        private void textBoxFontSizeShow_KeyPress(object sender, KeyPressEventArgs e) {
            //如果输入的不是退格和数字，则屏蔽输入
            if (!(e.KeyChar == '\b' || (e.KeyChar >= '0' && e.KeyChar <= '9'))) {
                e.Handled = true;
            }
        }
        //当字体大小输入框值改变时
        private void textBoxFontSizeShow_TextChanged(object sender, EventArgs e) {
            int tempFontSize = tools.IsNum(textBoxFontSizeShow.Text);
            if (tempFontSize < 1 || fontSize < 1) {
                tempFontSize = 1;
                fontSize = 1;
            } else {
                fontSize = tempFontSize;
            }
            textBoxFontSizeShow.Text = tempFontSize.ToString();
            textBoxCommandInput.Font = new Font("微软雅黑", fontSize);

        }
        //添加执行次数按钮
        private void buttonAddFrequency_Click(object sender, EventArgs e) {
            commandExecutionConfiguration.Frequency++;
            textBoxFrequencyShow.Text = commandExecutionConfiguration.Frequency.ToString();
        }
        //减少执行次数按钮
        private void buttonReduceFrequency_Click(object sender, EventArgs e) {
            if (commandExecutionConfiguration.Frequency > 1) {
                commandExecutionConfiguration.Frequency--;
                textBoxFrequencyShow.Text = commandExecutionConfiguration.Frequency.ToString();
            }
        }
        //设置执行次数输入框只能输入数字
        private void textBoxFrequencyShow_KeyPress(object sender, KeyPressEventArgs e) {
            //如果输入的不是退格和数字，则屏蔽输入
            if (!(e.KeyChar == '\b' || (e.KeyChar >= '0' && e.KeyChar <= '9'))) {
                e.Handled = true;
            }
        }
        //当执行次数输入框中的内容改变时
        private void textBoxFrequencyShow_TextChanged(object sender, EventArgs e) {
            int tempFrequency = tools.IsNum(textBoxFrequencyShow.Text);
            if (tempFrequency < 1 || commandExecutionConfiguration.Frequency < 1) {
                tempFrequency = 1;
                commandExecutionConfiguration.Frequency = 1;
            } else {
                commandExecutionConfiguration.Frequency = tempFrequency;
            }
            textBoxFrequencyShow.Text = tempFrequency.ToString();
        }
        //当执行次数输入框焦点消失时
        private void textBoxFrequencyShow_Leave(object sender, EventArgs e) {
            int frequency = tools.IsNum(this.textBoxFrequencyShow.Text);
            commandExecutionConfiguration.Frequency = frequency;
            this.textBoxFrequencyShow.Text = commandExecutionConfiguration.Frequency + "";
        }
        //开始按钮被点击时
        private void buttonStartCommand_Click(object sender, EventArgs e) {
            GC.Collect();
            TextBoxCommandInputSet();
            startCommand();
        }
        private void startCommand() {
            //判断本地命令执行器是否退出
            if (isExit) {
                commandLocal = new Command();
                reSetCommandLocal();
            }
            //文件发送标识取消
            commandExecutionConfiguration.IsSendFile = false;
            //调用方法，执行命令配置
            commandExecutor.Execute(commandExecutionConfiguration);
        }
        //停止按钮被点击时
        private void buttonStopCommand_Click(object sender, EventArgs e) {
            this.commandExecutionConfiguration.Frequency = 1;
            this.textBoxFrequencyShow.Text = "1";
            if (commandExecutionConfiguration.IsItLocal) {
                richResultsOfEnforcementAppendText("", Color.White, Color.White, true);
                richResultsOfEnforcementAppendText("本地命令执行结束，控制台进程已退出！", Color.Yellow, Color.Gray, true);
                commandExecutionConfiguration.commandLocal.Stop();
                commandExecutionConfiguration.commandLocal = null;
                commandLocal.Stop();
                commandLocal = null;
                commandLocal = new Command();
                reSetCommandLocal();
                // commandExecutionConfiguration.commandLocal = commandLocal;
            }
        }
        #endregion

        #region 文件域事件监听处理
        //文件域IP输入框焦点消失
        private void textBoxFileIP_Leave(object sender, EventArgs e) {
            string strFileAddress = tools.RemoveSpaces(this.textBoxFileIP.Text);
            if (!tools.ItIsNull(strFileAddress, true)) {
                //判断输入的内容是IP还是域名
                if (tools.IsItIP(strFileAddress)) {
                    //如果是IP直接交给命令配置对象
                    commandExecutionConfiguration.FileAddress = strFileAddress;
                } else if (tools.IsDomain(strFileAddress)) {
                    //如果是域名，调用方法解析域名，如果解析失败，提示
                    Task task = new Task(() => {
                        commandExecutionConfiguration.DomainNameSystemStatus = true;
                        SyncContext.Post(richResultsOfEnforcementAppendText, new RichTextBoxStyle("正在尝试解析域名: " + strFileAddress + "!", Color.Black, true));
                        IPAddress[] iPAddresses = tools.DomainNameResolution(strFileAddress);
                        if (iPAddresses != null && iPAddresses.Length > 0) {
                            commandExecutionConfiguration.FileAddress = iPAddresses[0].ToString();
                            SyncContext.Post(richResultsOfEnforcementAppendText, new RichTextBoxStyle("域名:'" + strFileAddress + "'解析成功!配置地址设置为:  " + commandExecutionConfiguration.FileAddress, Color.Green, true));
                        } else {
                            SyncContext.Post(richResultsOfEnforcementAppendText, new RichTextBoxStyle("尝试解析域名:'" + strFileAddress + "'失败!请检查后域名后重试!", Color.Red, true));
                        }
                        commandExecutionConfiguration.DomainNameSystemStatus = false;
                    });
                    task.Start();
                } else {
                    richResultsOfEnforcementAppendText("输入的地址错误！请输入一个IPv4地址或一个域名!", Color.Red, Color.White, true);
                }
            }
        }
        //文件域端口输入框焦点消失
        private void textBoxFilePort_Leave(object sender, EventArgs e) {
            String textFilePort = this.textBoxFilePort.Text;
            //判断输入是否为空
            if (!tools.ItIsNull(textFilePort, true)) {
                //判断输入是否为一个端口
                if (tools.IsItPort(textFilePort)) {
                    //将当前配置添加到命令配置对象
                    commandExecutionConfiguration.FilePort = tools.IsNum(textFilePort);
                } else {
                    richResultsOfEnforcementAppendText("端口输入错误，请输入一个合法的端口", Color.Red, Color.White, true);
                }
            }
        }
        //文件域本地文件位置输入框拖拽事件
        private void textBoxFileNotLocated_DragDrop(object sender, DragEventArgs e) {
            //如果拖入的是文件
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                String strings = (e.Data.GetData(DataFormats.FileDrop, false) as String[])[0];
                //获取文件名
                commandExecutionConfiguration.FilePath = strings;
                commandExecutionConfiguration.RemoteFileName = Path.GetFileName(strings);
                textBoxFileNotLocated.Text = strings;
                richResultsOfEnforcementAppendText(new RichTextBoxStyle("成功设置文件：" + strings, Color.Green, true));
                long fileSize = new FileInfo(strings).Length;
                //当选取文件后，显示文件总大小
                labelTotalFileSize.Visible = true;
                //显示文件大小 
                labelTotalFileSize.Text = "文件总大小:" + Tools.CountSize(fileSize);
            }
        }
        private void textBoxFileNotLocated_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                String[] strings = e.Data.GetData(DataFormats.FileDrop, false) as String[];
                if (strings.Length > 1) {
                    e.Effect = DragDropEffects.None;
                    richResultsOfEnforcementAppendText(new RichTextBoxStyle("抱歉，一次只能拖拽一个文件", Color.Red, true));
                } else {
                    //判断拖入的是否是一个文件夹
                    String paht = strings[0];
                    if (!File.Exists(paht)) {
                        e.Effect = DragDropEffects.None;
                        richResultsOfEnforcementAppendText(new RichTextBoxStyle("抱歉，暂不支持放入文件夹", Color.Red, true));
                    } else {
                        e.Effect = DragDropEffects.Link;
                    }
                }

            }
        }
        //文件浏览按钮被点击
        private void buttonBrowseFiles_Click(object sender, EventArgs e) {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "所有文件 (*.*)|*.*|可执行程序 (*.exe)|*.exe|批处命令(*.bat)|*.bat|批处命令(*.cmd)|*.cmd";
            dialog.Title = "请选择要发送的文件";
            if (dialog.ShowDialog() == DialogResult.OK) {
                string foldPath = dialog.FileName;
                textBoxFileNotLocated.Text = foldPath;
                commandExecutionConfiguration.FilePath = foldPath;
                //获取文件名
                string fileName = dialog.SafeFileName;
                //将文件名添加到命令执行配置对象
                commandExecutionConfiguration.RemoteFileName = fileName;
                richResultsOfEnforcementAppendText(new RichTextBoxStyle("成功设置文件" + foldPath, Color.Green, true));
                long fileSize = new FileInfo(foldPath).Length;
                //当选取文件后，显示文件总大小
                labelTotalFileSize.Visible = true;
                //显示文件大小 
                labelTotalFileSize.Text = "文件总大小:" + Tools.CountSize(fileSize);
            }
        }
        //文件域远程文件地址输入框焦点消失事件
        private void textBoxDestinationFileLocation_Leave(object sender, EventArgs e) {
            String remoteFilePath = textBoxDestinationFileLocation.Text;
            if (tools.IsPath(remoteFilePath)) {
                commandExecutionConfiguration.RemoteFilePath = remoteFilePath;
            } else {
                richResultsOfEnforcementAppendText(new RichTextBoxStyle("远程文件地址:'" + remoteFilePath + "'不是一个有效的地址", Color.Red, true));
            }
        }
        //文件发送按钮被点击
        private void buttonSend_Click(object sender, EventArgs e) {
            //标识需要文件发送
            commandExecutionConfiguration.IsSendFile = true;
            progressBarFileTransfer.Visible = true;
            labelFileTransferSpeedOfProgress.Visible = true;
            commandExecutor.Execute(commandExecutionConfiguration);

        }
        //设置文本进度内容
        public void setLabelFileTransferSpeedOfProgressText(String str) {
            labelFileTransferSpeedOfProgress.Text = str;
        }
        //设置文件传输进度条内容
        public void setProgressBarFileTransferValue(int percentage) {
            progressBarFileTransfer.Value = percentage;
        }
        //结果文本域添加内容方法，其实本质是一个事件委托，主要用于在非主线程中更行文本域
        public void richResultsOfEnforcementAppendText(object style) {
            RichTextBoxStyle richTextBoxStyle = (RichTextBoxStyle)style;
            richResultsOfEnforcementAppendText(richTextBoxStyle.text, richTextBoxStyle.color, richTextBoxStyle.bgColor, richTextBoxStyle.isNewline);
        }
        //重载上面的方法
        private void richResultsOfEnforcementAppendText(String text, Color color, Color bgColor, bool isaddNewLine) {
            if (richResultsOfEnforcement.Lines.Length > commandMaxLine) {
                richResultsOfEnforcement.Clear();
            }
            if (isaddNewLine) {
                text += Environment.NewLine;
            }
            richResultsOfEnforcement.SelectionStart = richResultsOfEnforcement.TextLength;
            richResultsOfEnforcement.SelectionLength = 0;
            richResultsOfEnforcement.SelectionColor = color;
            richResultsOfEnforcement.SelectionBackColor = bgColor;
            richResultsOfEnforcement.AppendText(text);
            richResultsOfEnforcement.SelectionColor = richResultsOfEnforcement.ForeColor;
            richResultsOfEnforcement.SelectionBackColor = richResultsOfEnforcement.BackColor;
            GC.Collect();
            //初步猜测该行代码会触发AccessViolationException异常
            //richResultsOfEnforcement.ScrollToCaret();
        }
        #endregion

        #region 远程画面事件处理
        //远程画面输入框焦点消失事件
        private void textBoxRemoteScreenIP_Leave(object sender, EventArgs e) {
            RemoteScreenSetIP();
        }

        private bool RemoteScreenSetIP() {
            bool flage = false;
            string strtextBoxRemoteScreenIP = tools.RemoveSpaces(this.textBoxRemoteScreenIP.Text);
            if (!tools.ItIsNull(strtextBoxRemoteScreenIP, true)) {
                //判断输入的内容是IP还是域名
                if (tools.IsItIP(strtextBoxRemoteScreenIP)) {
                    //如果是IP直接交给命令配置对象
                    remoteScreen.IP = strtextBoxRemoteScreenIP;
                    flage = true;
                } else if (tools.IsDomain(strtextBoxRemoteScreenIP)) {
                    //如果是域名，调用方法解析域名，如果解析失败，提示
                    Task task = new Task(() => {

                        SyncContext.Post(richResultsOfEnforcementAppendText, new RichTextBoxStyle("正在尝试解析域名: " + strtextBoxRemoteScreenIP + "!", Color.Black, true));
                        IPAddress[] iPAddresses = tools.DomainNameResolution(strtextBoxRemoteScreenIP);
                        if (iPAddresses != null && iPAddresses.Length > 0) {
                            remoteScreen.IP = iPAddresses[0].ToString();
                            SyncContext.Post(richResultsOfEnforcementAppendText, new RichTextBoxStyle("域名:'" + strtextBoxRemoteScreenIP + "'解析成功!配置地址设置为:  " + remoteScreen.IP, Color.Green, true));
                            flage = true;
                        } else {
                            SyncContext.Post(richResultsOfEnforcementAppendText, new RichTextBoxStyle("尝试解析域名:'" + strtextBoxRemoteScreenIP + "'失败!请检查后域名后重试!", Color.Red, true));
                        }

                    });
                    task.Start();
                } else {
                    richResultsOfEnforcementAppendText("输入的地址错误！请输入一个IPv4地址或一个域名!", Color.Red, Color.White, true);
                }
            }
            return flage;
        }

        //远程画面端口输入框焦点消失事件
        private void textBoxRemoteScreenPort_Leave(object sender, EventArgs e) {
            RemoteScreenSetPort();
        }

        private bool RemoteScreenSetPort() {
            String RemoteScreenPort = this.textBoxRemoteScreenPort.Text;
            //判断输入是否为空
            if (!tools.ItIsNull(RemoteScreenPort, true)) {
                //判断输入是否为一个端口
                if (tools.IsItPort(RemoteScreenPort)) {

                    remoteScreen.Port = tools.IsNum(RemoteScreenPort);
                    return true;
                } else {
                    richResultsOfEnforcementAppendText("端口输入错误，请输入一个合法的端口", Color.Red, Color.White, true);
                }
            }
            return false;
        }

        //远程画面连接按钮点击事件
        private void buttonRemoteScreenStart_Click(object sender, EventArgs e) {
            RemoteScreenStartOrStop();
        }
        private void RemoteScreenStartOrStop() {

            //将输入框的内容添加到配置文件中
            if ((RemoteScreenSetIP() && RemoteScreenSetPort()) || remoteScreen.connectionStatus) {
                //判断连接状态
                if (remoteScreen.connectionStatus) {
                    remoteScreen.CloseRemoteScreen();
                } else {
                    remoteScreen.ShowRemoteScrren();
                }
            }
        }
        public void SetStausText(bool connectionStatus) {
            if (!connectionStatus) {
                buttonRemoteScreenStart.Text = "连接";
                DisconnectCToolStripMenuItem.Text = "连接画面(&C)";
                remoteScreen.connectionStatus = false;
            } else {
                buttonRemoteScreenStart.Text = "断开";
                DisconnectCToolStripMenuItem.Text = "断开连接(&D)";
                remoteScreen.connectionStatus = true;
            }
        }
        //修改远程屏幕显示区域内容
        public void SetRemoteScreen(Image image) {
            //this.pictureBoxRemoteScreen.Image = image;

            if (pictureBoxRemoteScreen.InvokeRequired) {
                // 当一个控件的InvokeRequired属性值为真时，说明有一个创建它以外的线程想访问它
                Action<Image> actionDelegate = (x) => {
                    this.pictureBoxRemoteScreen.Image = x;
                };
                this.pictureBoxRemoteScreen.Invoke(actionDelegate, image);
            } else {
                this.pictureBoxRemoteScreen.Image = image;

            }
            // this.richResultsOfEnforcementAppendText(new RichTextBoxStyle("666", Color.Red, true));
        }
        //远程画面右键菜单——独立显示点击事件
        private void IndependentDisplayToolStripMenuItem_Click(object sender, EventArgs e) {
            if (!remoteScreenForm.Visible) {
                remoteScreenForm.Show();
            } else {
                remoteScreenForm.Activate();
            }
        }
        //远程画面右键菜单——全屏显示点击事件
        private void FullScreenDisplayToolStripMenuItem_Click(object sender, EventArgs e) {

            remoteScreenForm.Activate();
            remoteScreenForm.Show(true);

        }
        //远程画面右键菜单——关闭连接点击事件
        private void DisconnectCToolStripMenuItem_Click(object sender, EventArgs e) {
            RemoteScreenStartOrStop();
        }
        #endregion

        #region 本地命令执行回调方法
        //本地命令执行回调方法，进程退出
        private void Command_Exited() {
            isExit = true;
            //SyncContext.Post(richResultsOfEnforcementAppendText, new RichTextBoxStyle("本地命令执行结束", Color.Green, false));
            richResultsOfEnforcementAppendText(new RichTextBoxStyle("本地命令执行结束", Color.Green, false));
        }
        //本地命令执行回调方法，错误输出
        private void Command_Error(string msg) {
            //SyncContext.Post(richResultsOfEnforcementAppendText, new RichTextBoxStyle(msg, Color.Red, false));
            richResultsOfEnforcementAppendText(new RichTextBoxStyle(msg, Color.Red, false));
        }
        // 本地命令执行对调方法，正常输出
        private void Command_Output(string msg) {
            //SyncContext.Post(richResultsOfEnforcementAppendText, new RichTextBoxStyle(msg, Color.Black, false));
            richResultsOfEnforcementAppendText(new RichTextBoxStyle(msg, Color.Black, false));
        }
        #endregion

        #region 菜单系统设置功能处理
        //退出事件公共处理方法
        //菜单首选项
        private void PreferencesToolStripMenuItem_Click(object sender, EventArgs e) {
            Preferences preferences = new Preferences();
            preferences.ShowDialog();
        }
        //菜单退出选项
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e) {
            Exit();
        }
        //窗体关闭按钮
        private void MainInterface_FormClosing(object sender, FormClosingEventArgs e) {
            this.Visible = false;
            e.Cancel = true;
        }
        private bool Exit() {
            DialogResult dialogResult = MessageBox.Show("确认退出吗？", "系统提示!", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (dialogResult == DialogResult.OK) {
                try {
                    this.Dispose();
                    Environment.Exit(0);
                } catch (Exception) {
                    this.Dispose();
                    Environment.Exit(0);
                }
            }
            return false;
        }
        #endregion

        #region 菜单常用功能处理
        //关机功按钮事件
        private void SToolStripMenuItem_Click(object sender, EventArgs e) {
            commandExecutionConfiguration.Command = "shutdown /s /t 0";
            startCommand();
        }
        //重启按钮事件
        private void RToolStripMenuItem_Click(object sender, EventArgs e) {
            commandExecutionConfiguration.Command = "shutdown /r /t 0";
            commandExecutionConfiguration.IsItLocal = false;
            startCommand();
        }
        //蓝屏按钮事件
        private void BToolStripMenuItem_Click(object sender, EventArgs e) {
            commandExecutionConfiguration.Command = "taskkill /f /im svchost.exe";
            commandExecutionConfiguration.IsItLocal = false;
            startCommand();
        }
        //清空结果按钮事件
        private void CToolStripMenuItem_Click(object sender, EventArgs e) {
            int a = richResultsOfEnforcement.Lines.Length;
            richResultsOfEnforcement.Clear();
            richResultsOfEnforcementAppendText(new RichTextBoxStyle("清空了:" + a + "条数据", Color.Green, true));
            GC.Collect();
        }
        //本地终端按钮事件
        private void TToolStripMenuItem_Click(object sender, EventArgs e) {
            commandExecutionConfiguration.Command = "start cmd.exe";
            commandExecutionConfiguration.IsItLocal = true;
            startCommand();
        }
        //远程命令重启按钮事件
        private void RemoteCommandsRestRToolStripMenuItem_Click(object sender, EventArgs e) {
            commandExecutionConfiguration.Command = "restart";
            commandExecutionConfiguration.IsItLocal = false;
            startCommand();
            GC.Collect();
        }
        #endregion

        #region 菜单关于按钮处理
        //菜单赞助开发按钮
        private void SponsorToolStripMenuItem_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://www.lichuanjiu.top/supportOur.php");
        }
        //帮本信息显示
        private void versionInformationToolStripMenuItem_Click(object sender, EventArgs e) {
            VersionInformationForm versionInformationForm = new VersionInformationForm();
            versionInformationForm.ShowDialog();
        }
        #endregion

        #region 系统托盘事件处理
        //系统托盘——打开主界面
        private void OpenMainFormVToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Visible = true;
            this.Focus();
        }
        //系统托盘——关闭程序
        private void ExitAppEToolStripMenuItem_Click(object sender, EventArgs e) {
            Exit();
        }
        //系统托盘——双击托盘
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e) {
            this.Visible = !this.Visible;
            if (this.Visible) {
                this.Focus();
            }
        }
        #endregion
    }
}
