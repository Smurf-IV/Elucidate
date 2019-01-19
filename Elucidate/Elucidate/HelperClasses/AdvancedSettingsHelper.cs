#region Copyright (C)

// ---------------------------------------------------------------------------------------------------------------
//  <copyright file="AdvancedSettingsHelper.cs" company="Smurf-IV">
//
//  Copyright (C) 2012-2019 Smurf-IV
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

namespace Elucidate
{
   internal class AdvancedSettingsHelper
   {
      public string DisplayName { get; private set; }

      public bool CheckState { get; set; }

      public string TootTip { get; private set; }

      public AdvancedSettingsHelper(string displayName, bool checkState, string tootTip)
      {
         DisplayName = displayName;
         this.CheckState = checkState;
         TootTip = tootTip;
      }

   }
}