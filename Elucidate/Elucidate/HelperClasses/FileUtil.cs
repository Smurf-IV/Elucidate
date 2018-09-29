using System;
using System.IO;
using System.Management;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using ScintillaNET;

namespace Elucidate
{
    public static class FileUtil
    {
        public static async Task<Document> LoadFileAsync(
            ILoader loader,
            string path,
            CancellationToken cancellationToken)
        {
            try
            {
                int bufferSize = 4096;
                using (var file = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: bufferSize, useAsync: true))
                {
                    using (var reader = new StreamReader(file))
                    {
                        int count;
                        char[] buffer = new char[bufferSize];
                        while ((count = await reader.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false)) > 0)
                        {
                            // Check for cancellation
                            cancellationToken.ThrowIfCancellationRequested();

                            // Add the data to the document
                            if (!loader.AddData(buffer, count))
                                throw new IOException("The data could not be added to the loader.");
                        }

                        return loader.ConvertToDocument();
                    }
                }
            }
            catch
            {
                loader.Release();
                throw;
            }
        }

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
