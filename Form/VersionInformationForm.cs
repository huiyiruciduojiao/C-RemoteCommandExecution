using System;
using System.Windows.Forms;

namespace TCPConsole {
    public partial class VersionInformationForm : Form {
        public VersionInformationForm() {
            InitializeComponent();
        }

        private void pictureBoxLogo_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://www.lichuanjiu.top/");
        }

        private void linkLabelURLHome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start("https://www.lichuanjiu.top/");
        }

        private void linkLabelSponsor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start("https://www.lichuanjiu.top/supportOur.php");
        }

    }
}
