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
//  Url: http://Elucidate.codeplex.com/
//  Email: http://www.codeplex.com/site/users/view/smurfiv
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
               Log.FatalException("Failed to attach unhandled exception handler...", ex);
            }
            catch
            {
            }
         }
         try
         {
            Log.Error("=====================================================================");
            Log.Error("File Re-opened: Ver :" + Assembly.GetExecutingAssembly().GetName().Version);
            CheckAndRunSingleApp();
         }
         catch (Exception ex)
         {
            Log.Fatal("Exception has not been caught by the rest of the application!", ex);
            MessageBox.Show(ex.Message, "Uncaught Exception - Exiting !");
         }
         finally
         {
            Log.Error("File Closing");
            Log.Error("=====================================================================");
         }
      }

      private static void CheckAndRunSingleApp()
      {
         string MutexName = string.Format("{0} [{1}]", Path.GetFileName(Application.ExecutablePath), Environment.UserName);
         bool GrantedOwnership;
         using (Mutex AppUserMutex = new Mutex(true, MutexName, out GrantedOwnership))
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
            Exception ex = e.ExceptionObject as Exception;
            if (ex != null)
            {
               Log.FatalException("Exception details", ex);
            }
            else
            {
               Log.Fatal("Unexpected exception.");
            }
         }
         catch
         {
         }
      }
   }
}