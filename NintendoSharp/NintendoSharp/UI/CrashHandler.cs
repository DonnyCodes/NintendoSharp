using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NintendoSharp.Constants;

namespace NintendoSharp.UI
{
    public partial class CrashHandler : Form
    {
        public Exception crashExc = null;

        public CrashHandler()
        {
            InitializeComponent();
        }

        public CrashHandler(Exception crashExc)
        {
            InitializeComponent();
            this.crashExc = crashExc;
        }

        private void CrashHandler_Load(object sender, EventArgs e)
        {
            if (crashExc != null)
            {
                richTextBoxInfo.Text = crashExc.ToString();
            }
            this.Show();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                WinImports.ReleaseCapture();
                WinImports.SendMessage(Handle, WinImports.WM_NCLBUTTONDOWN, WinImports.HT_CAPTION, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
