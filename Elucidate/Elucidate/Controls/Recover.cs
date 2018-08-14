using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Elucidate.Logging;

namespace Elucidate.Controls
{
    public partial class Recover : UserControl
    {
        public event EventHandler TaskStarted;

        private void OnTaskStarted(EventArgs e)
        {
            EventHandler handler = TaskStarted;
            handler?.Invoke(this, e);
        }

        public event EventHandler TaskCompleted;

        private void OnTaskCompleted(EventArgs e)
        {
            EventHandler handler = TaskCompleted;
            handler?.Invoke(this, e);
        }

        private readonly List<string> _batchPaths = new List<string>();

        public Recover()
        {
            InitializeComponent();

            liveRunLogControl.HideAdditionalCommands();
            SetButtonsEnabledState();

            liveRunLogControl.HighlightWarnings = false;
            liveRunLogControl.ActionWorker.RunWorkerCompleted += liveRunLogControl_RunWorkerCompleted;
            liveRunLogControl.TaskStarted += LiveRunLogControl_TaskStarted;
            liveRunLogControl.TaskCompleted += LiveRunLogControl_TaskCompleted;
        }

        private void LiveRunLogControl_TaskStarted(object sender, EventArgs e)
        {
            OnTaskStarted(e);
        }

        private void LiveRunLogControl_TaskCompleted(object sender, EventArgs e)
        {
            OnTaskCompleted(e);
        }

        private void liveRunLogControl_RunWorkerCompleted(object sender, EventArgs e) => SetButtonsEnabledState();

        private void SetButtonsEnabledState()
        {
            lock (treeView1)
            {
                if (liveRunLogControl.IsRunning)
                {
                    btnLoadFiles.Enabled = false;
                    btnRecoverSelectedFiles.Enabled = false;
                    btnRecoverAllFiles.Enabled = false;
                    btnClearFiles.Enabled = false;
                }
                else
                {
                    bool countOfFilesRecoverable = CountFilesRecoverable(treeView1) > 0;
                    btnLoadFiles.Enabled = true;
                    btnRecoverSelectedFiles.Enabled = countOfFilesRecoverable;
                    btnRecoverAllFiles.Enabled = countOfFilesRecoverable;
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
            lock (treeView1)
            {
                treeView1.Width = tableLayoutPanel1.Width;
            }
        }

        // Return a list of the TreeNodes that are checked.
        private void FindRecoverableNodes(List<TreeNode> foundNodes, TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                // Add this node.
                if (node.BackColor != Color.Green) foundNodes.Add(node);

                // Check the node's descendants.
                FindCheckedNodes(foundNodes, node.Nodes);
            }
        }

        // Return a list of the TreeNodes that are checked.
        private void FindCheckedNodes(List<TreeNode> checkedNodes, TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                // Add this node.
                if (node.BackColor != Color.Green && node.Checked) checkedNodes.Add(node);

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

        // Return the count of all recoverable files
        private int CountFilesRecoverable(TreeView trv)
        {
            List<TreeNode> foundNodes = new List<TreeNode>();
            FindRecoverableNodes(foundNodes, trv.Nodes);
            return foundNodes.Count;
        }

        // Return the count of recoverable checked files
        // ReSharper disable once UnusedMember.Local
        private int CountFilesChecked(TreeView trv)
        {
            List<TreeNode> foundNodes = new List<TreeNode>();
            FindCheckedNodes(foundNodes, trv.Nodes);
            return foundNodes.Count;
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
                            if (!log.Message.Contains("[recoverable ")) continue; // this is not the line you seek

                            // use regex to parse log line and get the FilePath
                            string regexPattern = @"(?<LogEntryTimestamp>\d\d\d\d-\d\d-\d\d\s\d\d:\d\d:\d\d.\d\d\d\d).*\[recoverable\s(?<FilePath>.*)\].*";
                            Match matches = Regex.Match(log.Message, regexPattern, RegexOptions.Singleline);
                            if (!matches.Success)
                            {
                                // nothing to do, the string did not match regex but it contained "[recoverable ", odd
                                Group logEntryTimestamp = matches.Groups["FilePath"];
                                if (!logEntryTimestamp.Success) return; // paranoid, just check
                                Log.Instance.Error($"Unable to retrieve the recoverable file path from log entry at '{logEntryTimestamp.Value}'");
                                return;
                            }
                            Group groupFilePath = matches.Groups["FilePath"];

                            if (!groupFilePath.Success || string.IsNullOrEmpty(groupFilePath.Value)) return; // nothing to do, path is an empty string
                            string filePath = groupFilePath.Value;
                            treeView1.Invoke(new Action(() => treeView1.Nodes.Add($"/{filePath}", $"/{filePath}")));
                        }
                    }

                    if (liveRunLogControl.ActionWorker.IsBusy || LiveLog.LogQueueRecover.Any()) return; // more items to dequeue

                    SetButtonsEnabledState();
                    timerTreeViewFill.Enabled = false;
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
                        if (!log.Message.Contains("[recovered ")) continue; // this is not the line you seek

                        // use regex to parse log line and get the FilePath
                        string regexPattern = @"(?<LogEntryTimestamp>\d\d\d\d-\d\d-\d\d\s\d\d:\d\d:\d\d.\d\d\d\d).*\[recovered\s(?<FilePath>.*)\].*";
                        Match matches = Regex.Match(log.Message, regexPattern, RegexOptions.Singleline);
                        if (!matches.Success)
                        {
                            // nothing to do, the string did not match regex but it contained "[recoverable ", odd
                            Group logEntryTimestamp = matches.Groups["FilePath"];
                            if (!logEntryTimestamp.Success) return; // paranoid, just check
                            Log.Instance.Error($"Unable to retrieve the recovered file path from log entry at '{logEntryTimestamp.Value}'");
                            return;
                        }
                        Group groupFilePath = matches.Groups["FilePath"];
                        if (!groupFilePath.Success || string.IsNullOrEmpty(groupFilePath.Value)) return; // nothing to do, path is an empty string
                        string filePath = groupFilePath.Value;

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
            SetChildrenChecked(e.Node, e.Node.Checked);
        }

        private void SetChildrenChecked(TreeNode treeNode, bool checkedState)
        {
            // do not change nodes already recovered
            if (treeNode.BackColor == Color.Green) { return; }

            SetNodeColor(treeNode);

            foreach (TreeNode item in treeNode.Nodes)
            {
                if (item.Checked != checkedState)
                {
                    item.Checked = checkedState;
                }

                SetChildrenChecked(item, item.Checked);
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
        }

        private void CheckAll(TreeView treeView)
        {
            for (int i = 0; i < treeView.Nodes.Count; i++)
            {
                treeView.Nodes[i].Checked = true;
            }
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

        private void btnRecoverSelectedFiles_Click(object sender, EventArgs e)
        {
            lock (treeView1)
            {
                SetButtonsEnabledState();

                // Get the checked nodes eligible to be recovered
                List<TreeNode> checkedNodes = CheckedNodes(treeView1);

                if (checkedNodes.Count == 0)
                {
                    // only nodes show nas green are selected so deselect all
                    UncheckAll(treeView1);
                    return;
                }

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

        private void btnRecoverAllFiles_Click(object sender, EventArgs e)
        {
            lock (treeView1)
            {
                CheckAll(treeView1);

                btnRecoverSelectedFiles_Click(sender, e);
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            e.Node.Checked = !e.Node.Checked;
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