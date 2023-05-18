using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCPConsole {
    public partial class RemoteScreenForm : Form {



        //当前窗体的静态实例
        public static RemoteScreenForm RemoteScreenFormUI;
        public RemoteScreenForm() {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            RemoteScreenFormUI = this;
        }
        //当前窗体关闭事件
        private void RemoteScreenForm_FormClosing(object sender, FormClosingEventArgs e) {
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Normal;

            this.Visible = false;
            e.Cancel = true;
        }
        public void SetScreenImage(Image image) {
            if (this.Visible && image != null) {
                if (pictureBoxShowRemoteScreen.InvokeRequired) {
                    // 当一个控件的InvokeRequired属性值为真时，说明有一个创建它以外的线程想访问它
                    Action<Image> actionDelegate = (x) => {
                        this.pictureBoxShowRemoteScreen.Image = x;
                    };
                    this.pictureBoxShowRemoteScreen.Invoke(actionDelegate, image);
                } else {
                    this.pictureBoxShowRemoteScreen.Image = image;
                }
            }
        }
        public void Show(String title) {
            base.Show();
            this.Text = title;
        }
        public void Show(bool isFullScreen) {
            base.Show();
            if (isFullScreen) {
                this.FormBorderStyle = FormBorderStyle.None;     //设置窗体为无边框样式
                this.WindowState = FormWindowState.Maximized;    //最大化窗体 
            }
        }
        //按键监听
        private void RemoteScreenForm_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                if (this.FormBorderStyle == FormBorderStyle.None || this.WindowState == FormWindowState.Maximized) {
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                    this.WindowState = FormWindowState.Normal;
                } else {
                    this.Close();
                }
            }
            //监听F键或者F11键
            if (e.KeyCode == Keys.F || e.KeyCode == Keys.F11 || e.KeyCode == Keys.Enter) {

                //判断是否是全屏状态
                if (this.FormBorderStyle == FormBorderStyle.None || this.WindowState == FormWindowState.Maximized) {
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                    this.WindowState = FormWindowState.Normal;
                } else {
                    this.FormBorderStyle = FormBorderStyle.None;     //设置窗体为无边框样式
                    this.WindowState = FormWindowState.Maximized;    //最大化窗体 
                }
            }
        }
    }
}
