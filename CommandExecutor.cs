using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TCPConsole {

    /// <summary>
    /// 这是一个命令执行器类，该类用来执行命令配置对象中的数据
    /// </summary>
    internal class CommandExecutor {
        //创建连接的Socket
        Socket socketSend;
        //创建接收客户端发送消息的线程
        Thread threadReceive;
        //文件传输Socket 
        Socket fileSocketSend;

        //IP列表
        List<String> ipList = new List<String>();
        //port 列表
        List<int> portList = new List<int>();
        #region 执行器处理模块
        /// <summary>
        /// 执行命令配置，需要传入一个命令配置对象，用于执行命令
        /// </summary>
        /// <param name="commandExecutionConfiguration">命令配置对象</param>    
        public void Execute(CommandExecutionConfiguration commandExecutionConfiguration) {
            Task t = new Task(() => {
                if (!commandExecutionConfiguration.IsSendFile) {//执行命令
                    if (commandExecutionConfiguration.IsItLocal) {//本地执行代码
                        for (int i = 0; i < commandExecutionConfiguration.Frequency; i++) {
                            LocalExecution(commandExecutionConfiguration.Command, commandExecutionConfiguration.commandLocal);
                            Thread.Sleep(100);
                        }
                    } else {//远程执行命令
                        for (int i = 0; i < commandExecutionConfiguration.Frequency; i++) {
                            RemoteExecution(commandExecutionConfiguration);
                            Thread.Sleep(100);
                        }
                    }
                } else {//文件发送
                    SendFile(commandExecutionConfiguration);
                }
            });
            t.Start();
        }
        #endregion
        public void LocalExecution(String cmd, Command command) {
            if (command != null) {
                command.RunCMD(cmd);
            }
        }
        #region 远程命令执行模块
        /// <summary>
        /// 远程命令执行
        /// </summary>
        /// <param name="commandExecutionConfiguration">命令执行配置器</param>
        public void RemoteExecution(CommandExecutionConfiguration commandExecutionConfiguration) {
            bool hasAnErrorOccurred = false;
            //判断是否需要进行创建对象
            if (!WhetherItExists(commandExecutionConfiguration.Address, commandExecutionConfiguration.Port)) {
                try {
                    socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    IPAddress ip = IPAddress.Parse(commandExecutionConfiguration.Address);
                    socketSend.Connect(ip, commandExecutionConfiguration.Port);
                    //开启一个新的线程不停的接收服务器发送消息的线程
                    threadReceive = new Thread(new ThreadStart(Receive));
                    //设置为后台线程
                    threadReceive.IsBackground = true;
                    threadReceive.Start();

                    //连接添加到列表中
                    ipList.Add(commandExecutionConfiguration.Address);
                    portList.Add(commandExecutionConfiguration.Port);
                } catch (Exception ex) {
                    MainInterface.MainInterfaceUi.richResultsOfEnforcementAppendText(new RichTextBoxStyle("连接发生错误:" + ex.Message, Color.Red, true));
                    hasAnErrorOccurred = true;
                }
            }
            if (!hasAnErrorOccurred) {
                Send(commandExecutionConfiguration.Command);
            }

        }
        /// <summary>
        /// 接收服务器发送的消息
        /// </summary>
        private void Receive() {
            try {
                while (true) {
                    byte[] buffer = new byte[2048];
                    //实际接收到的字节数
                    int r = socketSend.Receive(buffer);
                    if (r == 0) {
                        break;
                    } else {
                        string str = Encoding.UTF8.GetString(buffer, 0, r);

                        //MainInterface.MainInterfaceUi.SyncContext.Post(MainInterface.MainInterfaceUi.richResultsOfEnforcementAppendText,new RichTextBoxStyle(str,Color.Black,false));
                        MainInterface.MainInterfaceUi.richResultsOfEnforcementAppendText(new RichTextBoxStyle(str, Color.Black, false));
                    }
                }
            } catch (Exception ex) {
                MainInterface.MainInterfaceUi.richResultsOfEnforcementAppendText(new RichTextBoxStyle("发生错误:" + ex.Message, Color.Red, true));
                if (socketSend != null) {

                    IPEndPoint a = (IPEndPoint)socketSend.RemoteEndPoint;
                    ipList.Remove(a.Address.ToString());

                    portList.Remove(int.Parse(a.Port.ToString()));
                }
            }
        }
        private void Send(String command) {
            try {
                byte[] buffer = new byte[2048];
                buffer = Encoding.UTF8.GetBytes(command);
                int receive = socketSend.Send(buffer);
            } catch (Exception ex) {
                IPEndPoint a = (IPEndPoint)socketSend.RemoteEndPoint;
                ipList.Remove(a.Address.ToString());

                portList.Remove(int.Parse(a.Port.ToString()));
                MainInterface.MainInterfaceUi.richResultsOfEnforcementAppendText(new RichTextBoxStyle("发生错误:" + ex.Message, Color.Red, true));
            }
        }
        #endregion
        #region 发送远程文件模块
        /// <summary>
        /// 远程文件发送
        /// </summary>
        /// <param name="commandExecutionConfiguration">命令执行配置器</param>
        public void SendFile(CommandExecutionConfiguration commandExecutionConfiguration) {
            //是否退出进度条更新线程
            bool isExitUI = false;
            try {

                string strPath = commandExecutionConfiguration.FilePath;
                MainInterface.MainInterfaceUi.richResultsOfEnforcementAppendText(new RichTextBoxStyle("尝试向:" + commandExecutionConfiguration.FileAddress + "发送文件:" + strPath, Color.Black, true));
                fileSocketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ip = IPAddress.Parse(commandExecutionConfiguration.FileAddress);
                fileSocketSend.Connect(ip, commandExecutionConfiguration.FilePort);

                byte[] buffer = new byte[2048];
                buffer = Encoding.UTF8.GetBytes(commandExecutionConfiguration.RemoteFilePath + commandExecutionConfiguration.RemoteFileName);
                int receive = fileSocketSend.Send(buffer);
                //线程等待
                Thread.Sleep(300);
                CancellationTokenSource tokenSource = new CancellationTokenSource();
                CancellationToken cancellationToken = tokenSource.Token;
                Task task = null;
                // 读取文件并发送到接收方
                using (FileStream fileStream = File.OpenRead(strPath)) {
                    buffer = new byte[1024];
                    long fileSize = fileStream.Length;
                    long nowSendSize = 0;
                    int bytesRead = 0;
                    //创建一个线程，用于独立更新UI
                    task = new Task(() => {
                        int percentage = 0;
                        while (nowSendSize < fileSize) {
                            //更新已传输大小标签
                            MainInterface.MainInterfaceUi.setLabelFileTransferSpeedOfProgressText("已传输:" + Tools.CountSize(nowSendSize));
                            //更新进度条
                            percentage = (int)(((double)nowSendSize / (double)fileSize) * 10000);
                            MainInterface.MainInterfaceUi.setProgressBarFileTransferValue(percentage);
                            Thread.Sleep(1000 / 60);
                            if (isExitUI) {
                                break;
                            }
                        }
                        MainInterface.MainInterfaceUi.setProgressBarFileTransferValue(10000);
                        //更新已传输大小标签
                        MainInterface.MainInterfaceUi.setLabelFileTransferSpeedOfProgressText("已传输:" + Tools.CountSize(nowSendSize));
                    }, cancellationToken);
                    //启动线程
                    task.Start();
                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0) {
                        fileSocketSend.Send(buffer, bytesRead, SocketFlags.None);
                        nowSendSize += bytesRead;
                    }
                }

                fileSocketSend.Shutdown(SocketShutdown.Both);
                fileSocketSend.Close();
                //文件发送结束后，关闭线程
                if (task != null) {
                    tokenSource.Cancel();
                }
                //文本域更新
                MainInterface.MainInterfaceUi.richResultsOfEnforcementAppendText(new RichTextBoxStyle("向:" + commandExecutionConfiguration.FileAddress + "发送文件:" + strPath + "成功", Color.Green, true));
            } catch (Exception ex) {
                isExitUI = true;
                MainInterface.MainInterfaceUi.richResultsOfEnforcementAppendText(new RichTextBoxStyle("向:" + commandExecutionConfiguration.FileAddress + "发送" + commandExecutionConfiguration.FilePath + "发生错误:" + ex.Message, Color.Red, true));

            }
        }
        #endregion
        //判断传入的数据是否在列表中存在了
        public bool WhetherItExists(String ip, int port) {
            if (this.ipList.Exists(t => t == ip) && this.portList.Exists(t => t == port)) {
                return true;
            }
            return false;
        }


    }
    #region 控制台执行器
    /// <summary>
    /// 控制台命令，由天蘩封装
    /// </summary>
    public class Command {
        private const int _ReadSize = 10240;
        private Process _CMD;//cmd进程
        private Encoding _OutEncoding;//输出字符编码
        private Stream _OutStream;//基础输出流
        private Stream _ErrorStream;//错误输出流
        public event Action<string> Output;//输出事件
        public event Action<string> Error;//错误事件
        public event Action Exited;//退出事件
        private bool _Run;//循环控制
        private byte[] _TempBuffer;//临时缓冲
        private byte[] _ReadBuffer;//读取缓存区

        private byte[] _ETempBuffer;//临时缓冲
        private byte[] _ErrorBuffer;//错误读取缓存区
        public Command() {
            _CMD = new Process();
            _CMD.StartInfo.FileName = "cmd.exe";
            _CMD.StartInfo.UseShellExecute = false;//是否使用操作系统shell启动
            _CMD.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            _CMD.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            _CMD.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            _CMD.StartInfo.CreateNoWindow = true;//不显示程序窗口
            _CMD.Exited += _CMD_Exited;
            _ReadBuffer = new byte[_ReadSize];
            _ErrorBuffer = new byte[_ReadSize];
            ReStart();
        }

        /// <summary>
        /// 停止使用，关闭进程和循环线程
        /// </summary>
        public void Stop() {
            _Run = false;
            _CMD.Close();
        }


        /// <summary>
        /// 重新启用
        /// </summary>
        public void ReStart() {
            Stop();
            _CMD.Start();
            _OutEncoding = _CMD.StandardOutput.CurrentEncoding;
            _OutStream = _CMD.StandardOutput.BaseStream;
            _ErrorStream = _CMD.StandardError.BaseStream;
            _Run = true;
            _CMD.StandardInput.AutoFlush = true;
            ReadResult();
            ErrorResult();
        }

        //退出事件
        private void _CMD_Exited(object sender, EventArgs e) {
            Exited?.Invoke();
        }

        /// <summary>
        /// 执行cmd命令
        /// </summary>
        /// <param name="cmd">需要执行的命令</param>
        public void RunCMD(string cmd) {

            if (!_Run) {
                if (cmd.Trim().Equals("/restart", StringComparison.CurrentCultureIgnoreCase)) {
                    ReStart();
                }
                return;
            }
            try {

                if (_CMD.HasExited) {
                    Stop();
                    return;
                }
            } catch (Exception ex) { }
            _CMD.StandardInput.WriteLine(cmd);
        }



        //异步读取输出结果
        private void ReadResult() {
            if (!_Run) {
                return;
            }
            _OutStream.BeginRead(_ReadBuffer, 0, _ReadSize, ReadEnd, null);
        }

        //一次异步读取结束
        private void ReadEnd(IAsyncResult ar) {
            int count = _OutStream.EndRead(ar);

            if (count < 1) {
                try {

                    if (_CMD.HasExited) {
                        Stop();
                    }
                } catch { }
                return;
            }

            if (_TempBuffer == null) {
                _TempBuffer = new byte[count];
                Buffer.BlockCopy(_ReadBuffer, 0, _TempBuffer, 0, count);
            } else {
                byte[] buff = _TempBuffer;
                _TempBuffer = new byte[buff.Length + count];
                Buffer.BlockCopy(buff, 0, _TempBuffer, 0, buff.Length);
                Buffer.BlockCopy(_ReadBuffer, 0, _TempBuffer, buff.Length, count);
            }

            if (count < _ReadSize) {
                string str = _OutEncoding.GetString(_TempBuffer);
                Output?.Invoke(str);
                _TempBuffer = null;
            }

            ReadResult();
        }


        //异步读取错误输出
        private void ErrorResult() {
            if (!_Run) {
                return;
            }
            _ErrorStream.BeginRead(_ErrorBuffer, 0, _ReadSize, ErrorCallback, null);
        }

        private void ErrorCallback(IAsyncResult ar) {
            int count = _ErrorStream.EndRead(ar);

            if (count < 1) {
                try {

                    if (_CMD.HasExited) {
                        Stop();
                    }
                } catch (Exception ex) { }
                return;
            }

            if (_ETempBuffer == null) {
                _ETempBuffer = new byte[count];
                Buffer.BlockCopy(_ErrorBuffer, 0, _ETempBuffer, 0, count);
            } else {
                byte[] buff = _ETempBuffer;
                _ETempBuffer = new byte[buff.Length + count];
                Buffer.BlockCopy(buff, 0, _ETempBuffer, 0, buff.Length);
                Buffer.BlockCopy(_ErrorBuffer, 0, _ETempBuffer, buff.Length, count);
            }

            if (count < _ReadSize) {
                string str = _OutEncoding.GetString(_ETempBuffer);
                Error?.Invoke(str);
                _ETempBuffer = null;
            }

            ErrorResult();
        }

        ~Command() {
            _Run = false;
            _CMD?.Close();
            _CMD?.Dispose();
        }

    }
    #endregion
}
