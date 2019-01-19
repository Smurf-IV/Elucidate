#region Copyright (C)
// ---------------------------------------------------------------------------------------------------------------
//  <copyright file="SyncVerb.cs" company="Smurf-IV">
// 
//  Copyright (C) 2018 Simon Coghlan (Aka Smurf-IV)
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

using CommandLine;

// ReSharper disable UnusedMember.Global

namespace Elucidate.CmdLine
{
    [Verb("sync", HelpText = "Synchronise with any changes that may have occurred since the last run.")]
    internal class SyncVerb : StdOptions
    {
        [Option('h', "pre-hash",
            HelpText = "In \"sync\" runs a preliminary hashing phase of all the new data to have an additional verification before " +
                       "the parity computation. Usually in \"sync\" no preliminary hashing is done, and the new data is hashed just " +
                       "before the parity computation when it's read for the first time. Unfortunately, this process happens when " +
                       "the system is under heavy load, with all disks spinning and with a busy CPU. This is an extreme condition " +
                       "for the machine, and if it has a latent hardware problem, it's possible to encounter silent errors that " +
                       "cannot be detected because the data is not yet hashed. To avoid this risk, you can enable the \"pre -hash\" " +
                       "mode and have all the data read two times to ensure its integrity. This option also verifies the files moved " +
                       "inside the array, to ensure that the move operation went successfully, and in case to block the sync and " +
                       "to allow to run a fix operation. This option can be used only with \"sync\".")]
        public bool PreHash { get; set; }

        [Option('Z', "force-zero",
            HelpText = "Forces the insecure operation of syncing a file with zero size that before was not. " +
                       "If SnapRAID detects a such condition, it stops proceeding unless you specify this option. " +
                       "This allows to easily detect when after a system crash, some accessed files were truncated. " +
                       "This is a possible condition in Linux with the ext3/ext4 file-systems. " +
                       "This option can be used only with \"sync\".")]
        public bool ForceZero { get; set; }

        [Option('E', "force-empty",
            HelpText = @"Forces the insecure operation of syncing a disk with all the original files missing.If SnapRAID detects " +
                       "that all the files originally present in the disk are missing or rewritten, it stops proceeding unless you " +
                       "specify this option.This allows to easily detect when a data file-system is not mounted. " +
                       "This option can be used only with \"sync\".  ")]
        public bool ForceEmpty { get; set; }

        [Option('U', "force-uuid",
            HelpText = "Forces the insecure operation of syncing, checking and fixing with disks that have changed their UUID. " +
                       "If SnapRAID detects that some disks have changed UUID, it stops proceeding unless you specify this option. " +
                       "This allows to detect when your disks are mounted in the wrong mount points. It's anyway allowed to have " +
                       "a single UUID change with single parity, and more with multiple parity, because it's the normal case of " +
                       "replacing disks after a recovery. This option can be used only with \"sync\", \"check\" or \"fix\".")]
        public bool ForceUuid { get; set; }

        [Option('N', "force-nocopy",
            HelpText = "In \"sync\", \"check\" and \"fix\", disables the copy detection heuristic.Without this option SnapRAID assumes " +
                       "that files with same attributes, like name, size and time-stamp are copies with the same data. " +
                       "This allows to identify copied or moved files from one disk to another, and to reuse the already computed " +
                       "hash information to detect silent errors or to recover missing files. This behavior, in some rare cases, " +
                       "may result in false positives, or in a slow process due the many hash verifications, and this option allows " +
                       "to resolve them. This option can be used only with \"sync\", \"check\" and \"fix\".")]
        public bool ForceNoCopy { get; set; }

        [Option('F', "force-full",
            HelpText = "In \"sync\" forces a full rebuild of the parity.This option can be used when you add a new parity level, " +
                       "or if you reverted back to an old content file using a more recent parity data.Instead of recomputing " +
                       "the parity from scratch, this allows to reuse the hashes present in the content file to validate data, " +
                       "and to maintain data protection during the \"sync\" process using the parity data you have." +
                       "This option can be used only with \"sync\".")]
        public bool ForceFull { get; set; }

        [Option('R', "force-realloc",
            HelpText = "In \"sync\" forces a full reallocation of files and rebuild of the parity. " +
                       "This option can be used to completely reallocate all the files removing the fragmentation, but reusing the " +
                       "hashes present in the content file to validate data. Compared to -F, --force-full, this option reallocates " +
                       "all the parity not having data protection during the operation. This option can be used only with \"sync\".")]
        public bool ForceRealloc { get; set; }

    }
}
