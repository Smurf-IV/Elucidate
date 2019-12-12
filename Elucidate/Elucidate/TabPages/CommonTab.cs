#region Copyright (C)
// ---------------------------------------------------------------------------------------------------------------
//  <copyright file="Settings.cs" company="Smurf-IV">
//
//  Copyright (C) 2010-2020 Simon Coghlan (Aka Smurf-IV) & BlueBlock 2018
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
#endregion Copyright (C)

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using CommandLine;
using CommandLine.Text;
using ComponentFactory.Krypton.Toolkit;

using Elucidate.CmdLine;
using Elucidate.Controls;

using NLog;

namespace Elucidate.TabPages
{
    internal partial class CommonTab : UserControl
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        private RunControl _liveRunLogControl;

        public RunControl RunLogControl
        {
            set
            {
                _liveRunLogControl = value;
                _liveRunLogControl.TaskCompleted += liveRunLogControl1_RunWorkerCompleted;
            }
        }

        public CommonTab()
        {
            InitializeComponent();
            // Force the output of the help for each verb
            Parser parser = new Parser(with => with.HelpWriter = null);
            HelpText helpVerb = new HelpText
                {
                    AddDashesToOption = true,
                    AddEnumValuesToHelpText = true,
                    AdditionalNewLineAfterOption = true,
                    MaximumDisplayWidth = 160,
                    AutoHelp = false,
                    AutoVersion = false
                };

            btnSync.ToolTipValues.Description = helpVerb.AddOptions(parser.ParseArguments<SyncVerb>(new[] { @"--help" })).ToString();
            btnStatus.ToolTipValues.Description = helpVerb.AddOptions(parser.ParseArguments<StatusVerb>(new[] { @"--help" })).ToString();
            btnDupFinder.ToolTipValues.Description = helpVerb.AddOptions(parser.ParseArguments<DupVerb>(new[] { @"--help" })).ToString();
            btnCheck.ToolTipValues.Description = helpVerb.AddOptions(parser.ParseArguments<CheckVerb>(new[] { @"--help" })).ToString();
            btnDiff.ToolTipValues.Description = helpVerb.AddOptions(parser.ParseArguments<DiffVerb>(new[] { @"--help" })).ToString();
            btnFix.ToolTipValues.Description = helpVerb.AddOptions(parser.ParseArguments<FixVerb>(new[] { @"--help" })).ToString();
            btnForceFullSync.ToolTipValues.Description = btnSync.ToolTipValues.Description;
            btnScrub.ToolTipValues.Description = helpVerb.AddOptions(parser.ParseArguments<ScrubVerb>(new[] { @"--help" })).ToString();
            btnCheckForMissing.ToolTipValues.Description = btnCheck.ToolTipValues.Description;
        }

        public void SetCommonButtonsEnabledState(bool enabled)
        {
            btnDiff.Enabled = enabled;
            btnSync.Enabled = enabled;
            btnCheck.Enabled = enabled;
            btnStatus.Enabled = enabled;
            btnScrub.Enabled = enabled;
            btnFix.Enabled = enabled;
            btnDupFinder.Enabled = enabled;
            btnForceFullSync.Enabled = enabled;
            btnCheckForMissing.Enabled = enabled;
        }

        public void PerformArgs(string[] args)
        {
            if (args.Any())
            {
                // https://github.com/commandlineparser/commandline
                ParserResult<AllOptions> optsResult = Parser.Default.ParseArguments<AllOptions>(args);
                optsResult.WithParsed<AllOptions>(DisplayStdOptions);
                optsResult.WithNotParsed(DisplayErrors);
                ParserResult<object> parserResult = Parser.Default.ParseArguments<SyncVerb, DiffVerb, CheckVerb, FixVerb, ScrubVerb, DupVerb, StatusVerb>(args);
                parserResult.WithNotParsed(DisplayErrors);
                // Order is important as commands "Can" be chained"
                // See http://www.snapraid.it/manual#4.1 Scrubbing for an indication of order
                parserResult.WithParsed<DiffVerb>(verb => DisplayAndCall(verb, Diff_Click));
                parserResult.WithParsed<CheckVerb>(verb => DisplayAndCall(verb, Check_Click));
                parserResult.WithParsed<SyncVerb>(verb => DisplayAndCall(verb, Sync_Click));
                parserResult.WithParsed<ScrubVerb>(verb => DisplayAndCall(verb, Scrub_Click));
                parserResult.WithParsed<DupVerb>(verb => DisplayAndCall(verb, DupFinder_Click));
                parserResult.WithParsed<StatusVerb>(verb => DisplayAndCall(verb, btnStatus_Click));
                parserResult.WithParsed<FixVerb>(verb => DisplayAndCall(verb, Fix_Click));
                // Verbs not done as they do not have buttons yet
                // list
                // smart
                // up
                // down
                // pool
                // devices
                // touch
                // rehash
            }
        }

        private void DisplayAndCall<T>(T verb, EventHandler<EventArgs> clickCall)
        {
            DisplayStdOptions(verb);
            clickCall(this, EventArgs.Empty);
        }

        private void DisplayStdOptions<TO>(TO sv)
        {
            string commandLineRead = string.Join(" ", Environment.GetCommandLineArgs());
            Log.Error(@"CommandLine Read: [{0}]", commandLineRead);
            string commandLine = Parser.Default.FormatCommandLine(sv);
            if (!string.IsNullOrWhiteSpace(commandLine))
            {
                Log.Info(@"CommandLine options Interpreted: [{0}]", commandLine);
                _liveRunLogControl.txtAddCommands.Text = commandLine;
                _liveRunLogControl.checkBoxCommandLineOptions.Checked = true;
                if ((sv as StdOptions).Verbose)
                {
                    _liveRunLogControl.checkBoxDisplayOutput.Checked = true;
                }
            }
        }

        #region Button Clicks
        private void btnStatus_Click(object sender, EventArgs e)
        {
            SetCommonButtonsEnabledState(false);
            _liveRunLogControl.StartSnapRaidProcess(RunControl.CommandType.Status);
        }

        private void Diff_Click(object sender, EventArgs e)
        {
            SetCommonButtonsEnabledState(false);
            _liveRunLogControl.StartSnapRaidProcess(RunControl.CommandType.Diff);
        }

        private void Check_Click(object sender, EventArgs e)
        {
            SetCommonButtonsEnabledState(false);
            _liveRunLogControl.checkBoxDisplayOutput.Checked = true;
            _liveRunLogControl.StartSnapRaidProcess(RunControl.CommandType.Check);
            KryptonMessageBox.Show(this, @"Switch to Recover tab to see the 'recoverable files' being populated",
                @"Recovery may be available");
        }

        private void btnCheckForMissing_Click(object sender, EventArgs e)
        {
            SetCommonButtonsEnabledState(false);
            _liveRunLogControl.checkBoxDisplayOutput.Checked = true;
            _liveRunLogControl.StartSnapRaidProcess(RunControl.CommandType.CheckForMissing);
            KryptonMessageBox.Show(this, @"Switch to Recover tab to see the 'recoverable files' being populated",
                @"Recovery may be available");
        }

        private void Sync_Click(object sender, EventArgs e)
        {
            SetCommonButtonsEnabledState(false);
            _liveRunLogControl.StartSnapRaidProcess(RunControl.CommandType.Sync);
        }

        private void Scrub_Click(object sender, EventArgs e)
        {
            SetCommonButtonsEnabledState(false);
            _liveRunLogControl.StartSnapRaidProcess(RunControl.CommandType.Scrub);
        }

        private void Fix_Click(object sender, EventArgs e)
        {
            SetCommonButtonsEnabledState(false);
            _liveRunLogControl.StartSnapRaidProcess(RunControl.CommandType.Fix);
        }

        private void DupFinder_Click(object sender, EventArgs e)
        {
            SetCommonButtonsEnabledState(false);
            _liveRunLogControl.StartSnapRaidProcess(RunControl.CommandType.Dup);
        }

        private void ForceFullSync_Click(object sender, EventArgs e)
        {
            SetCommonButtonsEnabledState(false);
            _liveRunLogControl.StartSnapRaidProcess(RunControl.CommandType.ForceFullSync);
        }
        #endregion Button Clicks

        private void DisplayErrors(IEnumerable<Error> errs)
        {
            foreach (Error err in errs)
            {
                Log.Error(err.Tag);
            }

            StringWriter writer = new StringWriter();
            {
                // Force the output of the help for each verb
                Parser parser = new Parser(with => with.HelpWriter = writer);
                parser.ParseArguments<SyncVerb, DiffVerb, CheckVerb, FixVerb, ScrubVerb, DupVerb, StatusVerb>(new[] { @"--help" });

                Log.Info(writer.ToString());
            }
        }

        private void liveRunLogControl1_RunWorkerCompleted(object sender, EventArgs e) => SetCommonButtonsEnabledState(true);

    }
}
