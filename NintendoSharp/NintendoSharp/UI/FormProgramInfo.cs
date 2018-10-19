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
    public partial class FormProgramInfo : Form
    {
        public FormProgramInfo()
        {
            InitializeComponent();
        }

        public void FillFromProgram(Control.UserScript program)
        {
            this.textBoxName.Text = program.name;
            this.textBoxAuthor.Text = program.author;
            this.textBoxVersionID.Text = program.versionID;
            this.richTextBoxDescription.Text = program.description;
            this.textBoxCompileTime.Text = "NYI";
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
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

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FormProgramInfo_Load(object sender, EventArgs e)
        {

        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            panel1_MouseMove(sender, e);
        }
    }
}
