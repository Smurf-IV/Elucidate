using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

using Alphaleonis.Win32.Filesystem;

using ComponentFactory.Krypton.Toolkit;

using Elucidate.HelperClasses;
using Elucidate.Logging;

using Newtonsoft.Json.Linq;

using RestSharp;

namespace Elucidate
{
    public static class Util
    {
        internal static void Dump(object o)
        {
            //string json = JsonConvert.SerializeObject(o, Formatting.Indented);
            //Log.Instance.Debug(json);
        }
        
        public static void CreateFullDirectoryPath(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            string dir = Path.GetDirectoryName(path);

            try
            {
                if (dir == null || Directory.Exists(dir))
                {
                    return;
                }

                Directory.CreateDirectory(dir);
            }
            catch (Exception)
            {
                Log.Instance.Warn($"Directory could not be created: {dir}");
            }
        }

        public static string FormatSnapRaidCommandArgs(string command, string additionalCommands, out string appPath)
        {
            // Format according to this: http://snapraid.sourceforge.net/manual.html
            
            appPath = Properties.Settings.Default.SnapRAIDFileLocation;
            
            // Find the meanings @ http://snapraid.sourceforge.net/manual.html
            // status|smart|up|down|diff|sync|scrub|fix|check|list|dup|pool|devices|touch|rehash

            StringBuilder args = new StringBuilder(additionalCommands.Trim());

            args.Append(' ');

            if (Properties.Settings.Default.UseVerboseMode)
            {
                args.Append("-v ");
            }

            if (Properties.Settings.Default.FindByNameInSync)
            {
                args.Append("-N ");
            }

            args.AppendFormat("-c \"{0}\" {1}", Properties.Settings.Default.ConfigFileLocation, command);

            return args.ToString();
        }
        
        public static double RoundUpToDecimalPlace(double numToRound, int decimalPlace)
        {
            if (decimalPlace < 1)
            {
                return numToRound; // return original nmber if 0 decimal places requested
            }

            string strX = $"1{new String('0', decimalPlace)}";
            int intX = Convert.ToInt32(strX);
            return Math.Ceiling(numToRound * intX) / intX;
        }

        public static void CreateEmptyFile(string filename)
        {
            if (File.Exists(filename))
            {
                return;
            }

            File.Create(filename).Dispose();
        }

        public static string ComputeSha1Hash(string rawData)
        {
            // Create a SHA1
            using (SHA1 sha1Hash = SHA1.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha1Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public static bool IsExecutableRunning(string exePath)
        {
            string path = exePath;

            string fileName = Path.GetFileName(path);

            // Get the process that is already running as per the exe file name.

            if (fileName == null)
            {
                return false;
            }

            Process[] processName = Process.GetProcessesByName(fileName.Substring(0, fileName.LastIndexOf('.')));

            return processName.Length > 0;
        }

        public static string SnapRaidLatestVersion()
        {
            try
            {
                string url = "https://api.github.com/repos/amadvance/snapraid/releases/latest";

                RestClient client = new RestClient(url);
                RestRequest request = new RestRequest(Method.GET);

                // execute the request

                IRestResponse response = client.Execute(request);

                string content = response.Content; // raw content as string

                JArray releases = JArray.Parse($"[{content}]");

                List<JToken> version = (from p in releases select p["tag_name"]).ToList();

                if (version.Count > 0 && version.FirstOrDefault() != null)
                {
                    return version.FirstOrDefault()?.ToString();
                }
            }
            catch
            {
                // ignored
            }

            return null;
        }

        public static string SnapRaidLocalVersion()
        {
            try
            {

                return null;
            }
            catch
            {
                // ignored
            }

            return null;
        }

        // ReSharper disable once UnusedMember.Local
        private static void RunElevatedProcess(string fileName, string args = "")
        {
            Process process = null;

            ProcessStartInfo processStartInfo = new ProcessStartInfo {FileName = fileName};

            if (Environment.OSVersion.Version.Major >= 6) // Windows Vista or higher
            {
                processStartInfo.Verb = "runas";
            }
            else
            {
                // No need to prompt to run as admin
            }

            processStartInfo.Arguments = args;
            processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            processStartInfo.UseShellExecute = true;

            try
            {
                process = Process.Start(processStartInfo);
                //process.WaitForExit();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                process?.Dispose();
            }
        }

        #region DLL Imports

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true,
            CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetDiskFreeSpaceExW(string lpDirectoryName, out ulong lpFreeBytesAvailable,
            out ulong lpTotalNumberOfBytes, out ulong lpTotalNumberOfFreeBytes);

        #endregion DLL Imports

        /// <summary>
        /// Note the usage of the Extension methods (bottom of this file) to enable the Linq Sum of ulongs
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        private static ulong DirSize(DirectoryInfo dir)
        {
            try
            {
                return dir.GetFiles()
                           .Sum(fi => (ulong) fi.Length) + dir.GetDirectories()
                           .Where(d => (d.Attributes & System.IO.FileAttributes.System) == 0 && (d.Attributes & System.IO.FileAttributes.Hidden) == 0)
                           .Sum(DirSize);
            }
            catch (UnauthorizedAccessException ex)
            {
                Log.Instance.Warn(string.Concat("No Access to ", dir.FullName), ex);
            }
            catch (Exception ex)
            {
                ExceptionHandler.ReportException(ex);
            }

            return 0;
        }

        public static void ParityPathFreeBytesAvailable(string path, 
            out ulong freeBytesAvailable, 
            out ulong pathUsedBytes,
            out ulong rootBytesNotCoveredByPath)
        {
            try
            {
                // get stats for parity location since it might be a folder

                string rootPath = StorageUtil.NormalizePath(StorageUtil.GetPathRoot(path));

                // ReSharper disable once UnusedVariable
                GetDiskFreeSpaceExW(rootPath, out freeBytesAvailable, out ulong totalBytes, out ulong num3);

                ulong driveUsedBytes = totalBytes - freeBytesAvailable;

                pathUsedBytes = File.Exists(path) ? (ulong) new FileInfo(path).Length : 0;

                if (pathUsedBytes < driveUsedBytes) // Might be driven down a symlink/junction/softlink path or file
                {
                    rootBytesNotCoveredByPath = driveUsedBytes - pathUsedBytes;
                }
                else
                {
                    rootBytesNotCoveredByPath = driveUsedBytes;
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error($"ParityPathFreeBytesAvailable failed for path {path} Exception Message: {ex.Message}");
                freeBytesAvailable = 0;
                pathUsedBytes = 0;
                rootBytesNotCoveredByPath = 0;
            }
        }

        public static void SourcePathFreeBytesAvailable(
            string path, 
            out ulong freeBytesAvailable, 
            out ulong pathUsedBytes,
            out ulong rootBytesNotCoveredByPath)
        {
            string fullPath = StorageUtil.NormalizePath(Path.GetFullPath(path));

            string rootPath = StorageUtil.NormalizePath(StorageUtil.GetPathRoot(path));

            // ReSharper disable once UnusedVariable
            GetDiskFreeSpaceExW(rootPath, out freeBytesAvailable, out ulong totalBytes, out ulong num3);

            ulong driveUsedBytes = totalBytes - freeBytesAvailable;
            
            rootBytesNotCoveredByPath = 0;

            Log.Instance.Debug($"rootPath {rootPath} freeBytesAvailable {freeBytesAvailable} totalBytes {totalBytes} num3 {num3}");

            if (rootPath == fullPath)
            {
                Log.Instance.Trace("Nothing more to do, so get values for the series");

                pathUsedBytes = driveUsedBytes;
            }
            else
            {
                Log.Instance.Debug("Need to perform some calculations of Path usage. TotalBytes[{0}]", totalBytes);

                pathUsedBytes = DirSize(new DirectoryInfo(path));
                
                if (pathUsedBytes < driveUsedBytes) // Might be driven down a symlink/junction/softlink path or file
                {
                    rootBytesNotCoveredByPath = driveUsedBytes - pathUsedBytes;
                }
            }
        }

        public static string GetUniqueKey(int maxSize)
        {
            // https://stackoverflow.com/questions/1344221/how-can-i-generate-random-alphanumeric-strings-in-c
            
            // ReSharper disable once RedundantAssignment
            char[] chars = new char[62];

            chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();

            byte[] data = new byte[1];

            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetNonZeroBytes(data);
                data = new byte[maxSize];
                crypto.GetNonZeroBytes(data);
            }

            StringBuilder result = new StringBuilder(maxSize);

            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }

            return result.ToString();
        }

    }
    
    internal static class Enumerator
    {
        public static ulong Sum<T>(this IEnumerable<T> source, Func<T, ulong> selector)
        {
            return source.Select(selector).Sum();
        }

        private static ulong Sum(this IEnumerable<ulong> source)
        {
            return source.Aggregate(0UL, (current, number) => current + number);
        }
    }

}
