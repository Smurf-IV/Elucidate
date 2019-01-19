#region Copyright (C)
// ---------------------------------------------------------------------------------------------------------------
//  <copyright file="CalculateBlockSize.cs" company="Smurf-IV">
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
using System.Collections.Generic;
using System.IO;

using ComponentFactory.Krypton.Toolkit;

using Elucidate.Shared;

using Microsoft.VisualBasic.Devices;

namespace Elucidate
{
    public partial class CalculateBlockSize : KryptonForm
    {
        public CalculateBlockSize()
        {
            ParityTargets = new List<string>(2);
            InitializeComponent();
            ulong available = new ComputerInfo().TotalPhysicalMemory;
            const Decimal TEST_VALUE = 1UL << 30; // Should be 1 GBytes 
            numericUpDown1.Value = (available / TEST_VALUE) - 1; // remove some to allow for the OS
        }

        private void btnCoverage_Click(object sender, EventArgs e)
        {
            try
            {
                Enabled = false;
                using (new WaitCursor(true))
                {
                    UInt64 min = 0;
                    UInt64 max = 0;
                    foreach (string path in SnapShotSources)
                    {
                        FindAndAddDisplaySizes(path, ref min, ref max);
                    }
                    // TotalStorage*28 div(Val*1024) = OS Ram required
                    min *= 28;
                    max *= 28;
                    UInt64 i = (1 << 10); // = 1024 
                    i <<= 30;   // * 1GB
                    min /= (UInt64)(numericUpDown1.Value * i);
                    max /= (UInt64)(numericUpDown1.Value * i);

                    // Any smaller than 256 is not really recommended - so let's make it the minimum
                    min = (min < 256) ? 256 : min;
                    max = (max < 256) ? 256 : max;

                    txtBlockSizeByCoverageMin.Text = FindNextPow2(min);
                    txtBlockSizeByCoverageMax.Text = FindNextPow2(max);
                }
            }
            finally
            {
                Enabled = true;
            }
        }

        private static string FindNextPow2(UInt64 val)
        {
            UInt64 positions = 2;
            while (positions < val)
            {
                positions <<= 1;
            }
            return positions.ToString();
        }

        public List<string> SnapShotSources { private get; set; }

        public List<string> ParityTargets { get; private set; }

        // Need to find 3 values, Total drive size, Root drive used, actual used by path
        // Need to be aware of UNC paths
        // Need to be aware of Junctions
        private static void FindAndAddDisplaySizes(string path, ref UInt64 min, ref UInt64 max)
        {
            // ReSharper disable once UnusedVariable
            Util.SourcePathFreeBytesAvailable(path, out ulong freeBytesAvailable, out ulong pathUsedBytes, out ulong rootBytesNotCoveredByPath);

            min += pathUsedBytes;
            max += pathUsedBytes;
            max += freeBytesAvailable;
        }

        private void btnFileCount_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBlockSizeByCoverageMin.Text))
            {
                btnCoverage_Click(sender, e);
            }

            try
            {
                Enabled = false;
                using (new WaitCursor(true))
                {
                    ulong freeBytesAvailable;
                    ulong pathUsedBytes;
                    ulong rootBytesNotCoveredByPath;

                    // e.g. 100,000 files @ 256KB/2 block size = 12GB of "extra" space
                    // So this is alot more tricky.

                    // 1st get the Minimum space that could be used for the Parity (Ignore the existing parity)
                    // For each parity target find min space after ignoring "existing" parity file

                    ulong maxParitySizeAvailable = ulong.MaxValue;
                    foreach (string parityTarget in ParityTargets)
                    {
                        string parityTargetDriveRoot = Directory.GetDirectoryRoot(parityTarget);
                        Util.SourcePathFreeBytesAvailable(parityTargetDriveRoot, out freeBytesAvailable, out pathUsedBytes, out rootBytesNotCoveredByPath);
                        ulong currentTarget = freeBytesAvailable + pathUsedBytes;
                        if (maxParitySizeAvailable > currentTarget)
                        {
                            maxParitySizeAvailable = currentTarget;
                        }
                    }

                    ulong minFiles = 0;
                    ulong maxFiles = 1 << 18;

                    // 2 - Then for each of the sources, get the number of actual files
                    // Set Min value to the actual max of the files
                    // 3 - Then for each source find actual and available coverage
                    // use the actual files, and project to theoretical possible
                    // Set Max value to the max of those
                    // 4 - Find the Max covered, 
                    ulong maxProjectedSource = 0;
                    foreach (string path in SnapShotSources)
                    {
                        Util.SourcePathFreeBytesAvailable(
                            path, 
                            out freeBytesAvailable, 
                            out pathUsedBytes,
                            out rootBytesNotCoveredByPath);

                        ulong currentSource = freeBytesAvailable + pathUsedBytes;

                        if (maxProjectedSource < currentSource)
                        {
                            maxProjectedSource = currentSource;
                        }
                    }

                    // 5 - Make sure that Parity has enough room times the number of max files, 
                    // and add onto the left over space to find the min and max values.

                    ulong minParityNeeded = maxProjectedSource + (minFiles * ulong.Parse(txtBlockSizeByCoverageMin.Text)) / 2;
                    ulong maxParityNeeded = maxProjectedSource + (maxFiles * ulong.Parse(txtBlockSizeByCoverageMax.Text)) / 2;
                    if (maxParityNeeded > maxParitySizeAvailable)
                    {
                        lblBadNews.Text =
                            @"Display bad news about theoretical projected value - maxParityNeeded > maxParitySizeAvailable";
                    }

                    if (minParityNeeded > maxParitySizeAvailable)
                    {
                        // Display bad news about theoretical projected value;
                        lblBadNews.Text =
                            @"Display bad news about theoretical projected value - minParityNeeded > maxParitySizeAvailable";
                    }
                }
            }
            catch (Exception ex)
            {
                Exception exx = ex;
            }
            finally
            {
                Enabled = true;
            }
        }

    }
}
