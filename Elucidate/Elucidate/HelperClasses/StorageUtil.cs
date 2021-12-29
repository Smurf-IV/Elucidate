#region Copyright (C)
// ---------------------------------------------------------------------------------------------------------------
//  <copyright file="StorageUtil.cs" company="Smurf-IV">
// 
//  Copyright (C) 2010-2021 Simon Coghlan (Aka Smurf-IV)
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

        public static string NormalizePath(string path) =>
            Path.GetFullPath(new Uri(path).LocalPath)
                .TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
                .ToUpperInvariant();

        public static bool IsPathRoot(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return false;
            }

            var root = GetVolumePathName(path);
            return path == root;
        }

        /// <summary>
        /// Gets the path root for logical drives and mounted folders.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>System.String.</returns>
        public static string GetPathRoot(string path)
        {
            var root = GetVolumePathName(path);
            return Path.GetFullPath(root);
        }

        public static string GetVolumeGuidPath(string mountPoint)
        {
            var sb = new StringBuilder(50);
            GetVolumeNameForVolumeMountPoint(mountPoint, sb, 50);
            return sb.ToString();
        }

        public static string GetVolumePathName(string path) => Volume.GetVolumePathName(path);

        /*const int MaxVolumeNameLength = 100;
            StringBuilder sb = new StringBuilder(MaxVolumeNameLength);
            if (!GetVolumePathName(path, sb, MaxVolumeNameLength))
            {
                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
            }

            string s = sb.ToString();
            return s;
            */
        public static ulong GetDriveSize(string path)
        {
            var success = GetDiskFreeSpaceEx(
                path,
                out var _,
                out var totalNumberOfBytes,
                out var _);

            if (success)
            {
                return totalNumberOfBytes;
            }

            return 0;
        }

        public static List<ulong> GetDriveSizes(List<string> sources)
        {
            var deviceSizes = new List<ulong>();

            foreach (var source in sources)
            {
                try
                {
                    var possiblePaths = source.Trim().Split(",".ToCharArray());
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
            var sourcePaths = new List<string>(sources.Count);

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
            var storageDevices = new List<StorageDevice>();

            using var mgmtObjSearcher = new ManagementObjectSearcher(@"SELECT * FROM Win32_Volume");
            using ManagementObjectCollection managementQuery = mgmtObjSearcher.Get();
            // convert to LINQ to Objects query
            var query =
                from ManagementObject mo in managementQuery
                orderby Convert.ToString(mo[@"DriveLetter"])
                select new
                {
                    Caption = Convert.ToString(mo[@"Caption"]),
                    Name = Convert.ToString(mo[@"Name"]),
                    DeviceID = Convert.ToString(mo[@"DeviceID"]),
                    DriveType = Convert.ToUInt32(mo[@"DriveType"]),
                    DriveLetter = Convert.ToString(mo[@"DriveLetter"]),
                    FileSystem = Convert.ToString(mo[@"FileSystem"])
                };

            // grab the fields
            foreach (var item in query)
            {
                try
                {
                    // ReSharper disable once UnusedVariable
                    var success = GetDiskFreeSpaceEx(
                        item.DeviceID,
                        out var freeBytesAvailable,
                        out var totalNumberOfBytes,
                        out var _);

                    var device = new StorageDevice
                    {
                        Caption = item.Caption,
                        Name = item.Name,
                        DeviceId = item.DeviceID,
                        DriveLetter = item.DriveLetter,
                        FileSystem = item.FileSystem,
                        Capacity = (uint)totalNumberOfBytes,
                        FreeSpace = (uint)freeBytesAvailable,
                        DriveType = item.DriveType switch
                        {
                            (uint)System.IO.DriveType.Removable => System.IO.DriveType.Removable,
                            (uint)System.IO.DriveType.Fixed => System.IO.DriveType.Fixed,
                            (uint)System.IO.DriveType.Network => System.IO.DriveType.Network,
                            (uint)System.IO.DriveType.CDRom => System.IO.DriveType.CDRom,
                            _ => System.IO.DriveType.Unknown
                        }
                    };

                    if (!string.IsNullOrEmpty(device.Caption)
                        && (!device.Caption.StartsWith(@"\\?\") || isIncludeNonMountedStorage))
                    {
                        storageDevices.Add(device);
                    }
                }
                catch (Exception ex)
                {
                    Log.Warn(ex, @"A storage device failed to enumerate.");
                }
            }

            return storageDevices;
        }

        #region DllImport

        [DllImport(@"kernel32.dll", SetLastError = true)]
        private static extern bool GetVolumeNameForVolumeMountPoint(string lpszFileName, [Out] StringBuilder lpszVolLpszVolumePathName, int cchBufferLength);

        [DllImport(@"kernel32.dll", SetLastError = true)]
        private static extern bool GetVolumePathName(string lpszVolumeMountPoint, [Out] StringBuilder lpszVolumeName, int cchBufferLength);

        [DllImport(@"kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetDiskFreeSpaceEx(string lpDirectoryName, out ulong lpFreeBytesAvailable, out ulong lpTotalNumberOfBytes, out ulong lpTotalNumberOfFreeBytes);

        #endregion
    }
}
