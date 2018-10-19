using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NintendoSharp.Control;
using NintendoSharp.IO;
using NintendoSharp;

namespace NintendoSharp.BuiltIn.InputDisplay //Namespace. Use only Alphanumeric characters. No Spaces/symbols/punctuation characters.
{
    public class InputDisplay : UserScript //Class. Rename "DemoScript" to whatever your progam is named. No Spaces/symbols/punctuation characters.
    {
        //variables below....
        FormMain gui = new FormMain();
        Timer updateTimer;

        public InputDisplay()
        {
            author = "Bob";
            name = "Input Display";
            description = "Input display for selected controller.";
            versionID = "0.1a";
        }

        public override void Load() //Load Method. Runs when the user program loads (when the app is opening). Only Runs Once.
        {
            updateTimer = new Timer();
            updateTimer.Interval = 50;
            updateTimer.Tick += TimerTick;
        }

        public override void Unload() //Unload Method. Runs when the user program unloads (when the app is closing). Only Runs Once.
        {

        }

        public override void Start() //Start Method. Runs when the user presses the "Start" button.
        {
            SerialController.StartSerial();
            updateTimer.Start();
        }

        public override void Stop() //Stop Method. Runs when the user presses the "Stop" button.
        {
            SerialController.StopSerial();
            updateTimer.Stop();
        }

        public override void GUI() //GUI Method. Runs when the user presses the "GUI" button.
        {
            gui.Show();
        }

        public void TimerTick(object sender, EventArgs e)
        {
            if (InputController.inputQueue.Count > 0)
            {
                string inputCmd;
                while (InputController.inputQueue.Count > 1)
                {
                    inputCmd = (string)InputController.inputQueue.Dequeue();
                }
                byte[] updateBytes = new byte[8];
                inputCmd = (string)InputController.inputQueue.Dequeue();
                string[] cmds = inputCmd.Split(',');
                if (cmds[0] == "i")
                {
                    updateBytes[0] = byte.Parse(cmds[1]);
                    updateBytes[1] = byte.Parse(cmds[2]);
                    updateBytes[2] = byte.Parse(cmds[3]);
                    updateBytes[3] = byte.Parse(cmds[4]);
                    updateBytes[4] = byte.Parse(cmds[5]);
                    updateBytes[5] = byte.Parse(cmds[6]);
                    updateBytes[6] = byte.Parse(cmds[7]);
                    updateBytes[7] = byte.Parse(cmds[8]);
                    gui.SetButtonsFromByteArray(updateBytes);
                    AppController.logBuffer += "ID: " + inputCmd + Environment.NewLine;
                }
            }
        }
    }
}
