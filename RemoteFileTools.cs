using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using TCPServer;

namespace TCPConsole {
    public class RemoteFileTools {
        //Socket列表
        List<Socket> socketsList = new List<Socket>();
        //ip列表
        List<string> ipList = new List<string>();
        //端口列表
        List<int> portList = new List<int>();
        //本次使用的Socket
        Socket socket = null;
        public bool Connect(String ip, int port) {
            if (DoesItExist(ip, port)) {
                socket = GetSocket(ip);
            } else {
                try {
                    //创建一个socket连接
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket.Connect(ip, port);
                    socketsList.Add(socket);
                } catch {
                    Console.WriteLine("连接失败");
                    return false;
                }
            }
            if (socket == null) {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 判断ip与port的组合是否存在列表
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="Port"></param>
        /// <returns>true 存在，false不存在</returns>
        public bool DoesItExist(String ip, int port) {
            if (this.ipList.Exists(t => t == ip) && this.portList.Exists(t => t == port)) {
                return true;
            }
            return false;

        }
        public Socket GetSocket(String ip) {
            return null;
        }
        public FileInfoData[] GetFileInfo() {
            return GetNodeInfo().FileInfoDatas;
        }
        public DiskInfoData[] GetDiskInfos() {
            return GetNodeInfo().FileSystemNode;
        }
        public FileNodeInfoData GetNodeInfo() {
            NetworkStream networkStream = new NetworkStream(socket);
            byte[] bytes = new byte[40960000];
            int bytesRead = networkStream.Read(bytes, 0, bytes.Length);
            string receivedData = Encoding.UTF8.GetString(bytes, 0, bytesRead);
            FileNodeInfoData deserializedFileInfoData = JsonConvert.DeserializeObject<FileNodeInfoData>(receivedData);
            return deserializedFileInfoData;
        }
    }
}
