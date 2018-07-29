#region Copyright (C)

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
using NLog;

namespace Elucidate
{
    // TODO: consider using nuget package "FileHelpers by Marco Meli" to work with the config file

    internal class ConfigFileHelper
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        private string ConfigPath { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="configPath"></param>
        public ConfigFileHelper(string configPath)
        {
            ConfigPath = configPath;
            ContentFiles = new List<string>();
            SnapShotSources = new List<string>();
            ExcludePatterns = new List<string>();
            IncludePatterns = new List<string>();
        }

        /// <summary>
        /// Reads the config file
        /// </summary>
        /// <returns>an empty string if no exception occurrs</returns>
        public string Read()
        {
            try
            {
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
                BlockSizeKB = 256;
                AutoSaveGB = 250;

                foreach (string line in File.ReadLines(ConfigPath))
                {
                    string lineStart = line.TrimStart();
                    if (string.IsNullOrWhiteSpace(lineStart) || lineStart.StartsWith("#")) continue;
                    // Not a comment, so off we go.
                    int splitIndex = lineStart.IndexOf(' ');
                    string value = lineStart.Substring(splitIndex + 1);
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        continue;
                    }
                    switch (lineStart.Substring(0, splitIndex).ToLower())
                    {
                        case "parity":
                            ParityFile1 = value;
                            break;

                        case "q-parity":
                            Log.Warn("'q-parity' entry in config file should be changed to '2-parity'");
                            ParityFile2 = value;
                            break;

                        case "2-parity":
                            // handle legacy 'q-parity' entry by giving it priority over any '2-parity' entry; saving config will rename 'q-parity' to '2-parity' and leave the path unchanged
                            if (string.IsNullOrEmpty(ParityFile2))
                            {
                                ParityFile2 = value;
                            }
                            break;

                        case "3-parity":
                            ParityFile3 = value;
                            break;

                        case "4-parity":
                            ParityFile4 = value;
                            break;

                        case "5-parity":
                            ParityFile5 = value;
                            break;

                        case "6-parity":
                            ParityFile6 = value;
                            break;

                        case "content":
                            ContentFiles.Add(value);
                            break;

                        case "disk":
                            // Step over the disk name
                            int diskSplitIndex = value.IndexOf(' ');
                            SnapShotSources.Add(value.Substring(diskSplitIndex + 1));
                            break;

                        case "exclude":
                            ExcludePatterns.Add(value);
                            break;

                        case "include":
                            IncludePatterns.Add(value);
                            break;

                        case "block_size":
                            BlockSizeKB = uint.Parse(value);
                            break;

                        case "nohidden":
                            Nohidden = true;
                            break;

                        case "autosave":
                            AutoSaveGB = uint.Parse(value);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.ReportException(ex);
                return ex.Message;
            }
            return string.Empty;
        }

        /// <summary>
        /// Writes the config file
        /// </summary>
        /// <returns>an empty string if no exception occurrs</returns>
        public string Write()
        {
            try
            {
                List<string> fileContents = new List<string>
                                             {
                                                "# Configuration for snapraid via Elucidate",
                                                string.Empty,
                                                "# Defines the file to use as Parity storage",
                                                "# It must NOT be in a data disk",
                                                "parity " + (Directory.Exists(ParityFile1)? Path.Combine(ParityFile1, "SnapRAID.parity"):ParityFile1),
                                                string.Empty,
                                                "# Defines the file to use as 2-parity storage",
                                                "# If specified, it enables a double failures protection like RAID6",
                                                "# It must NOT be in a data disk"
                                             };
                if (string.IsNullOrEmpty(ParityFile2))
                {
                    fileContents.Add(@"#2-parity F:\SnapRAID.2.parity");
                }
                else
                {
                    fileContents.Add("2-parity " + (Directory.Exists(ParityFile2) ? Path.Combine(ParityFile2, "SnapRAID.2.parity") : ParityFile2));
                }
                fileContents.Add(string.Empty);
                fileContents.Add("# Defines the file to use as content list");
                fileContents.Add("# You can use multiple specification to store more copies of the file");
                fileContents.Add("# It's suggested to have at least N+1 copies of the file, where N is the number of parity files.");
                fileContents.Add("# It can be in a data disk");
                fileContents.Add("# It can be in the disks used for parity storage");
                fileContents.AddRange(ContentFiles.Select(contentFile => "content " + (Directory.Exists(contentFile) ? Path.Combine(contentFile, "SnapRAID.content") : contentFile)));
                fileContents.Add(string.Empty);
                fileContents.Add("# Defines the data disks to use");
                fileContents.Add("# The order is relevant for parity, do not change it");
                fileContents.AddRange(SnapShotSources.Select((t, index) => string.Concat("disk d", index, ' ', t)));
                fileContents.Add(string.Empty);

                fileContents.Add("# Excludes hidden files and directories (uncomment to enable).");
                fileContents.Add(Nohidden ? "nohidden" : "# nohidden");
                fileContents.Add(string.Empty);

                fileContents.Add("# Defines files and directories to exclude");
                fileContents.Add("# Remember that all the paths are relative at the mount points");
                fileContents.Add("# Format: \"exclude FILE\"");
                fileContents.Add("# Format: \"exclude DIR\\\"");
                fileContents.Add("# Format: \"exclude \\PATH\\FILE\"");
                fileContents.Add("# Format: \"exclude \\PATH\\DIR\\\"");
                if (ExcludePatterns.Any())
                {
                    fileContents.AddRange(ExcludePatterns.Select(pattern => "exclude " + pattern));
                }
                if (IncludePatterns.Any())
                {
                    fileContents.AddRange(IncludePatterns.Select(pattern => "include " + pattern));
                }
                fileContents.Add(string.Empty);
                fileContents.Add("# Defines the block size in kibi bytes (1024 bytes).");
                fileContents.Add("# Default value is 256 -> 256 kibi bytes -> 262144 bytes");
                fileContents.Add("block_size " + BlockSizeKB);
                fileContents.Add(string.Empty);

                fileContents.Add("# Automatically save the state when synching after the specied amount of GiB processed.");
                fileContents.Add("# This option is useful to avoid to restart from scratch long 'sync'");
                fileContents.Add("# commands interrupted by a machine crash.");
                fileContents.Add("# The SIZE argument is specified in gibi bytes -> 1073741824 bytes");
                fileContents.Add("# Default value is 0, meaning disabled.");
                fileContents.Add("# Format: \"autosave SIZE_IN_GiB\"");
                fileContents.Add("autosave " + AutoSaveGB);
                fileContents.Add(string.Empty);
                File.WriteAllLines(ConfigPath, fileContents);
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

        public uint BlockSizeKB { get; set; }

        public uint AutoSaveGB { get; set; }

        public bool Nohidden { get; set; }

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