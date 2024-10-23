using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCPServer;

namespace TCPConsole {
    public partial class ShowRemoteFile : Form {
        private System.Windows.Forms.Timer debounceTimer = new System.Windows.Forms.Timer();
        private bool isResizing = false;


        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern void SetWindowTheme(IntPtr hWnd, string appId, string classId);


        private RemoteFileTools remoteFileTools = null;

        string ip = string.Empty;

        int port = -1;
        #region 调整条状态数据

        private bool isDragging = false;
        private Point resizeStartPoint;
        private int originalWidth;

        #endregion
        /// <summary>
        /// 命令执行配置器
        /// </summary>
        private CommandExecutionConfiguration commandExecutionConfiguration = new CommandExecutionConfiguration();
        /// <summary>
        /// 命令执行器
        /// </summary>
        private CommandExecutor commandExecutor = null;
        /// <summary>
        /// 鼠标右键时选中的元素
        /// </summary>
        private ListViewItem clickedItem = null;
        public ShowRemoteFile(RemoteFileTools remoteFileTools, string ip, int port, CommandExecutionConfiguration commandExecutionConfiguration, ref CommandExecutor commandExecutor) {
            InitializeComponent();
            //拿到父命令配置器中的地址和端口
            this.commandExecutionConfiguration.Address = commandExecutionConfiguration.Address;
            this.commandExecutionConfiguration.Port = commandExecutionConfiguration.Port;
            this.commandExecutor = commandExecutor;

            debounceTimer.Interval = 500; // 设置延迟时间，以毫秒为单位
            debounceTimer.Tick += DebounceTimer_Tick;


            this.remoteFileTools = remoteFileTools;
            this.ip = ip;
            this.port = port;
            if (remoteFileTools.Connect(ip, port)) {
                Task.Run(() => {
                    while (true) {
                        try {
                            FileNodeInfoData fileNodeInfoDatas = remoteFileTools.GetNodeInfo();

                            if (fileNodeInfoDatas.FileSystemOrFile) {//文件系统信息
                                DiskInfoData[] diskInfoDatas = fileNodeInfoDatas.FileSystemNode;
                                foreach (var diskInfoData in diskInfoDatas) {
                                    if (diskInfoData != null) {
                                        Console.WriteLine(diskInfoData.DiskName);
                                    }
                                }
                                DrawTreeViewNode(diskInfoDatas);
                            } else {
                                FileInfoData[] fileInfos = fileNodeInfoDatas.FileInfoDatas;
                                ListViewFileListView.Items.Clear();
                                Console.WriteLine("文件总个数：" + fileInfos.Length);
                                foreach (FileInfoData fileInfo in fileInfos) {
                                    Console.WriteLine(fileInfo.FilePath);
                                    Console.WriteLine(fileInfo.FileSize);
                                }
                                DrawFileView(fileInfos);
                            }

                        } catch (Exception ex) {
                            MainInterface.MainInterfaceUi.richResultsOfEnforcementAppendText(new RichTextBoxStyle(ex.ToString(), Color.Red, true));
                        }

                    }
                });
                ExecuteFileCommand("/diskInfo");
                ExecuteFileCommand("/cd ./");
            }
        }
        /// <summary>
        /// 传入一个fileinfodata，把文件中的数据画在页面中
        /// </summary>
        /// <param name="fileInfoData"></param>
        public void DrawFileView(FileInfoData[] fileInfoDatas) {
            //更新数据，挂起UI更新
            ListViewFileListView.BeginUpdate();
            AutoResizeListViewColumns(this.ListViewFileListView);
            // 在方法中使用  Explorer是固定的，设为它的样式
            SetWindowTheme(this.ListViewFileListView.Handle, "Explorer", null);
            SetWindowTheme(this.TreeViewFileTreeView.Handle, "Explorer", null);
            //创建回退目录元素
            ListViewItem listViewItemBakc = new ListViewItem();
            listViewItemBakc.SubItems[0].Text = "..";
            listViewItemBakc.SubItems.Add("0");
            ListViewFileListView.Items.Add(listViewItemBakc);

            foreach (FileInfoData fileInfoData in fileInfoDatas) {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.SubItems[0].Text = fileInfoData.FilePath;
                listViewItem.SubItems.Add(fileInfoData.FileSize + "");
                if (fileInfoData.FileType) {//判断文件类型
                    listViewItem.SubItems.Add(FileInfoData.FILE_TYPE_DIR);//文件夹
                } else {
                    listViewItem.SubItems.Add(FileInfoData.FILE_TYPE_FILE);//文件
                }
                ListViewFileListView.Items.Add(listViewItem);
            }

            ListViewFileListView.EndUpdate();
        }
        /// <summary>
        /// 执行文件操作相关的命令
        /// </summary>
        /// <param name="Command">命令</param>
        private void ExecuteFileCommand(String Command) {
            //修改命令配置器，设置命令为查看当前目录内容
            commandExecutionConfiguration.Address = this.ip;
            commandExecutionConfiguration.IsItLocal = false;
            commandExecutionConfiguration.IsSendFile = false;
            commandExecutionConfiguration.Command = Command;
            commandExecutionConfiguration.Frequency = 1;
            commandExecutor.Execute(commandExecutionConfiguration);
        }
        /// <summary>
        /// ListViewFileListViewItem双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewFileListView_ItemActivate(object sender, EventArgs e) {

            // 获取双击的ListView项
            System.Windows.Forms.ListView listView = (System.Windows.Forms.ListView)sender;
            if (listView.SelectedItems.Count > 0) {
                ListViewItem selectedItem = listView.SelectedItems[0];

                // 执行与双击的ListView项相关的操作
                string column1Value = selectedItem.SubItems[0].Text;
                string column2Value = selectedItem.SubItems[1].Text;
                ExecuteFileCommand("/cd " + column1Value);
            }
        }
        private void ListViewFileListView_ColumnClick(object sender, ColumnClickEventArgs e) {
            AutoResizeListViewColumns(this.ListViewFileListView);


        }
        /// <summary>
        /// 窗体大小改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewFileListView_Resize(object sender, EventArgs e) {
            if (!isResizing) {
                isResizing = true;
                debounceTimer.Start();
            }
        }
        /// <summary>
        /// 防抖函数，避免大量的窗体改变事件触发AutoResizeListViewColumns函数，造成页面卡顿
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DebounceTimer_Tick(object sender, EventArgs e) {
            // 防抖时间到达后，停止Timer并重新计算列宽度
            debounceTimer.Stop();
            isResizing = false;
            AutoResizeListViewColumns(this.ListViewFileListView);
        }
        /// <summary>
        /// 根据窗体大小计算ListView的每一列宽度
        /// </summary>
        /// <param name="listView">需要更改的ListView</param>
        private void AutoResizeListViewColumns(ListView listView) {
            int totalColumnWidth = 0;

            // 计算所有列的总宽度
            foreach (ColumnHeader column in listView.Columns) {
                totalColumnWidth += column.Width;
            }
            // 计算ListView控件的可用宽度（减去边距等）
            int availableWidth = listView.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;
            // 根据可用宽度重新计算每一列的宽度
            foreach (ColumnHeader column in listView.Columns) {
                double columnPercentage = (double)column.Width / totalColumnWidth;
                int newColumnWidth = (int)(availableWidth * columnPercentage);
                column.Width = newColumnWidth;
            }
        }

        /// <summary>
        /// 鼠标弹起事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewFileListView_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right && ListViewFileListView.FocusedItem != null) {
                // 获取右键单击的ListView项
                this.clickedItem = ListViewFileListView.FocusedItem;
                // 在ListView上下文菜单的位置显示上下文菜单
                contextMenuStrip.Show(ListViewFileListView, e.Location);
            }
        }
        #region 右键菜单元素点击事件处理
        /// <summary>
        /// 删除元素点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e) {
            // 执行操作1，可以根据需要自定义
            if (this.clickedItem != null) {
                //基准命令
                String datumCommand = "del /F /Q ";
                //判断选中的内容是否为文件夹,因为删除文件夹和删除文件的命令不一致
                if (clickedItem.SubItems[2].Text.Equals(FileInfoData.FILE_TYPE_DIR)) {//文件夹
                    datumCommand = "rmdir /S /Q ";
                }
                //执行删除命令
                ExecuteFileCommand(datumCommand + "\"" + this.clickedItem.SubItems[0].Text + "\"");
                //执行命令刷新数据
                ExecuteFileCommand("/cd .");
            }
        }
        /// <summary>
        /// 下载元素点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownLoadToolStripMenuItem_Click(object sender, EventArgs e) {
            // 执行操作2，可以根据需要自定义
            if (this.clickedItem != null) {
                MessageBox.Show($"操作2：{clickedItem.SubItems[0].Text}");
            }
        }
        /// <summary>
        /// 重命名元素点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReNameToolStripMenuItem_Click(object sender, EventArgs e) {
            if (this.clickedItem != null) {
                MessageBox.Show($"操作3：{clickedItem.SubItems[0].Text}");
            }
        }
        #endregion
        #region 左边树结构渲染
        /// <summary>
        /// 将文件路径转化为TreeNode节点
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        private TreeNode[] ConvertFilePathToTreeNodes(string path) {
            //分割路径
            string[] pathParts = path.Split(Path.DirectorySeparatorChar);
            //节点对象数组
            TreeNode[] treeNodes = new TreeNode[pathParts.Length];
            TreeNode currentNode = null;
            for (int i = 0; i < pathParts.Length; i++) {
                TreeNode node = new TreeNode(pathParts[i]);
                if (currentNode == null) {
                    treeNodes[i] = node;
                    currentNode = node;
                } else {
                    currentNode.Nodes.Add(node);
                    currentNode = node;
                }
            }
            return treeNodes;
        }
        /// <summary>
        /// 获取节点数据
        /// </summary>
        /// <param name="Node"></param>
        /// <returns>该节点中的所有数据</returns>
        private FileInfoData[] GetNodeData(TreeNode Node) {
            return new FileInfoData[0];
        }
        /// <summary>
        /// 将节点数组的内容渲染在TreeView中
        /// </summary>
        private void DrawTreeViewNode(DiskInfoData[] nodes) {
            foreach (var item in nodes) {
                if (item != null) {
                    TreeNode treeNode = new TreeNode(item.DiskName);
                    TreeViewFileTreeView.Invoke(new Action(() => {
                        TreeViewFileTreeView.Nodes.Add(treeNode);
                    }));
                    TreeViewFileTreeView.Invoke(new Action(() => {

                        AddTreeViewNode(treeNode, new TreeNode("000"));
                    }));
                }
            }
        }
        /// <summary>
        /// 在目标节点中添加子节点
        /// </summary>
        /// <param name="targetNode">目标节点</param>
        /// <param name="newNode">子节点</param>
        private void AddTreeViewNode(TreeNode targetNode, TreeNode newNode) {
            if (targetNode != null && newNode != null) {
                targetNode.Nodes.Add(newNode);
            }
        }
        #endregion
        #region 实现两个panel面板拖动改变大小
        private void AdjustmentBar_MouseDown(object sender, MouseEventArgs e) {
            isDragging = true;
        }
        private void AdjustmentBar_MouseMove(object sender, MouseEventArgs e) {
            if (isDragging) {
                if ((AdjustmentBar.Location.X < 50 && e.X < 0) || (AdjustmentBar.Location.X > this.Width - 50 && e.X > 0)) {
                    return;
                }
                AdjustmentBar.SetBounds(AdjustmentBar.Location.X + e.X, AdjustmentBar.Location.Y, AdjustmentBar.Width, AdjustmentBar.Height);
                if (AdjustmentBar.Location.X < 50) {
                    AdjustmentBar.SetBounds(50, AdjustmentBar.Location.Y, AdjustmentBar.Width, AdjustmentBar.Height);
                }
                if (AdjustmentBar.Location.X > this.Width - 50) {
                    AdjustmentBar.SetBounds(this.Width - 50, AdjustmentBar.Location.Y, AdjustmentBar.Width, AdjustmentBar.Height);
                }
            }
        }
        private void AdjustmentBar_MouseUp(object sender, MouseEventArgs e) {
            isDragging = false;

            //修改两个view的宽度
            TreeViewFileTreeView.SetBounds(TreeViewFileTreeView.Location.X, TreeViewFileTreeView.Location.Y,
                AdjustmentBar.Location.X, TreeViewFileTreeView.Height);
            ListViewFileListView.SetBounds(AdjustmentBar.Location.X + AdjustmentBar.Width, ListViewFileListView.Location.Y,
               this.Width - AdjustmentBar.Width - TreeViewFileTreeView.Width, ListViewFileListView.Height);
        }

        #endregion

        
    }
}
