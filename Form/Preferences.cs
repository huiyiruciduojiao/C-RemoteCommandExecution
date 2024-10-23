using System;
using System.Windows.Forms;

namespace TCPConsole {
    public partial class Preferences : Form {
        /// <summary>
        /// 创建一个配置文件读写工具对象
        /// </summary>
        ConfigurationTools configurationTools = new ConfigurationTools("./config.ini");
        /// <summary>
        /// 数据是否改变标识
        /// </summary>
        private bool changeOrNot = false;

        //创建设置对象
        private Setting setting = new Setting();

        /// <summary>
        /// 数据是否改变标识
        /// true 数据被更改
        /// false 数据未更改
        /// </summary>
        public bool ChangeOrNot {
            get => changeOrNot;
            set {
                changeOrNot = value;
                preservationButton.Enabled = value;
            }
        }

        public Preferences() {
            InitializeComponent();
        }
        //窗体加载时
        private void Preferences_Load(object sender, EventArgs e) {
            //将配置加载，并显示到窗体中
            LoadSetting();
            ChangeOrNot = false;
            //窗体加载完成默认不允许点击保存按钮
            //preservationButton.Enabled = false;
        }
        //取消保存按钮
        private void cancelButton_Click(object sender, EventArgs e) {
            if (ChangeOrNot) {
                DialogResult dialogResult = MessageBox.Show("您确定要放弃所做的更改吗？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.OK) {
                    this.Close();
                }
            } else {
                this.Close();
            }
        }
        //保存按钮
        private void preservationButton_Click(object sender, EventArgs e) {
            DialogResult dialogResult = MessageBox.Show("您确定要保存更改吗？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.OK) {
                SaveSettings();
                ChangeOrNot = false;
            }
        }
        //重置按钮
        private void resetButton_Click(object sender, EventArgs e) {
            DialogResult dialogResult = MessageBox.Show("所有设置将恢复默认？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.OK) {
                setting = new Setting();
                LoadDefulteSeting();
                ChangeOrNot = false;
            }
        }
        //窗体关闭事件
        private void Preferences_FormClosing(object sender, FormClosingEventArgs e) {
            if (ChangeOrNot) {
                DialogResult dialogResult = MessageBox.Show("是否保存更改？", "系统提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes) {
                    configurationTools.SaveSettings();
                } else if (dialogResult == DialogResult.Cancel) {
                    e.Cancel = true;
                }
            }

        }
        //加载默认设置
        private void LoadDefulteSeting() {
            String defalutSetting = "Defalut";
            //默认命令IP设置
            configurationTools.AddSetting(defalutSetting, "DefalutCommandAddress", setting.DefalutCommandAddress);
            //默认命令端口
            configurationTools.AddSetting(defalutSetting, "DefalutCommandPort", setting.DefalutCommandPort);
            //默认执行次数
            configurationTools.AddSetting(defalutSetting, "DefalutCommandFrequency", setting.DefalutCommandFrequency);
            //默认命令输入框字体大小
            configurationTools.AddSetting(defalutSetting, "DefalutCommandInputTextFontSize", setting.DefalutCommandInputTextFontSize);
            //命令执行结果最大显示行数
            configurationTools.AddSetting(defalutSetting, "CommandResultMaxLine", setting.CommandResultMaxLine);
            //默认文件发送地址
            configurationTools.AddSetting(defalutSetting, "DefalutFileSendAddress", setting.DefalutFileSendAddress);
            //默认文件发送端口
            configurationTools.AddSetting(defalutSetting, "DefalutFileSendPort", setting.DefalutFileSendPort);
            //默认远程文件保存位置
            configurationTools.AddSetting(defalutSetting, "DefalutFileRemoteSaveAddress", setting.DefalutFileRemoteSaveAddress);
            //默认远程画面地址
            configurationTools.AddSetting(defalutSetting, "DefaultRemoteScreenAddress", setting.DefalutRemoteScreenAddress);
            //默认远程画面端口
            configurationTools.AddSetting(defalutSetting, "DefaultRemoteScreenPort", setting.DefalutRemoteScreenPort);
            //默认AgentHost
            configurationTools.AddSetting(defalutSetting, "AgentHost", setting.DefalutAgentHost);
            //默认AgentPort
            configurationTools.AddSetting(defalutSetting, "AgentPort", setting.DefalutAgentPort);

            //保存配置
            configurationTools.SaveSettings();
            //显示配置数据到窗体
            LoadSetting();
        }
        //加载当前配置
        private void LoadSetting() {
            String defalutSetting = "Defalut";
            //命令IP
            textBoxDefaultCommandAddress.Text = configurationTools.GetSetting(defalutSetting, "DefalutCommandAddress");
            //命令端口
            textBoxDefaultCommandPort.Text = configurationTools.GetSetting(defalutSetting, "DefalutCommandPort");
            //执行次数
            numericUpDownDefaultCommandFrequency.Value = int.Parse(configurationTools.GetSetting(defalutSetting, "DefalutCommandFrequency"));
            //命令输入框文字默认大小
            numericUpDownDefaultFontSize.Value = int.Parse(configurationTools.GetSetting(defalutSetting, "DefalutCommandInputTextFontSize"));
            //命令执行结果最大显示行数
            numericUpDownResultMaxRows.Value = int.Parse(configurationTools.GetSetting(defalutSetting, "CommandResultMaxLine"));
            //默认文件发送地址
            textBoxDefaultFileSendAddress.Text = configurationTools.GetSetting(defalutSetting, "DefalutFileSendAddress");
            //默认文件发送端口
            textBoxDefaultFileSendProt.Text = configurationTools.GetSetting(defalutSetting, "DefalutFileSendPort");
            //默认远程文件保存位置
            textBoxDefaultRemoteSaveAddress.Text = configurationTools.GetSetting(defalutSetting, "DefalutFileRemoteSaveAddress");
            //默认远程画面地址
            textBoxDefaultRemoteScreenAddress.Text = configurationTools.GetSetting(defalutSetting, "DefaultRemoteScreenAddress");
            //默认远程画面端口
            textBoxDefaultRemoteScreenPort.Text = configurationTools.GetSetting(defalutSetting, "DefaultRemoteScreenPort");
            //默认Agent主机
            AgentHost.Text = configurationTools.GetSetting(defalutSetting, "AgentHost");
            //默认Agent端口
            AgentPort.Text = configurationTools.GetSetting(defalutSetting, "AgentPort");
        }
        //保存设置
        private void SaveSettings() {
            //修改设置对象的值
            setting.DefalutCommandAddress = textBoxDefaultCommandAddress.Text;
            setting.DefalutCommandPort = textBoxDefaultCommandPort.Text;
            setting.DefalutCommandFrequency = numericUpDownDefaultCommandFrequency.Value.ToString();
            setting.DefalutCommandInputTextFontSize = numericUpDownDefaultFontSize.Value.ToString();
            setting.CommandResultMaxLine = numericUpDownResultMaxRows.Value.ToString();
            setting.DefalutFileSendAddress = textBoxDefaultFileSendAddress.Text;
            setting.DefalutFileSendPort = textBoxDefaultFileSendProt.Text;
            setting.DefalutFileRemoteSaveAddress = textBoxDefaultRemoteSaveAddress.Text;
            setting.DefalutRemoteScreenAddress = textBoxDefaultRemoteScreenAddress.Text;
            setting.DefalutRemoteScreenPort = textBoxDefaultRemoteScreenPort.Text;
            setting.DefalutAgentHost = AgentHost.Text;
            setting.DefalutAgentPort = AgentPort.Text;
            //保存设置
            LoadDefulteSeting();
            //将设置显示到窗体
            LoadSetting();
        }
        //命令默认执行地址输入框值改变时
        private void textBoxDefaultCommandAddress_TextChanged(object sender, EventArgs e) {
            ChangeOrNot = true;
        }
        //命令默认执行端口输入框值改变时
        private void textBoxDefaultCommandPort_TextChanged(object sender, EventArgs e) {
            ChangeOrNot = true;
        }
        //默认命令执行次数输入框值改变时
        private void numericUpDownDefaultCommandFrequency_ValueChanged(object sender, EventArgs e) {
            ChangeOrNot = true;
        }
        //默认字体大小输入框值改变时
        private void numericUpDownDefaultFontSize_ValueChanged(object sender, EventArgs e) {
            ChangeOrNot = true;
        }
        //结果最大显示行数值改变时
        private void numericUpDownResultMaxRows_ValueChanged(object sender, EventArgs e) {
            ChangeOrNot = true;
        }
        //默认文件发送地址输入框值改变时
        private void textBoxDefaultFileSendAddress_TextChanged(object sender, EventArgs e) {
            ChangeOrNot = true;
        }
        //默认文件发送端口输入框值改变时
        private void textBoxDefaultFileSendProt_TextChanged(object sender, EventArgs e) {
            ChangeOrNot = true;
        }
        //默认远程文件保存位置输入框值改变时
        private void textBoxDefaultRemoteSaveAddress_TextChanged(object sender, EventArgs e) {
            ChangeOrNot = true;
        }
        //默认远程画面输入框值改变时
        private void textBoxDefaultRemoteScreenAddress_TextChanged(object sender, EventArgs e) {
            ChangeOrNot = true;
        }
        //默认远程画面端口输入框值改变时
        private void textBoxDefaultRemoteScreenPort_TextChanged(object sender, EventArgs e) {
            ChangeOrNot = true;
        }

        private void AgentHost_TextChanged(object sender, EventArgs e) {
            ChangeOrNot = true;
        }

        private void AgentPort_TextChanged(object sender, EventArgs e) {
            ChangeOrNot = true;
        }
    }
}
