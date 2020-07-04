#region Copyright (C)
// ---------------------------------------------------------------------------------------------------------------
//  <copyright file="Recover.cs" company="Smurf-IV">
// 
//  Copyright (C) 2010-2020 Simon Coghlan (Aka Smurf-IV) & BlueBlock 2018
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 2 of the License, or
//   any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program. If not, see http://www.gnu.org/licenses/.
//  </copyright>
//  <summary>
//  Url: https://github.com/Smurf-IV/Elucidate
//  Email: https://github.com/Smurf-IV
//  </summary>
// --------------------------------------------------------------------------------------------------------------------
#endregion

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Elucidate.Controls;
using Elucidate.Forms;

using NLog;

namespace Elucidate.TabPages
{
    public partial class Recover : UserControl
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        private RunControl liveRunLogControl;

        public RunControl RunLogControl
        {
            set
            {
                liveRunLogControl = value;
                liveRunLogControl.TaskStarted += LiveRunLogControl_TaskStarted;
                liveRunLogControl.TaskCompleted += LiveRunLogControl_TaskCompleted;
            }
        }

        private readonly Stack<string> batchPaths = new Stack<string>();

        public Recover()
        {
            InitializeComponent();

            SetButtonsEnabledState(true);
        }

        private void LiveRunLogControl_TaskStarted(object sender, EventArgs e)
        {
            SetButtonsEnabledState(false);
            switch (liveRunLogControl.CommandTypeRunning)
            {
                case RunControl.CommandType.Check:
                case RunControl.CommandType.CheckForMissing:
                    timerTreeViewFill.Enabled = true;
                    break;
                case RunControl.CommandType.Fix:
                case RunControl.CommandType.RecoverFix:
                    timerTreeViewRecover.Enabled = true;
                    break;
            }
        }

        private void LiveRunLogControl_TaskCompleted(object sender, EventArgs e)
        {
            switch (liveRunLogControl.CommandTypeRunning)
            {
                case RunControl.CommandType.Check:
                case RunControl.CommandType.CheckForMissing:
                    timerTreeViewFill.Enabled = false;
                    timerTreeViewFill_Tick(sender, EventArgs.Empty);
                    break;
                case RunControl.CommandType.Fix:
                case RunControl.CommandType.RecoverFix:
                    timerTreeViewRecover.Enabled = false;
                    timerTreeViewRecover_Tick(sender, EventArgs.Empty);
                    break;
            }
            SetButtonsEnabledState(true);
        }

        private void SetButtonsEnabledState(bool isEnabled)
        {
            void local()
            {
                lock (treeView1)
                {
                    if (!isEnabled)
                    {
                        btnRecoverSelectedFiles.Enabled = false;
                        btnRecoverAllFiles.Enabled = false;
                        btnClearFiles.Enabled = false;
                    }
                    else
                    {
                        bool countOfFilesRecoverable = CountFilesRecoverable(treeView1) > 0;
                        btnRecoverSelectedFiles.Enabled = countOfFilesRecoverable;
                        btnRecoverAllFiles.Enabled = countOfFilesRecoverable;
                        btnClearFiles.Enabled = treeView1.Nodes.Count > 0;
                    }
                }
            }

            if (InvokeRequired)
            {
                Invoke(new Action(local));
            }
            else
            {
                local();
            }
        }

        // Return a list of the TreeNodes that are checked.
        private void FindRecoverableNodes(List<TreeNode> foundNodes, TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                // Add this node.
                if (node.BackColor != Color.Green)
                {
                    foundNodes.Add(node);
                }

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
                if (node.BackColor != Color.Green && node.Checked)
                {
                    checkedNodes.Add(node);
                }

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

        private static Regex recoverable = new Regex(
            @"(?<LogEntryTimestamp>.*\d\d:\d\d:\d\d.\d\d\d\d).*\[recoverable\s(?<FilePath>.*)\].*",
            RegexOptions.Compiled | RegexOptions.Singleline);
        private static Regex damaged = new Regex(
            @"(?<LogEntryTimestamp>.*\d\d:\d\d:\d\d.\d\d\d\d).*\[damaged\s(?<FilePath>.*)\].*",
            RegexOptions.Compiled | RegexOptions.Singleline);
        // 2020-07-04 12:29:48.2953 [ 8]  INFO: Elucidate.Controls.LiveRunLogControl: StdOut[damaged stderr.log] 
        private static Regex missing = new Regex(
            @"(?<LogEntryTimestamp>.*\d\d:\d\d:\d\d.\d\d\d\d).*Missing\sfile\s'(?<FilePath>.*)'.*",
            RegexOptions.Compiled | RegexOptions.Singleline);

        private void timerTreeViewFill_Tick(object sender, EventArgs e)
        {
            try
            {
                lock (this)
                {
                    while (LiveLog.LogQueueRecover.TryDequeue(out string log))
                    {
                        bool matchedMissing = false;
                        // use regex to parse log line and get the FilePath
                        Match matches = recoverable.Match(log);
                        if (!matches.Success)
                        {
                            matches = damaged.Match(log);
                        }
                        if (!matches.Success)
                        {
                            matches = missing.Match(log);
                            matchedMissing = true;
                        }

                        if (!matches.Success)
                        {
                            // nothing to do, the string did not match regex but it contained "[recoverable ", odd
                            Group logEntryTimestamp = matches.Groups["FilePath"];
                            if (!logEntryTimestamp.Success)
                            {
                                return; // paranoid, just check
                            }

                            Log.Error(@"Unable to retrieve the recoverable file path from log entry at [{0}]", logEntryTimestamp.Value);
                            return;
                        }

                        Group groupFilePath = matches.Groups["FilePath"];

                        if (!groupFilePath.Success || string.IsNullOrEmpty(groupFilePath.Value))
                        {
                            return; // nothing to do, path is an empty string
                        }

                        string filePath = groupFilePath.Value;
                        if (!matchedMissing)
                        {
                            filePath = @"/" + filePath;
                        }

                        treeView1.Invoke(new Action(() => treeView1.Nodes.Add(filePath, filePath)));
                    }
                }
            }
            catch
            {
                // ignored
            }
        }

        private static Regex recovered = new Regex(
            @"(?<LogEntryTimestamp>.*\d\d:\d\d:\d\d.\d\d\d\d).*\[recovered\s(?<FilePath>.*)\].*",
            RegexOptions.Compiled | RegexOptions.Singleline);
        private void timerTreeViewRecover_Tick(object sender, EventArgs e)
        {
            try
            {
                // Now lock in case the timer is overlapping !
                lock (this)
                {
                    //read out of the file until the EOF
                    while (LiveLog.LogQueueRecover.TryDequeue(out string log))
                    {
                        // use regex to parse log line and get the FilePath
                        Match matches = recovered.Match(log);
                        if (!matches.Success)
                        {
                            // nothing to do, the string did not match regex but it contained "[recovered ", odd
                            Group logEntryTimestamp = matches.Groups["FilePath"];
                            if (!logEntryTimestamp.Success)
                            {
                                return; // paranoid, just check
                            }

                            Log.Error(@"Unable to retrieve the recovered file path from log entry at [{0}]", logEntryTimestamp.Value);
                            return;
                        }
                        Group groupFilePath = matches.Groups["FilePath"];
                        if (!groupFilePath.Success || string.IsNullOrEmpty(groupFilePath.Value))
                        {
                            return; // nothing to do, path is an empty string
                        }

                        string filePath = groupFilePath.Value;

                        TreeNode[] node = treeView1.Nodes.Find($"/{filePath}", false);
                        if (node.Length <= 0)
                        {
                            node = treeView1.Nodes.Find(filePath, false);
                            if (node.Length <= 0)
                            {
                                continue;
                            }
                        }

                        node[0].Text = $@"{node[0].Name} (RECOVERED)";
                        node[0].BackColor = Color.Green;
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
            foreach (TreeNode node in treeView.Nodes)
            {
                node.Checked = false;
            }
        }

        private void CheckAll(TreeView treeView)
        {
            foreach (TreeNode node in treeView.Nodes)
            {
                node.Checked = true;
            }
        }

        private void btnRecoverSelectedFiles_Click(object sender, EventArgs e)
        {
            lock (treeView1)
            {
                SetButtonsEnabledState(false);

                // Get the checked nodes eligible to be recovered
                List<TreeNode> checkedNodes = CheckedNodes(treeView1);

                if (checkedNodes.Count == 0)
                {
                    // only nodes shown as green are selected so deselect all
                    UncheckAll(treeView1);
                    return;
                }

                // recover items
                foreach (var node in checkedNodes.Where(node => node.BackColor != Color.Green)
                                    .Where(node => node.FullPath.StartsWith(@"/")) // only relative paths can be restored directly
                        )
                {
                    batchPaths.Push(node.FullPath);
                }

                UncheckAll(treeView1);

                timerTreeViewRecover.Enabled = true;

                if (!liveRunLogControl.IsRunning && (batchPaths.Count > 0))
                {
                    liveRunLogControl.checkBoxDisplayOutput.Checked = true;
                    liveRunLogControl.StartSnapRaidProcess(RunControl.CommandType.RecoverFix, batchPaths);
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
            // clicking the node checkbox checks the checkbox and also fires NodeMouseClick
            // so lets only do work here if the click happened on node bounds of the text itself
            if (e.Button == MouseButtons.Left && e.Node.Bounds.Contains(new Point(e.X, e.Y)))
            {
                ToggleNodeCheckbox(e.Node);
            }
        }
    }
}
