using System;
using System.Drawing;
using System.Net;
using System.Text.RegularExpressions;

namespace TCPConsole {
    /// <summary>
    /// 这是一个工具类，用来存放公共工具方法
    /// </summary>
    internal class Tools {
        /// <summary>
        /// 判断一个字符串是否是整数并且这个数字大于零
        /// </summary>
        /// <param name="num">需要判断的字符串</param>
        /// <returns>字符串转换后的值</returns>
        public int IsNum(String num) {
            int temp = -1;
            if (int.TryParse(num, out temp)) {
                return temp;
            } else {
                return -1;
            }
        }
        /// <summary>
        /// 验证字符串是否是域名
        /// </summary>
        /// <param name="str">指定字符串</param>
        /// <returns></returns>
        public bool IsDomain(string str) {
            string pattern = @"^[a-zA-Z0-9][-a-zA-Z0-9]{0,62}(\.[a-zA-Z0-9][-a-zA-Z0-9]{0,62})+$";
            return IsMatch(pattern, str);
        }
        /// <summary>
        /// 判断传入的address是否是一个IP 重载方法 
        /// </summary>
        /// <param name="address">传入一个需要判断的字符串</param>
        /// <returns></returns>
        public bool IsItIP(String address) {
            return Regex.IsMatch(address, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }
        /// <summary>
        /// 判断传入的port是否是一个端口号
        /// </summary>
        /// <param name="port">传入一个需要判断的int值</param>
        /// <returns>true 是端口;false 不是端口</returns>
        public bool IsItPort(int port) {
            if (port >= 0 && port <= 65535) {
                return true;
            } else {
                return false;
            }
        }
        /// <summary>
        /// 判断传入的port是否是一个端口号 重载
        /// </summary>
        /// <param name="port">传入一个需要判断的String值 如果传入的值是一个port 将会将传入的String转换为int,并把转换后的int值添加到当前配置中</param>
        /// <returns>true 是端口;false 不是端口</returns>
        public bool IsItPort(String port) {
            int tempPort = IsNum(port);
            if (tempPort > 0) {
                return IsItPort(tempPort);
            }
            return false;
        }
        /// <summary>
        /// 判断一个字符串，是否匹配指定的表达式(区分大小写的情况下)
        /// </summary>
        /// <param name="expression">正则表达式</param>
        /// <param name="str">要匹配的字符串</param>
        /// <returns></returns>
        public bool IsMatch(string expression, string str) {
            Regex reg = new Regex(expression);
            if (string.IsNullOrEmpty(str))
                return false;
            return reg.IsMatch(str);
        }
        /// <summary>
        /// 域名解析
        /// </summary>
        /// <param name="Domain">需要解析的域名</param>
        /// <returns>返回一个IPAddress数组</returns>
        public IPAddress[] DomainNameResolution(String Domain) {
            IPAddress[] ipHostInfo = null;
            try {
                ipHostInfo = Dns.GetHostAddresses(Domain);
            } catch (Exception e) {
                MainInterface.MainInterfaceUi.richResultsOfEnforcementAppendText(new RichTextBoxStyle(e.Message, Color.Red, true));
            }
            return ipHostInfo;
        }
        /// <summary>
        /// 去除字符串中的所有空格
        /// </summary>
        /// <param name="str">需要去空格的字符串</param>
        /// <returns>去除空格后的字符串</returns>
        public String RemoveSpaces(String str) {
            return Regex.Replace(str, @"\s", "");
        }
        /// <summary>
        /// 判断一个字符串是否为空
        /// </summary>
        /// <param name="str">需要判断的字符串</param>
        /// <returns>true 为空，false 不为空</returns>
        public bool ItIsNull(String str) {
            if (str != null && str != "") {
                return false;
            } else {
                return true;
            }
        }
        /// <summary>
        /// 判断一个字符串是否为空
        /// </summary>
        /// <param name="str">需要判断的字符串</param>
        /// <param name="removeSpaces">是否需要在判断前去空格处理 true 需要，false 不需要</param>
        /// <returns>true 为空，false 不为空</returns>
        public bool ItIsNull(String str, bool removeSpaces) {
            if (removeSpaces) {
                str = RemoveSpaces(str);
            }
            return ItIsNull(str);
        }
        /// <summary>
        /// 判断一个命令是否在本地执行 
        /// </summary>
        /// <param name="cmd">需要判断的命令 </param>
        /// <returns>true 是 ，false 否，在远程执行</returns>
        public bool WhetherToExecuteLocally(ref String cmd) {
            if (WhetherToExecuteLocally(cmd)) {
                //满足条件，由于使用ref 关键字传入参数，需要将命令中的标识文字去掉
                cmd = cmd.Remove(0, 1);
                return true;
            } else {
                return false;
            }
        }
        public bool WhetherToExecuteLocally(String cmd) {
            if (cmd != null && (cmd.Substring(0, 1).Equals("!") || cmd.Substring(0, 1).Equals("！"))) {
                return true;
            } else {
                return false;
            }
        }
        /// <summary>
        /// 判断一个字符串是否是一个路径
        /// </summary>
        /// <param name="path">需要判断的字符串</param>
        /// <returns>true 是一个地址 false 不是一个地址</returns>
        public bool IsPath(String path) {
            if (path == null) {
                return false;
            }
            Regex regex = new Regex(@"^([a-zA-Z]:\\)([-\u4e00-\u9fa5\w\s.()~!@#$%^&()\[\]{}+=]+\\?)*$");
            Match result = regex.Match(path);
            return result.Success;
        }
        // <summary>
        /// 计算文件大小函数(保留两位小数),Size为字节大小
        /// </summary>
        /// <param name="Size">初始文件大小</param>
        /// <returns></returns>
        public static string CountSize(long Size) {
            string m_strSize = "";
            long FactSize = 0;
            FactSize = Size;
            if (FactSize < 1024.00)
                m_strSize = FactSize.ToString("F2") + " Byte";
            else if (FactSize >= 1024.00 && FactSize < 1048576)
                m_strSize = (FactSize / 1024.00).ToString("F2") + " K";
            else if (FactSize >= 1048576 && FactSize < 1073741824)
                m_strSize = (FactSize / 1024.00 / 1024.00).ToString("F2") + " M";
            else if (FactSize >= 1073741824)
                m_strSize = (FactSize / 1024.00 / 1024.00 / 1024.00).ToString("F2") + " G";
            return m_strSize;
        }
    }
}
