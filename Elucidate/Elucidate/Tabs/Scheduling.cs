#region Copyright (C)

// ---------------------------------------------------------------------------------------------------------------
//  <copyright file="Scheduling.cs" company="Smurf-IV">
//
//  Copyright (C) 2015 Simon Coghlan (Aka Smurf-IV)
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
using System.Diagnostics;
using System.Security.Principal;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using wyDay.Controls;

namespace Elucidate
{
    public partial class Elucidate
   {
      private const string TaskName = "SnapRAID Sync";

      private void EnableScheduleButtons(bool b)
      {
         btnGetSchedules.Enabled = b;
         btnNew.Enabled = b;
         btnEdit.Enabled = b;
         btnDelete.Enabled = b;
      }

      //
      // See the code in the following location for how to do these things
      // http://taskscheduler.codeplex.com/wikipage?title=Examples&referringTitle=Documentation
      //

      private void btnGetSchedules_Click(object sender, EventArgs e)
      {
         try
         {
            EnableScheduleButtons(false);
            toolStripStatusLabel1.Text = DateTime.Now.ToString("u");
            toolStripProgressBar1.DisplayText = "Starting";
            toolStripProgressBar1.State = ProgressBarState.Normal;
            toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
            toolStripProgressBar1.Value = 0;
            UseWaitCursor = true;

         }
         finally
         {
            toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
            UseWaitCursor = false;
            toolStripProgressBar1.DisplayText = string.Empty;
            toolStripProgressBar1.Value = 0;
            EnableScheduleButtons(true);
         }
      }

      private void btnNew_Click(object sender, EventArgs e)
      {
         try
         {
            EnableScheduleButtons(false);

            btnGetSchedules_Click(sender, e);
         }
         catch (Exception ex)
         {
            Log.Error(ex, "btnNew_Click has thrown: ");
            KryptonMessageBox.Show(this, ex.Message, "New Schedule Task");
         }
         finally
         {
            EnableScheduleButtons(true);
         }
      }

      private void btnEdit_Click(object sender, EventArgs e)
      {
         try
         {
            EnableScheduleButtons(false);

            btnGetSchedules_Click(sender, e);
         }
         catch (Exception ex)
         {
            Log.Error(ex, "btnEdit_Click has thrown: ");
            KryptonMessageBox.Show(this, ex.Message, "Edit Schedule Task");
         }
         finally
         {
            EnableScheduleButtons(true);
         }
      }

      private void btnDelete_Click(object sender, EventArgs e)
      {
         try
         {
            EnableScheduleButtons(false);

            btnGetSchedules_Click(sender, e);
         }
         catch (Exception ex)
         {
            Log.Error(ex, "btnDelete_Click has thrown: ");
            KryptonMessageBox.Show(this, ex.Message, "Delete Schedule Task");
         }
         finally
         {
            EnableScheduleButtons(true);
         }
      }

   }
}
