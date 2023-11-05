using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TimeWidget
{
    public static class GetScreenPixel
    {
        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hwnd, IntPtr hDC);

        [DllImport("gdi32.dll")]
        public static extern uint GetPixel(IntPtr hDC, int x, int y);

        public static Color GetPixelColor(Point point)
        {
            IntPtr hDC = GetDC(IntPtr.Zero);
            uint pixel = GetPixel(hDC, point.X, point.Y);
            ReleaseDC(IntPtr.Zero, hDC);

            byte r = (byte)(pixel & 0x000000FF);
            byte g = (byte)((pixel & 0x0000FF00) >> 8);
            byte b = (byte)((pixel & 0x00FF0000) >> 16);

            if (r >= 254 && g >= 254 && b >= 254)
                return Color.FromArgb(254, 254, 254);

            return Color.FromArgb(r, g, b);
        }
    }
}
