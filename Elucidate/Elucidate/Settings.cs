#region Copyright (C)

// ---------------------------------------------------------------------------------------------------------------
//  <copyright file="Settings.cs" company="Smurf-IV">
//
//  Copyright (C) 2010-2017 Simon Coghlan (Aka Smurf-IV)
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

#endregion Copyright (C)

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using NLog;
using Shared;

namespace Elucidate
{
    public partial class Settings : Form
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private bool unsavedChangesMade;

        private bool UnsavedChangesMade
        {
            get { return unsavedChangesMade; }
            set
            {
                unsavedChangesMade = value;
                errorProvider1.SetError(btnSave, value ? "Changes have been made" : string.Empty);
            }
        }

        private readonly BindingList<AdvancedSettingsHelper> advSettingsList = new BindingList<AdvancedSettingsHelper>();
        private int ttIndex;

        public Settings()
        {
            InitializeComponent();

            ResizeRedraw = true;
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            // Not currently editable here
            IncludePatterns = new List<string>();

            // Add some items to the data source.
            advSettingsList.Add(new AdvancedSettingsHelper("SnapRAID without capture", Properties.Settings.Default.RunWithoutCapture, "Launch SnapRAID without log capture, thus allowing this to close"));
            advSettingsList.Add(new AdvancedSettingsHelper("Verbose Output", Properties.Settings.Default.UseVerboseMode, "Prints more information in the processing."));
            advSettingsList.Add(new AdvancedSettingsHelper("GUI mode Output", Properties.Settings.Default.UseGUIMode, "Enable more output of progress information.\nNot to be used in Elucidate as this uses lot's of CPU cycles scrolling the log window!"));
            advSettingsList.Add(new AdvancedSettingsHelper("Find-By-Name in Sync", Properties.Settings.Default.FindByNameInSync, "Allow to sync using only the file path and not the inode (i.e. source drive / directory),but the files themselves are the same (path/filename, size, ctime), and you do not want to waste time resyncing the files.\nThis option is also used after you have lost a drive, restored the files to a new drive, and you want to do a fast sync.\n\"Forced dangerous operation\" of synching a rewritten disk."));
            advSettingsList.Add(new AdvancedSettingsHelper("Hidden files excluded", Properties.Settings.Default.HiddenFilesExcluded, "Option to exclude \"hidden\" files and directories.\nIn Windows files with the HIDDEN attributes, in Unix files starting with \'.\'."));

            // Binding 'trick'.
            checkedListBox1.DataSource = advSettingsList;
            checkedListBox1.DisplayMember = "DisplayName";
            int offset = 0;
            foreach (AdvancedSettingsHelper helper in advSettingsList)
            {
                checkedListBox1.SetItemCheckState(offset++, helper.CheckState ? CheckState.Checked : CheckState.Unchecked);
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            snapRAIDFileLocation.Text = Properties.Settings.Default.SnapRAIDFileLocation;
            configFileLocation.Text = Properties.Settings.Default.ConfigFileLocation;
            StartTree();
            UnsavedChangesMade = false;
        }

        private void Settings_Shown(object sender, EventArgs e)
        {
        }

        #region driveAndDirTreeView

        private void StartTree()
        {
            // Code taken and adapted from http://msdn.microsoft.com/en-us/library/bb513869.aspx
            try
            {
                UseWaitCursor = true;
                driveAndDirTreeView.Nodes.Clear();

                Log.Debug("Create the root node.");
                TreeNode tvwRoot = new TreeNode { Text = Environment.MachineName, ImageIndex = 0 };
                tvwRoot.SelectedImageIndex = tvwRoot.ImageIndex;
                driveAndDirTreeView.Nodes.Add(tvwRoot);
                Log.Debug("Now we need to add any children to the root node.");

                Log.Debug("Start with drives if you have to search the entire computer.");
                string[] drives = Environment.GetLogicalDrives();
                foreach (string dr in drives)
                {
                    Log.Debug(dr);
                    DriveInfo di = new DriveInfo(dr);

                    FillInDirectoryType(tvwRoot, di);
                }

                tvwRoot.Expand();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "StartTree Threw: ");
            }
            finally
            {
                Enabled = true;
                UseWaitCursor = false;
            }
        }

        private void FillInDirectoryType(TreeNode parentNode, DriveInfo di)
        {
            if (di == null) return;
            TreeNode thisNode = new TreeNode { Text = di.Name, SelectedImageIndex = 8 };
            switch (di.DriveType)
            {
                //                     case DriveType.Unknown:
                //                     case DriveType.NoRootDirectory:
                default:
                    thisNode.ImageIndex = 7;
                    break;

                case DriveType.Removable:
                    thisNode.ImageIndex = 6;
                    break;

                case DriveType.Fixed:
                    thisNode.ImageIndex = 3;
                    break;

                case DriveType.Network:
                    thisNode.ImageIndex = 5;
                    thisNode.SelectedImageIndex = 9;
                    break;

                case DriveType.CDRom:
                    thisNode.ImageIndex = 4;
                    break;
            }
            thisNode.Tag = di.RootDirectory;
            if (di.IsReady)
            {
                thisNode.Nodes.Add("PH");
            }
            parentNode.Nodes.Add(thisNode);
        }

        private void driveAndDirTreeView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            Log.Debug("Select the clicked node");
            driveAndDirTreeView.SelectedNode = driveAndDirTreeView.GetNodeAt(e.X, e.Y);
        }

        private void driveAndDirTreeView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            Log.Debug("Select the clicked node");
            TreeNode selected = driveAndDirTreeView.GetNodeAt(e.X, e.Y);
            driveAndDirTreeView.SelectedNode = selected;
            if (selected != null)
            {
                PerformSnapShotSourceAdd(selected);
            }
        }

        private string GetSelectedNodesPath(TreeNode selected)
        {
            DirectoryInfo shNode = selected.Tag as DirectoryInfo;
            Log.Debug("Now we need to add any children to the root node.");
            string newPath = shNode != null ? shNode.FullName : selected.FullPath;
            return newPath;
        }

        private void PerformSnapShotSourceAdd(TreeNode selected)
        {
            string newPath = GetSelectedNodesPath(selected);
            // TODO: On Add check to make sure that the root (Or this) node have not already been covered.
            if (String.IsNullOrEmpty(newPath)) return;
            snapShotSourcesTreeView.Nodes.Add(new TreeNode(newPath, selected.ImageIndex, selected.ImageIndex));
            UnsavedChangesMade = true;
            driveSpace.StartProcessing((from TreeNode node in snapShotSourcesTreeView.Nodes select node.Text).ToList());
        }

        private void refreshStripMenuItem_Click(object sender, EventArgs e)
        {
            StartTree();
        }

        private void driveAndDirTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            Enabled = false;
            UseWaitCursor = true;
            try
            {
                Log.Debug("Remove the placeholder node.");
                if (e.Node.Tag is DirectoryInfo root)
                {
                    e.Node.Nodes.Clear();
                    WalkNextTreeLevel(e.Node);
                }
                e.Cancel = false;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "BeforeExpand has thrown: ");
            }
            finally
            {
                Enabled = true;
                UseWaitCursor = false;
            }
        }

        private void WalkNextTreeLevel(TreeNode parentNode)
        {
            try
            {
                if (!(parentNode.Tag is DirectoryInfo root)) return;
                Log.Debug("// Find all the subdirectories under this directory.");
                DirectoryInfo[] subDirs = root.GetDirectories();
                if (subDirs.Length == 0) return;
                foreach (DirectoryInfo dirInfo in subDirs)
                {
                    // Resursive call for each subdirectory.
                    TreeNode tvwChild = new TreeNode
                    {
                        Text = dirInfo.Name,
                        SelectedImageIndex = 8,
                        ImageIndex = 7,
                        Tag = dirInfo
                    };

                    Log.Debug("If this is a folder item and has children then add a place holder node.");

                    try
                    {
                        DirectoryInfo[] subChildDirs = dirInfo.GetDirectories();
                        if (subChildDirs.Length > 0)
                        {
                            tvwChild.Nodes.Add("PH");
                        }
                    }
                    catch (UnauthorizedAccessException uaex)
                    {
                        Log.Info(String.Concat("No Access to subdirs in ", tvwChild.Text), uaex);
                    }
                    parentNode.Nodes.Add(tvwChild);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "RecurseAddChildren has thrown:");
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode tn = driveAndDirTreeView.SelectedNode;
            if (tn == null) return;
            driveAndDirTreeView.Nodes.Remove(tn);
            UnsavedChangesMade = true;
        }

        private void driveAndDirTreeView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Get the tree.
                TreeView tree = (TreeView)sender;

                // Get the node underneath the mouse.
                TreeNode selected = tree.GetNodeAt(e.X, e.Y);
                tree.SelectedNode = selected;

                // Start the drag-and-drop operation with a cloned copy of the node.
                if (selected != null)
                {
                    tree.DoDragDrop(selected, DragDropEffects.All);
                }
            }
        }

        #endregion driveAndDirTreeView

        #region snapShotSourcesTreeView

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteNode();
        }

        private void snapShotSourcesTreeView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
            {
                return;
            }
            DeleteNode();
            e.Handled = true;
        }

        private void DeleteNode()
        {
            TreeNode selected = snapShotSourcesTreeView.SelectedNode;
            if (selected != null)
            {
                snapShotSourcesTreeView.SelectedNode = null;
                snapShotSourcesTreeView.Nodes.Remove(selected);
                UnsavedChangesMade = true;
                driveSpace.StartProcessing((from TreeNode node in snapShotSourcesTreeView.Nodes select node.Text).ToList());
            }
            else
            {
                SystemSounds.Beep.Play();
            }
        }

        private void snapShotSourcesTreeView_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void snapShotSourcesTreeView_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(typeof(TreeNode)) is TreeNode ud)
            {
                PerformSnapShotSourceAdd(ud);
            }
        }

        private void DRUnit_NewNode_MenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog { Description = "Browse for directory manually" };
            if (fbd.ShowDialog() != DialogResult.OK) return;
            DirectoryInfo dirInfo = new DirectoryInfo(fbd.SelectedPath);
            TreeNode tvwChild = new TreeNode { Text = dirInfo.Name, SelectedImageIndex = 8, ImageIndex = 7, Tag = dirInfo };
            driveAndDirTreeView.Nodes.Add(tvwChild);
            driveAndDirTreeView.SelectedNode = tvwChild;
            PerformSnapShotSourceAdd(tvwChild);
        }

        private void snapShotSourcesTreeView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            Log.Debug("Select the clicked node");
            snapShotSourcesTreeView.SelectedNode = snapShotSourcesTreeView.GetNodeAt(e.X, e.Y);
        }

        #endregion snapShotSourcesTreeView

        private bool ValidateData()
        {
            errorProvider1.Clear();
            bool isValid = true;
            if (!File.Exists(snapRAIDFileLocation.Text))
            {
                isValid = false;
                errorProvider1.SetError(snapRAIDFileLocation, "Executeable Not found!");
            }
            if (!File.Exists(configFileLocation.Text))
            {
                isValid = false;
                errorProvider1.SetError(configFileLocation, "Config File does not exist!");
            }
            if (string.IsNullOrEmpty(configFileLocation.Text)
               || !Directory.Exists(Path.GetDirectoryName(configFileLocation.Text))
               )
            {
                isValid = false;
                errorProvider1.SetError(configFileLocation, "Config File directory does not exist!");
            }
            if (snapShotSourcesTreeView.Nodes.Count == 0)
            {
                isValid = false;
                errorProvider1.SetIconAlignment(snapShotSourcesTreeView, ErrorIconAlignment.TopLeft);
                errorProvider1.SetIconPadding(snapShotSourcesTreeView, -20);
                errorProvider1.SetError(snapShotSourcesTreeView, "No protected regions set!");
            }
            return isValid;
        }

        private void findExeFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = Path.GetFullPath(snapRAIDFileLocation.Text);
                Log.Info("snapRAIDFileLocation from [{0}]", ofd.InitialDirectory);
                ofd.Filter = "Snap Raid application|SnapRAID.exe";
                ofd.CheckFileExists = true;
                ofd.RestoreDirectory = true;
                if (DialogResult.OK == ofd.ShowDialog())
                {
                    snapRAIDFileLocation.Text = Path.GetFullPath(ofd.FileName);
                }
            }
        }

        private void snapRAIDFileLocation_TextChanged(object sender, EventArgs e)
        {
            UnsavedChangesMade = true;
            ValidateData();
        }

        private void findConfigFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = Path.GetFullPath(configFileLocation.Text);
                Log.Info("configFileLocation from [{0}]", ofd.InitialDirectory);
                ofd.Filter = "Snap Raid Config|SnapRAID.config|All Files|*.*";
                ofd.CheckFileExists = true;
                ofd.RestoreDirectory = true;
                if (DialogResult.OK == ofd.ShowDialog())
                {
                    configFileLocation.Text = Path.GetFullPath(ofd.FileName);
                }
            }
        }

        private void configFileLocation_TextChanged(object sender, EventArgs e)
        {
            UnsavedChangesMade = true;
            ReadConfigDetails();
            ValidateData();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ReadConfigDetails();
            ValidateData();
        }

        private void ReadConfigDetails()
        {
            exludedFilesView.Rows.Clear();
            snapShotSourcesTreeView.Nodes.Clear();

            ConfigFileHelper cfg = new ConfigFileHelper(configFileLocation.Text);
            if (!File.Exists(configFileLocation.Text))
            {
                if (Properties.Settings.Default.UseWindowsSettings)
                {
                    exludedFilesView.Rows.Add(@"*.covefs");
                    exludedFilesView.Rows.Add(@"*.unrecoverable");
                    exludedFilesView.Rows.Add(@"Thumbs.db");
                    exludedFilesView.Rows.Add(@"\$RECYCLE.BIN");
                    exludedFilesView.Rows.Add(@"\System Volume Information");
                    exludedFilesView.Rows.Add(@"\Program Files\");
                    exludedFilesView.Rows.Add(@"\Program Files(x86)\");
                    exludedFilesView.Rows.Add(@"\Windows\");
                }
                else
                {
                    exludedFilesView.Rows.Add(@"/lost+found/");
                    exludedFilesView.Rows.Add(@"/tmp/");
                }
            }
            else
            {
                string readResult;
                if (!string.IsNullOrEmpty(readResult = cfg.Read()))
                {
                    MessageBoxExt.Show(this, readResult, "Config Read Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                IncludePatterns = cfg.IncludePatterns;
                numBlockSizeKB.Value = cfg.BlockSizeKB;
                advSettingsList[3].CheckState = cfg.Nohidden;
                numAutoSaveGB.Value = cfg.AutoSaveGB;
                foreach (string excludePattern in cfg.ExcludePatterns.Where(excludePattern => !string.IsNullOrWhiteSpace(excludePattern)))
                {
                    exludedFilesView.Rows.Add(excludePattern);
                }
                foreach (string source in cfg.SnapShotSources.Where(source => !string.IsNullOrWhiteSpace(source)))
                {
                    snapShotSourcesTreeView.Nodes.Add(new TreeNode(source, 7, 7));
                }
                parityLocation1.Text = cfg.ParityFile1;
                parityLocation2.Text = cfg.ParityFile2;
                parityLocation3.Text = cfg.ParityFile3;
                parityLocation4.Text = cfg.ParityFile4;
                parityLocation5.Text = cfg.ParityFile5;
                parityLocation6.Text = cfg.ParityFile6;
            }
            UnsavedChangesMade = false;
            driveSpace.StartProcessing((from TreeNode node in snapShotSourcesTreeView.Nodes select node.Text).ToList());
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            ConfigFileHelper cfg = new ConfigFileHelper(configFileLocation.Text)
            {
                IncludePatterns = IncludePatterns,
                BlockSizeKB = (uint)numBlockSizeKB.Value,
                Nohidden = advSettingsList[3].CheckState,
                AutoSaveGB = (uint)numAutoSaveGB.Value
            };
            foreach (DataGridViewRow row in exludedFilesView.Rows)
            {
                string value = $"{row.Cells[0].Value}";
                if (!string.IsNullOrWhiteSpace(value))
                {
                    cfg.ExcludePatterns.Add(value);
                }
            }
            foreach (string text in snapShotSourcesTreeView.Nodes.Cast<TreeNode>().Select(node => node.Text).Where(text => !string.IsNullOrWhiteSpace(text)))
            {
                cfg.SnapShotSources.Add(text);
                cfg.ContentFiles.Add(text);
            }

            switch (!string.IsNullOrEmpty(parityLocation1.Text.Trim()))
            {
                case true:
                    var trim1 = parityLocation1.Text.Trim();
                    cfg.ParityFile1 = trim1;
                    FileInfo fi = new FileInfo(trim1);
                    cfg.ContentFiles.Add(fi.DirectoryName ?? fi.FullName);

                    string trim2 = parityLocation2.Text.Trim();
                    if (string.IsNullOrEmpty(trim2)) break;
                    cfg.ParityFile2 = trim2;
                    fi = new FileInfo(trim2);
                    cfg.ContentFiles.Add(fi.DirectoryName ?? fi.FullName);

                    string trim3 = parityLocation3.Text.Trim();
                    if (string.IsNullOrEmpty(trim3)) break;
                    cfg.ParityFile2 = trim3;
                    fi = new FileInfo(trim3);
                    cfg.ContentFiles.Add(fi.DirectoryName ?? fi.FullName);

                    string trim4 = parityLocation4.Text.Trim();
                    if (string.IsNullOrEmpty(trim4)) break;
                    cfg.ParityFile4 = trim3;
                    fi = new FileInfo(trim4);
                    cfg.ContentFiles.Add(fi.DirectoryName ?? fi.FullName);

                    string trim5 = parityLocation5.Text.Trim();
                    if (string.IsNullOrEmpty(trim5)) break;
                    cfg.ParityFile5 = trim5;
                    fi = new FileInfo(trim5);
                    cfg.ContentFiles.Add(fi.DirectoryName ?? fi.FullName);

                    string trim6 = parityLocation6.Text.Trim();
                    if (string.IsNullOrEmpty(trim6)) break;
                    cfg.ParityFile6 = trim6;
                    fi = new FileInfo(trim6);
                    cfg.ContentFiles.Add(fi.DirectoryName ?? fi.FullName);

                    break;
            }

            try
            {
                // backup current config
                File.Copy(configFileLocation.Text, $"{configFileLocation.Text}.temp");

                string writeResult;
                if (!string.IsNullOrEmpty(writeResult = cfg.Write()))
                {
                    MessageBoxExt.Show(this, writeResult, "Config Write Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Properties.Settings.Default.ConfigFileIsValid = ValidateData();
                    Properties.Settings.Default.SnapRAIDFileLocation = snapRAIDFileLocation.Text;
                    Properties.Settings.Default.ConfigFileLocation = configFileLocation.Text;
                    Properties.Settings.Default.UseVerboseMode = advSettingsList[1].CheckState;
                    Properties.Settings.Default.UseGUIMode = advSettingsList[2].CheckState;
                    Properties.Settings.Default.FindByNameInSync = advSettingsList[3].CheckState;
                    // https://github.com/Smurf-IV/Elucidateworkitem/10114
                    Properties.Settings.Default.HiddenFilesExcluded = advSettingsList[4].CheckState;
                    Properties.Settings.Default.RunWithoutCapture = advSettingsList[0].CheckState;

                    Properties.Settings.Default.Save();
                    UnsavedChangesMade = false;

                    // keep config backup - by day, otherwise include minute, otherwise include second
                    var backupCconfig = $"{configFileLocation.Text}.{DateTime.Now:yyyyMMdd}";
                    if (File.Exists(backupCconfig))
                        backupCconfig = $"{configFileLocation.Text}.{DateTime.Now:yyyyMMddmm}";
                    if (File.Exists(backupCconfig))
                        backupCconfig = $"{configFileLocation.Text}.{DateTime.Now:yyyyMMddmmss}";
                    File.Copy($"{configFileLocation.Text}.temp", backupCconfig);
                    File.Delete($"{configFileLocation.Text}.temp");
                }
            }
            catch (Exception ex)
            {
                Log.Error("Failed to save config file.");
                Log.Error(ex);
            }
            
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!UnsavedChangesMade || (e.CloseReason != CloseReason.UserClosing)) return;
            if (DialogResult.No == MessageBoxExt.Show(this, "You have made changes that have not been saved.\n\nDo you wish to discard and exit?",
                    "Settings have changed..", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                e.Cancel = true;
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            advSettingsList[e.Index].CheckState = (e.NewValue == CheckState.Checked);
            UnsavedChangesMade = true;
        }
        
        private void findParity1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                parityLocation1.Text = folderBrowserDialog1.SelectedPath;
                
            }
        }

        private void findParity2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                parityLocation2.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void findParity3_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                parityLocation3.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        private void findParity4_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                parityLocation4.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        private void findParity5_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                parityLocation5.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        private void findParity6_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                parityLocation6.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void parityLocation1_TextChanged(object sender, EventArgs e)
        {
            UnsavedChangesMade = true;
        }

        private void parityLocation2_TextChanged(object sender, EventArgs e)
        {
            UnsavedChangesMade = true;
            string tooltip = "Optional disk failure protection root location.";
            if (!string.IsNullOrEmpty(parityLocation2.Text)
               && !File.Exists(parityLocation2.Text)
               )
            {
                tooltip = "To add an additional parity drive you will need to run the \"fix\" command.";
            }
            toolTip1.SetToolTip(parityLocation2, tooltip);
            toolTip1.SetToolTip(findParity2, tooltip);
            toolTip1.SetToolTip(labelParity2, tooltip);
        }
        
        private void parityLocation3_TextChanged(object sender, EventArgs e)
        {
            UnsavedChangesMade = true;
            string tooltip = "Optional disk failure protection root location.";
            if (!string.IsNullOrEmpty(parityLocation3.Text)
                && !File.Exists(parityLocation3.Text)
            )
            {
                tooltip = "To add an additional parity drive you will need to run the \"fix\" command.";
            }
            toolTip1.SetToolTip(parityLocation3, tooltip);
            toolTip1.SetToolTip(findParity3, tooltip);
            toolTip1.SetToolTip(labelParity3, tooltip);
        }

        private void parityLocation4_TextChanged(object sender, EventArgs e)
        {
            UnsavedChangesMade = true;
            string tooltip = "Optional disk failure protection root location.";
            if (!string.IsNullOrEmpty(parityLocation4.Text)
                && !File.Exists(parityLocation4.Text)
            )
            {
                tooltip = "To add an additional parity drive you will need to run the \"fix\" command.";
            }
            toolTip1.SetToolTip(parityLocation4, tooltip);
            toolTip1.SetToolTip(findParity4, tooltip);
            toolTip1.SetToolTip(labelParity4, tooltip);
        }

        private void parityLocation5_TextChanged(object sender, EventArgs e)
        {
            UnsavedChangesMade = true;
            string tooltip = "Optional disk failure protection root location.";
            if (!string.IsNullOrEmpty(parityLocation5.Text)
                && !File.Exists(parityLocation5.Text)
            )
            {
                tooltip = "To add an additional parity drive you will need to run the \"fix\" command.";
            }
            toolTip1.SetToolTip(parityLocation5, tooltip);
            toolTip1.SetToolTip(findParity5, tooltip);
            toolTip1.SetToolTip(labelParity5, tooltip);
        }

        private void parityLocation6_TextChanged(object sender, EventArgs e)
        {
            UnsavedChangesMade = true;
            string tooltip = "Optional disk failure protection root location.";
            if (!string.IsNullOrEmpty(parityLocation6.Text)
                && !File.Exists(parityLocation6.Text)
            )
            {
                tooltip = "To add an additional parity drive you will need to run the \"fix\" command.";
            }
            toolTip1.SetToolTip(parityLocation6, tooltip);
            toolTip1.SetToolTip(findParity6, tooltip);
            toolTip1.SetToolTip(labelParity6, tooltip);
        }

        private void checkedListBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //Make ttIndex a global integer variable to store index of item currently showing tooltip.
            //Check if current location is different from item having tooltip, if so call method
            if (ttIndex != checkedListBox1.IndexFromPoint(e.Location))
            {
                ShowToolTip();
            }
        }

        private void ShowToolTip()
        {
            ttIndex = checkedListBox1.IndexFromPoint(checkedListBox1.PointToClient(MousePosition));
            if (ttIndex <= -1) return;
            PointToClient(MousePosition);
            toolTip1.ToolTipTitle = advSettingsList[ttIndex].DisplayName;
            toolTip1.SetToolTip(checkedListBox1, advSettingsList[ttIndex].TootTip);
        }

        private void btnGetRecommended_Click(object sender, EventArgs e)
        {
            CalculateBlockSize calc = new CalculateBlockSize();
            List<string> snaps = snapShotSourcesTreeView.Nodes.Cast<TreeNode>().Select(node => node.Text).Where(text => !string.IsNullOrWhiteSpace(text)).ToList();
            calc.SnapShotSources = snaps;
            string trim5 = parityLocation1.Text.Trim();
            if (!string.IsNullOrEmpty(trim5))
            {
                calc.RaidTargets.Add(trim5);
                string trim6 = parityLocation2.Text.Trim();
                if (!string.IsNullOrEmpty(trim6))
                {
                    calc.RaidTargets.Add(trim6);
                }
            }

            calc.ShowDialog(this);
        }

    }
}