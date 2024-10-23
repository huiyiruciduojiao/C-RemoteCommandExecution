using System;

namespace TCPConsole {
    public class CommandExecutionConfiguration {
        //地址
        private String address = null;
        //端口
        private int port = -1;
        //命令
        private String command = null;
        //执行次数
        private int frequency = 1;
        //命令执行器
        private CommandExecutor commandExecutor = null;
        //域名解析状态
        private bool domainNameSystemStatus = false;
        //是否在本地执行
        private bool isItLocal = false;
        //本地控制台执行器
        public Command commandLocal = null;
        //是否发送文件
        private bool isSendFile = false;
        //文件IP
        private String fileAddress = null;
        //远程文件保存位置--文件名
        private String remoteFileName = null;
        //远程文件保存位置--路径
        private String remoteFilePath = null;
        //本地文件路径
        private String filePath = null;
        //远程文件接收端口
        private int filePort = -1;
        public string Address {
            get => address;
            set {
                address = value;
            }
        }
        public int Port {
            get => port;
            set {
                if (value < 0) {
                    port = -1;
                } else {
                    port = value;
                }
            }
        }
        public string Command {
            get => command;
            set => command = value;
        }
        public int Frequency {
            get => frequency;
            set {
                if (value > 0) {
                    frequency = value;
                } else {
                    frequency = 1;
                }
            }
        }
        internal CommandExecutor CommandExecutor {
            get => commandExecutor;
            set => commandExecutor = value;
        }
        public bool DomainNameSystemStatus {
            get => domainNameSystemStatus;
            set => domainNameSystemStatus = value;
        }
        public bool IsItLocal {
            get => isItLocal;
            set => isItLocal = value;
        }
        public string FileAddress {
            get => fileAddress;
            set => fileAddress = value;
        }
        public int FilePort {
            get => filePort;
            set {
                if (value < 0) {
                    filePort = -1;
                } else {
                    filePort = value;
                }
            }
        }

        public bool IsSendFile {
            get => isSendFile;
            set => isSendFile = value;
        }
        public string RemoteFileName {
            get => remoteFileName;
            set => remoteFileName = value;
        }
        public string RemoteFilePath {
            get => remoteFilePath;
            set => remoteFilePath = value;
        }
        public string FilePath {
            get => filePath;
            set => filePath = value;
        }


        /// <summary>
        /// 在执行命令前需要对命令执行配置进行检查，检查没有
        /// 后方可执行,如果有错误，则提示对应错误;该方法需要提供一个命令执行配置对象——(CommandExecutionConfiguration)对象
        /// </summary>
        /// <param name="commandExecutionConfiguration">命令执行配置对象</param>
        public bool PerformConfigurationChecks(CommandExecutionConfiguration commandExecutionConfiguration) {
            return true;
        }
        /// <summary>
        /// 调用该方法执行配置命令，需要提供一个命令执行器
        /// </summary>
        /// <param name="commandExecutor">命令执行器</param>
        public void ExecuteCommand(CommandExecutor commandExecutor) {
            //执行前检查命令配置
            if (PerformConfigurationChecks(this)) {
                commandExecutor.Execute(this);
            }
        }
    }
}
