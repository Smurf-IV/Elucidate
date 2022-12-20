#region Copyright (C)
// ---------------------------------------------------------------------------------------------------------------
//  <copyright file="Settings.cs" company="Smurf-IV">
//
//  Copyright (C) 2010-2022 Simon Coghlan (Aka Smurf-IV) & BlueBlock 2018
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

using Elucidate.HelperClasses;
using Elucidate.Objects;
using Elucidate.Shared;

using Krypton.Toolkit;

using NLog;

namespace Elucidate.Forms
{
    public partial class Settings : KryptonForm
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        private bool unsavedChangesMade;
        private readonly IOrderedEnumerable<KryptonTextBox> parityTextBoxes;
        private readonly List<KryptonTextBox> parityTextBoxesList;

        private ConfigFileHelper cfg = new();

        private bool initializing = true;

        private bool UnsavedChangesMade
        {
            get => unsavedChangesMade;
            set
            {
                unsavedChangesMade = value;
                errorProvider1.SetError(btnSave, value ? "Changes have been made" : string.Empty);
            }
        }

        private readonly BindingList<AdvancedSettingsHelper> advSettingsList = new();

        private int ttIndex;

        public Settings()
        {
            // For some reason the designer keeps removing the following !!
            snapShotSources = new Controls.ProtectedDrivesDisplay();
            Icon = Properties.Resources.ElucidateIco;
            InitializeComponent();

            snapShotSources.driveGrid.DragDrop += snapShotSourcesTreeView_DragDrop;
            snapShotSources.driveGrid.DragOver += snapShotSourcesTreeView_DragOver;
            snapShotSources.driveGrid.CellEndEdit += DriveGridOnCellEndEdit;
            snapShotSources.driveGrid.DoubleClick += editName_Click;

            ResizeRedraw = true;
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            // Not currently editable here
            IncludePatterns = new List<string>();

            // Add some items to the data source.
            advSettingsList.Add(new AdvancedSettingsHelper(@"Display Output", Properties.Settings.Default.IsDisplayOutputEnabled, "Command output is displayed when enabled."));
            advSettingsList.Add(new AdvancedSettingsHelper(@"Verbose Output", Properties.Settings.Default.UseVerboseMode, "Displays more information while processing."));
            advSettingsList.Add(new AdvancedSettingsHelper(@"Find-By-Name in Sync", Properties.Settings.Default.FindByNameInSync, "Allow to sync using only the file path and not the inode (i.e. source drive / directory), but the files themselves are the same (path/filename, size, ctime), and you do not want to waste time resyncing the files.\nThis option is also used after you have lost a drive, restored the files to a new drive, and you want to do a fast sync.\n\"Forced dangerous operation\" of synching a rewritten disk."));
            advSettingsList.Add(new AdvancedSettingsHelper(@"Hidden files excluded", Properties.Settings.Default.HiddenFilesExcluded, "Option to exclude \"hidden\" files and directories.\nIn Windows files with the HIDDEN attributes, in Unix files starting with \'.\'."));
            advSettingsList.Add(new AdvancedSettingsHelper(@"Debug Log Output", Properties.Settings.Default.DebugLoggingEnabled, "Option to include debug log output for troubleshooting Elucidate."));

            // Binding 'trick'.
            checkedListBox1.ListBox.DataSource = advSettingsList;
            checkedListBox1.ListBox.DisplayMember = "DisplayName";
            var offset = 0;
            foreach (AdvancedSettingsHelper helper in advSettingsList)
            {
                checkedListBox1.SetItemCheckState(offset++, helper.CheckState ? CheckState.Checked : CheckState.Unchecked);
            }

            parityTextBoxesList = (parityTextBoxes = grpParityLocations.Panel.Controls.OfType<KryptonTextBox>().OrderBy(static c => c.TabIndex)).ToList();

            labelParity3_CheckedChanged(this, EventArgs.Empty);
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            StartTree();
            errorProvider1.Clear();
        }

        private void Settings_Shown(object sender, EventArgs e)
        {
            snapRAIDFileLocation.Text = Properties.Settings.Default.SnapRAIDFileLocation;

            configFileLocation.Text = Properties.Settings.Default.ConfigFileLocation;

            // Text change above will trigger a ReadConfigDetails()
            // ReadConfigDetails();

            UnsavedChangesMade = false;

            initializing = false;

            Properties.Settings.Default.ConfigFileIsValid = ValidateFormData();

            ValidateParityTextBoxes();
        }

        #region driveAndDirTreeView

        private void StartTree()
        {
            // Code taken and adapted from http://msdn.microsoft.com/en-us/library/bb513869.aspx
            try
            {
                UseWaitCursor = true;
                driveAndDirTreeView.Nodes.Clear();

                Log.Debug(@"Create the root node.");
                var tvwRoot = new TreeNode { Text = Environment.MachineName, ImageIndex = 0 };
                tvwRoot.SelectedImageIndex = tvwRoot.ImageIndex;
                driveAndDirTreeView.Nodes.Add(tvwRoot);
                Log.Debug(@"Now we need to add any children to the root node.");

                Log.Debug(@"Start with drives if you have to search the entire computer.");

                // retrieve all storage devices
                var storageDevices = StorageUtil.GetStorageDevices();
                foreach (StorageDevice storageDevice in storageDevices)
                {
                    FillInStorageDeviceDirectoryType(tvwRoot, storageDevice);
                }

                tvwRoot.Expand();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, @"StartTree Threw:");
            }
            finally
            {
                Enabled = true;
                UseWaitCursor = false;
            }
        }

        private static void FillInStorageDeviceDirectoryType(TreeNode parentNode, StorageDevice storageDevice)
        {
            if (storageDevice == null)
            {
                return;
            }

            var thisNode = new TreeNode
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
                Log.Info(@"The drive {1}:{0} could not be read.", storageDevice.Caption, storageDevice.DriveType);
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

            Log.Trace(@"Select the clicked node");

            driveAndDirTreeView.SelectedNode = driveAndDirTreeView.GetNodeAt(e.X, e.Y);
        }

        private void driveAndDirTreeView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            Log.Trace(@"Select the clicked node");

            TreeNode selected = driveAndDirTreeView.GetNodeAt(e.X, e.Y);

            driveAndDirTreeView.SelectedNode = selected;

            if (selected != null)
            {
                PerformSnapShotSourceAddNode(selected);
            }
        }

        private static string GetSelectedNodesPath(TreeNode selected)
        {
            Log.Trace(@"Now we need to add any children to the root node.");

            var newPath = selected.Tag is DirectoryInfo shNode ? shNode.FullName : selected.FullPath;

            return newPath;
        }

        private void PerformSnapShotSourceAddNode(TreeNode selected)
        {
            var newPath = GetSelectedNodesPath(selected);

            var newDevice = StorageUtil.GetPathRoot(newPath);

            if (string.IsNullOrWhiteSpace(newPath))
            {
                return;
            }

            if (!Directory.Exists(newPath))
            {
                Log.Warn($"Data source not added. Path does not exist. Attempted to add [{newPath}]");
                KryptonMessageBox.Show(this,
                    $"Path does not exist.\nAttempted to add:\n [{newPath}]",
                    "Source not added", MessageBoxButtons.OK, KryptonMessageBoxIcon.Exclamation);
                return;
            }

            // check if device is already added by an existing entry; a device cannot be entered more than once
            foreach (DataGridViewRow row in snapShotSources.driveGrid.Rows)
            {
                if (row.Tag is CoveragePath coveragePath)
                {
                    var nodeDevice = StorageUtil.GetPathRoot(coveragePath.FullPath);

                    Log.Trace($"adding new node, so compare, nodeDevice = {nodeDevice}");

                    if (newDevice == nodeDevice)
                    {

                        Log.Warn(
                            $"Data source not added. The path is on a device for an existing path. Attempted to add [{newPath}] which is on the same device as the existing path [{coveragePath.FullPath}]");

                        KryptonMessageBox.Show(this,
                            $"Attempted to add:\n [{newPath}]\n\nWhich is on the same device as the existing device path:\n [{coveragePath.FullPath}]",
                            "Source not added", MessageBoxButtons.OK, KryptonMessageBoxIcon.Exclamation);

                        return;
                    }
                }
            }

            snapShotSources.AddCoverage(new CoveragePath
            {
                FullPath = newPath,
                Name = $@"d{snapShotSources.driveGrid.Rows.Count}",
                PathType = PathTypeEnum.Source
            });
            //snapShotSourcesTreeView.Nodes.Add(new TreeNode(newPath, selected.ImageIndex, selected.ImageIndex));

            UnsavedChangesMade = true;
        }

        private void refreshStripMenuItem_Click(object sender, EventArgs e)
        {
            StartTree();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TreeNode selected = driveAndDirTreeView.SelectedNode;
            if (selected != null)
            {
                PerformSnapShotSourceAddNode(selected);
            }
        }

        private void driveAndDirTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                Log.Trace(@"Remove the placeholder node.");

                if (e.Node.Tag is DirectoryInfo)
                {
                    e.Node.Nodes.Clear();
                    WalkNextTreeLevel(e.Node);
                }
                e.Cancel = false;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex);
            }
        }

        private static void WalkNextTreeLevel(TreeNode parentNode)
        {
            try
            {
                if (parentNode.Tag is not DirectoryInfo root)
                {
                    return;
                }

                Log.Trace(@"// Find all the subdirectories under this directory.");

                var subDirs = root.GetDirectories()
                                                .Where(static dir => (dir.Attributes & FileAttributes.System) == 0
                                                                        && (dir.Attributes & FileAttributes.Hidden) == 0)
                                                .ToArray();

                if (!subDirs.Any())
                {
                    return;
                }

                foreach (DirectoryInfo dirInfo in subDirs)
                {
                    // Recursive call for each subdirectory.

                    var tvwChild = new TreeNode
                    {
                        Text = dirInfo.Name,
                        SelectedImageIndex = 8,
                        ImageIndex = 7,
                        Tag = dirInfo
                    };

                    Log.Trace(@"If this is a folder item and has children then add a place holder node.");

                    try
                    {
                        var subChildDirs = dirInfo.GetDirectories()
                            .Where(static dir => (dir.Attributes & FileAttributes.System) == 0
                                                 && (dir.Attributes & FileAttributes.Hidden) == 0)
                            .ToArray();

                        if (subChildDirs.Any())
                        {
                            tvwChild.Nodes.Add("PH");
                        }
                    }
                    catch (UnauthorizedAccessException uaex)
                    {
                        Log.Info(uaex, @"No Access to subdirs in [{0}]", tvwChild.Text);
                    }

                    parentNode.Nodes.Add(tvwChild);
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex);
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
            DataGridViewRow selected = snapShotSources.driveGrid.SelectedRows[0];
            if ((selected != null)
                && (selected.Index < snapShotSources.driveGrid.RowCount)
                )
            {
                snapShotSources.driveGrid.Rows.RemoveAt(selected.Index);
                UnsavedChangesMade = true;
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
            var fsd = new FolderSelectDialog
            {
                Title = @"Select the Target Directory"
            };

            if (!fsd.ShowDialog(this))
            {
                return;
            }

            var dirInfo = new DirectoryInfo(fsd.FileName);

            var tvwChild = new TreeNode
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

        private void editName_Click(object sender, EventArgs e)
        {
            DataGridViewRow selected = snapShotSources.driveGrid.SelectedRows[0];
            if ((selected != null)
                && (selected.Index < snapShotSources.driveGrid.RowCount)
            )
            {
                if (DialogResult.Yes == KryptonMessageBox.Show(this,
                        "Changing a 'Name' will require a 'Full Sync' to be run.\nDo you wish to continue?",
                        @"Name Change Warning", MessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question))
                {
                    DataGridViewCell cell = selected.Cells[1];
                    snapShotSources.driveGrid.CurrentCell = cell;
                    snapShotSources.driveGrid.BeginEdit(true);
                }
            }
            else
            {
                SystemSounds.Beep.Play();
            }

            ValidateFormData();
        }

        private void DriveGridOnCellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 1)
            {
                return;
            }
            DataGridViewRow selected = snapShotSources.driveGrid.Rows[e.RowIndex];
            CoveragePath coveragePath = selected.Tag as CoveragePath;
            var value = (string)selected.Cells[1].Value;
            if (coveragePath.Name != value)
            {
                coveragePath.Name = value;
                UnsavedChangesMade = true;
            }
        }

        #endregion snapShotSourcesTreeView

        private bool ValidateFormData()
        {
            errorProvider1.Clear();

            if (initializing)
            {
                return true;
            }

            var isValid = true;

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
            if (snapShotSources.driveGrid.Rows.Count == 0)
            {
                isValid = false;
                errorProvider1.SetIconAlignment(snapShotSources, ErrorIconAlignment.TopLeft);
                errorProvider1.SetIconPadding(snapShotSources, -20);
                errorProvider1.SetError(snapShotSources, "No protected regions set!");
            }

            var deviceList = new List<string>();

            foreach (DataGridViewRow row in snapShotSources.driveGrid.Rows)
            {
                if (row.Tag is CoveragePath coveragePath)
                {
                    var errMsg = string.Empty;

                    // test if device already exists in list; SnapRAID only permits one device entry per device
                    if (deviceList.Contains(StorageUtil.GetPathRoot(coveragePath.FullPath)))
                    {
                        errMsg = $"{coveragePath.FullPath} A device may only appear once in the data source list!";
                    }

                    deviceList.Add(StorageUtil.GetPathRoot(coveragePath.FullPath));

                    // test if path exists
                    if (!Directory.Exists(coveragePath.FullPath))
                    {
                        errMsg = "Data source is inaccessible!";
                    }

                    if (string.IsNullOrEmpty(errMsg))
                    {
                        continue;
                    }

                    isValid = false;
                    row.ErrorText = errMsg;
                }
            }

            return isValid;
        }

        private void findExeFile_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog()
            {
                InitialDirectory = Path.GetFullPath(snapRAIDFileLocation.Text),
                Filter = @"Snap Raid application|SnapRAID.exe",
                CheckFileExists = true,
                RestoreDirectory = true
            };
            Log.Info(@"snapRAIDFileLocation from [{0}]", ofd.InitialDirectory);

            if (DialogResult.OK == ofd.ShowDialog())
            {
                snapRAIDFileLocation.Text = Path.GetFullPath(ofd.FileName);
                UnsavedChangesMade = true;
            }
        }

        private void snapRAIDFileLocation_TextChanged(object sender, EventArgs e)
        {
            UnsavedChangesMade = true;

            ValidateFormData();
        }

        private void findConfigFile_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog()
            {
                InitialDirectory = Path.GetFullPath(configFileLocation.Text),
                Filter = @"Snap Raid Config|*.conf*|All Files|*.*",
                CheckFileExists = true,
                RestoreDirectory = true
            };
            Log.Trace(@"configFileLocation from [{0}]", ofd.InitialDirectory);

            if (DialogResult.OK == ofd.ShowDialog())
            {
                configFileLocation.Text = Path.GetFullPath(ofd.FileName);
            }
        }

        private void configFileLocation_TextChanged(object sender, EventArgs e)
        {
            ReadConfigDetails(configFileLocation.Text);

            ValidateFormData();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ReadConfigDetails(Properties.Settings.Default.ConfigFileLocation);

            ValidateFormData();
        }

        private void ReadConfigDetails(string fileToLoad)
        {
            try
            {
                exludedFilesView.Rows.Clear();


                cfg = new ConfigFileHelper(fileToLoad);

                if (!cfg.ConfigFileExists)
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
                        exludedFilesView.Rows.Add(@"\Program Files (x86)\");
                        exludedFilesView.Rows.Add(@"\Windows\");
                        exludedFilesView.Rows.Add(@"\Windows.old\");
                    }
                    else
                    {
                        exludedFilesView.Rows.Add(@"/lost+found/");
                        exludedFilesView.Rows.Add(@"/tmp/");
                    }
                }
                else
                {
                    if (!cfg.Read())
                    {
                        KryptonMessageBox.Show(
                            this,
                            @"Failed to read the config file.",
                            @"Config Read Error:",
                            MessageBoxButtons.OK,
                            KryptonMessageBoxIcon.Error);
                        return;
                    }

                    snapShotSources.RefreshGrid(cfg, true);

                    IncludePatterns = cfg.IncludePatterns;

                    numBlockSizeKB.Value = cfg.BlockSizeKB;

                    advSettingsList[ConfigFileHelper.CHECKBOX_HIDDEN_FILES_EXCLUDED].CheckState = cfg.Nohidden;

                    numAutoSaveGB.Value = cfg.AutoSaveGB;

                    foreach (var excludePattern in cfg.ExcludePatterns.Where(static excludePattern => !string.IsNullOrWhiteSpace(excludePattern)))
                    {
                        exludedFilesView.Rows.Add(excludePattern);
                    }

                    parityLocation1.Text = cfg.ParityFile1;
                    parityLocation2.Text = cfg.ParityFile2;
                    if (!string.IsNullOrWhiteSpace(cfg.ZParityFile))
                    {
                        labelParity3.Checked = true;
                        parityLocation3.Text = cfg.ZParityFile;
                    }
                    else
                    {
                        parityLocation3.Text = cfg.ParityFile3;
                    }

                    parityLocation4.Text = cfg.ParityFile4;
                    parityLocation5.Text = cfg.ParityFile5;
                    parityLocation6.Text = cfg.ParityFile6;

                    labelParity3_CheckedChanged(this, EventArgs.Empty); // force disabling fields
                }

                UnsavedChangesMade = false;

            }
            catch (Exception ex)
            {
                Log.Error(ex, @"Failed to read config file.[{0}]", fileToLoad);
                KryptonMessageBox.Show(this, ex.Message, $"Failed to read config file.\n[{fileToLoad}");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (errorProvider1.GetErrorCount() > 0)
                {
                    KryptonMessageBox.Show(
                        this,
                        @"Configuration errors still exist.",
                        "Unable to save configuration",
                        MessageBoxButtons.OK,
                        KryptonMessageBoxIcon.Exclamation);
                    return;
                }

                var cfgToSave = new ConfigFileHelper()
                {
                    IncludePatterns = IncludePatterns,
                    BlockSizeKB = (uint)numBlockSizeKB.Value,
                    Nohidden = advSettingsList[ConfigFileHelper.CHECKBOX_HIDDEN_FILES_EXCLUDED].CheckState,
                    AutoSaveGB = (uint)numAutoSaveGB.Value
                };

                foreach (var value in exludedFilesView.Rows.Cast<DataGridViewRow>()
                    .Select(static row => $"{row.Cells[0].Value}")
                    .Where(static value => !string.IsNullOrWhiteSpace(value))
                    )
                {
                    cfgToSave.ExcludePatterns.Add(value);
                }

                foreach (DataGridViewRow row in snapShotSources.driveGrid.Rows)
                {
                    if (row.Tag is CoveragePath coveragePath)
                    {
                        cfgToSave.SnapShotSources.Add(new ConfigFileHelper.SnapShotSource
                        { Name = coveragePath.Name, DirSource = coveragePath.FullPath });
                        cfgToSave.ContentFiles.Add(coveragePath.FullPath);
                    }
                }

                // Do not force ContentFiles creation on parity locations
                var paths = parityTextBoxesList.Select(static c => c.Text).ToList();
                cfgToSave.ParityFile1 = paths[0].Trim();    // Must have at least one to use this!

                if (string.IsNullOrWhiteSpace(paths[1])) goto doneParity;
                cfgToSave.ParityFile2 = paths[1].Trim();

                if (string.IsNullOrWhiteSpace(paths[2])) goto doneParity;
                if (labelParity3.Checked)
                {
                    cfgToSave.ZParityFile = paths[2].Trim();
                    cfgToSave.ParityFile3 = string.Empty;
                }
                else
                {
                    cfgToSave.ZParityFile = string.Empty;
                    cfgToSave.ParityFile3 = paths[2].Trim();
                }

                if (string.IsNullOrWhiteSpace(paths[3])) goto doneParity;
                cfgToSave.ParityFile4 = paths[3].Trim();

                if (string.IsNullOrWhiteSpace(paths[4])) goto doneParity;
                cfgToSave.ParityFile5 = paths[4].Trim();

                if (string.IsNullOrWhiteSpace(paths[5])) goto doneParity;
                cfgToSave.ParityFile6 = paths[5].Trim();
                doneParity:

                // temp backup current config
                if (File.Exists(configFileLocation.Text))
                {
                    File.Copy(configFileLocation.Text, $"{configFileLocation.Text}.temp", overwrite: true);
                }

                string writeResult;

                if (!string.IsNullOrEmpty(writeResult = cfgToSave.Write(configFileLocation.Text)))
                {
                    KryptonMessageBox.Show(
                        this,
                        writeResult,
                        "Config Write Error:",
                        MessageBoxButtons.OK,
                        KryptonMessageBoxIcon.Error);
                }
                else
                {
                    // save the Elucidate settings
                    Properties.Settings.Default.ConfigFileIsValid = ValidateFormData();
                    Properties.Settings.Default.SnapRAIDFileLocation = snapRAIDFileLocation.Text;
                    Properties.Settings.Default.ConfigFileLocation = configFileLocation.Text;
                    Properties.Settings.Default.IsDisplayOutputEnabled = advSettingsList[ConfigFileHelper.CHECKBOX_DISPLAY_OUTPUT_ENABLED].CheckState;
                    Properties.Settings.Default.UseVerboseMode = advSettingsList[ConfigFileHelper.CHECKBOX_USE_VERBOSE_MODE].CheckState;
                    Properties.Settings.Default.FindByNameInSync = advSettingsList[ConfigFileHelper.CHECKBOX_FIND_BY_NAME_IN_SYNC].CheckState;
                    Properties.Settings.Default.HiddenFilesExcluded = advSettingsList[ConfigFileHelper.CHECKBOX_HIDDEN_FILES_EXCLUDED].CheckState;

                    Properties.Settings.Default.DebugLoggingEnabled = advSettingsList[ConfigFileHelper.CHECKBOX_DEBUG_LOGGING_ENABLED].CheckState;

                    Properties.Settings.Default.Save();

                    UnsavedChangesMade = false;

                    // keep config backup - by day, otherwise include minute, otherwise include second
                    var backupConfig = $"{configFileLocation.Text}.{DateTime.Now:yyyyMMdd}";

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

                    //driveSpace.RefreshGraph(GetPathsOfInterest());
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, @"Failed to save the config file.");
            }
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!UnsavedChangesMade || (e.CloseReason != CloseReason.UserClosing))
            {
                return;
            }

            if (DialogResult.No == KryptonMessageBox.Show(
                    this,
                    "You have made changes that have not been saved.\n\nDo you wish to discard and exit?",
                    "Settings have changed..",
                    MessageBoxButtons.YesNo,
                    KryptonMessageBoxIcon.Question)
                )
            {
                e.Cancel = true;
            }
            else
            {
                snapShotSources.StopProcessing();
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            UnsavedChangesMade = true;
            advSettingsList[e.Index].CheckState = (e.NewValue == CheckState.Checked);
        }

        private void findParity1_Click(object sender, EventArgs e)
        {
            FindParityFor(parityLocation1, findParity1, labelParity1, cfg.ParityFile1);
        }

        private void FindParityFor(KryptonTextBox parityLocation, KryptonButton findParity, KryptonLabel labelParity,
            string cfgParityFile)
        {
            var fsd = new FolderSelectDialog
            {
                Title = @"Select the Target Directory"
            };
            if (fsd.ShowDialog(this))
            {
                if (parityLocation.Text.Trim().EndsWith(","))
                {
                    parityLocation.Text += fsd.FileName;
                }
                else
                {
                    parityLocation.Text = fsd.FileName;
                }

                ValidateParityTextBoxes();
                UpdateParityTooltip(parityLocation, findParity, labelParity, cfgParityFile);
            }
        }

        private void UpdateParityTooltip(KryptonTextBox parityLocation, KryptonButton findParity,
            KryptonLabel labelParity, string cfgParityFile)
        {
            if (parityLocation.Text != cfgParityFile)
            {
                UnsavedChangesMade = true;
                parityLocation.ToolTipValues.Description =
                    @"To add an additional parity drive you will need to run the ""fix"" command.";
                findParity.ToolTipValues.Description =
                    @"To add an additional parity drive you will need to run the ""fix"" command.";
                labelParity.ToolTipValues.Description =
                    @"To add an additional parity drive you will need to run the ""fix"" command.";
            }
        }

        private void findParity2_Click(object sender, EventArgs e)
        {
            FindParityFor(parityLocation2, findParity2, labelParity2, cfg.ParityFile2);
        }

        private void findParity3_Click(object sender, EventArgs e)
        {
            // There is not labelParity3 so pass in labelParity4!
            FindParityFor(parityLocation3, findParity3, labelParity4, (labelParity3.Checked ? cfg.ZParityFile : cfg.ParityFile3));
        }

        private void findParity4_Click(object sender, EventArgs e)
        {
            FindParityFor(parityLocation4, findParity4, labelParity4, cfg.ParityFile4);
        }

        private void findParity5_Click(object sender, EventArgs e)
        {
            FindParityFor(parityLocation5, findParity5, labelParity5, cfg.ParityFile5);
        }

        private void findParity6_Click(object sender, EventArgs e)
        {
            FindParityFor(parityLocation6, findParity6, labelParity6, cfg.ParityFile6);
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

            if (ttIndex <= -1)
            {
                return;
            }

            PointToClient(MousePosition);

            toolTip1.ToolTipTitle = advSettingsList[ttIndex].DisplayName;

            toolTip1.SetToolTip(checkedListBox1, advSettingsList[ttIndex].TootTip);
        }

        private void btnGetRecommended_Click(object sender, EventArgs e)
        {
            var calc = new CalculateBlockSize();

            var snaps = new List<string>();
            foreach (DataGridViewRow row in snapShotSources.driveGrid.Rows)
            {
                if (row.Tag is CoveragePath coveragePath)
                {
                    snaps.Add(coveragePath.FullPath);
                }
            }

            calc.SnapShotSources = snaps;

            var trim1 = parityLocation1.Text.Trim();

            if (!string.IsNullOrEmpty(trim1))
            {
                calc.ParityTargets.Add(trim1);

                var trim2 = parityLocation2.Text.Trim();

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
            if (numBlockSizeKB.Value < Constants.MIN_BLOCK_SIZE)
            {
                numBlockSizeKB.Value = Constants.MIN_BLOCK_SIZE;
            }

            if (numBlockSizeKB.Value > Constants.MAX_BLOCK_SIZE)
            {
                numBlockSizeKB.Value = Constants.MAX_BLOCK_SIZE;
            }
        }

        private void numAutoSaveGB_ValueChanged(object sender, EventArgs e)
        {
            UnsavedChangesMade = true;
            if (numAutoSaveGB.Value < Constants.MIN_AUTO_SAVE)
            {
                numBlockSizeKB.Value = Constants.MIN_AUTO_SAVE;
            }

            if (numAutoSaveGB.Value > Constants.MAX_AUTO_SAVE)
            {
                numBlockSizeKB.Value = Constants.MAX_AUTO_SAVE;
            }
        }

        private void parityLocation1_Leave(object sender, EventArgs e)
        {
            ValidateParityTextBoxes();
            FindParityFor(parityLocation1, findParity1, labelParity1, cfg.ParityFile1);
        }

        private void parityLocation2_Leave(object sender, EventArgs e)
        {
            ValidateParityTextBoxes();
            UpdateParityTooltip(parityLocation2, findParity2, labelParity2, cfg.ParityFile2);
        }

        private void parityLocation3_Leave(object sender, EventArgs e)
        {
            ValidateParityTextBoxes();
            UpdateParityTooltip(parityLocation2, findParity2, labelParity2, (labelParity3.Checked ? cfg.ZParityFile : cfg.ParityFile3));
        }

        private void parityLocation4_Leave(object sender, EventArgs e)
        {
            ValidateParityTextBoxes();
            UpdateParityTooltip(parityLocation4, findParity4, labelParity4, cfg.ParityFile4);
        }

        private void parityLocation5_Leave(object sender, EventArgs e)
        {
            ValidateParityTextBoxes();
            UpdateParityTooltip(parityLocation5, findParity5, labelParity5, cfg.ParityFile5);
        }

        private void parityLocation6_Leave(object sender, EventArgs e)
        {
            ValidateParityTextBoxes();
            UpdateParityTooltip(parityLocation6, findParity6, labelParity6, cfg.ParityFile6);
        }

        private void ValidateParityTextBoxes()
        {
            var paths = parityTextBoxesList.Select(static c => c.Text).ToList();
            string previous = null;

            foreach (KryptonTextBox item in parityTextBoxes)
            {
                errorProvider1.SetErrorWithCount(item, "");

                var current = item.Text.Trim();

                if (!ConfigFileHelper.IsRulePassPreviousCannotBeEmpty(previous, current))
                {
                    errorProvider1.SetErrorWithCount(item, "There cannot be empty parity locations between parity locations.");
                }

                if (!ConfigFileHelper.IsRulePassDevicesMustNotRepeat(paths, current))
                {
                    errorProvider1.SetErrorWithCount(item, "Only one device can be used per parity location.");
                }

                previous = current;
            }
        }

        private void labelParity3_CheckedChanged(object sender, EventArgs e)
        {
            var enableOthers = !labelParity3.Checked;
            labelParity4.Enabled = enableOthers;
            parityLocation4.Enabled = enableOthers;
            findParity4.Enabled = enableOthers;
            labelParity5.Enabled = enableOthers;
            parityLocation5.Enabled = enableOthers;
            findParity5.Enabled = enableOthers;
            labelParity6.Enabled = enableOthers;
            parityLocation6.Enabled = enableOthers;
            findParity6.Enabled = enableOthers;
            if (!enableOthers)
            {
                parityLocation4.Text = string.Empty;
                parityLocation5.Text = string.Empty;
                parityLocation6.Text = string.Empty;
            }
        }
    }
}