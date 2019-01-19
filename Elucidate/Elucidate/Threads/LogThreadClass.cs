#region Copyright (C)
// ---------------------------------------------------------------------------------------------------------------
//  <copyright file="LogThreadClass.cs" company="Smurf-IV">
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
    public class LogThreadClass : IDisposable
    {
        public delegate void ProcessLogHandler();
        public event ProcessLogHandler OnProcessLogEvt;

        public void ProcessLog()
        {
            TriggerEventProcessLog();
        }

        private void TriggerEventProcessLog()
        {
            OnProcessLogEvt?.Invoke();
        }



        public delegate void LogEntryHandler(string message);
        public event LogEntryHandler OnLogEntryEvt;

        public void LogEntry(string message)
        {
            TriggerEvent(message);
        }

        private void TriggerEvent(string message)
        {
            OnLogEntryEvt?.Invoke(message);
        }

        #region Dispose
        public void Dispose() => GC.SuppressFinalize(this);
        ~LogThreadClass() => Dispose();
        #endregion
    }
}
