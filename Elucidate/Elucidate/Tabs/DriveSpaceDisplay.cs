#region Copyright (C)
// ---------------------------------------------------------------------------------------------------------------
//  <copyright file="DriveSpaceDisplay.cs" company="Smurf-IV">
// 
//  Copyright (C) 2010-2017 Simon Coghlan (Aka Smurf-IV)
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
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using NLog;
using Shared;

// ReSharper disable UnusedMember.Global

namespace GUIUtils
{
    public partial class DriveSpaceDisplay : UserControl
    {
        static private readonly Logger Log = LogManager.GetCurrentClassLogger();
        private bool percentage;
        private WaitCursor waiting;
        private string oldTooltip;

        public DriveSpaceDisplay()
        {
            InitializeComponent();
        }

        #region Designer

        /// <summary>
        /// Shows the Y Axis Text
        /// </summary>
        [DefaultValue(typeof(bool), "true")]
        public bool ShowYAxisText
        {
            get { return chart1.ChartAreas[0].AxisX.LabelStyle.Enabled; }
            set { chart1.ChartAreas[0].AxisX.LabelStyle.Enabled = value; }
        }

        /// <summary>
        /// Shows the X Axis Text
        /// </summary>
        [DefaultValue(typeof(bool), "true")]
        public bool ShowXAxisText
        {
            get { return chart1.ChartAreas[0].AxisY.LabelStyle.Enabled; }
            set { chart1.ChartAreas[0].AxisY.LabelStyle.Enabled = value; }
        }

        /// <summary>
        /// Shows the Legend
        /// </summary>
        [DefaultValue(typeof(bool), "true")]
        public bool ShowLegend
        {
            get { return chart1.Legends[0].Enabled; }
            set { chart1.Legends[0].Enabled = value; }
        }

        #endregion Designer

        public void StartProcessing(List<string> pathsOfInterest)
        {
            waiting = new WaitCursor(this);
            oldTooltip = toolTip1.GetToolTip(this);
            toolTip1.SetToolTip(this, "Calculating...");
            FillExpectedLayoutWorker.CancelAsync();
            while (FillExpectedLayoutWorker.IsBusy)
            {
                Thread.Sleep(500);
                Application.DoEvents();
            }
            Log.Info(string.Join(", ", pathsOfInterest));
            FillExpectedLayoutWorker.RunWorkerAsync(pathsOfInterest);
        }

        private void FillExpectedLayoutWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ClearExpectedList();
            List<string> pathsOfInterest = e.Argument as List<string>;
            BackgroundWorker worker = sender as BackgroundWorker;
            if ((pathsOfInterest == null)
               || (worker == null)
               )
            {
                Log.Error("Worker, or auguments are null, exiting.");
                return;
            }
            foreach (string path in pathsOfInterest.Reverse<string>())
            {
                if (worker.CancellationPending)
                {
                    return;
                }
                FindAndAddDisplaySizes(worker, path);
            }
        }

        private void FillExpectedLayoutWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            waiting.Dispose();
            toolTip1.SetToolTip(this, oldTooltip);
        }

        private void ClearExpectedList()
        {
            MethodInvoker method = delegate
            {
                foreach (Series series in chart1.Series)
                {
                    series.Points.Clear();
                }
            };
            Invoke(method);
        }

        // Need to find 3 values, Total drive size, Root drive used, actual used by path
        // Need to be aware of UNC paths
        // Need to be aware of Junctions
        private void FindAndAddDisplaySizes(BackgroundWorker worker, string path)
        {
            FreeBytesAvailable(out ulong freeBytesAvailable, path, out ulong pathUsedBytes, out ulong rootBytesNotCoveredByPath);
            AppendToSeries(path, rootBytesNotCoveredByPath, pathUsedBytes, freeBytesAvailable);
        }

        public static void FreeBytesAvailable(out ulong freeBytesAvailable, string path, out ulong pathUsedBytes,
           out ulong rootBytesNotCoveredByPath)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            rootBytesNotCoveredByPath = 0;

            GetDiskFreeSpaceExW(di.Root.FullName, out freeBytesAvailable, out ulong totalBytes, out ulong num3);
            ulong driveUsedBytes = totalBytes - freeBytesAvailable;
            if (di.Root.FullName == di.FullName)
            {
                Log.Info("Nothing more to do, so get values for the series");
                pathUsedBytes = driveUsedBytes;
            }
            else
            {
                Log.Info("Need to perform some calculations of Path usage. TotalBytes[{0}]", totalBytes);
                pathUsedBytes = DirSize(di);
                if (pathUsedBytes < driveUsedBytes) // Might be driven down a symlink/junction/softlink path or file
                {
                    rootBytesNotCoveredByPath = driveUsedBytes - pathUsedBytes;
                }
            }
        }

        /// <summary>
        /// Note the usage of the Extension methods (bottom of this file) to enable the Linq Sum of ulongs
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static ulong DirSize(DirectoryInfo dir)
        {
            try
            {
                return dir.GetFiles().Sum(fi => (ulong)fi.Length) + dir.GetDirectories().Sum(DirSize);
            }
            catch (UnauthorizedAccessException ex)
            {
                Log.Warn(String.Concat("No Access to ", dir.FullName), ex);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
            return 0;
        }

        private void AppendToSeries(string path, ulong rootBytesNotCoveredByPath, ulong pathUsedBytes, ulong freeBytesAvailable)
        {
            Log.Info("path[{0}], rootBytesNotCoveredByPath[{1}], pathUsedBytes[{2}], freeBytesAvailable[{3}]", path, rootBytesNotCoveredByPath, pathUsedBytes, freeBytesAvailable);
            // ReSharper disable RedundantAssignment
            ulong[] points = {
               // Scale the values into GBytes
               rootBytesNotCoveredByPath >>= 30,
               pathUsedBytes >>= 30,
               freeBytesAvailable >>= 30
            };
            // ReSharper restore RedundantAssignment
            MethodInvoker method = delegate
               {
                   int offset = 0;
                   foreach (Series series in chart1.Series)
                   {
                       series.Points.AddXY(path, points[offset++]);
                   }
               };
            Invoke(method);
        }

        #region DLL Imports

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetDiskFreeSpaceExW(string lpDirectoryName, out ulong lpFreeBytesAvailable,
           out ulong lpTotalNumberOfBytes, out ulong lpTotalNumberOfFreeBytes);

        #endregion DLL Imports

        private void chart1_Click(object sender, EventArgs e)
        {
            percentage = !percentage;
            SeriesChartType chartType = percentage ? SeriesChartType.StackedBar100 : SeriesChartType.StackedBar;
            foreach (Series series in chart1.Series)
            {
                series.ChartType = chartType;
            }
        }
    }

    internal static class Enumerator
    {
        public static ulong Sum<T>(this IEnumerable<T> source, Func<T, ulong> selector)
        {
            return source.Select(selector).Sum();
        }

        private static ulong Sum(this IEnumerable<ulong> source)
        {
            return source.Aggregate(0UL, (current, number) => current + number);
        }
    }
}