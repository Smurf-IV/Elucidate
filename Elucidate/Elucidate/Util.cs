using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Elucidate.Logging;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Elucidate
{
    public static class Util
    {
        public static string FormatSnapRaidCommandArgs(string command, string additionalCommands, out string appPath)
        {
            // Format according to this: http://snapraid.sourceforge.net/manual.html
            
            appPath = Properties.Settings.Default.SnapRAIDFileLocation;
            
            // Find the meanings @ http://snapraid.sourceforge.net/manual.html  6 Options
            // status|smart|up|down|diff|sync|scrub|fix|check|list|dup|pool|devices|touch|rehash

            // TODO: use regex to enforce check on addiitonal commands
            StringBuilder args = new StringBuilder(additionalCommands);

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

        public static string AddLoggingToArgs(string args)
        {
            string appDir = Path.GetDirectoryName(Properties.Settings.Default.ConfigFileLocation);
            string logDir = Properties.Settings.Default.LogFileDirectory;
            //string logFilename = $"{DateTime.Now:yyyyMMddhhmmss}.log";
            string logFilename = "%date:~10,4%%date:~4,2%%date:~7,2%%time:~0,2%%time:~3,2%%time:~6,2%.log";
            string newArgs = $@"--log ""{appDir}\{logDir}\{logFilename}"" {args}";
            return newArgs;
        }

        public static double RoundUpToDecimalPlace(double numToRound, int decimalPlace)
        {
            if (decimalPlace < 1) return numToRound; // return original nmber if 0 decimal places requested
            string strX = $"1{new String('0', decimalPlace)}";
            int intX = Convert.ToInt32(strX);
            return Math.Ceiling(numToRound * intX) / intX;
        }
        public static void CreateEmptyFile(string filename)
        {
            if (File.Exists(filename)) return;
            File.Create(filename).Dispose();
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

        public static string SnapRaidLatestVersion()
        {
            try
            {
                string url = "https://api.github.com/repos/amadvance/snapraid/releases/latest";

                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);

                // execute the request
                IRestResponse response = client.Execute(request);
                var content = response.Content; // raw content as string
                var releases = JArray.Parse($"[{content}]");
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

            var processStartInfo = new ProcessStartInfo {FileName = fileName};

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
                MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                return dir.GetFiles().Sum(fi => (ulong) fi.Length) + dir.GetDirectories().Sum(DirSize);
            }
            catch (UnauthorizedAccessException ex)
            {
                Log.Instance.Warn(String.Concat("No Access to ", dir.FullName), ex);
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
                // ReSharper disable once UnusedVariable
                GetDiskFreeSpaceExW(Path.GetPathRoot(path), out freeBytesAvailable, out ulong totalBytes, out ulong num3);
                ulong driveUsedBytes = totalBytes - freeBytesAvailable;
                pathUsedBytes = (ulong) new FileInfo(path).Length;
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
                ExceptionHandler.ReportException(ex);
                freeBytesAvailable = 0;
                pathUsedBytes = 0;
                rootBytesNotCoveredByPath = 0;
            }
        }

        public static void SourcePathFreeBytesAvailable(string path, 
            out ulong freeBytesAvailable, 
            out ulong pathUsedBytes,
            out ulong rootBytesNotCoveredByPath)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            // ReSharper disable once UnusedVariable
            GetDiskFreeSpaceExW(di.Root.FullName, out freeBytesAvailable, out ulong totalBytes, out ulong num3);
            ulong driveUsedBytes = totalBytes - freeBytesAvailable;
            
            rootBytesNotCoveredByPath = 0;
            if (di.Root.FullName == di.FullName)
            {
                Log.Instance.Debug("Nothing more to do, so get values for the series");
                pathUsedBytes = driveUsedBytes;
            }
            else
            {
                Log.Instance.Debug("Need to perform some calculations of Path usage. TotalBytes[{0}]", totalBytes);
                pathUsedBytes = DirSize(di);
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
