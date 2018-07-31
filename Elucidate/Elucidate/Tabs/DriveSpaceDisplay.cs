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
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ByteSizeLib;
using Elucidate.Logging;
using Shared;

namespace Elucidate.Tabs
{
    public partial class DriveSpaceDisplay : UserControl
    {
        private bool _percentage;
        private WaitCursor _waiting;
        private string _oldTooltip;
        public class ChartDataItem
        {
            public string Path { get; set; }
            public ByteSize RootBytesNotCoveredByPath { get; set; }
            public ByteSize PathUsedBytes { get; set; }
            public ByteSize FreeBytesAvailable { get; set; }
        }
        public readonly List<ChartDataItem> ChartDataList = new List<ChartDataItem>();
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
            get => chart1.ChartAreas[0].AxisX.LabelStyle.Enabled;
            set => chart1.ChartAreas[0].AxisX.LabelStyle.Enabled = value;
        }

        /// <summary>
        /// Shows the X Axis Text
        /// </summary>
        [DefaultValue(typeof(bool), "true")]
        public bool ShowXAxisText
        {
            get => chart1.ChartAreas[0].AxisY.LabelStyle.Enabled;
            set => chart1.ChartAreas[0].AxisY.LabelStyle.Enabled = value;
        }

        /// <summary>
        /// Shows the Legend
        /// </summary>
        [DefaultValue(typeof(bool), "true")]
        public bool ShowLegend
        {
            get => chart1.Legends[0].Enabled;
            set => chart1.Legends[0].Enabled = value;
        }

        #endregion Designer

        public void StartProcessing(List<string> pathsOfInterest)
        {
            _waiting = new WaitCursor(this);
            _oldTooltip = toolTip1.GetToolTip(this);
            toolTip1.SetToolTip(this, "Calculating...");
            FillExpectedLayoutWorker.CancelAsync();
            while (FillExpectedLayoutWorker.IsBusy)
            {
                Thread.Sleep(500);
                Application.DoEvents();
            }
            Log.Instance.Info(string.Join(", ", pathsOfInterest));
            FillExpectedLayoutWorker.RunWorkerAsync(pathsOfInterest);
        }

        private void FillExpectedLayoutWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ClearExpectedList();
            List<string> pathsOfInterest = e.Argument as List<string>;
            BackgroundWorker worker = sender as BackgroundWorker;
            if (pathsOfInterest == null || worker == null)
            {
                Log.Instance.Error("Worker, or auguments are null, exiting.");
                return;
            }
            foreach (string path in pathsOfInterest.Reverse<string>())
            {
                if (worker.CancellationPending)
                {
                    return;
                }
                if (!Directory.Exists(path))
                {
                    Log.Instance.Warn($"Directory path does not exist: {path}");
                    continue;
                }
                CompileChartDataItemForPath(path);
            }

            AddDataToDisplay();
        }

        private void FillExpectedLayoutWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _waiting.Dispose();
            toolTip1.SetToolTip(this, _oldTooltip);
        }

        private void ClearExpectedListMethodInvoker()
        {
            ChartDataList.Clear();
            foreach (Series series in chart1.Series)
            {
                series.Points.Clear();
            }
        }

        private void ClearExpectedList()
        {
            Invoke((MethodInvoker)ClearExpectedListMethodInvoker);
        }
        
        // Need to find 3 values, Total drive size, Root drive used, actual used by path
        // Need to be aware of UNC paths
        // Need to be aware of Junctions
        private void CompileChartDataItemForPath(string path)
        {
            Util.FreeBytesAvailable(path, out ulong freeBytesAvailable, out ulong pathUsedBytes, out ulong rootBytesNotCoveredByPath);
            var chartDataItem = new ChartDataItem
            {
                Path = path,
                FreeBytesAvailable = ByteSize.FromBytes(freeBytesAvailable),
                PathUsedBytes = ByteSize.FromBytes(pathUsedBytes),
                RootBytesNotCoveredByPath = ByteSize.FromBytes(rootBytesNotCoveredByPath)
            };
            ChartDataList.Add(chartDataItem);
        }
        
        private string GetLargestWholenumberSymbolOfChartData()
        {
            List<string> availableSymbols = new List<string> {"", "b", "B", "KB", "MB", "GB", "TB"};
            string currentMaxSymbol = string.Empty;
            foreach (var item in ChartDataList)
            {
                string[] symbols = { item.FreeBytesAvailable.LargestWholeNumberSymbol, item.PathUsedBytes.LargestWholeNumberSymbol, item.RootBytesNotCoveredByPath.LargestWholeNumberSymbol };
                foreach (var symbol in symbols)
                {
                    if (availableSymbols.IndexOf(symbol) > availableSymbols.IndexOf(currentMaxSymbol))
                    {
                        currentMaxSymbol = symbol;
                    }
                }
            }
            Log.Instance.Debug($"GetLargestWholenumberSymbolOfChartData is {currentMaxSymbol}");
            return currentMaxSymbol;
        }

        private void AddDataToDisplay()
        {
            Invoke((MethodInvoker)AddDataToDisplayMethodInvoker);
        }

        private void AddDataToDisplayMethodInvoker()
        {
            //string largestWholenumberSymbolOfChartData = GetLargestWholenumberSymbolOfChartData();
            string largestWholenumberSymbolOfChartData = "GB";

            foreach (var item in ChartDataList)
            {
                double[] points =
                {
                    // Scale the values
                    Util.RoundUpToDecimalPlace(item.RootBytesNotCoveredByPath.GigaBytes, 2), Util.RoundUpToDecimalPlace(item.PathUsedBytes.GigaBytes, 2), Util.RoundUpToDecimalPlace(item.FreeBytesAvailable.GigaBytes, 2)
                };

                chart1.Series[0].Points.AddXY(item.Path, points[0]);
                chart1.Series[1].Points.AddXY(item.Path, points[1]);
                chart1.Series[2].Points.AddXY(item.Path, points[2]);

                Log.Instance.Info("path[{0}], rootBytesNotCoveredByPath[{1}], pathUsedBytes[{2}], freeBytesAvailable[{3}]", item.Path, points[0], points[1], points[2]);
            }

            // set formatting:
            // do not display point labels that are 0
            // set data size label
            foreach (Series series in chart1.Series)
            {
                foreach (DataPoint dp in series.Points)
                {
                    foreach (double yValue in dp.YValues)
                    {
                        Log.Instance.Info(yValue);
                        if (!(yValue > 0))
                        {
                            dp.IsValueShownAsLabel = false;
                        }
                        else
                        {
                            dp.Label = $"#VALY\n{largestWholenumberSymbolOfChartData}";
                        }
                    }
                }
            }
        }
        
        private void chart1_Click(object sender, EventArgs e)
        {
            _percentage = !_percentage;
            SeriesChartType chartType = _percentage ? SeriesChartType.StackedBar100 : SeriesChartType.StackedBar;
            foreach (Series series in chart1.Series)
            {
                series.ChartType = chartType;
            }
        }

    }
}