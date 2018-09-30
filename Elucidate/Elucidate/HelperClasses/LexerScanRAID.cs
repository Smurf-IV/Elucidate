using System;
using System.Collections.Generic;
using System.Linq;

using ScintillaNET;

namespace Elucidate.HelperClasses
{
    // class based upon: https://github.com/jacobslusser/ScintillaNET/wiki/Custom-Syntax-Highlighting

    public class LexerScanRaid
    {
        private readonly string[] _defaultKeywordsErrorArray = { "error: ", "errors!", "error_unrecoverable" };
        private readonly string[] _defaultKeywordsWarningArray = { "WARNING!" };
        private readonly string[] _defaultKeywordsDebugArray = { "verbose:" };

        private readonly HashSet<string> _keywordsErrorHashSet;
        private readonly HashSet<string> _keywordsWarningHashSet;
        private readonly HashSet<string> _keywordsDebugHashSet;

        public const int StyleDefault = 0;
        public const int StyleError = 1;
        public const int StyleWarning = 2;
        public const int StyleDebug = 3;
        
        public LexerScanRaid(string[] keywordsError = null, string[] keywordsWarning = null, string[] keywordsDebug = null)
        {
            // Set keywords and put keywords in a HashSet

            if (keywordsError == null)
            {
                _keywordsErrorHashSet = new HashSet<string>(_defaultKeywordsErrorArray.ToList());
            }

            if (keywordsWarning == null)
            {
                _keywordsWarningHashSet = new HashSet<string>(_defaultKeywordsWarningArray.ToList());
            }

            if (keywordsDebug == null)
            {
                _keywordsDebugHashSet = new HashSet<string>(_defaultKeywordsDebugArray.ToList());
            }

            if (keywordsError != null)
            {
                _keywordsErrorHashSet = new HashSet<string>(keywordsError.ToList());
            }

            if (keywordsWarning != null)
            {
                _keywordsWarningHashSet = new HashSet<string>(keywordsWarning.ToList());
            }

            if (keywordsDebug != null)
            {
                _keywordsDebugHashSet = new HashSet<string>(keywordsDebug.ToList());
            }
        }

        public void Style(Scintilla scintilla, int startPos, int endPos)
        {
            // Back up to the line start
            int line = scintilla.LineFromPosition(startPos);
            startPos = scintilla.Lines[line].Position;

            scintilla.StartStyling(startPos);
            string tr = scintilla.GetTextRange(startPos, endPos);

            // error
            StyleTerms(scintilla, startPos, tr, _keywordsErrorHashSet, StyleError);

            // warning
            StyleTerms(scintilla, startPos, tr, _keywordsWarningHashSet, StyleWarning);

            // debug
            StyleTerms(scintilla, startPos, tr, _keywordsDebugHashSet, StyleDebug);
        }

        private void StyleTerms(Scintilla scintilla, int startPos, string tr, HashSet<string> keywordsHashSet, int styleType)
        {
            foreach (string word in keywordsHashSet)
            {
                IEnumerable<int> foundIndexes = tr.AllIndexesOf(word, StringComparison.CurrentCulture);
                foreach (int idx in foundIndexes)
                {
                    scintilla.StartStyling(startPos + idx);
                    scintilla.SetStyling(word.Length, styleType);
                }
            }
        }
    }
}
