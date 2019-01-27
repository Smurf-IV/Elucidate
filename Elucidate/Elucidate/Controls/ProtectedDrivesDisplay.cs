using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Alphaleonis.Win32.Filesystem;

using ByteSizeLib;

using Elucidate.Objects;

using NLog;

namespace Elucidate.Controls
{
    public partial class ProtectedDrivesDisplay : UserControl
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private CancellationTokenSource cancelTokenSrc;

        private volatile int useWaitCursor;

        public ProtectedDrivesDisplay()
        {
            cancelTokenSrc = new CancellationTokenSource();
            InitializeComponent();
        }

        public void FormClosing()
        {
            // have to stop "any" processes that might be refreshing as this is now closing
            cancelTokenSrc.Cancel();
        }

        private void IncrementWaitCursor()
        {
            if (Interlocked.Increment(ref useWaitCursor) == 1)
            {
                BeginInvoke((MethodInvoker) delegate { UseWaitCursor = true; });
            }
        }

        private void DecrementWaitCursor()
        {
            if (Interlocked.Decrement(ref useWaitCursor) == 0)
            {
                BeginInvoke((MethodInvoker) delegate { UseWaitCursor = false; });
            }
        }

        /// <summary>
        /// Take an existing config file and populate the Grid
        /// </summary>
        /// <param name="srConfig"></param>
        /// <param name="excludeParity"></param>
        public void RefreshGrid(ConfigFileHelper srConfig, bool excludeParity)
        {
            // have to stop "any" processes that might be refreshing as this is a new list
            IncrementWaitCursor();
            cancelTokenSrc.Cancel();
            while (driveGrid.Rows.Count > 1)
            {
                driveGrid.Rows.RemoveAt(0);
            }
            List<CoveragePath> pathsOfInterest = srConfig.GetPathsOfInterest();
            cancelTokenSrc = new CancellationTokenSource();
            if (excludeParity)
            {
                foreach (CoveragePath coveragePath in pathsOfInterest.Where(s => s.PathType == PathTypeEnum.Source))
                {
                    AddCoverage(coveragePath);
                }
            }
            else
            {
                pathsOfInterest.ForEach(AddCoverage);
            }

            DecrementWaitCursor();
        }

        public void AddCoverage(CoveragePath coveragePath)
        {
            DataGridViewRow row = (DataGridViewRow)driveGrid.RowTemplate.Clone();
            row.CreateCells(driveGrid, coveragePath.FullPath, coveragePath.Name, null, @"Processing");
            row.Tag = coveragePath;
            driveGrid.Rows.Add(row);
        }

        private void driveGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (!cancelTokenSrc.IsCancellationRequested)
            {
                for (int index = e.RowIndex; index < e.RowIndex+ e.RowCount; index++)
                {
                    // Get data to perform drive usage display
                    DataGridViewRow row = driveGrid.Rows[index];
                    StartDriveUsage(cancelTokenSrc.Token, row);
                }
            }
        }

        private void StartDriveUsage(CancellationToken token, DataGridViewRow row)
        {
            IncrementWaitCursor();
            if (row.Tag is CoveragePath coveragePath)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(coveragePath.DirectoryPath, PathFormat.FullPath);
                DriveInfo driveInfo = new DriveInfo(dirInfo.Root.FullName);
                if (coveragePath.PathType == PathTypeEnum.Parity)
                {
                    long totalUsed = driveInfo.TotalSize - driveInfo.AvailableFreeSpace;
                    long protectedUse = File.Exists(coveragePath.FullPath) ? new FileInfo(coveragePath.FullPath).Length : 0L;
                    row.Cells[2].Value = $@"{protectedUse}:{totalUsed}:{driveInfo.TotalSize}";
                    row.Cells[3].Value = $@"{new ByteSize(protectedUse)} : {new ByteSize(totalUsed)} : {new ByteSize(driveInfo.TotalSize)}";
                    DecrementWaitCursor();
                }
                else
                {
                    // Start background processing
                    Task.Run(() => { ProcessProtectedSpace(row, driveInfo, dirInfo, token); }, token);
                }
            }

        }

        private void ProcessProtectedSpace(DataGridViewRow row, DriveInfo driveInfo,
            DirectoryInfo dirInfo, CancellationToken token)
        {

            long totalUsed = driveInfo.TotalSize - driveInfo.AvailableFreeSpace;

            ulong protectedUse = DirSize(dirInfo, token);
            if (!token.IsCancellationRequested)
            {
                BeginInvoke((MethodInvoker) delegate
                {
                    row.Cells[2].Value = $@"{protectedUse}:{totalUsed}:{driveInfo.TotalSize}";
                    row.Cells[3].Value =
                        $@"{new ByteSize(protectedUse)} : {new ByteSize(totalUsed)} : {new ByteSize(driveInfo.TotalSize)}";
                });
            }

            DecrementWaitCursor();
        }

        /// <summary>
        /// Recursive and allow cancellation
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        private static ulong DirSize(DirectoryInfo dir, CancellationToken token)
        {
            try
            {
                if (token.IsCancellationRequested)
                {
                    return 0UL;
                }

                return dir.GetFiles()
                           .Sum(fi => (ulong)fi.Length) + dir.GetDirectories()
                           .Where(d => (d.Attributes & System.IO.FileAttributes.System) == 0 && (d.Attributes & System.IO.FileAttributes.Hidden) == 0)
                           .Sum(info => DirSize(info, token));
            }
            catch (UnauthorizedAccessException ex)
            {
                Log.Warn(string.Concat("No Access to ", dir.FullName), ex);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

            return 0UL;
        }

    }
}
