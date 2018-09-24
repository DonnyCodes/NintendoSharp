using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NintendoSharp.Constants;

namespace NintendoSharp.UI
{
    public partial class FormLog : Form
    {

        public volatile string logBuffer;

        public FormLog()
        {
            InitializeComponent();
        }

        private void FormLog_Load(object sender, EventArgs e)
        {
            
        }

        private void richTextBoxLog_TextChanged(object sender, EventArgs e)
        {
            if (checkBoxAutoUpdate.Checked)
            {
                richTextBoxLog.SelectionStart = richTextBoxLog.Text.Length;
                richTextBoxLog.ScrollToCaret();
            }
        }

        private void panelTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                WinImports.ReleaseCapture();
                WinImports.SendMessage(Handle, WinImports.WM_NCLBUTTONDOWN, WinImports.HT_CAPTION, 0);
            }
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void labelMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
