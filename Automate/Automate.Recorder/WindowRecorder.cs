﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Automate.Recorder
{
    public class WindowRecorder
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public POINT(System.Drawing.Point pt) : this(pt.X, pt.Y)
            {

            }


            public static implicit operator System.Drawing.Point(POINT p)
            {
                return new System.Drawing.Point(p.X, p.Y);
            }

            public static implicit operator POINT(System.Drawing.Point p)
            {
                return new POINT(p.X, p.Y);
            }

            public int X;
            public int Y;
        }

        #region GetAncestor

        private const int GA_PARENT = 1;
        private const int GA_ROOT = 2;
        private const int GA_ROOTOWNER = 3;
       
        #endregion

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetAncestor(IntPtr hWnd, int flags);

        [DllImport("user32.dll")]
        static extern IntPtr GetFocus();

        [DllImport("user32.dll")]
        public static extern IntPtr WindowFromPoint(POINT lpPoint);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetCursorPos(out POINT lpPoint);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
        static extern IntPtr GetWindowTextContent(IntPtr hWnd, UInt32 Msg, int wParam, [Out] StringBuilder lParam);      

        [DllImport("user32.dll", EntryPoint = "SendMessage",
          CharSet = CharSet.Auto)]
        static extern int GetTextContentLength(IntPtr hwndControl, UInt32 Msg, int wParam, int lParam); 

        private static int GetTextBoxTextLength(IntPtr hTextBox)
        {
            uint WM_GETTEXTLENGTH = 0x000E;
            int result = GetTextContentLength(hTextBox, WM_GETTEXTLENGTH, 0, 0);
            return result;
        }

        public static string GetTextBoxText(System.Drawing.Point point)
        {
            IntPtr hWnd = WindowFromPoint(new POINT(point));
            
            uint WM_GETTEXT = 0x000D;
            int len = GetTextBoxTextLength(hWnd);
            if (len <= 0) return string.Empty;
            StringBuilder sb = new StringBuilder(len + 1);
            GetWindowTextContent(hWnd, WM_GETTEXT, len + 1, sb);
            return sb.ToString();
        }

        public static string GetWindowTextUnderCursor()
        {
            POINT pointCursor = new POINT();

            if (!(GetCursorPos(out pointCursor))) return string.Empty;

            return GetWindowText(pointCursor);
        }

        public static string GetWindowText(System.Drawing.Point point)
        {
            IntPtr hWnd = WindowFromPoint(new POINT(point));
            if (IntPtr.Zero == hWnd) return string.Empty;

            IntPtr parent = GetAncestor(hWnd, GA_ROOT);
            if (IntPtr.Zero != parent) hWnd = parent;

            int length = GetWindowTextLength(hWnd);
            if (0 >= length) return string.Empty;

            StringBuilder sb = new StringBuilder(length + 1);
            int result = GetWindowText(hWnd, sb, length +1);
            if (0 >= result) return string.Empty;
            return sb.ToString();
        }

    }
}
