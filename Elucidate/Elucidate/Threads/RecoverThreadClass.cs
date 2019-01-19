#region Copyright (C)
// ---------------------------------------------------------------------------------------------------------------
//  <copyright file="RecoverThreadClass.cs" company="Smurf-IV">
// 
//  Copyright (C) 2010-2019 Simon Coghlan (Aka Smurf-IV)
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

using System;

namespace Elucidate.Threads
{
    public class RecoverThreadClass : IDisposable
    {
        public delegate void AddNodeHandler(string name);
        public event AddNodeHandler OnAddNodeEvt;

        public void AddNode(string name)
        {
            TriggerEvent(name);
        }

        private void TriggerEvent(string name)
        {
            OnAddNodeEvt?.Invoke(name);
        }

        #region Dispose
        public void Dispose() => GC.SuppressFinalize(this);
        ~RecoverThreadClass() => Dispose();
        #endregion

    }
}
