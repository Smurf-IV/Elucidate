#region Copyright (C)

// ---------------------------------------------------------------------------------------------------------------
//  <copyright file="Settings.cs" company="Smurf-IV">
//
//  Copyright (C) 2010-2019 Simon Coghlan (Aka Smurf-IV) & BlueBlock 2018
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

using ComponentFactory.Krypton.Toolkit;

using Elucidate.CmdLine;
using Elucidate.Controls;

using NLog;

namespace Elucidate.TabPages
{
    public partial class CommonTab : UserControl
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public CommonTab()
        {
            InitializeComponent();
            liveRunLogControl1.ActionWorker.RunWorkerCompleted += liveRunLogControl1_RunWorkerCompleted;
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
                // See http://www.snapraid.it/manual scrubbing for an indication of order
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
                liveRunLogControl1.txtAddCommands.Text = commandLine;
                liveRunLogControl1.checkBoxCommandLineOptions.Checked = true;
                if ((sv as StdOptions).Verbose)
                {
                    liveRunLogControl1.checkBoxDisplayOutput.Checked = true;
                }
            }
        }

        #region Button Clicks
        private void btnStatus_Click(object sender, EventArgs e)
        {
            SetCommonButtonsEnabledState(false);
            liveRunLogControl1.StartSnapRaidProcess(LiveRunLogControl.CommandType.Status);
        }

        private void Diff_Click(object sender, EventArgs e)
        {
            SetCommonButtonsEnabledState(false);
            liveRunLogControl1.StartSnapRaidProcess(LiveRunLogControl.CommandType.Diff);
        }

        private void Check_Click(object sender, EventArgs e)
        {
            SetCommonButtonsEnabledState(false);
            if (Util.IsExecutableRunning(Properties.Settings.Default.SnapRAIDFileLocation))
            {
                SetCommonButtonsEnabledState(true);
                KryptonMessageBox.Show(this, @"A SnapRAID process is already running");
                return;
            }
            liveRunLogControl1.StartSnapRaidProcess(LiveRunLogControl.CommandType.Check);
        }

        private void Sync_Click(object sender, EventArgs e)
        {
            SetCommonButtonsEnabledState(false);
            liveRunLogControl1.StartSnapRaidProcess(LiveRunLogControl.CommandType.Sync);
        }

        private void Scrub_Click(object sender, EventArgs e)
        {
            SetCommonButtonsEnabledState(false);
            liveRunLogControl1.StartSnapRaidProcess(LiveRunLogControl.CommandType.Scrub);
        }

        private void Fix_Click(object sender, EventArgs e)
        {
            SetCommonButtonsEnabledState(false);
            liveRunLogControl1.StartSnapRaidProcess(LiveRunLogControl.CommandType.Fix);
        }

        private void DupFinder_Click(object sender, EventArgs e)
        {
            SetCommonButtonsEnabledState(false);
            liveRunLogControl1.StartSnapRaidProcess(LiveRunLogControl.CommandType.Dup);
        }

        private void ForceFullSync_Click(object sender, EventArgs e)
        {
            SetCommonButtonsEnabledState(false);
            liveRunLogControl1.StartSnapRaidProcess(LiveRunLogControl.CommandType.ForceFullSync);
        }
        #endregion Button Clicks

        private void logViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (liveRunLogControl1.ActionWorker.IsBusy) { return; }

            string userAppData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), @"Elucidate");

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Path.Combine(userAppData, @"Logs"),
                Filter = @"Log files (*.log)|*.log|Archive logs (*.*)|*.*",
                FileName = "*.log",
                FilterIndex = 2,
                Title = @"Select name to view contents"
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (Properties.Settings.Default.UseWindowsSettings)
            {
                Process word = Process.Start("Wordpad.exe", '"' + openFileDialog.FileName + '"');
                if (word == null)
                {
                    return;
                }

                word.WaitForInputIdle();
                SendKeys.SendWait("^{END}");
            }
            else
            {
                // Launch whatever "Knows" how to view log files
                Process.Start('"' + openFileDialog.FileName + '"');
            }
        }

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
