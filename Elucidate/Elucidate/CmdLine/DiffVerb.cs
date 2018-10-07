using CommandLine;

// ReSharper disable UnusedMember.Global

namespace Elucidate.CmdLine
{
    [Verb("diff", HelpText = "Lists all the files have been modified since the last \"sync\" command.")]
    internal class DiffVerb : StdOptions
    {
    }
}
