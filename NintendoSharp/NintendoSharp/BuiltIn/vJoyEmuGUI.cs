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

namespace NintendoSharp.BuiltIn
{
    public partial class vJoyEmuGUI : Form
    {
        public vJoyEmuGUI()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            VJoyController.newAnalogMods[0] = (double)numericUpDownModX.Value;
            VJoyController.newAnalogMods[1] = (double)numericUpDownModY.Value;
            VJoyController.newAnalogMods[2] = (double)numericUpDownModZ.Value;
            VJoyController.newAnalogMods[3] = (double)numericUpDownModRX.Value;
            VJoyController.newAnalogMods[4] = (double)numericUpDownModRY.Value;
            VJoyController.newAnalogMods[5] = (double)numericUpDownModRZ.Value;
            VJoyController.newDeadzones[0] = (int)numericUpDownDzX.Value;
            VJoyController.newDeadzones[1] = (int)numericUpDownDzY.Value;
            VJoyController.newDeadzones[2] = (int)numericUpDownDzZ.Value;
            VJoyController.newDeadzones[3] = (int)numericUpDownDzRx.Value;
            VJoyController.newDeadzones[4] = (int)numericUpDownDzRy.Value;
            VJoyController.newDeadzones[5] = (int)numericUpDownDzRz.Value;
            VJoyController.analogSettingsUpdateQueued = true;
            AppController.settings.vJoyModX = (double)numericUpDownModX.Value;
            AppController.settings.vJoyModY = (double)numericUpDownModY.Value;
            AppController.settings.vJoyModZ = (double)numericUpDownModZ.Value;
            AppController.settings.vJoyModRX = (double)numericUpDownModRX.Value;
            AppController.settings.vJoyModRY = (double)numericUpDownModRY.Value;
            AppController.settings.vJoyModRZ = (double)numericUpDownModRZ.Value;
            AppController.settings.vJoyDeadX = (int)numericUpDownDzX.Value;
            AppController.settings.vJoyDeadY = (int)numericUpDownDzY.Value;
            AppController.settings.vJoyDeadZ = (int)numericUpDownDzZ.Value;
            AppController.settings.vJoyDeadRX = (int)numericUpDownDzRx.Value;
            AppController.settings.vJoyDeadRY = (int)numericUpDownDzRy.Value;
            AppController.settings.vJoyDeadRZ = (int)numericUpDownDzRz.Value;
            AppController.SaveSettings();
            AppController.Log("Saved changes to \"vJoy Interface\".", Constants.Enums.LogMessageType.Basic);
            this.Hide();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void vJoyEmuGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void vJoyEmuGUI_Shown(object sender, EventArgs e)
        {
            numericUpDownModX.Value = (decimal)AppController.settings.vJoyModX;
            numericUpDownModY.Value = (decimal)AppController.settings.vJoyModY;
            numericUpDownModZ.Value = (decimal)AppController.settings.vJoyModZ;
            numericUpDownModRX.Value = (decimal)AppController.settings.vJoyModRX;
            numericUpDownModRY.Value = (decimal)AppController.settings.vJoyModRY;
            numericUpDownModRZ.Value = (decimal)AppController.settings.vJoyModRZ;
            numericUpDownDzX.Value = (decimal)AppController.settings.vJoyDeadX;
            numericUpDownDzY.Value = (decimal)AppController.settings.vJoyDeadY;
            numericUpDownDzZ.Value = (decimal)AppController.settings.vJoyDeadZ;
            numericUpDownDzRx.Value = (decimal)AppController.settings.vJoyDeadRX;
            numericUpDownDzRy.Value = (decimal)AppController.settings.vJoyDeadRY;
            numericUpDownDzRz.Value = (decimal)AppController.settings.vJoyDeadRZ;
            AppController.Log("Loaded \"vJoy Interface\" settings.", Constants.Enums.LogMessageType.Basic);
        }

        private void comboBoxMappingInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMappingInfo.SelectedIndex == 0)
            {
                pictureBoxMappingInfo.Image = Properties.Resources.NES;
            }
            else if (comboBoxMappingInfo.SelectedIndex == 1)
            {
                pictureBoxMappingInfo.Image = Properties.Resources.SNES;
            }
            else if (comboBoxMappingInfo.SelectedIndex == 2)
            {
                pictureBoxMappingInfo.Image = Properties.Resources.N64;
            }
            else if (comboBoxMappingInfo.SelectedIndex == 3)
            {
                pictureBoxMappingInfo.Image = Properties.Resources.GameCube;
            }
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
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

        private void labelHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ask Bob.");
        }
    }
}
