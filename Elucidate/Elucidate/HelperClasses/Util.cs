﻿#region Copyright (C)

// ---------------------------------------------------------------------------------------------------------------
//  <copyright file="CoveragePath.cs" company="Smurf-IV">
//
//  Copyright (C) 2018-2022 Smurf-IV & BlueBlock 2018
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

#endregion Copyright (C)

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

using Alphaleonis.Win32.Filesystem;

using Elucidate.HelperClasses;

using Krypton.Toolkit;

using NLog;


namespace Elucidate
{
    public static class Util
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public static void CreateFullDirectoryPath(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            var dir = Path.GetDirectoryName(path);

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
                Log.Warn($"Directory could not be created: {dir}");
            }
        }

        public static string FormatSnapRaidCommandArgs(string command, out string appPath)
        {
            // Format according to this: http://snapraid.sourceforge.net/manual.html

            appPath = Properties.Settings.Default.SnapRAIDFileLocation;

            // Find the meanings @ http://snapraid.sourceforge.net/manual.html
            // status|smart|up|down|diff|sync|scrub|fix|check|list|dup|pool|devices|touch|rehash

            var args = new StringBuilder();

            args.Append(' ');

            if (Properties.Settings.Default.UseVerboseMode)
            {
                args.Append("-v ");
            }

            if (Properties.Settings.Default.FindByNameInSync)
            {
                switch (command)
                {
                    case @"sync": 
                    case @"check":
                    case @"fix":
                        args.Append("-N ");
                        break;
                }
            }

            args.AppendFormat("-c \"{0}\" ", Properties.Settings.Default.ConfigFileLocation).Append(command);
			
			// Convert to string for final processing
			var finalArgs = args.ToString();

			// Escape square brackets for Windows CMD
			if (finalArgs.Contains("-f "))
			{
				finalArgs = System.Text.RegularExpressions.Regex.Replace(finalArgs, @"(?<!\^)\[", "^[");
				finalArgs = System.Text.RegularExpressions.Regex.Replace(finalArgs, @"(?<!\^)\]", "^]");
			}

			return finalArgs;
		}

        public static double RoundUpToDecimalPlace(double numToRound, int decimalPlace)
        {
            if (decimalPlace < 1)
            {
                return numToRound; // return original number if 0 decimal places requested
            }

            var strX = $"1{new string('0', decimalPlace)}";
            var intX = Convert.ToInt32(strX);
            return Math.Ceiling(numToRound * intX) / intX;
        }

        public static string ComputeSha1Hash(string rawData)
        {
            // Create a SHA1
            using SHA1 sha1Hash = SHA1.Create();
            // ComputeHash - returns byte array  
            var bytes = sha1Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            // Convert byte array to a string   
            var builder = new StringBuilder();
            foreach (var bt in bytes)
            {
                builder.Append(bt.ToString("x2"));
            }

            return builder.ToString();
        }

        public static bool IsExecutableRunning(string exePath)
        {
            var path = exePath;

            var fileName = Path.GetFileName(path);

            // Get the process that is already running as per the exe file name.

            if (fileName == null)
            {
                return false;
            }

            var processName = Process.GetProcessesByName(fileName.Substring(0, fileName.LastIndexOf('.')));

            return processName.Length > 0;
        }

        // ReSharper disable once UnusedMember.Local
        private static void RunElevatedProcess(string fileName, string args = "")
        {
            Process process = null;

            var processStartInfo = new ProcessStartInfo { FileName = fileName };

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
                KryptonMessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
            }
            finally
            {
                process?.Dispose();
            }
        }

        #region DLL Imports

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true,
            CallingConvention = CallingConvention.Winapi)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
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
                return dir.EnumerateFiles().AsParallel().Sum(static fi => (ulong)fi.Length)
                       + dir.EnumerateDirectories()
                           .Where(static d => (d.Attributes & System.IO.FileAttributes.System) == 0 
                                              && (d.Attributes & System.IO.FileAttributes.Hidden) == 0)
                           .AsParallel()
                           .Sum(DirSize);
            }
            catch (UnauthorizedAccessException ex)
            {
                Log.Warn(string.Concat("No Access to ", dir.FullName), ex);
            }
            catch (Exception ex)
            {
                Log.Warn(ex);
            }

            return 0;
        }

        public static void SourcePathFreeBytesAvailable(
            string path,
            out ulong freeBytesAvailable,
            out ulong pathUsedBytes,
            out ulong rootBytesNotCoveredByPath)
        {
            var fullPath = StorageUtil.NormalizePath(Path.GetFullPath(path));

            var rootPath = StorageUtil.NormalizePath(StorageUtil.GetPathRoot(path));

            // ReSharper disable once UnusedVariable
            GetDiskFreeSpaceExW(rootPath, out freeBytesAvailable, out var totalBytes, out var num3);

            var driveUsedBytes = totalBytes - freeBytesAvailable;

            rootBytesNotCoveredByPath = 0;

            Log.Debug($"rootPath {rootPath} freeBytesAvailable {freeBytesAvailable} totalBytes {totalBytes} num3 {num3}");

            if (rootPath == fullPath)
            {
                Log.Trace(@"Nothing more to do, so get values for the series");

                pathUsedBytes = driveUsedBytes;
            }
            else
            {
                Log.Debug(@"Need to perform some calculations of Path usage. TotalBytes[{0}]", totalBytes);

                pathUsedBytes = DirSize(new DirectoryInfo(path));

                if (pathUsedBytes < driveUsedBytes) // Might be driven down a symlink/junction/ softlink path or file
                {
                    rootBytesNotCoveredByPath = driveUsedBytes - pathUsedBytes;
                }
            }
        }

    }

    internal static class Enumerator
    {
        public static ulong Sum<T>(this IEnumerable<T> source, Func<T, ulong> selector) => source.Select(selector).Sum();

        private static ulong Sum(this IEnumerable<ulong> source)
        {
            return source.Aggregate(0UL, static (current, number) => current + number);
        }
    }

}
