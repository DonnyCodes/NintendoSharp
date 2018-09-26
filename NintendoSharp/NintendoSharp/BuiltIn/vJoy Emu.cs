using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NintendoSharp.NintendoSpyW.Readers;
using NintendoSharp.NintendoSpyW;

namespace NintendoSharp.BuiltIn
{
    public static class vJoy_Emu
    {
        static Thread emuThread;
        static volatile bool enabled;

        public static void Start()
        {
            AppController.Log("Starting vJoy Sender.", Constants.Enums.LogMessageType.Basic);
            emuThread = new Thread(ThreadLoop);
            NintendoSpyWrapper.StartListening();
            VJoyController.StartVjoyThread();
            emuThread.Start();
        }

        public static void ThreadLoop()
        {
            AppController.logBuffer += "vJoy Sender Started." + Environment.NewLine;
            enabled = true;
            ControllerState lastState = null;
            Thread.Sleep(100);
            NintendoSpyWrapper.ControlStyle controlStyle = NintendoSpyWrapper.controlStyle;
            while (enabled)
            {
                ControllerState thisState = NintendoSpyWrapper.state;
                if (lastState == null || VJoyController.outputQueue.Count < 2)
                {
                    SendToVJoy(thisState, controlStyle);
                    lastState = thisState;
                    //AppController.logBuffer = "Nintendo Spy:\n" + thisState.ToString() + Environment.NewLine;
                }
            }
            AppController.logBuffer += "vJoy Sender Stopped." + Environment.NewLine;
        }

        public static byte BoolToByte(bool boolean)
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

        static void SendToVJoy(ControllerState state, NintendoSpyWrapper.ControlStyle controlStyle)
        {
            byte[] newInput = {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,128,128,128,128,128,128};
            byte[] deadzones = { 5, 5, 5, 5, 5, 5 };
            byte[] stickDefaults = {128,128,128,128,128,128};
            int[] stickBytes = new int[6];
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
                stickBytes[0] = (byte)(state.Analogs["lstick_x"] * 127);
                stickBytes[1] = (byte)(state.Analogs["lstick_y"] * 127);
                stickBytes[2] = -(byte)(state.Analogs["trig_l"] * 127);
                stickBytes[3] = (byte)(state.Analogs["cstick_x"] * 127);
                stickBytes[4] = (byte)(state.Analogs["cstick_y"] * 127);
                stickBytes[5] = (byte)(state.Analogs["trig_r"] * 127);

                for (int i = 0; i < 6; i += 1)
                {
                    if (Math.Abs(stickBytes[i]) > deadzones[i])
                    {
                        newInput[i + 17] = (byte)(128 + stickBytes[i]);
                    }
                    else
                    {
                        newInput[i + 17] = stickDefaults[i];
                    }
                }
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
                newInput[17] = (byte)((state.Analogs["stick_x"] * 127));
                newInput[18] = (byte)((state.Analogs["stick_y"] * 127));
                newInput[19] = (byte)(128);
                newInput[20] = (byte)(128);
                newInput[21] = (byte)(128);
                newInput[22] = (byte)(128);
            }
            VJoyController.outputQueue.Enqueue(newInput);
        }

        public static void Stop()
        {
            AppController.Log("Stopping vJoy Sender.", Constants.Enums.LogMessageType.Basic);
            enabled = false;
        }

        public static void OnGUI()
        {

        }
    }
}
