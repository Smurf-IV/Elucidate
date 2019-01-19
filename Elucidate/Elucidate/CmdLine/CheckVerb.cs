#region Copyright (C)
// ---------------------------------------------------------------------------------------------------------------
//  <copyright file="CheckVerb.cs" company="Smurf-IV">
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
    [Verb("check", HelpText = "Check the snapshot to confirm it's integrity. (use -a for hash only)")]
    internal class CheckVerb : StdOptions
    {
        [Option('f', "filter", // PATTERN] 
            HelpText = "Filters the files to process in \"check\" and \"fix\". Only the files matching the entered pattern are processed. " +
                       "This option can be used many times.See the PATTERN section for more details in the pattern specifications. " +
                       "In Unix, ensure to quote globbing chars if used.This option can be used only with \"check\" and \"fix\". " +
                       "Note that it cannot be used with \"sync\" and \"scrub\", because they always process the whole array.")]
        public string Filter { get; set; }

        [Option('d', "filter-disk", // NAME,
            HelpText = "Filters the disks to process in \"check\", \"fix\", \"up\" and \"down\". You must specify a disk name as named " +
                       "in the configuration file.You can also specify parity disks with the names: \"parity\", \"2-parity\", " +
                       "\"3 -parity\", ... to limit the operations a specific parity disk.If you combine more --filter, " +
                       "--filter-disk and --filter-missing options, only files matching all the set of filters are selected. " +
                       "This option can be used many times. This option can be used only with \"check\", \"fix\", \"up\" and \"down\". " +
                       "Note that it cannot be used with \"sync\" and \"scrub\", because they always process the whole array.")]
        public string FilterDisk { get; set; }

        [Option('m', "filter-missing",
            HelpText = "Filters the files to process in \"check\" and \"fix\". Only the files missing/deleted from the array are processed. " +
                       "When used with \"fix\", this is a kind of \"undelete\" command.If you combine more --filter, --filter-disk " +
                       "and --filter-missing options, only files matching all the set of filters are selected. " +
                       "This option can be used only with \"check\" and \"fix\". Note that it cannot be used with \"sync\" and \"scrub\", " +
                       "because they always process the whole array.")]
        public bool FilterMissing { get; set; }

        [Option('e', "filter-error",
            HelpText = "Filters the blocks to process in \"check\" and \"fix\". It processes only the blocks marked with silent or " +
                       "input/output errors during \"sync\" and \"scrub\", and listed in \"status\". This option can be used only with \"check\" and \"fix\".  ")]
        public bool FilterError { get; set; }

        [Option('a', "audit-only",
            HelpText = "In \"check\" verifies the hash of the files without doing any kind of check on the parity data. " +
                       "If you are interested in checking only the file data this option can speedup a lot the checking process. " +
                       "This option can be used only with \"check\".  ")]
        public bool AuditOnly { get; set; }

        [Option('i', "import", // DIR,
            HelpText = "Imports from the specified directory any file that you deleted from the array after the last \"sync\". " +
                       "If you still have such files, they could be used by \"check\" and \"fix\" to improve the recover process. " +
                       "The files are read also in subdirectories and they are identified regardless of their name.This option " +
                       "can be used only with \"check\" and \"fix\".  ")]
        public string Import { get; set; }

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


    }
}
