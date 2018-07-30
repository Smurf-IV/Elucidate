using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Elucidate.Logging;
using GUIUtils;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Elucidate
{
    public static class Util
    {
        
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
        
        #region DLL Imports

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true, CallingConvention = CallingConvention.Winapi)]
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
                return dir.GetFiles().Sum(fi => (ulong)fi.Length) + dir.GetDirectories().Sum(DirSize);
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
        
        public static void FreeBytesAvailable(string path, out ulong freeBytesAvailable, out ulong pathUsedBytes,
            out ulong rootBytesNotCoveredByPath)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            rootBytesNotCoveredByPath = 0;

            GetDiskFreeSpaceExW(di.Root.FullName, out freeBytesAvailable, out ulong totalBytes, out ulong num3);
            ulong driveUsedBytes = totalBytes - freeBytesAvailable;
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
