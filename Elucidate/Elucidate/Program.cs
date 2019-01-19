#region Copyright (C)
//  <copyright file="Program.cs" company="Smurf-IV">
//
//  Copyright (C) 2011-2019 Smurf-IV
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
#endregion Copyright (C)

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

using ComponentFactory.Krypton.Toolkit;

using Exceptionless;

using NLog;

namespace Elucidate
{
    internal static class Program
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            try
            {
                ExceptionlessClient.Default.Register();
                // Include the username if available (E.G., Environment.UserName or IIdentity.Name)
                ExceptionlessClient.Default.Configuration.IncludeUserName = false;
                // Include the MachineName in MachineInfo.
                ExceptionlessClient.Default.Configuration.IncludeMachineName = true;
                // Include Ip Addresses in MachineInfo and RequestInfo.
                ExceptionlessClient.Default.Configuration.IncludeIpAddress = false;
                // Include Cookies, please note that DataExclusions are applied to all Cookie keys when enabled.
                ExceptionlessClient.Default.Configuration.IncludeCookies = false;
                // Include Form/POST Data, please note that DataExclusions are only applied to Form data keys when enabled.
                ExceptionlessClient.Default.Configuration.IncludePostData = false;
                // Include Query String information, please note that DataExclusions are applied to all Query String keys when enabled.
                ExceptionlessClient.Default.Configuration.IncludeQueryString = false;

                ExceptionlessClient.Default.Configuration.SetVersion(Assembly.GetExecutingAssembly().GetName().Version);

                AppDomain.CurrentDomain.UnhandledException += (sender, e) => LogUnhandledException(e.ExceptionObject);
                //if (FileUtil.IsDirectoryCompressed(Path.GetDirectoryName(Properties.Settings.Default.ConfigFileLocation)))
                //{
                //    FileUtil.SetDirectoryAsCompressed(Path.GetDirectoryName(Properties.Settings.Default.ConfigFileLocation));
                //}
            }
            catch (Exception ex)
            {
                try
                {
                    Log.Fatal(ex, @"Failed to attach unhandled exception handler...");
                    // https://github.com/exceptionless/Exceptionless.Net/wiki/Sending-Events
                    ex.ToExceptionless().Submit();
                }
                catch
                {
                    // ignored
                }
            }
            try
            {
                Log.Info("=====================================================================");
                Log.Error("File Re-opened: Ver :" + Assembly.GetExecutingAssembly().GetName().Version);
                CheckAndRunSingleApp();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Exception has not been caught by the rest of the application!");
                KryptonMessageBox.Show(ex.Message, "Uncaught Exception - Exiting !");
                ex.ToExceptionless().Submit();
            }
            finally
            {
                Log.Info("File Closing");
                Log.Info("=====================================================================");
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
                    KryptonMessageBox.Show( $@"{mutexName} is already running", mutexName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Log.Error($@"{mutexName} is already running");
                }
            }
        }

        private static void LogUnhandledException(object exceptionObject)
        {
            try
            {
                Log.Fatal("Unhandled exception.\r\n{0}", exceptionObject);
                string cs = Assembly.GetExecutingAssembly().GetName().Name;
                try
                {
                    if (!EventLog.SourceExists(cs))
                    {
                        EventLog.CreateEventSource(cs, @"Application");
                    }
                }
                catch (Exception sex)
                {
                    Log.Warn(sex);
                    cs = @"Application";    // https://stackoverflow.com/questions/25725151/write-to-windows-application-event-log-without-registering-an-event-source
                }
                EventLog.WriteEntry(cs, exceptionObject.ToString(), EventLogEntryType.Error);
                if (exceptionObject is Exception ex)
                {
                    Log.Fatal(ex, "Exception details");
                    EventLog.WriteEntry(cs, ex.ToString(), EventLogEntryType.Error);
                    // https://github.com/exceptionless/Exceptionless.Net/wiki/Sending-Events
                    ex.ToExceptionless().Submit();
                }
                else
                {
                    Log.Fatal("Unexpected exception.");
                }
            }
            catch
            {
                // ignored
            }
        }

    }
}