using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WatermarkTextBox
{
    public partial class WatermarkTextBox : TextBox
    {
        private string watermarkText;

        public string WatermarkText
        {
            get { return watermarkText; }
            set
            {
                watermarkText = value;
                SetWatermark(watermarkText);
            }
        }

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        private void SetWatermark(string text)
        {
            SendMessage(this.Handle, 0x1501, 1, text);
        }
    }
}
