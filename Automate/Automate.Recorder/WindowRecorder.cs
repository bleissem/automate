using System;
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

        [DllImport("user32.dll")]
        public static extern IntPtr WindowFromPoint(POINT lpPoint);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetCursorPos(out POINT lpPoint);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, [Out] StringBuilder lParam);



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

            int length = GetWindowTextLength(hWnd);
            StringBuilder sb = new StringBuilder(length);
            GetWindowText(hWnd, sb, sb.Capacity+1);
            return sb.ToString();
        }

    }
}
