#region Copyright (C)
// ---------------------------------------------------------------------------------------------------------------
//  <copyright file="FileUtil.cs" company="Smurf-IV">
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

using System.IO;
using System.Management;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

using ScintillaNET;

using DirectoryInfo = Alphaleonis.Win32.Filesystem.DirectoryInfo;
using Path = Alphaleonis.Win32.Filesystem.Path;

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
                using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: bufferSize, useAsync: true))
                {
                    using (StreamReader reader = new StreamReader(file))
                    {
                        int count;
                        char[] buffer = new char[bufferSize];
                        while ((count = await reader.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false)) > 0)
                        {
                            // Check for cancellation
                            cancellationToken.ThrowIfCancellationRequested();

                            // Add the data to the document
                            if (!loader.AddData(buffer, count))
                            {
                                throw new IOException("The data could not be added to the loader.");
                            }
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
                if ((directoryInfo.Attributes & FileAttributes.Compressed) == FileAttributes.Compressed)
                {
                    return true;
                }

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
