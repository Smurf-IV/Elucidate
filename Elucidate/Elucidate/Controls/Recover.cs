using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Elucidate.Logging;

namespace Elucidate.Controls
{
    public partial class Recover : UserControl
    {
        private int _nodeCheckCount;
        private readonly List<string> _batchPaths = new List<string>();

        public Recover()
        {
            InitializeComponent();
            liveRunLogControl.HideAdditionalCommands();
            SetButtonsEnabledState();
            liveRunLogControl.ActionWorker.RunWorkerCompleted += liveRunLogControl_RunWorkerCompleted;
        }

        private void liveRunLogControl_RunWorkerCompleted(object sender, EventArgs e) => SetButtonsEnabledState();

        private void SetButtonsEnabledState()
        {
            lock (treeView1)
            {
                if (liveRunLogControl.IsRunning)
                {
                    btnLoadFiles.Enabled = false;
                    btnRecoverFiles.Enabled = false;
                    btnClearFiles.Enabled = false;
                }
                else
                {
                    btnLoadFiles.Enabled = true;
                    btnRecoverFiles.Enabled = treeView1.Nodes.Count - _nodeCheckCount > 0;
                    btnClearFiles.Enabled = treeView1.Nodes.Count > 0;
                }
            }
        }

        private void Recover_Load(object sender, EventArgs e)
        {
            timerTreeViewFill.Enabled = false;
            timerTreeViewRecover.Enabled = false;
            splitContainer1.SplitterDistance = (int)(splitContainer1.Height * 0.8);
        }

        private void Recover_Resize(object sender, EventArgs e)
        {
            treeView1.Width = tableLayoutPanel1.Width;
        }

        // Return a list of the TreeNodes that are checked.
        private void FindCheckedNodes(List<TreeNode> checkedNodes, TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                // Add this node.
                if (node.Checked) checkedNodes.Add(node);

                // Check the node's descendants.
                FindCheckedNodes(checkedNodes, node.Nodes);
            }
        }

        // Return a lst of the checked TreeView nodes.
        private List<TreeNode> CheckedNodes(TreeView trv)
        {
            List<TreeNode> checkedNodes = new List<TreeNode>();
            FindCheckedNodes(checkedNodes, trv.Nodes);
            return checkedNodes;
        }

        private void timerTreeViewFill_Tick(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        while (LiveLog.LogQueueRecover.Any())
                        {
                            LiveLog.LogString log = LiveLog.LogQueueRecover.Dequeue();
                            if (!log.Message.Contains("recoverable \"")) continue;
                            string filePath = log.Message.Split('"')[1];
                            //if (filePath.Substring(1, 1) != ":") continue;
                            treeView1.Invoke(new Action(() => treeView1.Nodes.Add($"/{filePath}", $"/{filePath}")));
                            //Thread thread1 = new Thread(() => thr.AddNode($"/{filePath}"));
                            //thread1.Start();
                        }
                    }

                    if (!liveRunLogControl.ActionWorker.IsBusy && !LiveLog.LogQueueRecover.Any())
                    {
                        SetButtonsEnabledState();
                        timerTreeViewFill.Enabled = false;
                    }
                }
            }
            catch
            {
                // ignored
            }
        }

        private void timerTreeViewRecover_Tick(object sender, EventArgs e)
        {
            try
            {
                // Now lock in case the timer is overlapping !
                lock (this)
                {
                    //read out of the file until the EOF
                    while (LiveLog.LogQueueRecover.Any())
                    {
                        LiveLog.LogString log = LiveLog.LogQueueRecover.Dequeue();
                        if (!log.Message.Contains("recovered \"")) continue;
                        string filePath = log.Message.Split('"')[1];
                        TreeNode[] node = treeView1.Nodes.Find($"/{filePath}", false);
                        if (node.Length <= 0) continue;
                        node[0].Text = $@"{node[0].Name} (RECOVERED)";
                        node[0].BackColor = Color.Green;
                    }

                    if (!liveRunLogControl.ActionWorker.IsBusy && !LiveLog.LogQueueRecover.Any())
                    {
                        //SetRecoveryButtonEnableState();
                        timerTreeViewRecover.Enabled = false;
                    }
                }
            }
            catch
            {
                // ignored
            }
        }
        
        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (!(e.Node is TreeNode treeNode)) return;
            if (treeNode.BackColor == Color.Green) { return; }
            SetNodeColor(treeNode);
            if (treeNode.Checked)
            {
                _nodeCheckCount++;
            }
            else
            {
                _nodeCheckCount--;
            }
        }

        private void SetNodeColor(TreeNode treeNode)
        {
            treeNode.BackColor = treeNode.Checked ? Color.Aqua : Color.Empty;
        }

        private void ToggleNodeCheckbox(TreeNode treeNode)
        {
            treeNode.Checked = !treeNode.Checked;
        }

        private void UncheckAll(TreeView treeView)
        {
            for (int i = 0; i < treeView.Nodes.Count; i++)
            {
                treeView.Nodes[i].Checked = false;
            }
            _nodeCheckCount = 0;
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (!(e.Node is TreeNode treeNode)) return;
            ToggleNodeCheckbox(treeNode);
        }

        private void btnLoadFiles_Click(object sender, EventArgs e)
        {
            lock (treeView1)
            {
                SetButtonsEnabledState();
                // run only if app is not already running an operation
                // replace mlog method with ours
                treeView1.Nodes.Clear();
                timerTreeViewFill.Enabled = true;
                liveRunLogControl.StartSnapRaidProcess(LiveRunLogControl.CommandType.RecoverCheck);
            }
        }

        private void btnRecoverFiles_Click(object sender, EventArgs e)
        {
            lock (treeView1)
            {
                SetButtonsEnabledState();
                if (_nodeCheckCount == 0)
                {
                    UncheckAll(treeView1);
                    return;
                }

                // Get the checked nodes.
                List<TreeNode> checkedNodes = CheckedNodes(treeView1);
                // recover items
                foreach (var node in checkedNodes)
                {
                    if (node.BackColor == Color.Green) continue;
                    _batchPaths.Add(node.FullPath);
                    //paths = new List<string>(paths.OrderBy(p => p.Count(c => c == Path.DirectorySeparatorChar || c == Path.AltDirectorySeparatorChar)));
                }

                UncheckAll(treeView1);
                timerTreeViewRecover.Enabled = true;

                if (!liveRunLogControl.ActionWorker.IsBusy && _batchPaths.Any())
                {
                    liveRunLogControl.StartSnapRaidProcess(LiveRunLogControl.CommandType.RecoverFix, _batchPaths);
                }
            }
        }

        private void btnClearFiles_Click(object sender, EventArgs e)
        {
            lock (treeView1)
            {
                treeView1.Nodes.Clear();
            }
        }
    }
}

#region tree hier code
// sort list of paths
//paths = new List<string>(paths.OrderBy(p => p.Count(c => c == Path.DirectorySeparatorChar || c == Path.AltDirectorySeparatorChar)));
//private void LoadFile(string fileFullName)
//{
//    List<string> items = new List<string>();
//    var filename = new FileInfo(fileFullName).Name;
//    items.Add(filename);
//    do
//    {
//        fileFullName = new DirectoryInfo(fileFullName).Parent?.FullName;
//        if (fileFullName != null) items.Add(new DirectoryInfo(fileFullName).Name);
//    } while (fileFullName != null);

//    foreach (string item in items.AsEnumerable().Reverse())
//    {
//        if (currentNode != null && currentNode.Nodes.ContainsKey(item))
//        {
//            currentNode = currentNode.Nodes.Find(item, true).FirstOrDefault();
//        }
//        else
//        {
//            TreeNode newnode = new TreeNode(item) { Name = item };
//            currentNode.Nodes.Add(newnode);
//            currentNode = newnode;
//        }
//    }

//    //if (treeView1.TopNode == null)
//    //{
//    //    TreeNode root = new TreeNode("Damaged Files");
//    //    treeView1.Nodes.Add(root);
//    //}
//    //TreeNode currentNode = treeView1.TopNode;
//    //foreach (string item in items.AsEnumerable().Reverse())
//    //{
//    //    if (currentNode != null && currentNode.Nodes.ContainsKey(item))
//    //    {
//    //        currentNode = currentNode.Nodes.Find(item, true).FirstOrDefault();
//    //    }
//    //    else
//    //    {
//    //        TreeNode newnode = new TreeNode(item) { Name = item };
//    //        currentNode.Nodes.Add(newnode);
//    //        currentNode = newnode;
//    //    }
//    //}
//}
#endregion