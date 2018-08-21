using System.Runtime.InteropServices;
using System.Text;

namespace MountedFolderSupportLibrary
{
    public class MountedFolder
    {
        static string GetVolumeGuidPath(string mountPoint)
        {
            StringBuilder sb = new StringBuilder(50);
            GetVolumeNameForVolumeMountPoint(mountPoint, sb, 50);
            return sb.ToString();
        }

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

        public static string GetVolumePathName(string path)
        {
            const int MaxVolumeNameLength = 100;
            StringBuilder sb = new StringBuilder(MaxVolumeNameLength);
            if (!GetVolumePathName(path, sb, MaxVolumeNameLength))
                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
            string s = sb.ToString();
            return s;
        }

    }
}
