#region Copyright (C)

// ---------------------------------------------------------------------------------------------------------------
//  <copyright file="Schedule.cs" company="Smurf-IV">
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

#endregion Copyright (C)

using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

using ComponentFactory.Krypton.Toolkit;

using NLog;
using NLog.Targets;

namespace Elucidate.TabPages
{
    // See the code in the following location for taskscheduler
    // http://taskscheduler.codeplex.com/wikipage?title=Examples&referringTitle=Documentation

    // The TaskListView behaves strangely, the item
    // clicked event seems to not always contain 
    // the item clicked, so instead we'll go directly
    // to the control and the get the selected item

    public partial class Schedule : UserControl
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        private string TaskNameSelected { get; set; } = string.Empty;
        private const string TASK_FOLDER = @"Elucidate";

        public Schedule()
        {
            InitializeComponent();
        }
    }
}
