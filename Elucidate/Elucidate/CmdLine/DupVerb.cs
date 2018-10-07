using CommandLine;

// ReSharper disable UnusedMember.Global

namespace Elucidate.CmdLine
{
    [Verb("dup", HelpText = "Lists all the duplicate files. Two files are assumed equal if their hashes are matching. ")]
    internal class DupVerb : StdOptions    
    {
    }
}
