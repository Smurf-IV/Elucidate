#region Copyright (C)

// ---------------------------------------------------------------------------------------------------------------
//  <copyright file="Program.cs" company="Smurf-IV">
//
//  Copyright (C) 2011-2012 Smurf-IV
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
                AppDomain.CurrentDomain.UnhandledException += logUnhandledException;
            }
            catch (Exception ex)
            {
                try
                {
                    Log.Fatal(ex, "Failed to attach unhandled exception handler...");
                }
                catch
                {
                }
            }
            try
            {
                Log.Info("=====================================================================");
                Log.Info("File Re-opened: Ver :" + Assembly.GetExecutingAssembly().GetName().Version);
                CheckAndRunSingleApp();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Exception has not been caught by the rest of the application!");
                MessageBox.Show(ex.Message, "Uncaught Exception - Exiting !");
            }
            finally
            {
                Log.Info("File Closing");
                Log.Info("=====================================================================");
            }
        }

        private static void CheckAndRunSingleApp()
        {
            string MutexName = string.Format("{0} [{1}]", Path.GetFileName(Application.ExecutablePath), Environment.UserName);
            using (Mutex AppUserMutex = new Mutex(true, MutexName, out bool GrantedOwnership))
            {
                if (GrantedOwnership)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Elucidate());
                }
                else
                {
                    MessageBox.Show(MutexName + " is already running");
                }
            }
        }

        private static void logUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Log.Fatal("Unhandled exception.\r\n{0}", e.ExceptionObject);
                if (e.ExceptionObject is Exception ex)
                {
                    Log.Fatal(ex, "Exception details");
                }
                else
                {
                    Log.Fatal("Unexpected exception.");
                }
            }
            catch
            {
                // skipped
            }
        }
    }
}