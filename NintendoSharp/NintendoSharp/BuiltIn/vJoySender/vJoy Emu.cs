using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NintendoSharp.NintendoSpyW.Readers;
using NintendoSharp.NintendoSpyW;
using NintendoSharp.Control;

namespace NintendoSharp.BuiltIn.vJoyInterface
{
    public class vJoy_Emu : UserScript
    {
        Thread emuThread;
        volatile bool enabled;
        public volatile bool deviceSettingsUpdateQueued = false;
        public volatile bool maxesUpdateQueued = false;
        public volatile long[] newMaxes = {0,0,0,0,0,0};
        public volatile int[] newDeadzones = {0,0,0,0,0,0};
        public volatile double[] newAnalogMods = { 1.00, 1.00, 1.00, 1.00, 1.00, 1.00 };
        public vJoyEmuGUI gui = new vJoyEmuGUI();

        public vJoy_Emu()
        {
            author = "Bob";
            name = "vJoy Interface";
            description = "Allows you to send inputs to a vJoy driver.";
            versionID = "0.5b";
        }

        public override void Load()
        {
            gui.parent = this;
        }

        public override void Start()
        {
            AppController.Log("App: Starting vJoy Sender.", Constants.Enums.LogMessageType.Basic);
            newDeadzones[0] = AppController.settings.vJoyDeadX;
            newDeadzones[1] = AppController.settings.vJoyDeadY;
            newDeadzones[2] = AppController.settings.vJoyDeadZ;
            newDeadzones[3] = AppController.settings.vJoyDeadRX;
            newDeadzones[4] = AppController.settings.vJoyDeadRY;
            newDeadzones[5] = AppController.settings.vJoyDeadRZ;
            newAnalogMods[0] = AppController.settings.vJoyModX;
            newAnalogMods[1] = AppController.settings.vJoyModY;
            newAnalogMods[2] = AppController.settings.vJoyModZ;
            newAnalogMods[3] = AppController.settings.vJoyModRX;
            newAnalogMods[4] = AppController.settings.vJoyModRY;
            newAnalogMods[5] = AppController.settings.vJoyModRZ;
            AppController.Log("App: Starting vJoy Sender.", Constants.Enums.LogMessageType.Basic);
            emuThread = new Thread(ThreadLoop);
            NintendoSpyWrapper.StartListening();
            IO.VJoyController.StartVjoyThread();
            emuThread.IsBackground = true;
            emuThread.Start();
        }

        public void ThreadLoop()
        {
            try
            {
                AppController.logBuffer += "App: vJoy Sender Started." + Environment.NewLine;
                enabled = true;

                ControllerState lastState = null;
                Thread.Sleep(100);
                NintendoSpyWrapper.ControlStyle controlStyle = NintendoSpyWrapper.controlStyle;
                long[] axisMax = newMaxes;
                int[] deadZones = newDeadzones;
                double[] analogMods = newAnalogMods;
                while (enabled)
                {
                    if (deviceSettingsUpdateQueued)
                    {
                        deviceSettingsUpdateQueued = false;
                        analogMods = newAnalogMods;
                        deadZones = newDeadzones;
                        AppController.logBuffer += "App: Updated Analog modifiers to:\n" + "X:" + analogMods[0].ToString() + ", Y:" + analogMods[1].ToString() + ", Z:" + analogMods[2].ToString() + ", rX:" + analogMods[3].ToString() + ", rY:" + analogMods[4].ToString() + ", rZ:" + analogMods[5].ToString() + Environment.NewLine;
                        AppController.logBuffer += "App: Updated Analog deadzones to:\n" + "X:" + deadZones[0].ToString() + ", Y:" + deadZones[1].ToString() + ", Z:" + deadZones[2].ToString() + ", rX:" + deadZones[3].ToString() + ", rY:" + deadZones[4].ToString() + ", rZ:" + deadZones[5].ToString() + Environment.NewLine;
                    }

                    if (maxesUpdateQueued)
                    {
                        maxesUpdateQueued = false;
                        axisMax = newMaxes;
                        AppController.logBuffer += "App: Updated vJoy Maximums to:\n" + "X:" + axisMax[0].ToString() + ", Y:" + axisMax[1].ToString() + ", Z:" + axisMax[2].ToString() + ", rX:" + axisMax[3].ToString() + ", rY:" + axisMax[4].ToString() + ", rZ:" + axisMax[5].ToString() + Environment.NewLine;
                    }

                    ControllerState thisState = NintendoSpyWrapper.state;
                    if (lastState == null || IO.VJoyController.outputQueue.Count < 2)
                    {
                        SendToVJoy(thisState, axisMax, deadZones, analogMods, controlStyle);
                        lastState = thisState;
                        //AppController.logBuffer = "Nintendo Spy:\n" + thisState.ToString() + Environment.NewLine;
                    }
                }
                AppController.logBuffer += "App: vJoy Sender Stopped." + Environment.NewLine;
            }
            catch(Exception exc)
            {
                new UI.CrashHandler(exc).Show();
            }
        }

        int BoolToByte(bool boolean)
        {
            if (boolean)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        void SendToVJoy(ControllerState state, long[] axisMax, int[] deadZones, double[] analogMods, NintendoSpyWrapper.ControlStyle controlStyle)
        {
            int[] newInput = {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
            int[] axisStart = new int[6];
            for (int i = 0; i < 6; i += 1)
            {
                axisStart[i] = Convert.ToInt32(axisMax[i] / 2);
                newInput[17 + i] = axisStart[i];
            }

            if (controlStyle == NintendoSpyWrapper.ControlStyle.GameCube)
            {
                newInput[1] = BoolToByte(state.Buttons["a"]);
                newInput[2] = BoolToByte(state.Buttons["b"]);
                newInput[3] = BoolToByte(state.Buttons["x"]);
                newInput[4] = BoolToByte(state.Buttons["y"]);
                newInput[5] = BoolToByte(state.Buttons["z"]);
                newInput[6] = BoolToByte(state.Buttons["start"]);
                newInput[7] = BoolToByte(state.Buttons["l"]);
                newInput[8] = BoolToByte(state.Buttons["r"]);
                newInput[13] = BoolToByte(state.Buttons["up"]);
                newInput[14] = BoolToByte(state.Buttons["left"]);
                newInput[15] = BoolToByte(state.Buttons["down"]);
                newInput[16] = BoolToByte(state.Buttons["right"]);
                newInput[17] = Convert.ToInt32(state.Analogs["lstick_x"] * axisMax[0]);
                newInput[18] = Convert.ToInt32(state.Analogs["lstick_y"] * axisMax[1]);
                newInput[19] = Convert.ToInt32(state.Analogs["trig_l"] * axisMax[2]);
                newInput[20] = Convert.ToInt32(state.Analogs["cstick_x"] * axisMax[3]);
                newInput[21] = Convert.ToInt32(state.Analogs["cstick_y"] * axisMax[4]);
                newInput[22] = Convert.ToInt32(state.Analogs["trig_r"] * axisMax[5]);

            }
            else if (controlStyle == NintendoSpyWrapper.ControlStyle.N64)
            {
                newInput[1] = BoolToByte(state.Buttons["a"]);
                newInput[2] = BoolToByte(state.Buttons["b"]);
                newInput[5] = BoolToByte(state.Buttons["z"]);
                newInput[6] = BoolToByte(state.Buttons["start"]);
                newInput[7] = BoolToByte(state.Buttons["l"]);
                newInput[8] = BoolToByte(state.Buttons["r"]);
                newInput[9] = BoolToByte(state.Buttons["cup"]);
                newInput[10] = BoolToByte(state.Buttons["cleft"]);
                newInput[11] = BoolToByte(state.Buttons["cdown"]);
                newInput[12] = BoolToByte(state.Buttons["cright"]);
                newInput[13] = BoolToByte(state.Buttons["up"]);
                newInput[14] = BoolToByte(state.Buttons["left"]);
                newInput[15] = BoolToByte(state.Buttons["down"]);
                newInput[16] = BoolToByte(state.Buttons["right"]);
                newInput[17] = Convert.ToInt32(state.Analogs["stick_x"] * analogMods[0] * axisMax[0]);
                newInput[18] = Convert.ToInt32(state.Analogs["stick_y"] * analogMods[1] * axisMax[1]);
            }
            
            for (int i = 0; i < 6; i += 1)
            {
                long tmp = Convert.ToInt64(axisStart[i] + newInput[17 + i]);
                if (tmp > axisMax[i])
                {
                    tmp = axisMax[i];
                }
                if (tmp < 0)
                {
                    tmp = 0;
                }
                newInput[17 + i] = Convert.ToInt32(tmp);
            }
            IO.VJoyController.outputQueue.Enqueue(newInput);
        }

        public override void Stop()
        {
            AppController.Log("App: Stopping vJoy Sender.", Constants.Enums.LogMessageType.Basic);
            enabled = false;
        }

        public override void Unload()
        {
            if (enabled)
            {
                enabled = false;
                Thread.Sleep(10);
            }
        }

        public override void GUI()
        {
            gui.Show();
            gui.BringToFront();
        }
    }
}
