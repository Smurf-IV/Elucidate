#region Copyright (C)
// ---------------------------------------------------------------------------------------------------------------
//  <copyright file="LiveLog.cs" company="Smurf-IV">
// 
//  Copyright (C) 2020-2021 Simon Coghlan (Aka Smurf-IV)
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

using System.Collections.Concurrent;

using Elucidate.Controls;

using Krypton.Toolkit;

namespace Elucidate.Forms
{
    public partial class LiveLog : KryptonForm
    {
        private static ListBoxLog ListBoxLog;

        public LiveLog()
        {
            InitializeComponent();
            ListBoxLog ??= new ListBoxLog(rtbLiveLog);
            WindowLocation.GeometryFromString(Properties.Settings.Default.LogWindowLocation, this);
        }

        public static ConcurrentQueue<string> LogQueueRecover { get; } = new ConcurrentQueue<string>();

        // ReSharper disable UnusedMember.Global
        // This is used by the logging to force all to the output window
        public static void LogMethod(string levelUppercase, string message)
        {
            if (message.Contains(@"[damaged ") // this is the -a option
            || message.Contains(@"Missing file '") // this is the -a option
            || message.Contains(@"[recover") // this is without the -a option or part of the recovery
            )
            {
                LogQueueRecover.Enqueue(message);
            }

            ListBoxLog?.LogMethod(levelUppercase, message);
        }

        // Sort out shutdown sequence when FormClosing is overridden
        // https://stackoverflow.com/questions/13894294/systemevents-sessionended-is-not-being-caught-or-fired/13935246#13935246
        private const int WM_QUERYENDSESSION = 0x11;
        private bool systemShutdown;
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == WM_QUERYENDSESSION)
            {
                systemShutdown = true;
            }
            base.WndProc(ref m);
        }

        private void LiveLog_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            // Do not allow user to close this form !
            e.Cancel = !systemShutdown;
        }
    }
}
