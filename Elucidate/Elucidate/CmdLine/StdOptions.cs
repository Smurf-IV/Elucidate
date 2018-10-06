using CommandLine;

// ReSharper disable UnusedMember.Global

namespace Elucidate.CmdLine
{
    internal class StdOptions
    {
        [Option('v', "verbose",
            Default = false,
            HelpText = "Prints all messages to standard output.")]
        public bool Verbose { get; set; }

        [Option('l', "log", // FILE
            HelpText = "Write a detailed log in the specified file.If this option is not specified, unexpected errors are printed " +
                       "on the screen, likely resulting in too much output in case of many errors.When -l, --log is specified, on " +
                       "the screen, go only fatal errors that makes SnapRAID to stop progress. If the path starts with '>>' the " +
                       "file is opened in append mode. Occurrences of '%D' and '%T' in the name are replaced with the date and time " +
                       "in the format YYYYMMDD and HHMMSS.Note that in Windows batch files, you'll have to double the '%' char, " +
                       "like result-%%D.log. And to use '>>' you'll have to enclose the name in, like \">> result.log\". " +
                       "To output the log to standard output or standard error, you can use respectively \" > &1\" and \">&2\".  ")]
        public string LogFile { get; set; }

        [Option('L', "error-limit",
            HelpText = "Sets a new error limit before stopping execution. By default SnapRAID stops if it encounters more than 100 " +
                       "Input/Output errors, meaning that likely a disk is going to die. This options affects \"sync\" and \"scrub\", " +
                       "that are allowed to continue after the first bunch of disk errors, to try to complete at most their operations. " +
                       "Instead, \"check\" and \"fix\" always stop at the first error.")]
        public uint ErrorLimit { get; set; }

        [Option('S', "start", // BLKSTART,
            HelpText = @"Starts the processing from the specified block number. It could be useful to retry to check or fix some " +
                       "specific block, in case of a damaged disk. It's present mainly for advanced manual recovering.")]
        public uint Start { get; set; }

        [Option('B', "count", // BLKCOUNT,
            HelpText = @"Processes only the specified number of blocks. It's present mainly for advanced manual recovering.")]
        public uint Count { get; set; }

        [Option('q', "quiet",
            HelpText = "Prints less information on the screen.If specified one time, removes the progress bar, if two times," +
                       "the running operations, three times, the info messages, four times the status messages." +
                       "Fatal errors are always printed on the screen. This option has no effect on the log files.")]
        public bool Quiet { get; set; }

        // -H, --help
        // Prints a short help screen.

        // -V, --version
        // Prints the program version.
    }

    internal class AllOptions : StdOptions
    {
        // <- Do not implement this, as it should be covered by Elucidate ->
        //[-c, --conf" // CONFIG] 
        // Selects the configuration file to use.If not specified in Unix it's used the file "/usr/local/etc/snapraid.conf"
        // if it exists, or "/etc/snapraid.conf" otherwise.
        // In Windows it's used the file "snapraid.conf" in the same directory of "snapraid.exe". 

        [Option('f', "filter", // PATTERN] 
            HelpText = "Filters the files to process in \"check\" and \"fix\". Only the files matching the entered pattern are processed. " +
            "This option can be used many times.See the PATTERN section for more details in the pattern specifications. " +
            "In Unix, ensure to quote globbing chars if used.This option can be used only with \"check\" and \"fix\". " +
        "Note that it cannot be used with \"sync\" and \"scrub\", because they always process the whole array.")]
        public string Filter { get; set; }


        [Option('d', "filter-disk", // NAME,
        HelpText = "Filters the disks to process in \"check\", \"fix\", \"up\" and \"down\". You must specify a disk name as named " +
        "in the configuration file. You can also specify parity disks with the names: \"parity\", \"2-parity\", " +
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

        [Option('p', "plan", // PERC|bad|new|full,
        HelpText = "Selects the scrub plan. If PERC is a numeric value from 0 to 100, it's interpreted as the percentage of " +
        "blocks to scrub. Instead of a percentage, you can also specify a plan: \"bad\" scrubs bad blocks, " +
        "\"new\" the blocks not yet scrubbed, and \"full\" for everything. This option can be used only with \"scrub\".  ")]
        public string Plan { get; set; }

        [Option('o', "older-than", // DAYS,
        HelpText = "Selects the older the part of the array to process in \"scrub\". DAYS is the minimum age in days for a " +
        "block to be scrubbed, default is 10. Blocks marked as bad are always scrubbed despite this option. " +
        "This option can be used only with \"scrub\".  ")]
        public uint OlderThan { get; set; }

        [Option('a', "audit-only",
                HelpText = "In \"check\" verifies the hash of the files without doing any kind of check on the parity data. " +
        "If you are interested in checking only the file data this option can speedup a lot the checking process. " +
        "This option can be used only with \"check\".  ")]
        public bool AuditOnly { get; set; }

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

        [Option('i', "import", // DIR,
        HelpText = "Imports from the specified directory any file that you deleted from the array after the last \"sync\". " +
        "If you still have such files, they could be used by \"check\" and \"fix\" to improve the recover process. " +
        "The files are read also in subdirectories and they are identified regardless of their name.This option " +
        "can be used only with \"check\" and \"fix\".  ")]
        public string Import { get; set; }

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
        public bool ForceUUID { get; set; }

        [Option('D', "force-device",
                HelpText = "Forces the insecure operation of fixing with inaccessible disks, or with disks on the same physical device. " +
                           "Like if you lost two data disks, and you have a spare disk to recover only the first one, and you want to " +
                           "ignore the second inaccessible disk.Or if you want to recover a disk in the free space left in an already " +
                           "used disk, sharing the same physical device.This option can be used only with \"fix\".")]
        public bool ForceDevice { get; set; }

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

        // <- Do not implement this, as it should be covered by Elucidate ->
        //[Option('C', "gen-conf", // CONTENT_FILE,
        //HelpText = "Generates a dummy configuration file from an existing content file. The configuration file is written in "+
        //"the standard output, and it doesn't overwrite an existing one. This configuration file also contains the "+
        //"information needed to reconstruct the disk mount points, in case you lose the entire system.")]
        //public string ContentFile { get; set; }
    }
}
