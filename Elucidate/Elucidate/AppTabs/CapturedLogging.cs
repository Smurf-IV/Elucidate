#region Copyright (C)

// ---------------------------------------------------------------------------------------------------------------
//  <copyright file="CapturedLogging.cs" company="Smurf-IV">
//
//  Copyright (C) 2015 Simon Coghlan (Aka Smurf-IV)
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
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Elucidate.Logging;

namespace Elucidate
{
    public partial class ElucidateForm
    {
        private void AddThreadingCallbacks()
        {
            // Add threading callbacks
            actionWorker.DoWork += actionWorker_DoWork;
            actionWorker.ProgressChanged += actionWorker_ProgressChanged;
            actionWorker.RunWorkerCompleted += actionWorker_RunWorkerCompleted;
            comboBox1.Text = @"Stopped";
            comboBox1.Enabled = false;
            timer1.Enabled = true;
        }

        private void DeleteContentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxLiveLog.Clear();
        }

        private void CopySelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataObject dto = new DataObject();
            if (textBoxLiveLog.SelectionLength <= 1)
            {
                textBoxLiveLog.SelectAll();
            }
            dto.SetText(textBoxLiveLog.SelectedRtf, TextDataFormat.Rtf);
            dto.SetText(textBoxLiveLog.SelectedText, TextDataFormat.UnicodeText);
            Clipboard.Clear();
            Clipboard.SetDataObject(dto);
        }

        private void Elucidate_KeyDown(object sender, KeyEventArgs e)
        {
            // The realtime tab + menu, might not have focus
            if (e.Control
                && e.KeyCode == Keys.C)
            {
                CopySelectedToolStripMenuItem_Click(sender, e);
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!LogQueue.Any())
                {
                    //Thread.Sleep(250);
                    return;
                }
                // Now lock in case the timer is overlapping !
                lock (this)
                {
                    textBoxLiveLog._Paint = false; // turn off flag to ignore WM_PAINT messages
                    if (textBoxLiveLog.Lines.Length > Properties.Settings.Default.MaxNumberOfRealTimeLines)
                    {
                        //textBox1.SelectionStart = 0;
                        //textBox1.SelectionLength = textBox1.GetFirstCharIndexFromLine(Properties.Settings.Default.MaxNumberOfRealTimeLines - 10);
                        //textBox1.SelectedText = string.Empty;
                        // The above makes it beep as well !!
                        textBoxLiveLog.Clear();
                    }
                    //read out of the file until the EOF
                    while (LogQueue.Any())
                    {
                        LogString log = LogQueue.Dequeue();
                        switch (log.LevelUppercase)
                        {
                            case "FATAL":
                                textBoxLiveLog.SelectionColor = Color.DarkViolet;
                                break;

                            case "ERROR":
                                textBoxLiveLog.SelectionColor = Color.Red;
                                break;

                            case "WARN":
                                textBoxLiveLog.SelectionColor = Color.RoyalBlue;
                                break;

                            case "INFO":
                                textBoxLiveLog.SelectionColor = Color.Black;
                                break;

                            case "DEBUG":
                                textBoxLiveLog.SelectionColor = Color.DarkGray;
                                break;

                            case "TRACE":
                                textBoxLiveLog.SelectionColor = Color.DimGray;
                                break;

                            default:
                                // Leave it as is
                                break;
                        }
                        textBoxLiveLog.AppendText(log.Message + Environment.NewLine);
                        textBoxLiveLog.ScrollToCaret();
                    }
                    // check if our textbox is getting too full
                    int textLength = textBoxLiveLog.TextLength;
                    if (textLength > (textBoxLiveLog.MaxLength - 1000))
                    {
                        //max possible on control = 2147483647
                        textBoxLiveLog.Clear();
                        Log.Instance.Debug("CLEAR");
                    }
                }
            }
            catch
            {
                // ignored
            }

            textBoxLiveLog._Paint = true; // restore flag so we can paint the control
        }

        private class LogString
        {
            public string LevelUppercase;
            public string Message;
        };

        private static readonly Queue<LogString> LogQueue = new Queue<LogString>();

        // ReSharper disable UnusedMember.Global
        // This is used by the logging to force all to the output window
        public static void LogMethod(string levelUppercase, string message)
        {
            LogQueue.Enqueue(new LogString
            {
                LevelUppercase = levelUppercase,
                Message = message
            });
        }

    }
}
