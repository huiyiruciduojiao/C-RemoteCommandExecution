using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TCPConsole {
    internal static class Program {
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main() {
            AllocConsole();
            Console.WriteLine("????");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainInterface());
        }
    }
}
