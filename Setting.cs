using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCPConsole {
    /// <summary>
    /// 这是一个设置类，其中封装了程序默认配置，当你需要写入配置时，可以通过设置封装的值
    /// </summary>
    internal class Setting {
        private String defalutCommandAddress = "127.0.0.1";
        private String defalutCommandPort = "8888";
        private String defalutCommandFrequency = "1";
        private String defalutCommandInputTextFontSize = "12";
        private String commandResultMaxLine = "10000";
        private String defalutFileSendAddress = "127.0.0.1";
        private String defalutFileSendPort = "8889";
        private String defalutFileRemoteSaveAddress = "C:\\Users\\";
        private String defalutRemoteScreenAddress = "127.0.0.1";
        private String defalutRemoteScreenPort = "7878";
        private String defalutAgentHost = "lichuanjiu.top";
        private String defalutAgentPort = "8887";

        Tools tools = new Tools();
        public string DefalutCommandAddress {
            get => defalutCommandAddress;
            set {
                if (!tools.ItIsNull(value, true)) {
                    //判断输入的内容是IP还是域名
                    if (tools.IsItIP(value)) {
                        defalutCommandAddress = value;
                    } else if (tools.IsDomain(value)) {
                        //如果是域名，调用方法解析域名，如果解析失败，提示
                        Task task = new Task(() => {
                            IPAddress[] iPAddresses = tools.DomainNameResolution(value);
                            if (iPAddresses != null && iPAddresses.Length > 0) {
                                defalutCommandAddress = iPAddresses[0].ToString();
                            } else {
                                defalutCommandAddress = "127.0.0.1";
                                MessageBox.Show("解析:" + value + "失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        });
                        task.Start();
                    } else {
                        defalutCommandAddress = "127.0.0.1";
                        MessageBox.Show("请输入IP地址或域名！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        public string DefalutCommandPort {
            get => defalutCommandPort;
            set => defalutCommandPort = value;
        }
        public string DefalutCommandFrequency {
            get => defalutCommandFrequency;
            set => defalutCommandFrequency = value;
        }
        public string DefalutCommandInputTextFontSize {
            get => defalutCommandInputTextFontSize;
            set => defalutCommandInputTextFontSize = value;
        }
        public string CommandResultMaxLine {
            get => commandResultMaxLine;
            set => commandResultMaxLine = value;
        }
        public string DefalutFileSendAddress {
            get => defalutFileSendAddress;
            set => defalutFileSendAddress = value;
        }
        public string DefalutFileSendPort {
            get => defalutFileSendPort;
            set => defalutFileSendPort = value;
        }
        public string DefalutFileRemoteSaveAddress {
            get => defalutFileRemoteSaveAddress;
            set => defalutFileRemoteSaveAddress = value;
        }
        public string DefalutRemoteScreenAddress {
            get => defalutRemoteScreenAddress;
            set => defalutRemoteScreenAddress = value;
        }
        public string DefalutRemoteScreenPort {
            get => defalutRemoteScreenPort;
            set => defalutRemoteScreenPort = value;
        }
        public string DefalutAgentHost {
            get => defalutAgentHost;
            set => defalutAgentHost = value;
        }
        public string DefalutAgentPort {
            get => defalutAgentPort;
            set => defalutAgentPort = value;
        }
    }

}
