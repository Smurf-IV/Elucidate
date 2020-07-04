#region Copyright (C)
// ---------------------------------------------------------------------------------------------------------------
//  <copyright file="ErrorProviderExtensions.cs" company="Smurf-IV">
// 
//  Copyright (C) 2010-2020 Simon Coghlan (Aka Smurf-IV)
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

using System.Windows.Forms;

namespace Elucidate.HelperClasses
{
    public static class ErrorProviderExtensions
    {
        private static int _count;

        public static void SetErrorWithCount(this ErrorProvider ep, Control c, string message)
        {
            if (message == "")
            {
                if (ep.GetError(c) != "")
                {
                    _count--;
                }
            }
            else
            if (ep.GetError(c) == "")
            {
                _count++;
            }

            ep.SetError(c, message);
        }

        public static bool HasErrors(this ErrorProvider ep)
        {
            return _count != 0;
        }

        public static int GetErrorCount(this ErrorProvider ep)
        {
            return _count;
        }
    }
}
