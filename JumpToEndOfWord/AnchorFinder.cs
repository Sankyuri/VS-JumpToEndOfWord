using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EnvDTE;
using Microsoft;
using Microsoft.VisualStudio.Shell;

namespace JumpToEndOfWord
{
    public static class AnchorFinder
    {
        private static char[] charsToTrim = { ' ', '\t' };

        public static int GetNumOfCharsToNextAnchor(VirtualPoint InitialPoint)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            if (InitialPoint.AtEndOfLine)
                return 0;

            EditPoint StartPoint = InitialPoint.CreateEditPoint();
            string RightChar = StartPoint.GetText(1);

            EditPoint EndPoint = InitialPoint.CreateEditPoint();
            EndPoint.WordRight(1);

            int iMoveCaretDistance = 0;
            if (RightChar == " " || RightChar == "\t")
            {
                // Move to beginning of next word: Count whitespace
                string text = StartPoint.GetText(EndPoint);
                iMoveCaretDistance = text.Length;
            }
            else
            {
                // Move to end of current word: Trim whitespace
                string text = StartPoint.GetText(EndPoint);
                text = text.TrimEnd(charsToTrim);
                iMoveCaretDistance = text.Length;
            }

            return iMoveCaretDistance;
        }

        public static int GetNumOfCharsToPreviousAnchor(VirtualPoint InitialPoint)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            if (InitialPoint.AtStartOfLine)
                return 0;

            EditPoint StartPoint = InitialPoint.CreateEditPoint();
            StartPoint.WordLeft(1);

            EditPoint EndPoint = InitialPoint.CreateEditPoint();
            EndPoint.CharLeft(1);
            string LeftChar = EndPoint.GetText(1);

            int iMoveCaretDistance = 0;
            if (LeftChar == " " || LeftChar == "\t")
            {
                // Move to end of previous word: Count whitespace
                string text = StartPoint.GetText(EndPoint);
                string textTrimmed = text.TrimEnd(charsToTrim);
                iMoveCaretDistance = text.Length - textTrimmed.Length + 1; // +1 due to CharLeft of Endpoint
            }
            else
            {
                // Move to start of current word: Trim whitespace
                string text = StartPoint.GetText(EndPoint);
                iMoveCaretDistance = text.Length + 1; // +1 due to CharLeft of Endpoint
            }

            return iMoveCaretDistance;
        }
    }
}
