#region Copyright (C)

// ---------------------------------------------------------------------------------------------------------------
//  <copyright file="Common.cs" company="Smurf-IV">
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

namespace Elucidate
{
   public partial class Elucidate
   {
      private void EnableCommonButtons(bool enabled)
      {
         btnDiff.Enabled = enabled;
         btnSync.Enabled = enabled;
         btnCheck.Enabled = enabled;
         btnStatus.Enabled = enabled;
      }

      private void btnDiff_Click(object sender, EventArgs e)
      {
         StartSnapRaidProcess("Diff");
      }

      private void btnSync_Click(object sender, EventArgs e)
      {
         StartSnapRaidProcess("Sync");
      }

      private void btnCheck_Click(object sender, EventArgs e)
      {
         StartSnapRaidProcess("Check");
      }

      private void btnStatus_Click(object sender, EventArgs e)
      {
         StartSnapRaidProcess("Status");
      }

   }
}
