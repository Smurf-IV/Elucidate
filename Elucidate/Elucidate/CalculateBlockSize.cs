using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Elucidate.Shared;
using Microsoft.VisualBasic.Devices;

namespace Elucidate
{
    public partial class CalculateBlockSize : Form
    {
        public CalculateBlockSize()
        {
            ParityTargets = new List<string>(2);
            InitializeComponent();
            ulong available = new ComputerInfo().TotalPhysicalMemory;
            const Decimal testValue = 1UL << 30; // Should be 1 GBytes 
            numericUpDown1.Value = (available / testValue) - 1; // remove some to allow for the OS
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
                    // Any smaller than 256 is not really recommended
                    txtCoverageMin.Text = FindNextPow2(min);
                    txtCoverageMax.Text = FindNextPow2(max);
                }
            }
            finally
            {
                Enabled = true;
            }
        }

        private static string FindNextPow2(UInt64 val)
        {
            UInt64 positions = 64;
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
            Util.FreeBytesAvailable(path, out var freeBytesAvailable, out var pathUsedBytes, out ulong rootBytesNotCoveredByPath);
            min += pathUsedBytes;
            max += pathUsedBytes;
            max += freeBytesAvailable;
        }

        private void btnFileCount_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCoverageMin.Text))
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
                    foreach (string raidTarget in ParityTargets)
                    {
                        Util.FreeBytesAvailable(raidTarget, out freeBytesAvailable, out pathUsedBytes, out rootBytesNotCoveredByPath);
                        ulong currentTarget = freeBytesAvailable + pathUsedBytes;
                        if (maxParitySizeAvailable > currentTarget)
                        {
                            maxParitySizeAvailable = currentTarget;
                        }
                    }

                    // 2 - Then for each of the sources, get the number of actual files
                    // Set Min value to the actual max of the files

                    // 3 - Then for each source find actual and available coverage
                    //  use the actual files, and project to theoretical possible
                    // Set Max value to the max of those
                    ulong minFiles = 0;

                    // 4 - Find the Max covered, 
                    ulong maxFiles = 1 << 18;

                    // 5 - Make sure that Parity has enough room times the number of max files, 
                    // and add onto the left over space to find the min and max values.
                    ulong maxProjectedSource = 0;
                    foreach (string path in SnapShotSources)
                    {
                        Util.FreeBytesAvailable(path, out freeBytesAvailable, out pathUsedBytes, out rootBytesNotCoveredByPath);
                        ulong currentSource = freeBytesAvailable + pathUsedBytes;
                        if (maxProjectedSource < currentSource)
                        {
                            maxProjectedSource = currentSource;
                        }
                    }
                    ulong minParityNeeded = maxProjectedSource + (minFiles * ulong.Parse(txtCoverageMin.Text)) / 2;
                    ulong maxParityNeeded = maxProjectedSource + (minFiles * ulong.Parse(txtCoverageMax.Text)) / 2;
                    if (maxParityNeeded > maxParitySizeAvailable)
                    {
                        lblBadNews.Text = @"Display badnews about theoretical projected value - maxParityNeeded > maxParitySizeAvailable";
                    }
                    if (minParityNeeded > maxParitySizeAvailable)
                    {
                        // Display bad news about theoretical projected value;
                        lblBadNews.Text = @"Display badnews about theoretical projected value - minParityNeeded > maxParitySizeAvailable";
                    }
                }
            }
            finally
            {
                Enabled = true;
            }
        }

    }
}
