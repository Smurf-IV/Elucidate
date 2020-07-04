#region Copyright (C)
// ---------------------------------------------------------------------------------------------------------------
//  <copyright file="StorageUtil.cs" company="Smurf-IV">
// 
//  Copyright (C) 2010-2020 Simon Coghlan (Aka Smurf-IV)
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
using System.Collections.ObjectModel;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;

using Alphaleonis.Win32.Filesystem;

using Elucidate.Objects;

using NLog;

namespace Elucidate.HelperClasses
{
    public static class StorageUtil
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public static string NormalizePath(string path)
        {
            return Path.GetFullPath(new Uri(path).LocalPath)
                .TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
                .ToUpperInvariant();
        }

        public static bool IsPathRoot(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return false;
            }

            string root = GetVolumePathName(path);
            return path == root;
        }

        /// <summary>
        /// Gets the path root for logical drives and mounted folders.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>System.String.</returns>
        public static string GetPathRoot(string path)
        {
            string root = GetVolumePathName(path);
            return Path.GetFullPath(root);
        }

        public static string GetVolumeGuidPath(string mountPoint)
        {
            StringBuilder sb = new StringBuilder(50);
            GetVolumeNameForVolumeMountPoint(mountPoint, sb, 50);
            return sb.ToString();
        }

        public static string GetVolumePathName(string path)
        {
            return Volume.GetVolumePathName(path);
            /*const int MaxVolumeNameLength = 100;
            StringBuilder sb = new StringBuilder(MaxVolumeNameLength);
            if (!GetVolumePathName(path, sb, MaxVolumeNameLength))
            {
                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
            }

            string s = sb.ToString();
            return s;
            */
        }
        
        public static ulong GetDriveSize(string path)
        {
            bool success = GetDiskFreeSpaceEx(
                path,
                out ulong _,
                out ulong totalNumberOfBytes,
                out ulong _);

            if (success)
            {
                return totalNumberOfBytes;
            }

            return 0;
        }

        public static List<ulong> GetDriveSizes(List<string> sources)
        {
            List<ulong> deviceSizes = new List<ulong>();

            foreach (string source in sources)
            {
                try
                {
                    string[] possiblePaths = source.Trim().Split(",".ToCharArray());
                    deviceSizes.Add(possiblePaths.Select(GetPathRoot).Sum(GetDriveSize));
                }
                catch (Exception ex)
                {
                    Log.Warn(ex.Message);
                }
            }

            if (deviceSizes.Count == 0)
            {
                // Catch case when nothing has been set up yet
                deviceSizes.Add(0);
            }
            return deviceSizes;
        }

        public static List<ulong> GetDriveSizes(ReadOnlyCollection<ConfigFileHelper.SnapShotSource> sources)
        {
            List<string> sourcePaths = new List<string>(sources.Count);

            foreach (ConfigFileHelper.SnapShotSource source in sources)
            {
                sourcePaths.Add(source.DirSource);
            }

            return GetDriveSizes(sourcePaths);
        }
        
        /// <summary>
        /// Gets the storage devices.
        /// </summary>
        /// <param name="isIncludeNonMountedStorage">if set to <c>true</c> [is include non mounted storage].</param>
        /// <returns>List&lt;StorageDevice&gt;.</returns>
        public static List<StorageDevice> GetStorageDevices(bool isIncludeNonMountedStorage = false)
        {
            List<StorageDevice> storageDevices = new List<StorageDevice>();

            using (ManagementObjectSearcher mgmtObjSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Volume"))
            {
                using (ManagementObjectCollection managementQuery = mgmtObjSearcher.Get())
                {
                    // convert to LINQ to Objects query
                    var query =
                        from ManagementObject mo in managementQuery
                        orderby Convert.ToString(mo["DriveLetter"])
                        select new
                        {
                            Caption = Convert.ToString(mo["Caption"]),
                            Name = Convert.ToString(mo["Name"]),
                            DeviceID = Convert.ToString(mo["DeviceID"]),
                            DriveType = Convert.ToUInt32(mo["DriveType"]),
                            DriveLetter = Convert.ToString(mo["DriveLetter"]),
                            FileSystem = Convert.ToString(mo["FileSystem"])
                        };

                    // grab the fields
                    foreach (var item in query)
                    {
                        try
                        {
                            // ReSharper disable once UnusedVariable
                            bool success = GetDiskFreeSpaceEx(
                                item.DeviceID,
                                out ulong freeBytesAvailable,
                                out ulong totalNumberOfBytes,
                                out ulong _);

                            StorageDevice device = new StorageDevice
                            {
                                Caption = item.Caption,
                                Name = item.Name,
                                DeviceId = item.DeviceID,
                                DriveLetter = item.DriveLetter,
                                FileSystem = item.FileSystem,
                                Capacity = (uint)totalNumberOfBytes,
                                FreeSpace = (uint)freeBytesAvailable
                            };

                            switch (item.DriveType)
                            {
                                case (uint)System.IO.DriveType.Removable:
                                    device.DriveType = System.IO.DriveType.Removable;
                                    break;

                                case (uint)System.IO.DriveType.Fixed:
                                    device.DriveType = System.IO.DriveType.Fixed;
                                    break;

                                case (uint)System.IO.DriveType.Network:
                                    device.DriveType = System.IO.DriveType.Network;
                                    break;

                                case (uint)System.IO.DriveType.CDRom:
                                    device.DriveType = System.IO.DriveType.CDRom;
                                    break;

                                default:
                                    device.DriveType = System.IO.DriveType.Unknown;
                                    break;
                            }

                            if (!string.IsNullOrEmpty(device.Caption) && (!device.Caption.StartsWith(@"\\?\") || isIncludeNonMountedStorage))
                            {
                                storageDevices.Add(device);
                            }
                        }
                        catch (Exception ex)
                        {
                            Log.Warn(ex,"A storage device failed to enumerate.");
                        }
                    }
                }
            }

            return storageDevices;
        }

        #region DllImport

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool GetVolumeNameForVolumeMountPoint(
            string lpszFileName,
            [Out] StringBuilder lpszVollpszVolumePathName,
            int cchBufferLength);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool GetVolumePathName(
            string lpszVolumeMountPoint,
            [Out] StringBuilder lpszVolumeName,
            int cchBufferLength);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetDiskFreeSpaceEx(string lpDirectoryName,
            out ulong lpFreeBytesAvailable,
            out ulong lpTotalNumberOfBytes,
            out ulong lpTotalNumberOfFreeBytes);

        #endregion
    }
}
