using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TimeWidget
{
    public static class HideFromAltTab
    {
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr window, int index, int value);

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr window, int index);

        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_TOOLWINDOW = 0x00000080;

        public static void Hide(Form form)
        {
            SetWindowLong(form.Handle, GWL_EXSTYLE, GetWindowLong(form.Handle, GWL_EXSTYLE) | WS_EX_TOOLWINDOW);
        }
    }
}
