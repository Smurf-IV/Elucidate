using System;
using System.Collections.Generic;
using System.Linq;
using ScintillaNET;

namespace Elucidate.HelperClasses
{
    // class based upon: https://github.com/jacobslusser/ScintillaNET/wiki/Custom-Syntax-Highlighting

    public class LexerNlog
    {
        public bool IsHighlightErrorEnabled { get; set; } = true;
        public bool IsHighlightWarningEnabled { get; set; } = true;
        public bool IsHighlightDebugEnabled { get; set; } = true;

        private readonly string[] _defaultKeywordsErrorArray = { "ERROR", "FATAL" };
        private readonly string[] _defaultKeywordsWarningArray = { "WARN" };
        private readonly string[] _defaultKeywordsDebugArray = { "DEBUG", "TRACE" };

        private readonly HashSet<string> _keywordsErrorHashSet;
        private readonly HashSet<string> _keywordsWarningHashSet;
        private readonly HashSet<string> _keywordsDebugHashSet;

        public const int StyleDefault = 0;
        public const int StyleError = 1;
        public const int StyleWarning = 2;
        public const int StyleDebug = 3;
        
        // ReSharper disable once InconsistentNaming
        private const int STATE_UNKNOWN = 0;
        // ReSharper disable once InconsistentNaming
        private const int STATE_WORD = 1;

        public LexerNlog(string[] keywordsError = null, string[] keywordsWarning = null, string[] keywordsDebug = null)
        {
            // Put keywords in a HashSet

            if (keywordsError == null) _keywordsErrorHashSet = new HashSet<string>(_defaultKeywordsErrorArray.ToList());
            if (keywordsWarning == null) _keywordsWarningHashSet = new HashSet<string>(_defaultKeywordsWarningArray.ToList());
            if (keywordsDebug == null) _keywordsDebugHashSet = new HashSet<string>(_defaultKeywordsDebugArray.ToList());

            if (keywordsError != null) _keywordsErrorHashSet = new HashSet<string>(keywordsError.ToList());
            if (keywordsWarning != null) _keywordsWarningHashSet = new HashSet<string>(keywordsWarning.ToList());
            if (keywordsDebug != null) _keywordsDebugHashSet = new HashSet<string>(keywordsDebug.ToList());
        }

        public void Style(Scintilla scintilla, int startPos, int endPos)
        {
            // Back up to the line start
            var line = scintilla.LineFromPosition(startPos);
            startPos = scintilla.Lines[line].Position;

            var length = 0;
            var state = STATE_UNKNOWN;

            // Start styling
            scintilla.StartStyling(startPos);
            while (startPos < endPos)
            {
                var c = (char)scintilla.GetCharAt(startPos);

                REPROCESS:
                switch (state)
                {
                    case STATE_UNKNOWN:
                        if (Char.IsLetter(c))
                        {
                            state = STATE_WORD;
                            goto REPROCESS;
                        }
                        else
                        {
                            // Everything else
                            scintilla.SetStyling(1, StyleDefault);
                        }
                        break;
                        
                    case STATE_WORD:
                        if (Char.IsLetterOrDigit(c))
                        {
                            length++;
                        }
                        else
                        {
                            int style = StyleDefault;
                            var identifier = scintilla.GetTextRange(startPos - length, length);
                            if (IsHighlightErrorEnabled && _keywordsErrorHashSet != null && _keywordsErrorHashSet.Contains(identifier))
                                style = StyleError;
                            else if (IsHighlightWarningEnabled && _keywordsWarningHashSet != null && _keywordsWarningHashSet.Contains(identifier))
                                style = StyleWarning;
                            else if (IsHighlightDebugEnabled && _keywordsDebugHashSet != null && _keywordsDebugHashSet.Contains(identifier))
                                style = StyleDebug;

                            scintilla.SetStyling(length, style);

                            length = 0;
                            state = STATE_UNKNOWN;
                            goto REPROCESS;
                        }
                        break;
                }

                startPos++;
            }
        }

    }
}
