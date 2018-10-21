#region Copyright (C)
// ---------------------------------------------------------------------------------------------------------------
//  <copyright file="ScrubVerb.cs" company="Smurf-IV">
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
    [Verb("scrub", HelpText = "Defaults to 100% (-p100) of all of blocks (older than 0 days = -o0).\r\nBlocks alre" +
                              "ady marked as bad are always checked.\r\nUse \"Additional Command\" to override the " +
                              "default of 100% of 0 days")]
    internal class ScrubVerb : StdOptions
    {
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


    }
}
