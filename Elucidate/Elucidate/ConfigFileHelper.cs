#region Copyright (C)

// ---------------------------------------------------------------------------------------------------------------
//  Forked by BlueBlock on July 28th, 2018
// ---------------------------------------------------------------------------------------------------------------
//  <copyright file="ConfigHelper.cs" company="Smurf-IV">
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
using System.IO;
using System.Linq;
using System.Text;
using Elucidate.HelperClasses;
using Elucidate.Logging;
using MoreLinq.Extensions;

namespace Elucidate
{
    public class ConfigFileHelper
    {
        public bool IsValid { get; set; }
        public string ConfigPath { get; set; }

        public bool ConfigFileExists => File.Exists(ConfigPath);

        private readonly string[] _validConfigNames =
        {
            "parity",
            "2-parity",
            "q-parity",
            "content",
            "disk",
            "nohidden",
            "exclude",
            "block_size",
            "hashsize",
            "autosave",
            "pool",
            "share",
            "smartctl"
        };

        // ReSharper disable once InconsistentNaming
        public const int CHECKBOX_DISPLAY_OUTPUT_ENABLED = 0;
        // ReSharper disable once InconsistentNaming
        public const int CHECKBOX_USE_VERBOSE_MODE = 1;
        // ReSharper disable once InconsistentNaming
        public const int CHECKBOX_FIND_BY_NAME_IN_SYNC = 2;
        // ReSharper disable once InconsistentNaming
        public const int CHECKBOX_HIDDEN_FILES_EXCLUDED = 3;
        // ReSharper disable once InconsistentNaming
        public const int CHECKBOX_DEBUG_LOGGING_ENABLED = 4;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="configPath"></param>
        public ConfigFileHelper(string configPath = null)
        {
            ConfigPath = configPath;
            ContentFiles = new List<string>();
            SnapShotSources = new List<string>();
            ExcludePatterns = new List<string>();
            IncludePatterns = new List<string>();
            if (!string.IsNullOrEmpty(configPath))
            {
                LoadConfigFile(configPath);
            }
        }
        
        public bool LoadConfigFile(string configFile)
        {
            Log.Instance.Debug($"Loading config file {configFile}");

            ConfigPath = configFile;

            if (Read())
            {
                if (Validate())
                {
                    IsValid = true;
                    return true;
                }
            }

            return false;
        }

        private bool Validate()
        {
            // data sources must be unique devices
            List<string> roots = new List<string>();
            foreach (string item in SnapShotSources)
            {
                string root = StorageUtil.GetPathRoot(item);
                if (roots.Contains(root))
                {
                    return false; // a data source overlaps
                }
                roots.Add(root);
            }
            
            // all validation steps have passed
            return true;
        }

        /// <summary>
        /// Reads the config file
        /// </summary>
        /// <returns>an empty string if no exception occurrs</returns>
        public bool Read()
        {
            Log.Instance.Trace("ConfigFileHelper.Read() ...");

            try
            {
                if (!ConfigFileExists) return false;

                bool isConfigRead = true;

                // it is criticial for the order to be preserved, d1, d2, d3 etc so we treat the data sources carefully to preserve the order
                Dictionary<string, string> dataSources = new Dictionary<string, string>();

                ParityFile1 = string.Empty;
                ParityFile2 = string.Empty;
                ParityFile3 = string.Empty;
                ParityFile4 = string.Empty;
                ParityFile5 = string.Empty;
                ParityFile6 = string.Empty;
                ContentFiles.Clear();
                SnapShotSources.Clear();
                ExcludePatterns.Clear();
                IncludePatterns.Clear();
                BlockSizeKB = Constants.DefaultBlockSize;
                AutoSaveGB = Constants.DefaultAutoSave;

                foreach (string line in File.ReadLines(ConfigPath))
                {
                    string lineStart = line.Trim();
                    if (string.IsNullOrWhiteSpace(lineStart) || lineStart.StartsWith("#")) continue;
                    
                    // Not a comment so process the line

                    // split the line by the first space encountered
                    string[] configItem = lineStart.Split(new[] { ' ' }, 2);
                    string configItemName = configItem[0] ?? string.Empty;
                    string configItemValue = (configItem.Length > 1) ? configItem[1] : string.Empty;

                    // ignore the line if it is not an a recognized setting
                    if (!_validConfigNames.Contains(configItemName)) continue;

                    switch (configItemName)
                    {
                        case "parity":
                            ParityFile1 = configItemValue;
                            break;

                        case "q-parity":
                            Log.Instance.Warn("'q-parity' entry in config file should be changed to '2-parity'");
                            ParityFile2 = configItemValue;
                            break;

                        case "2-parity":
                            // handle legacy 'q-parity' entry by giving it priority over any '2-parity' entry; saving config will rename 'q-parity' to '2-parity' and leave the path unchanged
                            if (string.IsNullOrEmpty(ParityFile2))
                            {
                                ParityFile2 = configItemValue;
                            }
                            break;

                        case "3-parity":
                            ParityFile3 = configItemValue;
                            break;

                        case "4-parity":
                            ParityFile4 = configItemValue;
                            break;

                        case "5-parity":
                            ParityFile5 = configItemValue;
                            break;

                        case "6-parity":
                            ParityFile6 = configItemValue;
                            break;

                        case "content":
                            ContentFiles.Add(configItemValue);
                            break;

                        case "disk":
                            // get the data name, d1,d2,d3 etc
                            string diskName = configItemValue.Split(' ')[0];

                            // get the path
                            int diskSplitIndex = configItemValue.IndexOf(' ');
                            string diskPath = configItemValue.Substring(diskSplitIndex + 1);

                            if (!string.IsNullOrEmpty(diskName) && !string.IsNullOrEmpty(diskPath))
                                dataSources.Add(diskName, diskPath);
                            
                            break;

                        case "exclude":
                            ExcludePatterns.Add(configItemValue);
                            break;

                        case "include":
                            IncludePatterns.Add(configItemValue);
                            break;

                        case "block_size":
                            BlockSizeKB = uint.Parse(configItemValue);
                            if (BlockSizeKB < Constants.MinBlockSize || BlockSizeKB > Constants.MaxBlockSize)
                                isConfigRead = false;
                            break;

                        case "autosave":
                            AutoSaveGB = uint.Parse(configItemValue);
                            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                            if (AutoSaveGB < Constants.MinAutoSave || AutoSaveGB > Constants.MaxAutoSave)
                                isConfigRead = false;
                            break;

                        case "nohidden":
                            Nohidden = true;
                            break;
                    }
                }

                // special handling of data sources since order preservation is extremely important
                IOrderedEnumerable<KeyValuePair<string, string>> dataSourcesOrdered = dataSources.OrderBy(a => a.Key);
                foreach (var item in dataSourcesOrdered)
                {
                    SnapShotSources.Add(item.Value);
                }

                return isConfigRead;
            }
            catch (Exception ex)
            {
                Log.Instance.Error(ex);
                return false;
            }
        }
        
        public List<CoveragePath> GetPathsOfInterest()
        {
            List<CoveragePath> pathsOfInterest = new List<CoveragePath>();

            // SnapShotsource might be root or folders, so we handle both cases
            foreach (string snapShotSource in SnapShotSources)
            {
                pathsOfInterest.Add(new CoveragePath
                {
                    FullPath = Path.GetDirectoryName(snapShotSource) ?? Path.GetFullPath(snapShotSource),
                    PathType = PathTypeEnum.Source
                });
            }

            if (!string.IsNullOrEmpty(ParityFile1)) { pathsOfInterest.Add(new CoveragePath { FullPath = Path.GetFullPath(ParityFile1), PathType = PathTypeEnum.Parity }); }

            if (!string.IsNullOrEmpty(ParityFile2)) { pathsOfInterest.Add(new CoveragePath { FullPath = Path.GetFullPath(ParityFile2), PathType = PathTypeEnum.Parity }); }

            if (!string.IsNullOrEmpty(ParityFile3)) { pathsOfInterest.Add(new CoveragePath { FullPath = Path.GetFullPath(ParityFile3), PathType = PathTypeEnum.Parity }); }

            if (!string.IsNullOrEmpty(ParityFile4)) { pathsOfInterest.Add(new CoveragePath { FullPath = Path.GetFullPath(ParityFile4), PathType = PathTypeEnum.Parity }); }

            if (!string.IsNullOrEmpty(ParityFile5)) { pathsOfInterest.Add(new CoveragePath { FullPath = Path.GetFullPath(ParityFile5), PathType = PathTypeEnum.Parity }); }

            if (!string.IsNullOrEmpty(ParityFile6)) { pathsOfInterest.Add(new CoveragePath { FullPath = Path.GetFullPath(ParityFile6), PathType = PathTypeEnum.Parity }); }

            return pathsOfInterest.OrderBy(s => s.FullPath).DistinctBy(d => d.Drive).ToList();
        }

        /// <summary>
        /// Writes the config file
        /// </summary>
        /// <returns>an empty string if no exception occurs</returns>
        public string Write()
        {
            try
            {
                StringBuilder fileContents = new StringBuilder();

                fileContents.Append(Section1);

                // parity
                fileContents.Append(Section2);
                fileContents.AppendLine($"parity {(Directory.Exists(ParityFile1) ? Path.Combine(ParityFile1, "SnapRAID.parity") : ParityFile1)}");

                // X-parity
                fileContents.Append(Section3);
                if (!string.IsNullOrEmpty(ParityFile2))
                {
                    fileContents.AppendLine($"2-parity {(Directory.Exists(ParityFile2) ? Path.Combine(ParityFile2, "SnapRAID.2-parity") : ParityFile2)}");
                }
                if (!string.IsNullOrEmpty(ParityFile3))
                {
                    fileContents.AppendLine($"3-parity {(Directory.Exists(ParityFile3) ? Path.Combine(ParityFile3, "SnapRAID.3-parity") : ParityFile3)}");
                }
                if (!string.IsNullOrEmpty(ParityFile4))
                {
                    fileContents.AppendLine($"4-parity {(Directory.Exists(ParityFile4) ? Path.Combine(ParityFile4, "SnapRAID.4-parity") : ParityFile4)}");
                }
                if (!string.IsNullOrEmpty(ParityFile5))
                {
                    fileContents.AppendLine($"5-parity {(Directory.Exists(ParityFile5) ? Path.Combine(ParityFile5, "SnapRAID.5-parity") : ParityFile5)}");
                }
                if (!string.IsNullOrEmpty(ParityFile6))
                {
                    fileContents.AppendLine($"6-parity {(Directory.Exists(ParityFile6) ? Path.Combine(ParityFile6, "SnapRAID.6-parity") : ParityFile6)}");
                }

                // content
                fileContents.Append(Section4);
                ContentFiles.ForEach(item => fileContents.AppendLine($"content {(Directory.Exists(item) ? Path.Combine(item, "SnapRAID.content") : item)}"));

                // data sources
                fileContents.Append(Section5);
                List<string> strSnapShotSources = new List<string>();
                strSnapShotSources.AddRange(SnapShotSources.Select((t, index) => string.Concat("disk d", index+1, ' ', t)));
                strSnapShotSources.ForEach(item => fileContents.AppendLine(item));

                // exclude hidden files
                fileContents.Append(Section6);
                fileContents.AppendLine(Nohidden ? "nohidden" : "#nohidden");

                // exclude files and directories
                fileContents.Append(Section7);
                if (ExcludePatterns.Any())
                {
                    ExcludePatterns.ForEach(item => fileContents.AppendLine("exclude " + item));
                }

                // include files and directories
                if (IncludePatterns.Any())
                {
                    IncludePatterns.ForEach(item => fileContents.AppendLine("include " + item));
                }

                // blocksize
                fileContents.Append(Section8);
                BlockSizeKB = BlockSizeKB >= Constants.MinBlockSize && BlockSizeKB <= Constants.MaxBlockSize ? BlockSizeKB : Constants.DefaultBlockSize;
                fileContents.AppendLine($"block_size {BlockSizeKB}");
                
                // hashsize
                fileContents.Append(Section9);
                
                // autosave
                fileContents.Append(Section10);
                // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                AutoSaveGB = AutoSaveGB >= Constants.MinAutoSave && AutoSaveGB <= Constants.MaxAutoSave ? AutoSaveGB : Constants.DefaultAutoSave;
                fileContents.AppendLine("autosave " + AutoSaveGB);

                // pool
                fileContents.Append(Section11);

                // windows share

                // smartctl

                File.WriteAllText(ConfigPath, fileContents.ToString());
            }
            catch (Exception ex)
            {
                ExceptionHandler.ReportException(ex);
                return ex.Message;
            }
            return string.Empty;
        }
        
        public string ParityFile1 { get; set; }

        public string ParityFile2 { get; set; }

        public string ParityFile3 { get; set; }

        public string ParityFile4 { get; set; }

        public string ParityFile5 { get; set; }

        public string ParityFile6 { get; set; }
        
        public List<string> ContentFiles { get; private set; }

        public List<string> SnapShotSources { get; private set; }

        public List<string> ExcludePatterns { get; private set; }

        public List<string> IncludePatterns { get; set; }

        // ReSharper disable once InconsistentNaming
        public uint BlockSizeKB { get; set; }

        // ReSharper disable once InconsistentNaming
        public uint AutoSaveGB { get; set; }

        public bool Nohidden { get; set; }

        private StringBuilder Section1
        {
            get
            {
                var sb = new StringBuilder();
                sb.AppendLine("# Example configuration for snapraid for Windows");
                return sb;
            }
        }

        private StringBuilder Section2
        {
            get
            {
                var sb = new StringBuilder();
                sb.AppendLine("# Defines the file to use as parity storage");
                sb.AppendLine("# It must NOT be in a data disk");
                sb.AppendLine("# Format: \"parity FILE [,FILE] ...\"");
                //sb.AppendLine("parity E:\\snapraid.parity");
                return sb;
            }
        }

        private StringBuilder Section3
        {
            get
            {
                var sb = new StringBuilder();
                sb.AppendLine();
                sb.AppendLine("# Defines the files to use as additional parity storage.");
                sb.AppendLine("# If specified, they enable the multiple failures protection");
                sb.AppendLine("# from two to six level of parity.");
                sb.AppendLine("# To enable, uncomment one parity file for each level of extra");
                sb.AppendLine("# protection required. Start from 2-parity, and follow in order.");
                sb.AppendLine("# It must NOT be in a data disk");
                sb.AppendLine("# Format: \"X-parity FILE [,FILE] ...\"");
                return sb;
            }
        }

        private StringBuilder Section4
        {
            get
            {
                var sb = new StringBuilder();
                sb.AppendLine();
                sb.AppendLine("# Defines the files to use as content list");
                sb.AppendLine("# You can use multiple specification to store more copies");
                sb.AppendLine("# You must have least one copy for each parity file plus one. Some more don't hurt");
                sb.AppendLine("# They can be in the disks used for data, parity or boot,");
                sb.AppendLine("# but each file must be in a different disk");
                sb.AppendLine("# Format: \"content FILE\"");
                return sb;
            }
        }

        private StringBuilder Section5
        {
            get
            {
                var sb = new StringBuilder();
                sb.AppendLine();
                sb.AppendLine("# Defines the data disks to use");
                sb.AppendLine("# The name and mount point association is relevant for parity, do not change it");
                sb.AppendLine("# WARNING: Adding here your boot C:\\ disk is NOT a good idea!");
                sb.AppendLine("# SnapRAID is better suited for files that rarely changes!");
                sb.AppendLine("# Format: \"data DISK_NAME DISK_MOUNT_POINT\"");
                return sb;
            }
        }

        private StringBuilder Section6
        {
            get
            {
                var sb = new StringBuilder();
                sb.AppendLine();
                sb.AppendLine("# Excludes hidden files and directories (uncomment to enable).");
                return sb;
            }
        }

        private StringBuilder Section7
        {
            get
            {
                var sb = new StringBuilder();
                sb.AppendLine();
                sb.AppendLine("# Defines files and directories to exclude");
                sb.AppendLine("# Remember that all the paths are relative at the mount points");
                sb.AppendLine("# Format: \"exclude FILE\"");
                sb.AppendLine("# Format: \"exclude DIR\\\"");
                sb.AppendLine("# Format: \"exclude \\PATH\\FILE\"");
                sb.AppendLine("# Format: \"exclude \\PATH\\DIR\\\"");
                return sb;
            }
        }

        private StringBuilder Section8
        {
            get
            {
                var sb = new StringBuilder();
                sb.AppendLine();
                sb.AppendLine("# Defines the block size in kibi bytes (1024 bytes) (uncomment to enable).");
                sb.AppendLine("# WARNING: Changing this value is for experts only!");
                sb.AppendLine("# Default value is 256 -> 256 kibi bytes -> 262144 bytes");
                sb.AppendLine("# Format: \"blocksize SIZE_IN_KiB\"");
                return sb;
            }
        }

        private StringBuilder Section9
        {
            get
            {
                var sb = new StringBuilder();
                sb.AppendLine();
                sb.AppendLine("# Defines the hash size in bytes (uncomment to enable).");
                sb.AppendLine("# WARNING: Changing this value is for experts only!");
                sb.AppendLine("# Default value is 16 -> 128 bits");
                sb.AppendLine("# Format: \"hashsize SIZE_IN_BYTES\"");
                sb.AppendLine("#hashsize 16");
                return sb;
            }
        }

        private StringBuilder Section10
            {
                get
                {
                    var sb = new StringBuilder();
                    sb.AppendLine();
                    sb.AppendLine("# Automatically save the state when syncing after the specified amount");
                    sb.AppendLine("# of GB processed (uncomment to enable).");
                    sb.AppendLine("# This option is useful to avoid to restart from scratch long 'sync'");
                    sb.AppendLine("# commands interrupted by a machine crash.");
                    sb.AppendLine("# It also improves the recovering if a disk break during a 'sync'.");
                    sb.AppendLine("# Default value is 0, meaning disabled.");
                    sb.AppendLine("# Format: \"autosave SIZE_IN_GB\"");
                    return sb;
                }
            }

        private StringBuilder Section11
        {
            get
            {
                var sb = new StringBuilder();
                sb.AppendLine();
                sb.AppendLine("# Defines the pooling directory where the virtual view of the disk");
                sb.AppendLine("# array is created using the \"pool\" command (uncomment to enable).");
                sb.AppendLine("# The files are not really copied here, but just linked using");
                sb.AppendLine("# symbolic links.");
                sb.AppendLine("# This directory must be outside the array.");
                sb.AppendLine("# Format: \"pool DIR\"");
                sb.AppendLine("#pool C:\\pool");
                sb.AppendLine("# Defines the Windows UNC path required to access disks from the pooling");
                sb.AppendLine("# directory when shared in the network.");
                sb.AppendLine("# If present (uncomment to enable), the symbolic links created in the");
                sb.AppendLine("# pool virtual view, instead of using local paths, are created using the");
                sb.AppendLine("# specified UNC path, adding the disk names and file path.");
                sb.AppendLine("# This allows to share the pool directory in the network.");
                sb.AppendLine("# See the manual page for more details.");
                sb.AppendLine("#");
                sb.AppendLine("# Format: \"share UNC_DIR\"");
                sb.AppendLine("#share \\\\server");
                sb.AppendLine("# Defines a custom smartctl command to obtain the SMART attributes");
                sb.AppendLine("# for each disk. This may be required for RAID controllers and for");
                sb.AppendLine("# some USB disk that cannot be autodetected.");
                sb.AppendLine("# In the specified options, the \"%s\" string is replaced by the device name.");
                sb.AppendLine("# Refers at the smartmontools documentation about the possible options:");
                sb.AppendLine("# RAID -> https://www.smartmontools.org/wiki/Supported_RAID-Controllers");
                sb.AppendLine("# USB -> https://www.smartmontools.org/wiki/Supported_USB-Devices");
                sb.AppendLine("#smartctl d1 -d sat %s");
                sb.AppendLine("#smartctl d2 -d usbjmicron %s");
                sb.AppendLine("#smartctl parity -d areca,1/1 /dev/arcmsr0");
                sb.AppendLine("#smartctl 2-parity -d areca,2/1 /dev/arcmsr0");
                return sb;
            }
        }


        // Should result in the following formats
        /*
         * An example of a typical configuration for Unix is:
         *
  parity /mnt/diskpar/parity
  content /mnt/diskpar/content
  content /var/snapraid/content
  disk d1 /mnt/disk1/
  disk d2 /mnt/disk2/
  disk d3 /mnt/disk3/
  exclude *.bak
  exclude /lost+found/
  exclude /tmp/

         * An example of a typical configuration for Windows is:
         *
  parity E:\par\parity
  content E:\par\content
  content C:\snapraid\content
  disk d1 G:\array\
  disk d2 H:\array\
  disk d3 I:\array\
  exclude *.bak
  exclude Thumbs.db
  exclude \$RECYCLE.BIN\
  exclude \System Volume Information\
  */
    }
}