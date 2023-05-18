namespace TCPConsole {
    partial class Preferences {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Preferences));
            this.preservationButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.otherTabPage = new System.Windows.Forms.TabPage();
            this.routineTabPage = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxDefaultRemoteSaveAddress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxDefaultFileSendProt = new System.Windows.Forms.TextBox();
            this.textBoxDefaultFileSendAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownResultMaxRows = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDefaultFontSize = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDefaultCommandFrequency = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDefaultCommandPort = new System.Windows.Forms.TextBox();
            this.textBoxDefaultCommandAddress = new System.Windows.Forms.TextBox();
            this.labelDefaultCommandIP = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxDefaultRemoteScreenPort = new System.Windows.Forms.TextBox();
            this.textBoxDefaultRemoteScreenAddress = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.routineTabPage.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownResultMaxRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDefaultFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDefaultCommandFrequency)).BeginInit();
            this.tabControl.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // preservationButton
            // 
            this.preservationButton.Location = new System.Drawing.Point(290, 555);
            this.preservationButton.Name = "preservationButton";
            this.preservationButton.Size = new System.Drawing.Size(75, 23);
            this.preservationButton.TabIndex = 1;
            this.preservationButton.Text = "保存设置";
            this.preservationButton.UseVisualStyleBackColor = true;
            this.preservationButton.Click += new System.EventHandler(this.preservationButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(102, 555);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 3;
            this.resetButton.Text = "重置设置";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // otherTabPage
            // 
            this.otherTabPage.Location = new System.Drawing.Point(4, 29);
            this.otherTabPage.Name = "otherTabPage";
            this.otherTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.otherTabPage.Size = new System.Drawing.Size(367, 517);
            this.otherTabPage.TabIndex = 2;
            this.otherTabPage.Text = "其他";
            this.otherTabPage.UseVisualStyleBackColor = true;
            // 
            // routineTabPage
            // 
            this.routineTabPage.Controls.Add(this.groupBox3);
            this.routineTabPage.Controls.Add(this.groupBox2);
            this.routineTabPage.Controls.Add(this.groupBox1);
            this.routineTabPage.Location = new System.Drawing.Point(4, 29);
            this.routineTabPage.Name = "routineTabPage";
            this.routineTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.routineTabPage.Size = new System.Drawing.Size(367, 517);
            this.routineTabPage.TabIndex = 0;
            this.routineTabPage.Text = "常规";
            this.routineTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxDefaultRemoteSaveAddress);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBoxDefaultFileSendProt);
            this.groupBox2.Controls.Add(this.textBoxDefaultFileSendAddress);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(4, 203);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(357, 132);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "文件域";
            // 
            // textBoxDefaultRemoteSaveAddress
            // 
            this.textBoxDefaultRemoteSaveAddress.Location = new System.Drawing.Point(112, 72);
            this.textBoxDefaultRemoteSaveAddress.Name = "textBoxDefaultRemoteSaveAddress";
            this.textBoxDefaultRemoteSaveAddress.Size = new System.Drawing.Size(239, 23);
            this.textBoxDefaultRemoteSaveAddress.TabIndex = 16;
            this.textBoxDefaultRemoteSaveAddress.TextChanged += new System.EventHandler(this.textBoxDefaultRemoteSaveAddress_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "默认保存位置:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "默认发送端口:";
            // 
            // textBoxDefaultFileSendProt
            // 
            this.textBoxDefaultFileSendProt.Location = new System.Drawing.Point(112, 45);
            this.textBoxDefaultFileSendProt.Name = "textBoxDefaultFileSendProt";
            this.textBoxDefaultFileSendProt.Size = new System.Drawing.Size(239, 23);
            this.textBoxDefaultFileSendProt.TabIndex = 13;
            this.textBoxDefaultFileSendProt.TextChanged += new System.EventHandler(this.textBoxDefaultFileSendProt_TextChanged);
            // 
            // textBoxDefaultFileSendAddress
            // 
            this.textBoxDefaultFileSendAddress.Location = new System.Drawing.Point(112, 16);
            this.textBoxDefaultFileSendAddress.Name = "textBoxDefaultFileSendAddress";
            this.textBoxDefaultFileSendAddress.Size = new System.Drawing.Size(239, 23);
            this.textBoxDefaultFileSendAddress.TabIndex = 12;
            this.textBoxDefaultFileSendAddress.TextChanged += new System.EventHandler(this.textBoxDefaultFileSendAddress_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "默认发送地址:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numericUpDownResultMaxRows);
            this.groupBox1.Controls.Add(this.numericUpDownDefaultFontSize);
            this.groupBox1.Controls.Add(this.numericUpDownDefaultCommandFrequency);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxDefaultCommandPort);
            this.groupBox1.Controls.Add(this.textBoxDefaultCommandAddress);
            this.groupBox1.Controls.Add(this.labelDefaultCommandIP);
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(357, 191);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "命令域";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "结果最大显示行数(0-9999999):";
            // 
            // numericUpDownResultMaxRows
            // 
            this.numericUpDownResultMaxRows.Location = new System.Drawing.Point(231, 136);
            this.numericUpDownResultMaxRows.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numericUpDownResultMaxRows.Name = "numericUpDownResultMaxRows";
            this.numericUpDownResultMaxRows.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownResultMaxRows.TabIndex = 10;
            this.numericUpDownResultMaxRows.ValueChanged += new System.EventHandler(this.numericUpDownResultMaxRows_ValueChanged);
            // 
            // numericUpDownDefaultFontSize
            // 
            this.numericUpDownDefaultFontSize.Location = new System.Drawing.Point(231, 107);
            this.numericUpDownDefaultFontSize.Name = "numericUpDownDefaultFontSize";
            this.numericUpDownDefaultFontSize.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownDefaultFontSize.TabIndex = 9;
            this.numericUpDownDefaultFontSize.ValueChanged += new System.EventHandler(this.numericUpDownDefaultFontSize_ValueChanged);
            // 
            // numericUpDownDefaultCommandFrequency
            // 
            this.numericUpDownDefaultCommandFrequency.Location = new System.Drawing.Point(231, 78);
            this.numericUpDownDefaultCommandFrequency.Name = "numericUpDownDefaultCommandFrequency";
            this.numericUpDownDefaultCommandFrequency.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownDefaultCommandFrequency.TabIndex = 8;
            this.numericUpDownDefaultCommandFrequency.ValueChanged += new System.EventHandler(this.numericUpDownDefaultCommandFrequency_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "默认字体大小:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "默认执行次数:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "默认命令端口:";
            // 
            // textBoxDefaultCommandPort
            // 
            this.textBoxDefaultCommandPort.Location = new System.Drawing.Point(112, 48);
            this.textBoxDefaultCommandPort.Name = "textBoxDefaultCommandPort";
            this.textBoxDefaultCommandPort.Size = new System.Drawing.Size(239, 23);
            this.textBoxDefaultCommandPort.TabIndex = 2;
            this.textBoxDefaultCommandPort.TextChanged += new System.EventHandler(this.textBoxDefaultCommandPort_TextChanged);
            // 
            // textBoxDefaultCommandAddress
            // 
            this.textBoxDefaultCommandAddress.Location = new System.Drawing.Point(112, 19);
            this.textBoxDefaultCommandAddress.Name = "textBoxDefaultCommandAddress";
            this.textBoxDefaultCommandAddress.Size = new System.Drawing.Size(239, 23);
            this.textBoxDefaultCommandAddress.TabIndex = 0;
            this.textBoxDefaultCommandAddress.TextChanged += new System.EventHandler(this.textBoxDefaultCommandAddress_TextChanged);
            // 
            // labelDefaultCommandIP
            // 
            this.labelDefaultCommandIP.AutoSize = true;
            this.labelDefaultCommandIP.Location = new System.Drawing.Point(6, 22);
            this.labelDefaultCommandIP.Name = "labelDefaultCommandIP";
            this.labelDefaultCommandIP.Size = new System.Drawing.Size(83, 17);
            this.labelDefaultCommandIP.TabIndex = 1;
            this.labelDefaultCommandIP.Text = "默认命令地址:";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.routineTabPage);
            this.tabControl.Controls.Add(this.otherTabPage);
            this.tabControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabControl.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl.ItemSize = new System.Drawing.Size(60, 25);
            this.tabControl.Location = new System.Drawing.Point(1, -1);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(0, 0);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(375, 550);
            this.tabControl.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(196, 555);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "取消更改";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.textBoxDefaultRemoteScreenPort);
            this.groupBox3.Controls.Add(this.textBoxDefaultRemoteScreenAddress);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(6, 341);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(357, 97);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "画面域";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 17);
            this.label9.TabIndex = 14;
            this.label9.Text = "默认画面端口:";
            // 
            // textBoxDefaultRemoteScreenPort
            // 
            this.textBoxDefaultRemoteScreenPort.Location = new System.Drawing.Point(112, 45);
            this.textBoxDefaultRemoteScreenPort.Name = "textBoxDefaultRemoteScreenPort";
            this.textBoxDefaultRemoteScreenPort.Size = new System.Drawing.Size(239, 23);
            this.textBoxDefaultRemoteScreenPort.TabIndex = 13;
            this.textBoxDefaultRemoteScreenPort.TextChanged += new System.EventHandler(this.textBoxDefaultRemoteScreenPort_TextChanged);
            // 
            // textBoxDefaultRemoteScreenAddress
            // 
            this.textBoxDefaultRemoteScreenAddress.Location = new System.Drawing.Point(112, 16);
            this.textBoxDefaultRemoteScreenAddress.Name = "textBoxDefaultRemoteScreenAddress";
            this.textBoxDefaultRemoteScreenAddress.Size = new System.Drawing.Size(239, 23);
            this.textBoxDefaultRemoteScreenAddress.TabIndex = 12;
            this.textBoxDefaultRemoteScreenAddress.TextChanged += new System.EventHandler(this.textBoxDefaultRemoteScreenAddress_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 17);
            this.label10.TabIndex = 12;
            this.label10.Text = "默认画面地址:";
            // 
            // Preferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 590);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.preservationButton);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Preferences";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "首选项";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Preferences_FormClosing);
            this.Load += new System.EventHandler(this.Preferences_Load);
            this.routineTabPage.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownResultMaxRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDefaultFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDefaultCommandFrequency)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button preservationButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.TabPage otherTabPage;
        private System.Windows.Forms.TabPage routineTabPage;
        private System.Windows.Forms.TextBox textBoxDefaultCommandAddress;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label labelDefaultCommandIP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDefaultCommandPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownDefaultFontSize;
        private System.Windows.Forms.NumericUpDown numericUpDownDefaultCommandFrequency;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownResultMaxRows;
        private System.Windows.Forms.TextBox textBoxDefaultRemoteSaveAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxDefaultFileSendProt;
        private System.Windows.Forms.TextBox textBoxDefaultFileSendAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxDefaultRemoteScreenPort;
        private System.Windows.Forms.TextBox textBoxDefaultRemoteScreenAddress;
        private System.Windows.Forms.Label label10;
    }
}