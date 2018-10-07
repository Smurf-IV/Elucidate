using CommandLine;

// ReSharper disable UnusedMember.Global

namespace Elucidate.CmdLine
{
    [Verb("status", HelpText = "A summary of the state of the disk array, upto the last sync time.")]
    internal class StatusVerb : StdOptions
    {
    }
}
