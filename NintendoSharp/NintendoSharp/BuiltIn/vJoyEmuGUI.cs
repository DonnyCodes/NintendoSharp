using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            AppController.Log("Saving changes to \"vJoy Interface\"....", Constants.Enums.LogMessageType.Basic);
            VJoyController.newAnalogMods[0] = (double)numericUpDownModX.Value;
            VJoyController.newAnalogMods[1] = (double)numericUpDownModY.Value;
            VJoyController.newAnalogMods[2] = (double)numericUpDownModZ.Value;
            VJoyController.newAnalogMods[3] = (double)numericUpDownModRX.Value;
            VJoyController.newAnalogMods[4] = (double)numericUpDownModRY.Value;
            VJoyController.newAnalogMods[5] = (double)numericUpDownModRZ.Value;
            VJoyController.analogSettingsUpdateQueued = true;
            AppController.settings.vJoyModX = (double)numericUpDownModX.Value;
            AppController.settings.vJoyModY = (double)numericUpDownModY.Value;
            AppController.settings.vJoyModZ = (double)numericUpDownModZ.Value;
            AppController.settings.vJoyModRX = (double)numericUpDownModRX.Value;
            AppController.settings.vJoyModRY = (double)numericUpDownModRY.Value;
            AppController.settings.vJoyModRZ = (double)numericUpDownModRZ.Value;
            AppController.SaveSettings();
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
            AppController.Log("Loaded \"vJoy Interface\" settings.", Constants.Enums.LogMessageType.Basic);
        }
    }
}
