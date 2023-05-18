using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TCPConsole {
    internal class GetRemoteScreen {

        private String iP;
        private int port;


        //是否关闭连接
        private bool isClose = false;
        //连接状态
        public bool connectionStatus = false;
        public int Port {
            get => port;
            set => port = value;
        }
        public string IP {
            get => iP;
            set => iP = value;
        }

        private Tools tools = new Tools();
        //  int frameRate = 0;
        public void ShowRemoteScrren() {
            Task task = new Task(() => {
              
                try {
                    Socket fileSocketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    IPAddress ip = IPAddress.Parse(iP);
                    fileSocketSend.Connect(ip, port);
                    MainInterface.MainInterfaceUi.richResultsOfEnforcementAppendText(new RichTextBoxStyle("连接远程画面：" + iP + ":" + port + " 成功！", Color.Green, true));
                    connectionStatus = true;
                    MainInterface.MainInterfaceUi.SetStausText(true);
                    while (true) {
                        
                        if (isClose) {
                            MainInterface.MainInterfaceUi.richResultsOfEnforcementAppendText(new RichTextBoxStyle("与：" + fileSocketSend.RemoteEndPoint + "的远程画面断开了连接！", Color.Red, true));
                            isClose = false;
                            connectionStatus = false;
                            MainInterface.MainInterfaceUi.SetStausText(false);
                            fileSocketSend.Close();
                            fileSocketSend.Dispose();
                            GC.Collect();
                            break;
                        }
                        byte[] dataBuffer = null;
                        byte[] buffer = new byte[1024];
                        int a = fileSocketSend.Receive(buffer);
                        if (a == 4) {
                            int temp = BitConverter.ToInt32(buffer, 0);
                            if (temp > 0 && temp < 1073741824) {
                                dataBuffer = new byte[temp];
                            }
                        } else if (a == 0) {
                            MainInterface.MainInterfaceUi.richResultsOfEnforcementAppendText(new RichTextBoxStyle("与：" + fileSocketSend.RemoteEndPoint + "的远程画面断开了连接！", Color.Red, true));
                            MainInterface.MainInterfaceUi.SetStausText(false);
                            connectionStatus = false;
                            isClose = false;
                            fileSocketSend.Close();
                            fileSocketSend.Dispose();
                            GC.Collect();
                            break;
                        }
                        if (dataBuffer != null) {
                            int dataLength = fileSocketSend.Receive(dataBuffer);
                            if (dataLength >= BitConverter.ToInt32(buffer, 0)) {
                                try {
                                    var stream = new MemoryStream(dataBuffer);
                                    stream.Seek(0, SeekOrigin.Begin);
                                    var image = Image.FromStream(stream);

                                    RemoteScreenForm.RemoteScreenFormUI.SetScreenImage(image);
                                    MainInterface.MainInterfaceUi.SetRemoteScreen(image);
                                    GC.Collect();
                                    
                                } catch (Exception ex) {
                                    MainInterface.MainInterfaceUi.richResultsOfEnforcementAppendText(new RichTextBoxStyle("远程画面连接发生错误：" + ex, Color.Red, true));
                                }
                            }
                        }
                        if (isClose) {
                            MainInterface.MainInterfaceUi.richResultsOfEnforcementAppendText(new RichTextBoxStyle("与：" + fileSocketSend.RemoteEndPoint + "的远程画面断开了连接！", Color.Red, true));
                            MainInterface.MainInterfaceUi.SetStausText(false);
                            connectionStatus = false;
                            isClose = false;
                            fileSocketSend.Close();
                            fileSocketSend.Dispose();
                            GC.Collect();
                            break;
                        }
                    }
                } catch (Exception ex) {
                    isClose = false;
                    connectionStatus = false;
                    MainInterface.MainInterfaceUi.SetStausText(false);
            
                    MainInterface.MainInterfaceUi.richResultsOfEnforcementAppendText(new RichTextBoxStyle("尝试连接" + this.iP + "的画面时发生错误" + ex.Message, Color.Red, true));
                    GC.Collect();
                }
            });
            task.Start();

        }
        public void CloseRemoteScreen() {
            isClose = true;
        }
    }
}
