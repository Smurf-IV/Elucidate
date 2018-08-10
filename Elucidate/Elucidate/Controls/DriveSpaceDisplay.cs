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
using Elucidate.HelperClasses;
using Elucidate.Logging;
using MoreLinq;

namespace Elucidate.Controls
{
    public partial class DriveSpaceDisplay : UserControl
    {
        private ConfigFileHelper _snapRaidConfig;
        private readonly List<ChartDataItem> _chartDataList = new List<ChartDataItem>();
        private bool _percentage;
        private string _oldTooltip;
        
        private class ChartDataItem
        {
            public string Path { get; set; }
            public ByteSize RootBytesNotCoveredByPath { get; set; }
            public ByteSize PathUsedBytes { get; set; }
            public ByteSize FreeBytesAvailable { get; set; }
        }

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
        private bool ShowLegend
        {
            get => chart1.Legends[0].Enabled;
            set => chart1.Legends[0].Enabled = value;
        }

        #endregion Designer

        public void RefreshGraph(List<CoveragePath> pathsOfInterest = null)
        {
            try
            {
                if (pathsOfInterest == null)
                {
                    _snapRaidConfig = new ConfigFileHelper(Properties.Settings.Default.ConfigFileLocation);
                    if (!_snapRaidConfig.ConfigFileExists) return;
                    _snapRaidConfig.Read();
                    pathsOfInterest = GetPathsOfInterest();
                }
                StartProcessing(pathsOfInterest);
            }
            catch (Exception ex)
            {
                ExceptionHandler.ReportException(ex);
            }
        }

        public void StartProcessing(List<CoveragePath> pathsOfInterest = null)
        {
            ShowXAxisText = true;
            ShowLegend = true;
            ShowYAxisText = true;
            if (pathsOfInterest == null)
            {
                pathsOfInterest = GetPathsOfInterest();
            }

            _oldTooltip = toolTip1.GetToolTip(this);

            toolTip1.SetToolTip(this, "Calculating...");

            FillExpectedLayoutWorker.CancelAsync();

            while (FillExpectedLayoutWorker.IsBusy)
            {
                Thread.Sleep(50);
                Application.DoEvents();
            }
            
            Log.Instance.Info(string.Join(", ", pathsOfInterest));

            FillExpectedLayoutWorker.RunWorkerAsync(pathsOfInterest);
        }

        private void FillExpectedLayoutWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            UseWaitCursor = true;

            ClearExpectedList();

            List<CoveragePath> pathsOfInterest = e.Argument as List<CoveragePath>;

            BackgroundWorker worker = sender as BackgroundWorker;

            if (pathsOfInterest == null || worker == null)
            {
                Log.Instance.Error("Worker, or auguments are null, exiting.");
                return;
            }

            foreach (CoveragePath coveragePath in pathsOfInterest.OrderByDescending(o => o.Path).ToList())
            {
                if (worker.CancellationPending)
                {
                    return;
                }
                if (!Directory.Exists(coveragePath.Path))
                {
                    Log.Instance.Warn($"Directory path does not exist: {coveragePath.Path}");
                    continue;
                }
                CompileChartDataItemForPath(coveragePath.Path);
            }

            AddDataToDisplay();
        }

        private void FillExpectedLayoutWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UseWaitCursor = false;
            toolTip1.SetToolTip(this, _oldTooltip);
        }

        private void ClearExpectedListMethodInvoker()
        {
            _chartDataList.Clear();
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
            _chartDataList.Add(chartDataItem);
        }

        // ReSharper disable once UnusedMember.Local
        private string GetLargestWholenumberSymbolOfChartData()
        {
            List<string> availableSymbols = new List<string> { "", "b", "B", "KB", "MB", "GB", "TB" };
            string currentMaxSymbol = string.Empty;
            foreach (var item in _chartDataList)
            {
                string[] symbols =
                {
                    item.FreeBytesAvailable.LargestWholeNumberSymbol,
                    item.PathUsedBytes.LargestWholeNumberSymbol,
                    item.RootBytesNotCoveredByPath.LargestWholeNumberSymbol
                };
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
            string largestWholenumberSymbolOfChartData = "GB";

            foreach (var item in _chartDataList)
            {
                double[] points =
                {
                    // Scale the values
                    Util.RoundUpToDecimalPlace(item.RootBytesNotCoveredByPath.GigaBytes, 2),
                    Util.RoundUpToDecimalPlace(item.PathUsedBytes.GigaBytes, 2),
                    Util.RoundUpToDecimalPlace(item.FreeBytesAvailable.GigaBytes, 2)
                };

                chart1.Series[0].Points.AddXY(item.Path, points[0]);
                chart1.Series[1].Points.AddXY(item.Path, points[1]);
                chart1.Series[2].Points.AddXY(item.Path, points[2]);

                Log.Instance.Info(
                    "path[{0}], rootBytesNotCoveredByPath[{1}], pathUsedBytes[{2}], freeBytesAvailable[{3}]", 
                    item.Path, points[0], points[1], points[2]);
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

        private void DriveSpaceDisplay_Load(object sender, EventArgs e)
        {
            try
            {
                _snapRaidConfig = new ConfigFileHelper(Properties.Settings.Default.ConfigFileLocation);
                _snapRaidConfig.Read();
                List<CoveragePath> pathsOfInterest = GetPathsOfInterest();
                StartProcessing(pathsOfInterest);
            }
            catch
            {
                // ignored
            }
        }

        private List<CoveragePath> GetPathsOfInterest()
        {
            List<CoveragePath> pathsOfInterest = new List<CoveragePath>();

            // SnapShotsource might be root or folders, so we handle both cases
            foreach (string snapShotSource in _snapRaidConfig.SnapShotSources)
            {
                pathsOfInterest.Add(new CoveragePath
                {
                    Path = Path.GetDirectoryName(snapShotSource) ?? Path.GetFullPath(snapShotSource),
                    PathType = PathTypeEnum.Source
                });
            }

            if (!string.IsNullOrEmpty(_snapRaidConfig.ParityFile1)) { pathsOfInterest.Add(new CoveragePath { Path = Path.GetDirectoryName(_snapRaidConfig.ParityFile1), PathType = PathTypeEnum.Parity }); }

            if (!string.IsNullOrEmpty(_snapRaidConfig.ParityFile2)) { pathsOfInterest.Add(new CoveragePath { Path = Path.GetDirectoryName(_snapRaidConfig.ParityFile2), PathType = PathTypeEnum.Parity }); }

            if (!string.IsNullOrEmpty(_snapRaidConfig.ParityFile3)) { pathsOfInterest.Add(new CoveragePath { Path = Path.GetDirectoryName(_snapRaidConfig.ParityFile3), PathType = PathTypeEnum.Parity }); }

            if (!string.IsNullOrEmpty(_snapRaidConfig.ParityFile4)) { pathsOfInterest.Add(new CoveragePath { Path = Path.GetDirectoryName(_snapRaidConfig.ParityFile4), PathType = PathTypeEnum.Parity }); }

            if (!string.IsNullOrEmpty(_snapRaidConfig.ParityFile5)) { pathsOfInterest.Add(new CoveragePath { Path = Path.GetDirectoryName(_snapRaidConfig.ParityFile5), PathType = PathTypeEnum.Parity }); }

            if (!string.IsNullOrEmpty(_snapRaidConfig.ParityFile6)) { pathsOfInterest.Add(new CoveragePath { Path = Path.GetDirectoryName(_snapRaidConfig.ParityFile6), PathType = PathTypeEnum.Parity }); }

            return pathsOfInterest.OrderBy(s => s.Path).DistinctBy(d => d.Path).ToList();
        }
    }
}