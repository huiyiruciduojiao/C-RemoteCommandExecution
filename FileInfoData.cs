using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPServer {
    [Serializable]
    public class FileInfoData {
        public const string FILE_TYPE_FILE = "文件";
        public const string FILE_TYPE_DIR = "文件夹";
        public string FilePath {
            get; set;
        }
        public string FileName {
            get; set;
        }
        public string EditTime {
            get; set;
        }
        public string ReadTime {
            get; set;
        }
        public long FileSize {
            get; set;
        }
        public bool FileType {
            get; set;
        }
    }
}
