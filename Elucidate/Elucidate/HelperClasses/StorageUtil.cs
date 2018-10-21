#region Copyright (C)
// ---------------------------------------------------------------------------------------------------------------
//  <copyright file="StorageUtil.cs" company="Smurf-IV">
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
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;

using Alphaleonis.Win32.Filesystem;

using Elucidate.Logging;
using Elucidate.Objects;

namespace Elucidate.HelperClasses
{
    public static class StorageUtil
    {
        #region DllImport

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool GetVolumeNameForVolumeMountPoint(
            string lpszFileName,
            [Out] StringBuilder lpszVollpszVolumePathNameumeName,
            int cchBufferLength);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool GetVolumePathName(
            string lpszVolumeMountPoint,
            [Out] StringBuilder lpszVolumeName,
            int cchBufferLength);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetDiskFreeSpaceEx(string lpDirectoryName,
            out ulong lpFreeBytesAvailable,
            out ulong lpTotalNumberOfBytes,
            out ulong lpTotalNumberOfFreeBytes);
        
        #endregion

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

            string root = StorageUtil.GetVolumePathName(path);
            return path == root;
        }

        /// <summary>
        /// Gets the path root for logical drives and mounted folders.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>System.String.</returns>
        public static string GetPathRoot(string path)
        {
            string root = StorageUtil.GetVolumePathName(path);
            return Path.GetFullPath(root);
        }

        static string GetVolumeGuidPath(string mountPoint)
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
            bool success = StorageUtil.GetDiskFreeSpaceEx(
                path,
                out ulong freeBytesAvailable,
                out ulong totalNumberOfBytes,
                out ulong totalNumberOfFreeBytes);

            if (success)
            {
                return totalNumberOfBytes;
            }

            return 0;
        }

        public static List<ulong> GetDriveSizes(List<string> paths)
        {
            List<ulong> deviceSizes = new List<ulong>();

            foreach (string path in paths.Where(p => !string.IsNullOrEmpty(p)))
            {
                try
                {
                    string pathRoot = StorageUtil.GetPathRoot(path);
                    deviceSizes.Add(StorageUtil.GetDriveSize(pathRoot));
                }
                catch (Exception ex)
                {
                    Log.Instance.Warn(ex.Message);
                }
            }

            return deviceSizes;
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
                                out ulong totalNumberOfFreeBytes);

                            StorageDevice device = new StorageDevice
                            {
                                Caption = item.Caption,
                                Name = item.Name,
                                DeviceID = item.DeviceID,
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
                            Log.Instance.Warn("A storage device failed to enumerate.");
                            Log.Instance.Warn(ex);
                        }
                    }
                }
            }

            return storageDevices;
        }

    }
}
