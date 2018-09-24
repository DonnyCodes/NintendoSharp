using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace NintendoSharp.Constants
{
    public static class WinImports
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
    }
}
