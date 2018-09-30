#region Copyright (C)
// ---------------------------------------------------------------------------------------------------------------
//  <copyright file="DriveSpaceDisplay.cs" company="Smurf-IV">
// 
//  Copyright (C) 2010-2018 Simon Coghlan (Aka Smurf-IV)
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
using Elucidate.Objects;
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
            public PathTypeEnum PathType { get; set; }
            public string Path { get; set; }
            public ByteSize ParityUsedBytes { get; set; }
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
            // ReSharper disable once UnusedMember.Local
            get => chart1.ChartAreas[0].AxisX.LabelStyle.Enabled;
            set => chart1.ChartAreas[0].AxisX.LabelStyle.Enabled = value;
        }

        /// <summary>
        /// Shows the X Axis Text
        /// </summary>
        [DefaultValue(typeof(bool), "true")]
        public bool ShowXAxisText
        {
            // ReSharper disable once UnusedMember.Local
            get => chart1.ChartAreas[0].AxisY.LabelStyle.Enabled;
            set => chart1.ChartAreas[0].AxisY.LabelStyle.Enabled = value;
        }

        /// <summary>
        /// Show the Legend
        /// </summary>
        [DefaultValue(typeof(bool), "true")]
        private bool ShowLegend
        {
            // ReSharper disable once UnusedMember.Local
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

                    if (!_snapRaidConfig.ConfigFileExists)
                    {
                        return;
                    }

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
            
            FillExpectedLayoutWorker.RunWorkerAsync(pathsOfInterest);
        }

        private void FillExpectedLayoutWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            UseWaitCursor = true;

            ClearExpectedList();

            List<CoveragePath> pathsOfInterest = e.Argument as List<CoveragePath>;

            BackgroundWorker worker = sender as BackgroundWorker;

            if (pathsOfInterest == null || !pathsOfInterest.Any() || worker == null)
            {
                Log.Instance.Error("Worker, or auguments are null, exiting.");
                return;
            }

            foreach (CoveragePath coveragePath in pathsOfInterest.OrderByDescending(o => o.FullPath).ToList())
            {
                if (worker.CancellationPending)
                {
                    return;
                }

                if (!Directory.Exists(coveragePath.DirectoryPath) && !File.Exists(coveragePath.FullPath))
                {
                    Log.Instance.Warn($"Directory path does not exist: {coveragePath.FullPath}");
                    continue;
                }

                CompileChartDataItemForPath(coveragePath);
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
        private void CompileChartDataItemForPath(CoveragePath pathOfInterest)
        {
            switch (pathOfInterest.PathType)
            {
                //case PathTypeEnum.Parity when !File.Exists(pathOfInterest.FullPath):
                //    return;
                case PathTypeEnum.Parity:
                    {
                        // parity is always a single file

                        Util.ParityPathFreeBytesAvailable(pathOfInterest.FullPath, out ulong freeBytesAvailable, out ulong pathUsedBytes, out ulong rootBytesNotCoveredByPath);

                        ChartDataItem chartDataItem = new ChartDataItem
                        {
                            PathType = PathTypeEnum.Parity,
                            Path = pathOfInterest.DirectoryPath,
                            ParityUsedBytes = ByteSize.FromBytes(File.Exists(pathOfInterest.FullPath) ? new FileInfo(pathOfInterest.FullPath).Length : 0),
                            FreeBytesAvailable = ByteSize.FromBytes(freeBytesAvailable),
                            PathUsedBytes = new ByteSize(0),
                            RootBytesNotCoveredByPath = ByteSize.FromBytes(rootBytesNotCoveredByPath)
                        };

                        _chartDataList.Add(chartDataItem);
                        break;
                    }
                case PathTypeEnum.Source when !Directory.Exists(pathOfInterest.FullPath):
                    return;
                // data source is always a directory
                case PathTypeEnum.Source:
                    {
                        Util.SourcePathFreeBytesAvailable(pathOfInterest.FullPath, out ulong freeBytesAvailable, out ulong pathUsedBytes, out ulong rootBytesNotCoveredByPath);

                        ChartDataItem chartDataItem = new ChartDataItem
                        {
                            PathType = PathTypeEnum.Source,
                            Path = pathOfInterest.DirectoryPath,
                            ParityUsedBytes = new ByteSize(0),
                            FreeBytesAvailable = ByteSize.FromBytes(freeBytesAvailable),
                            PathUsedBytes = ByteSize.FromBytes(pathUsedBytes),
                            RootBytesNotCoveredByPath = ByteSize.FromBytes(rootBytesNotCoveredByPath)
                        };

                        _chartDataList.Add(chartDataItem);
                        break;
                    }

                default:
                    Log.Instance.Error($"PathType is not supported for the graph.");
                    break;
            }

            Util.Dump(_chartDataList);
        }

        // ReSharper disable once UnusedMember.Local
        private string GetLargestWholeNumberSymbolOfChartData()
        {
            List<string> availableSymbols = new List<string> { "", "b", "B", "KB", "MB", "GB", "TB" };

            string currentMaxSymbol = string.Empty;

            foreach (ChartDataItem item in _chartDataList)
            {
                string[] symbols =
                {
                    item.FreeBytesAvailable.LargestWholeNumberSymbol,
                    item.PathUsedBytes.LargestWholeNumberSymbol,
                    item.RootBytesNotCoveredByPath.LargestWholeNumberSymbol
                };
                foreach (string symbol in symbols)
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
            string largestWholeNumberSymbolOfChartData = "GB";

            foreach (ChartDataItem item in _chartDataList)
            {
                double[] points =
                {
                    // Scale the values
                    Util.RoundUpToDecimalPlace(item.ParityUsedBytes.GigaBytes, 2),
                    Util.RoundUpToDecimalPlace(item.RootBytesNotCoveredByPath.GigaBytes, 2),
                    Util.RoundUpToDecimalPlace(item.PathUsedBytes.GigaBytes, 2),
                    Util.RoundUpToDecimalPlace(item.FreeBytesAvailable.GigaBytes, 2)
                };

                string itemPathDisplay = item.PathType == PathTypeEnum.Parity
                    ? StorageUtil.GetPathRoot(item.Path)
                    : item.Path; 

                chart1.Series[0].Points.AddXY(itemPathDisplay, points[0]);
                chart1.Series[1].Points.AddXY(itemPathDisplay, points[1]);
                chart1.Series[2].Points.AddXY(itemPathDisplay, points[2]);
                chart1.Series[3].Points.AddXY(itemPathDisplay, points[3]);

                Log.Instance.Info($"Storage info: pathType[{item.PathType}], path[{item.Path}], parityUsedBytes[{points[0]}], rootBytesNotCoveredByPath[{points[1]}], pathUsedBytes[{points[2]}], freeBytesAvailable[{points[3]}]");
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
                            dp.Label = $"#VALY\n{largestWholeNumberSymbolOfChartData}";
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

            // SnapShotSource might be root or folders, so we handle both cases
            foreach (string snapShotSource in _snapRaidConfig.SnapShotSources)
            {
                pathsOfInterest.Add(new CoveragePath
                {
                    FullPath = snapShotSource,
                    PathType = PathTypeEnum.Source
                });
            }

            if (!string.IsNullOrWhiteSpace(_snapRaidConfig.ParityFile1))
            {
                pathsOfInterest.Add(new CoveragePath
                    {FullPath = Path.GetFullPath(_snapRaidConfig.ParityFile1), PathType = PathTypeEnum.Parity});
            }

            if (!string.IsNullOrWhiteSpace(_snapRaidConfig.ParityFile2))
            {
                pathsOfInterest.Add(new CoveragePath
                    {FullPath = Path.GetFullPath(_snapRaidConfig.ParityFile2), PathType = PathTypeEnum.Parity});
            }

            if (!string.IsNullOrWhiteSpace(_snapRaidConfig.ZParityFile))
            {
                pathsOfInterest.Add(new CoveragePath
                    { FullPath = Path.GetFullPath(_snapRaidConfig.ZParityFile), PathType = PathTypeEnum.Parity });
            }

            if (!string.IsNullOrWhiteSpace(_snapRaidConfig.ParityFile3))
            {
                pathsOfInterest.Add(new CoveragePath
                    {FullPath = Path.GetFullPath(_snapRaidConfig.ParityFile3), PathType = PathTypeEnum.Parity});
            }

            if (!string.IsNullOrWhiteSpace(_snapRaidConfig.ParityFile4))
            {
                pathsOfInterest.Add(new CoveragePath
                    {FullPath = Path.GetFullPath(_snapRaidConfig.ParityFile4), PathType = PathTypeEnum.Parity});
            }

            if (!string.IsNullOrWhiteSpace(_snapRaidConfig.ParityFile5))
            {
                pathsOfInterest.Add(new CoveragePath
                    {FullPath = Path.GetFullPath(_snapRaidConfig.ParityFile5), PathType = PathTypeEnum.Parity});
            }

            if (!string.IsNullOrWhiteSpace(_snapRaidConfig.ParityFile6))
            {
                pathsOfInterest.Add(new CoveragePath
                    {FullPath = Path.GetFullPath(_snapRaidConfig.ParityFile6), PathType = PathTypeEnum.Parity});
            }

            return pathsOfInterest.OrderBy(s => s.FullPath).DistinctBy(d => d.Drive).ToList();
        }
    }
}