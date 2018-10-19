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
        FormProgramInfo programInfoForm = new FormProgramInfo();
        bool appRunning = false;
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            AppController.mainForm = this;
            this.Icon = Properties.Resources.nsharp;
            AppController.Startup();
            RefreshComPorts();
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
            string[] newPorts = SerialPort.GetPortNames();
            if (newPorts.Length == 0)
            {
                AppController.Log("No serial ports found! Please make sure your NintendoSpy or Arduino is plugged in to one of your PC's USB ports, and then press the refresh button.", Enums.LogMessageType.Warning);
            }
            foreach (string portStr in newPorts)
            {
                comboBoxPorts.Items.Add(portStr);
                AppController.Log("Found Serial Port: " + portStr, Enums.LogMessageType.Basic);
            }
        }

        private void comboBoxPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string newPrtStr = this.comboBoxPorts.GetItemText(this.comboBoxPorts.SelectedItem);
            IO.SerialController.portNameNew = newPrtStr;
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
            AppController.loadedProgram.GUI();
        }

        private void buttonProgramStart_Click(object sender, EventArgs e)
        {
            if (!TryStart())
            {
                return;
            }
            SaveToSettings();
            AppController.SaveSettings();
            labelAppStatus.ForeColor = Color.Yellow;
            labelAppStatus.Text = "Starting Program....";
            appRunning = !appRunning;
            if (appRunning)
            {
                AppController.loadedProgram.Start();
                buttonProgramStart.Text = "Stop";
            }
            else
            {
                AppController.loadedProgram.Stop();
                buttonProgramStart.Text = "Start";
            }
        }

        public void LoadFromSettings()
        {
            try
            {
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
                if (AppController.settings.selectedDevice != -1)
                {
                    comboBoxPorts.SelectedIndex = AppController.settings.selectedDevice;
                }
            }
            catch (Exception exc)
            {
                new UI.CrashHandler(exc).Show();
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
                new UI.CrashHandler(exc).Show();
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
            AppController.logForm.BringToFront();
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            AppController.ShutDown();
        }

        private void labelHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ask Bob.");
        }

        private void comboBoxProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProgram.SelectedIndex == comboBoxProgram.Items.Count - 1)
            {
                MessageBox.Show("Coming Soon.");
                comboBoxProgram.SelectedIndex = 0;
            }
            else
            {
                AppController.loadedProgram = AppController.programs[comboBoxProgram.SelectedIndex];
                AppController.Log("Changed program to: " + AppController.loadedProgram.name + " | " + AppController.loadedProgram.versionID, Enums.LogMessageType.Basic);
                buttonProgramGUI.Enabled = true;
                buttonProgramStart.Enabled = true;
                buttonProgramInfo.Enabled = true;
                programInfoForm.FillFromProgram(AppController.loadedProgram);
            }
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

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonProgramInfo_Click(object sender, EventArgs e)
        {
            programInfoForm.Show();
            programInfoForm.BringToFront();
        }

        private void labelTitle_MouseMove(object sender, MouseEventArgs e)
        {
            panelTop_MouseMove(sender, e);
        }

        private void linkLabelWeb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://nintendosharp.bobwillneverdie.com");
        }
    }
}
