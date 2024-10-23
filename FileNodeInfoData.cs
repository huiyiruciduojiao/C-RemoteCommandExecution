using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPServer;

namespace TCPConsole {
    [Serializable]
    public class FileNodeInfoData {
        //文件数据
        public FileInfoData[] FileInfoDatas {
            get; set;
        }
        /// <summary>
        /// 保存的文件系统节点数据——或者叫根节点数据
        /// </summary>
        public DiskInfoData[] FileSystemNode {
            get; set;
        }
        /// <summary>
        /// 标识对象保存数据是文件节点数据还是文件系统数据
        /// </summary>
        public bool FileSystemOrFile {
            get; set;
        }
    }
}
