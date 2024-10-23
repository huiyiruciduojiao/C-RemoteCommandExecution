using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPConsole {
    [Serializable]
    public class DiskInfoData {
        /// <summary>
        /// 磁盘可用空间
        /// </summary>
        public long DiskTotalFreeSpace {
            get; set;
        }
        /// <summary>
        /// 磁盘总空间
        /// </summary>
        public long DiskTotalSize {
            get; set;
        }
        /// <summary>
        /// 磁盘名字，盘符
        /// </summary>
        public String DiskName {
            get; set;
        }
        /// <summary>
        /// 磁盘类型
        /// </summary>
        public String DiskType {
            get; set;
        }
        /// <summary>
        /// 磁盘格式
        /// </summary>
        public String DiskFormat {
            get; set;
        }
    }
}
