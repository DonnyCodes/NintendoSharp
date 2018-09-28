using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NintendoSharp.Constants;
using NintendoSharp;
using System.IO.Ports;

namespace NintendoSharp.UI
{
    public partial class FormMain : Form {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            AppController.mainForm = this;
            this.Icon = Properties.Resources.nsharp;
            RefreshComPorts();
            AppController.Startup();
            labelAppStatus.ForeColor = Color.LightGreen;
            LoadFromSettings();
            labelAppStatus.Text = "Ready";
            this.Enabled = true;
        }

        private void pictureBoxRefresh_Click(object sender, EventArgs e)
        {
            RefreshComPorts();
        }

        void RefreshComPorts()
        {
            comboBoxPorts.Items.Clear();
            foreach (string portStr in SerialPort.GetPortNames())
            {
                comboBoxPorts.Items.Add(portStr);
            }
        }

        private void comboBoxPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string newPrtStr = this.comboBoxPorts.GetItemText(this.comboBoxPorts.SelectedItem);
            SerialController.portNameNew = newPrtStr;
            AppController.Log("Port Change: " + newPrtStr, Enums.LogMessageType.Basic);
            comboBoxBoard.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming Soon.");
        }

        private void labelDisclaimer_Click(object sender, EventArgs e)
        {

        }

        private void timerDisclaimer_Tick(object sender, EventArgs e)
        {
            if (labelDisclaimer.ForeColor != Color.Red)
            {
                labelDisclaimer.ForeColor = Color.Red;
            }
            else
            {
                labelDisclaimer.ForeColor = Color.Yellow;
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

        private void labelMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void comboBoxBoard_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxFirmware.Enabled = true;
        }

        private void comboBoxControllerPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = this.comboBoxControllerPort.GetItemText(this.comboBoxControllerPort.SelectedItem);
            comboBoxControllerType.Items.Clear();
            if (item.StartsWith("NES"))
            {
                foreach (Enums.Controllers.NES newElement in Enum.GetValues(typeof(Enums.Controllers.NES)))
                {
                    comboBoxControllerType.Items.Add(newElement.ToString());
                }
            }
            else if (item.StartsWith("SNES"))
            {
                foreach (Enums.Controllers.SNES newElement in Enum.GetValues(typeof(Enums.Controllers.SNES)))
                {
                    comboBoxControllerType.Items.Add(newElement.ToString());
                }
            }
            else if (item.StartsWith("N64"))
            {
                foreach (Enums.Controllers.N64 newElement in Enum.GetValues(typeof(Enums.Controllers.N64)))
                {
                    comboBoxControllerType.Items.Add(newElement.ToString());
                }
            }
            else if (item.StartsWith("GameCube"))
            {
                foreach (Enums.Controllers.Gamecube newElement in Enum.GetValues(typeof(Enums.Controllers.Gamecube)))
                {
                    comboBoxControllerType.Items.Add(newElement.ToString());
                }
            }
            else if (item.StartsWith("Bluetooth"))
            {
                foreach (Enums.Controllers.Bluetooth newElement in Enum.GetValues(typeof(Enums.Controllers.Bluetooth)))
                {
                    comboBoxControllerType.Items.Add(newElement.ToString());
                }
            }
            else if (item.StartsWith("NintendoSpy"))
            {
                foreach (Enums.Controllers.NintendoSpy newElement in Enum.GetValues(typeof(Enums.Controllers.NintendoSpy)))
                {
                    comboBoxControllerType.Items.Add(newElement.ToString());
                }
            }
            else if (item.StartsWith("PC"))
            {
                comboBoxControllerType.Items.Add("USB");
            }
            else if (item.StartsWith("Custom"))
            {
                comboBoxConsoleInput.Items.Add("Import DLL");
            }
            else
            {
                comboBoxControllerType.Items.Add("None");
            }
            comboBoxControllerType.Enabled = true;
            comboBoxControllerType.SelectedIndex = 0;
        }

        private void buttonProgramGUI_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Just Press \"Start\" and use the \"vjoy\" input in your game/emulator.");
            BuiltIn.vJoy_Emu.OnGUI();
        }

        private void buttonProgramStart_Click(object sender, EventArgs e)
        {
            if (!TryStart())
            {
                return;
            }
            SaveToSettings();
            AppController.SaveSettings();
            buttonProgramStart.Enabled = false;
            labelAppStatus.ForeColor = Color.Yellow;
            labelAppStatus.Text = "Starting Program....";
            StartProgram(this.comboBoxProgram.GetItemText(this.comboBoxProgram.SelectedItem));
        }

        void StartProgram(string programName)
        {
            if (programName.StartsWith("vJoy"))
            {
                labelAppStatus.ForeColor = Color.LightGreen;
                BuiltIn.vJoy_Emu.Start();
                labelAppStatus.Text = "Re-direcing Nintendospy to vJoy. Don't close this app!";
            }
            else if (programName.StartsWith("Install"))
            {
                MessageBox.Show("Script Installer Coming Soon");
                labelAppStatus.ForeColor = Color.LightGreen;
                buttonProgramStart.Enabled = true;
                labelAppStatus.Text = "Choose a program!";
            }
            else
            {
                MessageBox.Show("Choose a program!");
                labelAppStatus.ForeColor = Color.LightGreen;
                buttonProgramStart.Enabled = true;
                labelAppStatus.Text = "Choose a program!";
            }
        }

        public void LoadFromSettings()
        {
            try
            {
                if (AppController.settings.selectedDevice != -1)
                {
                    comboBoxPorts.SelectedIndex = AppController.settings.selectedDevice;
                }
                if (AppController.settings.selectedConsole != -1)
                {
                    comboBoxConsole.SelectedIndex = AppController.settings.selectedConsole;
                }
                if (AppController.settings.selectedControllerPort != -1)
                {
                    comboBoxControllerPort.SelectedIndex = AppController.settings.selectedControllerPort;
                }
                if (AppController.settings.selectedConsoleController != -1)
                {
                    comboBoxConsoleInput.SelectedIndex = AppController.settings.selectedConsoleController;
                }
                if (AppController.settings.selectedControllerType != -1)
                {
                    comboBoxControllerType.SelectedIndex = AppController.settings.selectedControllerType;
                }
                if (AppController.settings.selectedBoardType != -1)
                {
                    comboBoxBoard.SelectedIndex = AppController.settings.selectedBoardType;
                }
                if (AppController.settings.selectedFirmware != -1)
                {
                    comboBoxFirmware.SelectedIndex = AppController.settings.selectedFirmware;
                }
            }
            catch (Exception exc)
            {

            }
        }

        public void SaveToSettings()
        {
            try
            {
                AppController.settings.selectedDevice = comboBoxPorts.SelectedIndex;
                AppController.settings.selectedConsole = comboBoxConsole.SelectedIndex;
                AppController.settings.selectedConsoleController = comboBoxConsoleInput.SelectedIndex;
                AppController.settings.selectedControllerPort = comboBoxControllerPort.SelectedIndex;
                AppController.settings.selectedControllerType = comboBoxControllerType.SelectedIndex;
                AppController.settings.selectedBoardType = comboBoxBoard.SelectedIndex;
                AppController.settings.selectedFirmware = comboBoxFirmware.SelectedIndex;
            }
            catch(Exception exc)
            {
                
            }
        }

        private bool TryStart()
        {
            if (comboBoxConsole.SelectedIndex < 0)
            {
                MessageBox.Show("Please Choose a Console in \"Console IO\".\nChoose \"None\" if you don't have a console connected.", caption: "Can't Start!");
                return false;
            }
            if (comboBoxControllerPort.SelectedIndex < 0)
            {
                MessageBox.Show("Please Choose a Controller in \"Controller IO\".\nChoose \"None\" if you don't have a controller connected.", caption: "Can't Start!");
                return false;
            }
            if (comboBoxPorts.SelectedIndex < 0)
            {
                MessageBox.Show("Please Choose a Port in \"Device Settings\".", caption:"Can't Start!");
                return false;
            }
            if (comboBoxBoard.SelectedIndex < 0)
            {
                MessageBox.Show("Please Choose a Board in \"Board Settings\".", caption: "Can't Start!");
                return false;
            }
            if (comboBoxFirmware.SelectedIndex < 0)
            {
                MessageBox.Show("Please Choose a Firmware in \"Board Settings\".", caption: "Can't Start!");
                return false;
            }
            if (comboBoxControllerPort.SelectedIndex < 0)
            {
                MessageBox.Show("Please Choose a Progam.", caption: "Can't Start!");
                return false;
            }
            AppController.Log("Starting Program: " + this.comboBoxProgram.GetItemText(this.comboBoxProgram.SelectedItem) + ".", Enums.LogMessageType.Basic);
            return true;
        }

        private void buttonLog_Click(object sender, EventArgs e)
        {
            AppController.logForm.Show();
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            AppController.ShutDown();
        }

        private void labelHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ask Bob");
        }

        private void comboBoxProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonProgramGUI.Enabled = true;
            buttonProgramStart.Enabled = true;
        }

        private void linkLabelWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/DonnyCodes/NintendoSharp");
        }

        private void comboBoxConsole_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = this.comboBoxConsole.GetItemText(this.comboBoxConsole.SelectedItem);
            comboBoxConsoleInput.Items.Clear();
            if (item.StartsWith("NES"))
            {
                foreach (Enums.Controllers.NES newElement in Enum.GetValues(typeof(Enums.Controllers.NES)))
                {
                    comboBoxConsoleInput.Items.Add(newElement.ToString());
                }
            }
            else if (item.StartsWith("SNES"))
            {
                foreach (Enums.Controllers.SNES newElement in Enum.GetValues(typeof(Enums.Controllers.SNES)))
                {
                    comboBoxConsoleInput.Items.Add(newElement.ToString());
                }
            }
            else if (item.StartsWith("N64"))
            {
                foreach (Enums.Controllers.N64 newElement in Enum.GetValues(typeof(Enums.Controllers.N64)))
                {
                    comboBoxConsoleInput.Items.Add(newElement.ToString());
                }
            }
            else if (item.StartsWith("GameCube"))
            {
                foreach (Enums.Controllers.Gamecube newElement in Enum.GetValues(typeof(Enums.Controllers.Gamecube)))
                {
                    comboBoxConsoleInput.Items.Add(newElement.ToString());
                }
            }
            else if (item.StartsWith("Wii"))
            {
                foreach (Enums.Controllers.Wii newElement in Enum.GetValues(typeof(Enums.Controllers.Wii)))
                {
                    comboBoxConsoleInput.Items.Add(newElement.ToString());
                }
            }
            else if (item.StartsWith("WiiU"))
            {
                foreach (Enums.Controllers.WiiU newElement in Enum.GetValues(typeof(Enums.Controllers.WiiU)))
                {
                    comboBoxConsoleInput.Items.Add(newElement.ToString());
                }
            }
            else if (item.StartsWith("Custom"))
            {
                comboBoxConsoleInput.Items.Add("Import DLL");
            }
            else
            {
                comboBoxConsoleInput.Items.Add("None");
            }
            comboBoxConsoleInput.Enabled = true;
            comboBoxConsoleInput.SelectedIndex = 0;
        }
    }
}
