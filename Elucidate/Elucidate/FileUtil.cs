using System.IO;
using System.Management;
using System.Text.RegularExpressions;

namespace Elucidate
{
    public static class FileUtil
    {
        public static bool IsDirectoryCompressed(string destinationDir)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(destinationDir);
            return (directoryInfo.Attributes & FileAttributes.Compressed) == FileAttributes.Compressed;
        }

        public static bool SetDirectoryAsCompressed(string destinationDir)
        {
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(destinationDir);
                if ((directoryInfo.Attributes & FileAttributes.Compressed) == FileAttributes.Compressed) return true;
                string objPath = $"Win32_Directory.Name=\'{directoryInfo.FullName.Replace("\\", @"\\").TrimEnd('\\')}\'";
                using (ManagementObject dir = new ManagementObject(objPath))
                {
                    ManagementBaseObject outParams = dir.InvokeMethod("Compress", null, null);
                    if (outParams == null) { return false; }
                    uint ret = (uint)(outParams.Properties["ReturnValue"].Value);
                }
                return IsDirectoryCompressed(destinationDir);
            }
            catch
            {
                // ignored
            }

            return false;
        }
        
        public static bool IsValidFilename(string testName)
        {
            string regexString = $"[{Regex.Escape(Path.GetInvalidPathChars().ToString())}]";
            Regex containsABadCharacter = new Regex(regexString);
            return !containsABadCharacter.IsMatch(testName);
        }

    }
}
