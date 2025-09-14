﻿#region Copyright (C)
//  <copyright file="ProtectedDrivesDisplay.cs" company="Smurf-IV">
//
//  Copyright (C) 2019-2025 Smurf-IV
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
#endregion Copyright (C)

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Alphaleonis.Win32.Filesystem;

using ByteSizeLib;

using Elucidate.Objects;

using NLog;

namespace Elucidate.Controls;

internal partial class ProtectedDrivesDisplay : UserControl
{
    private static readonly Logger Log = LogManager.GetCurrentClassLogger();
    private CancellationTokenSource cancelTokenSrc;

    private volatile int useWaitCursor;

    internal ProtectedDrivesDisplay()
    {
        InitializeComponent();
        cancelTokenSrc = new CancellationTokenSource();
    }

    internal void StopProcessing()
    {
        // have to stop "any" processes that might be refreshing as this is now closing
        cancelTokenSrc.Cancel();
    }

    private void IncrementWaitCursor()
    {
        if (Interlocked.Increment(ref useWaitCursor) == 1)
        {
            BeginInvoke((MethodInvoker)(() => UseWaitCursor = true));
        }
    }

    private void DecrementWaitCursor()
    {
        if (Interlocked.Decrement(ref useWaitCursor) <= 0)
        {
            BeginInvoke((MethodInvoker)(() => UseWaitCursor = false));
        }
    }

    /// <summary>
    /// Take an existing config file and populate the Grid
    /// </summary>
    /// <param name="srConfig"></param>
    /// <param name="excludeParity"></param>
    public void RefreshGrid(ConfigFileHelper srConfig, bool excludeParity)
    {
        Interlocked.Exchange(ref useWaitCursor, 0);
        IncrementWaitCursor();
        // have to stop "any" processes that might be refreshing as this is a new list
        cancelTokenSrc.Cancel();
        while (driveGrid.Rows.Count > 1)    // Got to leave the "New" edit row
        {
            driveGrid.Rows.RemoveAt(0);
        }
        var pathsOfInterest = srConfig.GetPathsOfInterest();
        cancelTokenSrc = new CancellationTokenSource();
        if (excludeParity)
        {
            foreach (CoveragePath coveragePath in pathsOfInterest.Where(static s => s.PathType == PathTypeEnum.Source))
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
        var row = (DataGridViewRow)driveGrid.RowTemplate.Clone()!;
        row.CreateCells(driveGrid, coveragePath.FullPath, coveragePath.Name, null, @"Processing");
        row.Tag = coveragePath;
        driveGrid.Rows.Add(row);
    }

    private void driveGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
    {
        if (!cancelTokenSrc.IsCancellationRequested)
        {
            for (var index = e.RowIndex; index < e.RowIndex + e.RowCount; index++)
            {
                // Get data to perform drive usage display
                DataGridViewRow row = driveGrid.Rows[index];
                StartDriveUsage(row, cancelTokenSrc.Token);
            }
        }
    }

    private void StartDriveUsage(DataGridViewRow row, CancellationToken token)
    {
        if (row.Tag is CoveragePath coveragePath)
        {
            var dirInfo = new DirectoryInfo(coveragePath.DirectoryPath, PathFormat.FullPath);
            var driveInfo = new DriveInfo(dirInfo.Root.FullName);
            if (coveragePath.PathType == PathTypeEnum.Parity
                || dirInfo.FullName == driveInfo.Name)
            {
                var totalUsed = driveInfo.TotalSize - driveInfo.AvailableFreeSpace;
                var protectedUse = File.Exists(coveragePath.FullPath) ? new FileInfo(coveragePath.FullPath).Length : (dirInfo.FullName == driveInfo.Name)? totalUsed:0L;
                row.Cells[2].Value = $@"{protectedUse}:{totalUsed}:{driveInfo.TotalSize}";
                row.Cells[3].Value = $@"{ByteSize.FromBytes(protectedUse).ToBinaryString()}  :  {ByteSize.FromBytes(totalUsed).ToBinaryString()}  :  {ByteSize.FromBytes(driveInfo.TotalSize).ToBinaryString()}";
            }
            else
            {
                // Start background processing
                IncrementWaitCursor();
                Task.Run(() => ProcessProtectedSpace(row, driveInfo, dirInfo, token), token);
            }
        }
    }

    private void ProcessProtectedSpace(DataGridViewRow row, DriveInfo driveInfo,
        DirectoryInfo dirInfo, CancellationToken token)
    {
        var totalUsed = driveInfo.TotalSize - driveInfo.AvailableFreeSpace;

        var protectedUse = DirSize(dirInfo, token);
        if (!token.IsCancellationRequested)
        {
            BeginInvoke((MethodInvoker)delegate
           {
               try
               {
                   row.Cells[2].Value = $@"{protectedUse}:{totalUsed}:{driveInfo.TotalSize}";
                   row.Cells[3].Value =
                       $@"{ByteSize.FromBytes(protectedUse).ToBinaryString()}  :  {ByteSize.FromBytes(totalUsed).ToBinaryString()}  :  {ByteSize.FromBytes(driveInfo.TotalSize).ToBinaryString()}";
               }
               catch
               {
                   // Do nothing
                   // Might be caused by fast closure
               }
           });
        }

        DecrementWaitCursor();
    }

    /// <summary>
    /// Recursive and allow cancellation
    /// </summary>
    /// <param name="dir"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    private static ulong DirSize(DirectoryInfo dir, CancellationToken token)
    {
        try
        {
            if (token.IsCancellationRequested
                || dir.EntryInfo.IsMountPoint
                || dir.EntryInfo.IsSymbolicLink)
            {
                return 0UL;
            }

            return dir.EnumerateFiles().AsParallel().Sum(static fi => (ulong)fi.Length)
                   + dir.EnumerateDirectories()
                       .Where(static d => (d.Attributes & System.IO.FileAttributes.System) == 0 
                                          && (d.Attributes & System.IO.FileAttributes.Hidden) == 0)
                       .AsParallel()
                       .Sum(info => DirSize(info, token));
        }
        catch (UnauthorizedAccessException ex)
        {
            Log.Warn(ex, @"No Access to [{0}]", dir.FullName);
        }
        catch (Exception ex)
        {
            Log.Warn(ex);
        }

        return 0UL;
    }

    private void DriveGrid_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            DataGridView.HitTestInfo hti = driveGrid.HitTest(e.X, e.Y);
            driveGrid.ClearSelection();
            driveGrid.Rows[hti.RowIndex].Selected = true;
        }
    }
}
