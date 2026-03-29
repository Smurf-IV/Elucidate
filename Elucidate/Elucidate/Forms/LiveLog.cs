#region Copyright (C)
// ---------------------------------------------------------------------------------------------------------------
//  <copyright file="LiveLog.cs" company="Smurf-IV">
// 
//  Copyright (C) 2020-2026 Simon Coghlan (Aka Smurf-IV)
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

using Krypton.Toolkit;

namespace Elucidate.Forms
{
    public partial class LiveLog : KryptonForm
    {
        public LiveLog()
        {
            Icon = Properties.Resources.ElucidateIco;
            InitializeComponent();
            WindowLocation.GeometryFromString(Properties.Settings.Default.LogWindowLocation, this);
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
            Properties.Settings.Default.LogWindowLocation = WindowLocation.GeometryToString(this);

            // Do not allow user to close this form !
            e.Cancel = !systemShutdown;
        }

    }
}
