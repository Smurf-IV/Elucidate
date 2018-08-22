using System;
using System.Collections.Generic;
using System.IO;
using System.Management;
using Elucidate.Logging;
using Elucidate.Objects;

namespace Elucidate.HelperClasses
{
    public static class StorageUtil
    {
        public static string NormalizePath(string path)
        {
            return Path.GetFullPath(new Uri(path).LocalPath)
                .TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
                .ToUpperInvariant();
        }

        public static bool IsPathRoot(string path)
        {
            if (string.IsNullOrEmpty(path)) return false;
            string root = MountedFolderSupportLibrary.MountedFolder.GetVolumePathName(path);
            return path == root;
        }

        /// <summary>
        /// Gets the path root for logical drives and mounted folders.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>System.String.</returns>
        public static string GetPathRoot(string path)
        {
            string root = MountedFolderSupportLibrary.MountedFolder.GetVolumePathName(path);
            return Path.GetFullPath(root);
        }

        /// <summary>
        /// Gets the storage devices.
        /// </summary>
        /// <param name="isIncludeNonMountedStorage">if set to <c>true</c> [is include non mounted storage].</param>
        /// <returns>List&lt;StorageDevice&gt;.</returns>
        public static List<StorageDevice> GetStorageDevices(bool isIncludeNonMountedStorage = false)
        {
            List<StorageDevice> storageDevices = new List<StorageDevice>();

            ManagementObjectSearcher mgmtObjSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Volume");
            ManagementObjectCollection colDisks = mgmtObjSearcher.Get();

            foreach (var colDisk in colDisks)
            {
                ManagementObject objDisk = (ManagementObject) colDisk;

                try
                {
                    StorageDevice device = new StorageDevice
                    {
                        Caption = (string) objDisk["Caption"],
                        Name = (string) objDisk["Name"],
                        DeviceID = (string) objDisk["DeviceID"],
                        DriveLetter = (string) objDisk["DriveLetter"],
                        FileSystem = (string) objDisk["FileSystem"],
                        Capacity = objDisk["Capacity"] is uint uc ? uc : 0,
                        FreeSpace = objDisk["FreeSpace"] is uint uf ? uf : 0
                    };
                    switch ((uint) objDisk["DriveType"])
                    {
                        case (uint)DriveType.Removable:
                            device.DriveType = DriveType.Removable;
                            break;

                        case (uint)DriveType.Fixed:
                            device.DriveType = DriveType.Fixed;
                            break;

                        case (uint)DriveType.Network:
                            device.DriveType = DriveType.Network;
                            break;

                        case (uint)DriveType.CDRom:
                            device.DriveType = DriveType.CDRom;
                            break;

                        default:
                            device.DriveType = DriveType.Unknown;
                            break;
                    }

                    if (!string.IsNullOrEmpty(device.Caption) && (!device.Caption.StartsWith(@"\\?\") || isIncludeNonMountedStorage))
                    {
                        storageDevices.Add(device);
                    }
                }
                catch(Exception ex)
                {
                    Log.Instance.Warn("A storage device failed to enumerate.");
                    Log.Instance.Warn(ex);
                }
            }

            return storageDevices;
        }
    }
}
