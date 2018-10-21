#region Copyright (C)

// ---------------------------------------------------------------------------------------------------------------
//  <copyright file="Program.cs" company="Smurf-IV">
//
//  Copyright (C) 2011-2018 Smurf-IV
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
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

using ComponentFactory.Krypton.Toolkit;

using Elucidate.Logging;

namespace Elucidate
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            try
            {
                AppDomain.CurrentDomain.UnhandledException += LogUnhandledException;
                //if (FileUtil.IsDirectoryCompressed(Path.GetDirectoryName(Properties.Settings.Default.ConfigFileLocation)))
                //{
                //    FileUtil.SetDirectoryAsCompressed(Path.GetDirectoryName(Properties.Settings.Default.ConfigFileLocation));
                //}
#if !DEBUG
                Log.SetLogLevel(Log.LogLevels.Debug, Properties.Settings.Default.DebugLoggingEnabled);
#else
                Log.Instance.Debug("------------------------------------------------------------------");
                Log.Instance.Debug("------------------------------------------------------------------");
#endif
            }
            catch (Exception ex)
            {
                try
                {
                    ExceptionHandler.ReportException(ex, "Failed to attach unhandled exception handler...");
                }
                catch
                {
                    // ignored
                }
            }
            try
            {
                Log.Instance.Info($"File Re-opened: Ver :{Assembly.GetExecutingAssembly().GetName().Version}");

                CheckAndRunSingleApp();
            }
            catch (Exception ex)
            {
                ExceptionHandler.ReportException(ex, "Application Exception");
            }
            finally
            {
                Log.Instance.Info("File Closing");
                Log.Shutdown(); // Flush and close down internal threads and timers
            }
        }

        private static void CheckAndRunSingleApp()
        {
            string mutexName = $"{Path.GetFileName(Application.ExecutablePath)} [{Environment.UserName}]";

            // ReSharper disable once UnusedVariable
            using (Mutex appUserMutex = new Mutex(true, mutexName, out bool grantedOwnership))
            {
                if (grantedOwnership)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new ElucidateForm());
                }
                else
                {
                    KryptonMessageBox.Show( $@"{mutexName} is already running");
                    Log.Instance.Error($@"{mutexName} is already running");
                }
            }
        }

        private static void LogUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Log.Instance.Fatal("Unhandled exception.\r\n{0}", e.ExceptionObject);

                if (e.ExceptionObject is Exception ex)
                {
                    Log.Instance.Fatal(ex, "Exception details");
                }
                else
                {
                    Log.Instance.Fatal("Unexpected exception.");
                }

                ExceptionHandler.ReportException((Exception) e.ExceptionObject);
            }
            catch
            {
                // ignored
            }
        }

    }
}