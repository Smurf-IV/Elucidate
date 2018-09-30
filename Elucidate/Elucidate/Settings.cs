#region Copyright (C)

// ---------------------------------------------------------------------------------------------------------------
//  Forked by BlueBlock on July 28th, 2018
// ---------------------------------------------------------------------------------------------------------------
//  <copyright file="Settings.cs" company="Smurf-IV">
//
//  Copyright (C) 2010-2018 Simon Coghlan (Aka Smurf-IV)
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
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;

using Elucidate.HelperClasses;
using Elucidate.Logging;
using Elucidate.Objects;
using Elucidate.Shared;

using MoreLinq;

namespace Elucidate
{
    public partial class Settings : Form
    {
        public static event EventHandler ConfigSaved;

        // ReSharper disable once UnusedMember.Local
        private static void OnConfigSaved(EventArgs e)
        {
            EventHandler handler = ConfigSaved;
            handler?.Invoke(null, e);
        }

        private bool _unsavedChangesMade;

        private ConfigFileHelper _cfg = new ConfigFileHelper();

        private bool _initializing = true;

        private bool UnsavedChangesMade
        {
            get => _unsavedChangesMade;
            set
            {
                _unsavedChangesMade = value;
                errorProvider1.SetError(btnSave, value ? "Changes have been made" : string.Empty);
            }
        }

        private readonly BindingList<AdvancedSettingsHelper> _advSettingsList = new BindingList<AdvancedSettingsHelper>();

        private int _ttIndex;

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
            _advSettingsList.Add(new AdvancedSettingsHelper("Display Output", Properties.Settings.Default.IsDisplayOutputEnabled, "Command output is displayed when enabled."));
            _advSettingsList.Add(new AdvancedSettingsHelper("Verbose Output", Properties.Settings.Default.UseVerboseMode, "Displays more information while processing."));
            _advSettingsList.Add(new AdvancedSettingsHelper("Find-By-Name in Sync", Properties.Settings.Default.FindByNameInSync, "Allow to sync using only the file path and not the inode (i.e. source drive / directory),but the files themselves are the same (path/filename, size, ctime), and you do not want to waste time resyncing the files.\nThis option is also used after you have lost a drive, restored the files to a new drive, and you want to do a fast sync.\n\"Forced dangerous operation\" of synching a rewritten disk."));
            _advSettingsList.Add(new AdvancedSettingsHelper("Hidden files excluded", Properties.Settings.Default.HiddenFilesExcluded, "Option to exclude \"hidden\" files and directories.\nIn Windows files with the HIDDEN attributes, in Unix files starting with \'.\'."));
            _advSettingsList.Add(new AdvancedSettingsHelper("Debug Log Output", Properties.Settings.Default.DebugLoggingEnabled, "Option to include debug log output for troubleshooting Elucidate."));

            // Binding 'trick'.
            checkedListBox1.DataSource = _advSettingsList;
            checkedListBox1.DisplayMember = "DisplayName";
            int offset = 0;
            foreach (AdvancedSettingsHelper helper in _advSettingsList)
            {
                checkedListBox1.SetItemCheckState(offset++, helper.CheckState ? CheckState.Checked : CheckState.Unchecked);
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            StartTree();
        }

        private void Settings_Shown(object sender, EventArgs e)
        {
            snapRAIDFileLocation.Text = Properties.Settings.Default.SnapRAIDFileLocation;

            configFileLocation.Text = Properties.Settings.Default.ConfigFileLocation;

            ReadConfigDetails();

            errorProvider1.Clear();

            UnsavedChangesMade = false;

            _initializing = false;

            Properties.Settings.Default.ConfigFileIsValid = ValidateFormData();

            ValidateParityTextBox();
        }

        #region driveAndDirTreeView

        private void StartTree()
        {
            // Code taken and adapted from http://msdn.microsoft.com/en-us/library/bb513869.aspx
            try
            {
                UseWaitCursor = true;
                driveAndDirTreeView.Nodes.Clear();

                Log.Instance.Debug("Create the root node.");
                TreeNode tvwRoot = new TreeNode { Text = Environment.MachineName, ImageIndex = 0 };
                tvwRoot.SelectedImageIndex = tvwRoot.ImageIndex;
                driveAndDirTreeView.Nodes.Add(tvwRoot);
                Log.Instance.Debug("Now we need to add any children to the root node.");

                Log.Instance.Debug("Start with drives if you have to search the entire computer.");

                // retrieve all storage devices
                List<StorageDevice> storageDevices = StorageUtil.GetStorageDevices();
                foreach (StorageDevice storageDevice in storageDevices)
                {
                    FillInStorageDeviceDirectoryType(tvwRoot, storageDevice);
                }

                tvwRoot.Expand();
            }
            catch (Exception ex)
            {
                ExceptionHandler.ReportException(ex, "StartTree Threw: ");
            }
            finally
            {
                Enabled = true;
                UseWaitCursor = false;
            }
        }

        private void FillInStorageDeviceDirectoryType(TreeNode parentNode, StorageDevice storageDevice)
        {
            if (storageDevice == null)
            {
                return;
            }

            TreeNode thisNode = new TreeNode
            {
                Text = storageDevice.Caption,
                Tag = new DirectoryInfo(storageDevice.Caption)
            };

            switch (storageDevice.DriveType)
            {
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

                default:
                    thisNode.ImageIndex = 7;
                    break;
            }

            thisNode.SelectedImageIndex = thisNode.ImageIndex;

            if (!new DriveInfo(storageDevice.Caption).IsReady)
            {
                Log.Instance.Info($"The drive {storageDevice.Caption} could not be read.");
            }
            else
            {
                thisNode.Nodes.Add("PH");
            }

            parentNode.Nodes.Add(thisNode);
        }

        private void driveAndDirTreeView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }

            Log.Instance.Trace("Select the clicked node");

            driveAndDirTreeView.SelectedNode = driveAndDirTreeView.GetNodeAt(e.X, e.Y);
        }

        private void driveAndDirTreeView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            Log.Instance.Trace("Select the clicked node");

            TreeNode selected = driveAndDirTreeView.GetNodeAt(e.X, e.Y);

            driveAndDirTreeView.SelectedNode = selected;

            if (selected != null)
            {
                PerformSnapShotSourceAddNode(selected);
            }
        }

        private string GetSelectedNodesPath(TreeNode selected)
        {
            DirectoryInfo shNode = selected.Tag as DirectoryInfo;

            Log.Instance.Trace("Now we need to add any children to the root node.");

            string newPath = shNode != null ? shNode.FullName : selected.FullPath;

            return newPath;
        }

        private void PerformSnapShotSourceAddNode(TreeNode selected)
        {
            string newPath = GetSelectedNodesPath(selected);

            string newDevice = StorageUtil.GetPathRoot(newPath);

            if (string.IsNullOrEmpty(newPath))
            {
                return;
            }

            if (!Directory.Exists(newPath))
            {
                Log.Instance.Warn($"Data source not added. Path does not exist. Attempted to add [{newPath}]");
                return;
            }

            // check if device is already added by an existing entry; a device cannot be entered more than once
            foreach (TreeNode node in snapShotSourcesTreeView.Nodes)
            {
                string nodeDevice = StorageUtil.GetPathRoot(node.FullPath);

                Log.Instance.Trace($"adding new node, so compare, nodeDevice = {nodeDevice}");

                if (newDevice != nodeDevice)
                {
                    continue;
                }

                Log.Instance.Warn($"Data source not added. The path is on a device for an existing path. Attempted to add [{newPath}] which is on the same device as the existing path [{node.FullPath}]");

                MessageBoxExt.Show(this, $"The path is on a device for an existing path.\n\nExisting device path:\n{node.FullPath}", "Source not added", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            snapShotSourcesTreeView.Nodes.Add(new TreeNode(newPath, selected.ImageIndex, selected.ImageIndex));

            UnsavedChangesMade = true;

            driveSpace.StartProcessing(GetPathsOfInterestFromForm());
        }

        private void refreshStripMenuItem_Click(object sender, EventArgs e)
        {
            StartTree();
        }

        private void driveAndDirTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                Log.Instance.Trace("Remove the placeholder node.");

                if (e.Node.Tag is DirectoryInfo)
                {
                    e.Node.Nodes.Clear();
                    WalkNextTreeLevel(e.Node);
                }
                e.Cancel = false;
            }
            catch (Exception ex)
            {
                ExceptionHandler.ReportException(ex);
            }
        }

        private void WalkNextTreeLevel(TreeNode parentNode)
        {
            try
            {
                if (!(parentNode.Tag is DirectoryInfo root))
                {
                    return;
                }

                Log.Instance.Trace("// Find all the subdirectories under this directory.");

                DirectoryInfo[] subDirs = root.GetDirectories().Where(dir => (dir.Attributes & FileAttributes.System) == 0 && (dir.Attributes & FileAttributes.Hidden) == 0).ToArray();

                if (!subDirs.Any())
                {
                    return;
                }

                foreach (DirectoryInfo dirInfo in subDirs)
                {
                    // Recursive call for each subdirectory.

                    TreeNode tvwChild = new TreeNode
                    {
                        Text = dirInfo.Name,
                        SelectedImageIndex = 8,
                        ImageIndex = 7,
                        Tag = dirInfo
                    };

                    Log.Instance.Trace("If this is a folder item and has children then add a place holder node.");

                    try
                    {
                        DirectoryInfo[] subChildDirs = dirInfo.GetDirectories().Where(dir => (dir.Attributes & FileAttributes.System) == 0 && (dir.Attributes & FileAttributes.Hidden) == 0).ToArray();

                        if (subChildDirs.Any())
                        {
                            tvwChild.Nodes.Add("PH");
                        }
                    }
                    catch (UnauthorizedAccessException uaex)
                    {
                        Log.Instance.Info(String.Concat("No Access to subdirs in ", tvwChild.Text), uaex);
                    }

                    parentNode.Nodes.Add(tvwChild);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.ReportException(ex);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode tn = driveAndDirTreeView.SelectedNode;
            if (tn == null)
            {
                return;
            }

            driveAndDirTreeView.Nodes.Remove(tn);
            UnsavedChangesMade = true;
        }

        private void driveAndDirTreeView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
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

        #endregion driveAndDirTreeView

        #region snapShotSourcesTreeView

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PerformSnapShotSourceDeleteNode();
        }

        private void snapShotSourcesTreeView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
            {
                return;
            }

            PerformSnapShotSourceDeleteNode();

            e.Handled = true;
        }

        private void PerformSnapShotSourceDeleteNode()
        {
            TreeNode selected = snapShotSourcesTreeView.SelectedNode;
            if (selected != null)
            {
                snapShotSourcesTreeView.SelectedNode = null;
                snapShotSourcesTreeView.Nodes.Remove(selected);
                UnsavedChangesMade = true;
                driveSpace.StartProcessing(GetPathsOfInterestFromForm());
            }
            else
            {
                SystemSounds.Beep.Play();
            }

            ValidateFormData();
        }

        private void snapShotSourcesTreeView_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void snapShotSourcesTreeView_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(typeof(TreeNode)) is TreeNode ud)
            {
                PerformSnapShotSourceAddNode(ud);
            }
        }

        private void DRUnit_NewNode_MenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog { Description = @"Browse for directory manually" };

            if (fbd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            DirectoryInfo dirInfo = new DirectoryInfo(fbd.SelectedPath);

            TreeNode tvwChild = new TreeNode
            {
                Text = dirInfo.Name,
                SelectedImageIndex = 8,
                ImageIndex = 7,
                Tag = dirInfo
            };

            driveAndDirTreeView.Nodes.Add(tvwChild);

            driveAndDirTreeView.SelectedNode = tvwChild;

            PerformSnapShotSourceAddNode(tvwChild);
        }

        private void snapShotSourcesTreeView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }

            Log.Instance.Trace("Select the clicked node");

            snapShotSourcesTreeView.SelectedNode = snapShotSourcesTreeView.GetNodeAt(e.X, e.Y);
        }

        #endregion snapShotSourcesTreeView

        private List<CoveragePath> GetPathsOfInterest()
        {
            List<CoveragePath> pathsOfInterest = new List<CoveragePath>();

            // SnapShotsource might be root or folders, so we handle both cases
            foreach (TreeNode snapShotSource in snapShotSourcesTreeView.Nodes)
            {
                pathsOfInterest.Add(new CoveragePath
                {
                    FullPath = Path.GetDirectoryName(snapShotSource.FullPath) ?? Path.GetFullPath(snapShotSource.FullPath),
                    PathType = PathTypeEnum.Source
                });
            }

            if (!string.IsNullOrEmpty(parityLocation1.Text)) { pathsOfInterest.Add(new CoveragePath { FullPath = Path.GetFullPath(parityLocation1.Text), PathType = PathTypeEnum.Parity }); }

            if (!string.IsNullOrEmpty(parityLocation2.Text)) { pathsOfInterest.Add(new CoveragePath { FullPath = Path.GetFullPath(parityLocation2.Text), PathType = PathTypeEnum.Parity }); }

            if (!string.IsNullOrEmpty(parityLocation3.Text)) { pathsOfInterest.Add(new CoveragePath { FullPath = Path.GetFullPath(parityLocation3.Text), PathType = PathTypeEnum.Parity }); }

            if (!string.IsNullOrEmpty(parityLocation4.Text)) { pathsOfInterest.Add(new CoveragePath { FullPath = Path.GetFullPath(parityLocation4.Text), PathType = PathTypeEnum.Parity }); }

            if (!string.IsNullOrEmpty(parityLocation5.Text)) { pathsOfInterest.Add(new CoveragePath { FullPath = Path.GetFullPath(parityLocation5.Text), PathType = PathTypeEnum.Parity }); }

            if (!string.IsNullOrEmpty(parityLocation6.Text)) { pathsOfInterest.Add(new CoveragePath { FullPath = Path.GetFullPath(parityLocation6.Text), PathType = PathTypeEnum.Parity }); }

            return pathsOfInterest.OrderBy(s => s.FullPath).DistinctBy(d => d.Drive).ToList();
        }

        private bool ValidateFormData()
        {
            errorProvider1.Clear();

            if (_initializing)
            {
                return true;
            }

            bool isValid = true;

            if (!File.Exists(snapRAIDFileLocation.Text))
            {
                isValid = false;
                errorProvider1.SetError(snapRAIDFileLocation, "Executable not found!");
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

            List<string> deviceList = new List<string>();

            foreach (TreeNode node in snapShotSourcesTreeView.Nodes)
            {
                node.BackColor = Color.Empty;

                string errMsg = string.Empty;

                // test if device already exists in list; SnapRAID only permits one device entry per device
                if (deviceList.Contains(StorageUtil.GetPathRoot(node.FullPath)))
                {
                    errMsg = $"{node.Index} A device may only appear once in the data source list!";
                }

                deviceList.Add(StorageUtil.GetPathRoot(node.FullPath));

                // test if path exists
                if (!Directory.Exists(node.FullPath))
                {
                    errMsg = "Data source is inaccessible!";
                }

                if (string.IsNullOrEmpty(errMsg))
                {
                    continue;
                }

                isValid = false;
                node.BackColor = Color.Red;
                errorProvider1.SetIconAlignment(snapShotSourcesTreeView, ErrorIconAlignment.TopLeft);
                errorProvider1.SetIconPadding(snapShotSourcesTreeView, -20);
                errorProvider1.SetIconAlignment(snapShotSourcesTreeView, ErrorIconAlignment.TopLeft);
                errorProvider1.SetError(snapShotSourcesTreeView, errMsg);
            }

            return isValid;
        }

        private void findExeFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = Path.GetFullPath(snapRAIDFileLocation.Text);

                Log.Instance.Info("snapRAIDFileLocation from [{0}]", ofd.InitialDirectory);

                ofd.Filter = @"Snap Raid application|SnapRAID.exe";

                ofd.CheckFileExists = true;

                ofd.RestoreDirectory = true;

                if (DialogResult.OK == ofd.ShowDialog())
                {
                    snapRAIDFileLocation.Text = Path.GetFullPath(ofd.FileName);
                    UnsavedChangesMade = true;
                }
            }
        }

        private void snapRAIDFileLocation_TextChanged(object sender, EventArgs e)
        {
            UnsavedChangesMade = true;

            ValidateFormData();
        }

        private void findConfigFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = Path.GetFullPath(configFileLocation.Text);

                Log.Instance.Trace("configFileLocation from [{0}]", ofd.InitialDirectory);

                ofd.Filter = @"Snap Raid Config|*.conf*|All Files|*.*";

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
            ReadConfigDetails();

            ValidateFormData();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ReadConfigDetails();

            ValidateFormData();
        }

        private void ReadConfigDetails()
        {
            try
            {
                exludedFilesView.Rows.Clear();

                snapShotSourcesTreeView.Nodes.Clear();

                _cfg = new ConfigFileHelper(Properties.Settings.Default.ConfigFileLocation);

                if (!File.Exists(Properties.Settings.Default.ConfigFileLocation))
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
                    if (!_cfg.Read())
                    {
                        MessageBoxExt.Show(
                            this, 
                            "Failed to read the config file.", 
                            "Config Read Error:", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
                        return;
                    }

                    IncludePatterns = _cfg.IncludePatterns;

                    numBlockSizeKB.Value = _cfg.BlockSizeKB;

                    _advSettingsList[ConfigFileHelper.CHECKBOX_HIDDEN_FILES_EXCLUDED].CheckState = _cfg.Nohidden;

                    numAutoSaveGB.Value = _cfg.AutoSaveGB;

                    foreach (string excludePattern in _cfg.ExcludePatterns.Where(excludePattern => !string.IsNullOrWhiteSpace(excludePattern)))
                    {
                        exludedFilesView.Rows.Add(excludePattern);
                    }

                    foreach (string source in _cfg.SnapShotSources.Where(source => !string.IsNullOrWhiteSpace(source)))
                    {
                        snapShotSourcesTreeView.Nodes.Add(new TreeNode(source, 7, 7));
                    }

                    parityLocation1.Text = _cfg.ParityFile1;
                    parityLocation2.Text = _cfg.ParityFile2;
                    parityLocation3.Text = _cfg.ParityFile3;
                    parityLocation4.Text = _cfg.ParityFile4;
                    parityLocation5.Text = _cfg.ParityFile5;
                    parityLocation6.Text = _cfg.ParityFile6;
                }

                UnsavedChangesMade = false;

                driveSpace.StartProcessing(GetPathsOfInterestFromForm());
            }
            catch (Exception)
            {
                MessageBox.Show(@"Failed to read config file.", @"Config File");
            }
        }

        private List<CoveragePath> GetPathsOfInterestFromForm()
        {
            try
            {
                List<string> paths = (from TreeNode node in snapShotSourcesTreeView.Nodes select node.Text).ToList();

                List<CoveragePath> pathsOfInterest = paths.Select(
                    path => new CoveragePath
                    {
                        FullPath = path,
                        PathType = PathTypeEnum.Source
                    }).ToList();

                if (!string.IsNullOrEmpty(parityLocation1.Text))
                {
                    pathsOfInterest.Add(new CoveragePath
                    {
                        FullPath = Path.GetFullPath(parityLocation1.Text),
                        PathType = PathTypeEnum.Parity
                    });
                }

                if (!string.IsNullOrEmpty(parityLocation2.Text))
                {
                    pathsOfInterest.Add(new CoveragePath
                    {
                        FullPath = Path.GetFullPath(parityLocation2.Text),
                        PathType = PathTypeEnum.Parity
                    });
                }

                if (!string.IsNullOrEmpty(parityLocation3.Text))
                {
                    pathsOfInterest.Add(new CoveragePath
                    {
                        FullPath = Path.GetFullPath(parityLocation3.Text),
                        PathType = PathTypeEnum.Parity
                    });
                }

                if (!string.IsNullOrEmpty(parityLocation4.Text))
                {
                    pathsOfInterest.Add(new CoveragePath
                    {
                        FullPath = Path.GetFullPath(parityLocation4.Text),
                        PathType = PathTypeEnum.Parity
                    });
                }

                if (!string.IsNullOrEmpty(parityLocation5.Text))
                {
                    pathsOfInterest.Add(new CoveragePath
                    {
                        FullPath = Path.GetFullPath(parityLocation5.Text),
                        PathType = PathTypeEnum.Parity
                    });
                }

                if (!string.IsNullOrEmpty(parityLocation6.Text))
                {
                    pathsOfInterest.Add(new CoveragePath
                    {
                        FullPath = Path.GetFullPath(parityLocation6.Text),
                        PathType = PathTypeEnum.Parity
                    });
                }

                Util.Dump(pathsOfInterest.OrderBy(s => s.FullPath).DistinctBy(s => s.Drive).ToList());

                return pathsOfInterest.OrderBy(s => s.FullPath).DistinctBy(s => s.Drive).ToList();
            }
            catch
            {
                // ignored
            }

            return null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (errorProvider1.GetErrorCount() > 0)
                {
                    MessageBoxExt.Show(
                        this, 
                        @"Configuration errors still exist.", 
                        "Unable to save configuration", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Exclamation);
                    return;
                }

                ConfigFileHelper cfgToSave = new ConfigFileHelper(configFileLocation.Text)
                {
                    IncludePatterns = IncludePatterns,
                    BlockSizeKB = (uint)numBlockSizeKB.Value,
                    Nohidden = _advSettingsList[ConfigFileHelper.CHECKBOX_HIDDEN_FILES_EXCLUDED].CheckState,
                    AutoSaveGB = (uint)numAutoSaveGB.Value
                };

                cfgToSave.ExcludePatterns.Clear();
                cfgToSave.SnapShotSources.Clear();
                cfgToSave.ContentFiles.Clear();

                foreach (DataGridViewRow row in exludedFilesView.Rows)
                {
                    string value = $"{row.Cells[0].Value}";
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        cfgToSave.ExcludePatterns.Add(value);
                    }
                }

                foreach (string text in snapShotSourcesTreeView.Nodes.Cast<TreeNode>().Select(node => node.Text)
                    .Where(text => !string.IsNullOrWhiteSpace(text)))
                {
                    cfgToSave.SnapShotSources.Add(text);
                    cfgToSave.ContentFiles.Add(text);
                }

                switch (!string.IsNullOrEmpty(parityLocation1.Text.Trim()))
                {
                    case true:

                        string trim1 = parityLocation1.Text.Trim();
                        cfgToSave.ParityFile1 = trim1;
                        if (string.IsNullOrEmpty(trim1))
                        {
                            break;
                        }

                        Util.CreateFullDirectoryPath(trim1);
                        cfgToSave.ContentFiles.Add(Path.GetDirectoryName(trim1));

                        string trim2 = parityLocation2.Text.Trim();
                        cfgToSave.ParityFile2 = trim2;
                        if (string.IsNullOrEmpty(trim2))
                        {
                            break;
                        }

                        Util.CreateFullDirectoryPath(trim2);
                        cfgToSave.ContentFiles.Add(Path.GetDirectoryName(trim2));

                        string trim3 = parityLocation3.Text.Trim();
                        cfgToSave.ParityFile3 = trim3;
                        if (string.IsNullOrEmpty(trim3))
                        {
                            break;
                        }

                        Util.CreateFullDirectoryPath(trim3);
                        cfgToSave.ContentFiles.Add(Path.GetDirectoryName(trim3));

                        string trim4 = parityLocation4.Text.Trim();
                        cfgToSave.ParityFile4 = trim4;
                        if (string.IsNullOrEmpty(trim4))
                        {
                            break;
                        }

                        Util.CreateFullDirectoryPath(trim4);
                        cfgToSave.ContentFiles.Add(Path.GetDirectoryName(trim4));

                        string trim5 = parityLocation5.Text.Trim();
                        cfgToSave.ParityFile5 = trim5;
                        if (string.IsNullOrEmpty(trim5))
                        {
                            break;
                        }

                        Util.CreateFullDirectoryPath(trim5);
                        cfgToSave.ContentFiles.Add(Path.GetDirectoryName(trim5));

                        string trim6 = parityLocation6.Text.Trim();
                        cfgToSave.ParityFile6 = trim6;
                        if (string.IsNullOrEmpty(trim6))
                        {
                            break;
                        }

                        Util.CreateFullDirectoryPath(trim6);
                        cfgToSave.ContentFiles.Add(Path.GetDirectoryName(trim6));

                        break;
                }

                // temp backup current config
                if (File.Exists(configFileLocation.Text))
                {
                    File.Copy(configFileLocation.Text, $"{configFileLocation.Text}.temp", overwrite: true);
                }

                string writeResult;

                if (!string.IsNullOrEmpty(writeResult = cfgToSave.Write()))
                {
                    MessageBoxExt.Show(
                        this, 
                        writeResult, 
                        "Config Write Error:", 
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    // save the Elucidate settings
                    Properties.Settings.Default.ConfigFileIsValid = ValidateFormData();
                    Properties.Settings.Default.SnapRAIDFileLocation = snapRAIDFileLocation.Text;
                    Properties.Settings.Default.ConfigFileLocation = configFileLocation.Text;
                    Properties.Settings.Default.IsDisplayOutputEnabled = _advSettingsList[ConfigFileHelper.CHECKBOX_DISPLAY_OUTPUT_ENABLED].CheckState;
                    Properties.Settings.Default.UseVerboseMode = _advSettingsList[ConfigFileHelper.CHECKBOX_USE_VERBOSE_MODE].CheckState;
                    Properties.Settings.Default.FindByNameInSync = _advSettingsList[ConfigFileHelper.CHECKBOX_FIND_BY_NAME_IN_SYNC].CheckState;
                    Properties.Settings.Default.HiddenFilesExcluded = _advSettingsList[ConfigFileHelper.CHECKBOX_HIDDEN_FILES_EXCLUDED].CheckState;

                    Properties.Settings.Default.DebugLoggingEnabled = _advSettingsList[ConfigFileHelper.CHECKBOX_DEBUG_LOGGING_ENABLED].CheckState;

                    Log.SetLogLevel(Log.LogLevels.Debug, Properties.Settings.Default.DebugLoggingEnabled);

                    Properties.Settings.Default.Save();

                    UnsavedChangesMade = false;

                    // keep config backup - by day, otherwise include minute, otherwise include second
                    string backupConfig = $"{configFileLocation.Text}.{DateTime.Now:yyyyMMdd}";

                    if (File.Exists(backupConfig))
                    {
                        backupConfig = $"{configFileLocation.Text}.{DateTime.Now:yyyyMMddmm}";
                    }

                    if (File.Exists(backupConfig))
                    {
                        backupConfig = $"{configFileLocation.Text}.{DateTime.Now:yyyyMMddmmss}";
                    }

                    if (!File.Exists($"{configFileLocation.Text}.temp"))
                    {
                        return;
                    }

                    File.Copy($"{configFileLocation.Text}.temp", backupConfig);

                    File.Delete($"{configFileLocation.Text}.temp");

                    driveSpace.RefreshGraph(GetPathsOfInterest());

                    OnConfigSaved(e);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.ReportException(ex, "Failed to save the config file.");
                Log.Instance.Error("Failed to save the config file.");
            }
        }
        
        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!UnsavedChangesMade || (e.CloseReason != CloseReason.UserClosing))
            {
                return;
            }

            if (DialogResult.No == MessageBoxExt.Show(
                    this, 
                    "You have made changes that have not been saved.\n\nDo you wish to discard and exit?",
                    "Settings have changed..", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question)
                )
            {
                e.Cancel = true;
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            UnsavedChangesMade = true;
            _advSettingsList[e.Index].CheckState = (e.NewValue == CheckState.Checked);
        }

        private void findParity1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            parityLocation1.Text = folderBrowserDialog1.SelectedPath;

            ValidateParityTextBox();

            ParityLocationChanged();
        }

        private void findParity2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            parityLocation2.Text = folderBrowserDialog1.SelectedPath;

            ValidateParityTextBox();

            ParityLocationChanged();
        }

        private void findParity3_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            parityLocation3.Text = folderBrowserDialog1.SelectedPath;

            ValidateParityTextBox();

            ParityLocationChanged();
        }

        private void findParity4_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            parityLocation4.Text = folderBrowserDialog1.SelectedPath;

            ValidateParityTextBox();

            ParityLocationChanged();
        }

        private void findParity5_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            parityLocation5.Text = folderBrowserDialog1.SelectedPath;

            ValidateParityTextBox();

            ParityLocationChanged();
        }

        private void findParity6_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            parityLocation6.Text = folderBrowserDialog1.SelectedPath;
                
            ValidateParityTextBox();

            ParityLocationChanged();
        }

        private void checkedListBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //Make ttIndex a global integer variable to store index of item currently showing tooltip.
            //Check if current location is different from item having tooltip, if so call method
            if (_ttIndex != checkedListBox1.IndexFromPoint(e.Location))
            {
                ShowToolTip();
            }
        }

        private void ShowToolTip()
        {
            _ttIndex = checkedListBox1.IndexFromPoint(checkedListBox1.PointToClient(MousePosition));

            if (_ttIndex <= -1)
            {
                return;
            }

            PointToClient(MousePosition);

            toolTip1.ToolTipTitle = _advSettingsList[_ttIndex].DisplayName;

            toolTip1.SetToolTip(checkedListBox1, _advSettingsList[_ttIndex].TootTip);
        }

        private void btnGetRecommended_Click(object sender, EventArgs e)
        {
            CalculateBlockSize calc = new CalculateBlockSize();

            List<string> snaps = snapShotSourcesTreeView.Nodes.Cast<TreeNode>().Select(node => node.Text).Where(text => !string.IsNullOrWhiteSpace(text)).ToList();

            calc.SnapShotSources = snaps;

            string trim1 = parityLocation1.Text.Trim();

            if (!string.IsNullOrEmpty(trim1))
            {
                calc.ParityTargets.Add(trim1);

                string trim2 = parityLocation2.Text.Trim();

                if (!string.IsNullOrEmpty(trim2))
                {
                    calc.ParityTargets.Add(trim2);
                }
            }

            calc.ShowDialog(this);
        }

        private void numBlockSizeKB_ValueChanged(object sender, EventArgs e)
        {
            UnsavedChangesMade = true;
            if (numBlockSizeKB.Value < Constants.MinBlockSize)
            {
                numBlockSizeKB.Value = Constants.MinBlockSize;
            }

            if (numBlockSizeKB.Value > Constants.MaxBlockSize)
            {
                numBlockSizeKB.Value = Constants.MaxBlockSize;
            }
        }

        private void numAutoSaveGB_ValueChanged(object sender, EventArgs e)
        {
            UnsavedChangesMade = true;
            if (numAutoSaveGB.Value < Constants.MinAutoSave)
            {
                numBlockSizeKB.Value = Constants.MinAutoSave;
            }

            if (numAutoSaveGB.Value > Constants.MaxAutoSave)
            {
                numBlockSizeKB.Value = Constants.MaxAutoSave;
            }
        }

        private void parityLocation1_Leave(object sender, EventArgs e)
        {
            if (!(sender is TextBox textBox))
            {
                return;
            }

            ValidateParityTextBox();

            if (textBox.Text.Trim() == _cfg.ParityFile1)
            {
                return;
            }

            ParityLocationChanged();
        }

        private void parityLocation2_Leave(object sender, EventArgs e)
        {
            if (!(sender is TextBox textBox))
            {
                return;
            }

            ValidateParityTextBox();

            if (textBox.Text.Trim() == _cfg.ParityFile2)
            {
                return;
            }

            ParityLocationChanged();

            string tooltip = "Optional disk failure protection root location.";
            if (!string.IsNullOrEmpty(textBox.Text) && !File.Exists(textBox.Text))
            {
                tooltip = "To add an additional parity drive you will need to run the \"fix\" command.";
            }
            toolTip1.SetToolTip(parityLocation2, tooltip);
            toolTip1.SetToolTip(findParity2, tooltip);
            toolTip1.SetToolTip(labelParity2, tooltip);
        }

        private void parityLocation3_Leave(object sender, EventArgs e)
        {
            if (!(sender is TextBox textBox))
            {
                return;
            }

            ValidateParityTextBox();

            if (textBox.Text.Trim() == _cfg.ParityFile3)
            {
                return;
            }

            ParityLocationChanged();

            string tooltip = "Optional disk failure protection root location.";
            if (!string.IsNullOrEmpty(textBox.Text) && !File.Exists(textBox.Text))
            {
                tooltip = "To add an additional parity drive you will need to run the \"fix\" command.";
            }
            toolTip1.SetToolTip(parityLocation3, tooltip);
            toolTip1.SetToolTip(findParity3, tooltip);
            toolTip1.SetToolTip(labelParity3, tooltip);
        }

        private void parityLocation4_Leave(object sender, EventArgs e)
        {
            if (!(sender is TextBox textBox))
            {
                return;
            }

            ValidateParityTextBox();
            
            if (textBox.Text.Trim() == _cfg.ParityFile4)
            {
                return;
            }

            ParityLocationChanged();

            string tooltip = "Optional disk failure protection root location.";
            if (!string.IsNullOrEmpty(textBox.Text) && !File.Exists(textBox.Text))
            {
                tooltip = "To add an additional parity drive you will need to run the \"fix\" command.";
            }
            toolTip1.SetToolTip(parityLocation4, tooltip);
            toolTip1.SetToolTip(findParity4, tooltip);
            toolTip1.SetToolTip(labelParity4, tooltip);
        }
        
        private void parityLocation5_Leave(object sender, EventArgs e)
        {
            if (!(sender is TextBox textBox))
            {
                return;
            }

            ValidateParityTextBox();

            if (textBox.Text.Trim() == _cfg.ParityFile5)
            {
                return; // unchanged
            }

            ParityLocationChanged();

            string tooltip = "Optional disk failure protection root location.";
            if (!string.IsNullOrEmpty(textBox.Text) && !File.Exists(textBox.Text))
            {
                tooltip = "To add an additional parity drive you will need to run the \"fix\" command.";
            }
            toolTip1.SetToolTip(parityLocation5, tooltip);
            toolTip1.SetToolTip(findParity5, tooltip);
            toolTip1.SetToolTip(labelParity5, tooltip);
        }

        private void parityLocation6_Leave(object sender, EventArgs e)
        {
            if (!(sender is TextBox textBox))
            {
                return;
            }

            ValidateParityTextBox();

            if (textBox.Text.Trim() == _cfg.ParityFile6)
            {
                return;
            }

            ParityLocationChanged();

            string tooltip = "Optional disk failure protection root location.";
            if (!string.IsNullOrEmpty(textBox.Text) && !File.Exists(textBox.Text))
            {
                tooltip = "To add an additional parity drive you will need to run the \"fix\" command.";
            }
            toolTip1.SetToolTip(parityLocation6, tooltip);
            toolTip1.SetToolTip(findParity6, tooltip);
            toolTip1.SetToolTip(labelParity6, tooltip);
        }
        
        private void ValidateParityTextBox()
        {
            IOrderedEnumerable<TextBox> parityTextBoxes;
            List<TextBox> parityTextBoxesList = (parityTextBoxes = groupBox2.Controls.OfType<TextBox>().OrderBy(c => c.TabIndex)).ToList();

            string previous = null;

            foreach (TextBox item in parityTextBoxes)
            {
                errorProvider1.SetErrorWithCount(item, "");

                string current = item.Text.Trim();

                if (!ConfigFileHelper.IsRulePassPreviousCannotBeEmpty(previous, current))
                {
                    errorProvider1.SetErrorWithCount(item, "There cannot be empty parity locations between parity locations.");
                }

                if (!ConfigFileHelper.IsRulePassDevicesMustNotRepeat(parityTextBoxesList.Select(c => c.Text).ToList(), current))
                {
                    errorProvider1.SetErrorWithCount(item, "Only one device can be used per parity location.");
                }

                previous = current;
            }
        }

        private void ParityLocationChanged()
        {
            UnsavedChangesMade = true;

            driveSpace.StartProcessing(GetPathsOfInterestFromForm());
        }
    }
}