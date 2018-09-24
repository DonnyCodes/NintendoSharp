using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using vJoyInterfaceWrap;
using System.Collections;

namespace NintendoSharp
{
    public static class VJoyController
    {
        public static Thread vJoyThread;
        public static Queue outputQueue; //to vjoy
        public static volatile uint controllerID = 1;
        public static volatile bool enabled = false;

        public static void StartVjoyThread()
        {
            outputQueue = Queue.Synchronized(new Queue());
            vJoyThread = new Thread(vJoyLoop);
            vJoyThread.Start();
            AppController.Log("vJoy Thread Started.", Constants.Enums.LogMessageType.Basic);
        }

        public static void StopVjoyThread()
        {
            if (enabled)
            {
                AppController.Log("Stopping vJoy Thread.", Constants.Enums.LogMessageType.Basic);
                try
                {
                    enabled = false;
                    Thread.Sleep(25);
                    vJoyThread.Abort();
                }
                catch (Exception exc)
                {

                }
            }
        }

        static int ButtonsToPov(byte up, byte left, byte down, byte right)
        {
            if (right == 1)
            {
                return 1;
            }
            if (left == 1)
            {
                return 3;
            }
            if (up == 1)
            {
                return 0;
            }
            if (down == 1)
            {
                return 2;
            }
            return -1;
        }

        static void vJoyLoop()
        {
            vJoy joystick;
            vJoy.JoystickState iReport;
            uint id = 1;
            // Create one joystick object and a position structure.
            joystick = new vJoy();
            iReport = new vJoy.JoystickState();

            if (id <= 0 || id > 16)
            {
                AppController.logBuffer += String.Format("Illegal device ID {0}\nExit!", id);
                return;
            }

            // Get the driver attributes (Vendor ID, Product ID, Version Number)
            if (!joystick.vJoyEnabled())
            {
                AppController.logBuffer += String.Format("vJoy driver not enabled: Failed Getting vJoy attributes.\n");
                return;
            }
            else
                AppController.logBuffer += String.Format("Vendor: {0}\nProduct :{1}\nVersion Number:{2}\n", joystick.GetvJoyManufacturerString(), joystick.GetvJoyProductString(), joystick.GetvJoySerialNumberString());

            // Get the state of the requested device
            VjdStat status = joystick.GetVJDStatus(id);
            switch (status)
            {
                case VjdStat.VJD_STAT_OWN:
                    AppController.logBuffer += String.Format("vJoy Device {0} is already owned by this feeder\n", id);
                    break;
                case VjdStat.VJD_STAT_FREE:
                    AppController.logBuffer += String.Format("vJoy Device {0} is free\n", id);
                    break;
                case VjdStat.VJD_STAT_BUSY:
                    AppController.logBuffer += String.Format("vJoy Device {0} is already owned by another feeder\nCannot continue\n", id);
                    return;
                case VjdStat.VJD_STAT_MISS:
                    AppController.logBuffer += String.Format("vJoy Device {0} is not installed or disabled\nCannot continue\n", id);
                    return;
                default:
                    AppController.logBuffer += String.Format("vJoy Device {0} general error\nCannot continue\n", id);
                    return;
            };

            // Check which axes are supported
            bool AxisX = joystick.GetVJDAxisExist(id, HID_USAGES.HID_USAGE_X);
            bool AxisY = joystick.GetVJDAxisExist(id, HID_USAGES.HID_USAGE_Y);
            bool AxisZ = joystick.GetVJDAxisExist(id, HID_USAGES.HID_USAGE_Z);
            bool AxisRX = joystick.GetVJDAxisExist(id, HID_USAGES.HID_USAGE_RX);
            bool AxisRZ = joystick.GetVJDAxisExist(id, HID_USAGES.HID_USAGE_RZ);
            // Get the number of buttons and POV Hat switchessupported by this vJoy device
            int nButtons = joystick.GetVJDButtonNumber(id);
            int ContPovNumber = joystick.GetVJDContPovNumber(id);
            int DiscPovNumber = joystick.GetVJDDiscPovNumber(id);

            // Print results
            AppController.logBuffer += String.Format("\nvJoy Device {0} capabilities:\n", id);
            AppController.logBuffer += String.Format("Numner of buttons\t\t{0}\n", nButtons);
            AppController.logBuffer += String.Format("Numner of Continuous POVs\t{0}\n", ContPovNumber);
            AppController.logBuffer += String.Format("Numner of Descrete POVs\t\t{0}\n", DiscPovNumber);
            AppController.logBuffer += String.Format("Axis X\t\t{0}\n", AxisX ? "Yes" : "No");
            AppController.logBuffer += String.Format("Axis Y\t\t{0}\n", AxisX ? "Yes" : "No");
            AppController.logBuffer += String.Format("Axis Z\t\t{0}\n", AxisX ? "Yes" : "No");
            AppController.logBuffer += String.Format("Axis Rx\t\t{0}\n", AxisRX ? "Yes" : "No");
            AppController.logBuffer += String.Format("Axis Rz\t\t{0}\n", AxisRZ ? "Yes" : "No");

            // Test if DLL matches the driver
            UInt32 DllVer = 0, DrvVer = 0;
            bool match = joystick.DriverMatch(ref DllVer, ref DrvVer);
            if (match)
                AppController.logBuffer += String.Format("Version of Driver Matches DLL Version ({0:X})\n", DllVer);
            else
                AppController.logBuffer += String.Format("Version of Driver ({0:X}) does NOT match DLL Version ({1:X})\n", DrvVer, DllVer);


            // Acquire the target
            if ((status == VjdStat.VJD_STAT_OWN) || ((status == VjdStat.VJD_STAT_FREE) && (!joystick.AcquireVJD(id))))
            {
                AppController.logBuffer += String.Format("Failed to acquire vJoy device number {0}.\n", id);
                return;
            }
            else
                AppController.logBuffer += String.Format("Acquired: vJoy device number {0}.\n", id);
            enabled = true;
            long vjoyMax = 0;
            joystick.GetVJDAxisMax(id, HID_USAGES.HID_USAGE_X, ref vjoyMax);
            double mod = (vjoyMax / 255);
            AppController.logBuffer += "Running....";
            while (enabled) //loop driver
            {
                try
                {
                    if (outputQueue.Count != 0) //new command
                    {
                        byte[] command = (byte[])outputQueue.Dequeue();
                        byte cmdType = command[0];
                        if (cmdType == (byte)1) //send input
                        {
                            for (uint i = 1; i <= 12; i += 1) //buttons
                            {
                                bool btn = false;
                                if (command[i] == 1)
                                {
                                    btn = true;
                                }
                                joystick.SetBtn(btn, id, i);
                            }

                            joystick.SetDiscPov(ButtonsToPov(command[13], command[14], command[15], command[16]), 1,1);

                            joystick.SetAxis(Convert.ToInt32(command[17] * mod), 1, HID_USAGES.HID_USAGE_X);
                            joystick.SetAxis(Convert.ToInt32(command[18] * mod), 1, HID_USAGES.HID_USAGE_Y);
                            joystick.SetAxis(Convert.ToInt32(command[19] * mod), 1, HID_USAGES.HID_USAGE_Z);
                            joystick.SetAxis(Convert.ToInt32(command[20] * mod), 1, HID_USAGES.HID_USAGE_RX);
                            joystick.SetAxis(Convert.ToInt32(command[21] * mod), 1, HID_USAGES.HID_USAGE_RY);
                            joystick.SetAxis(Convert.ToInt32(command[22] * mod), 1, HID_USAGES.HID_USAGE_RZ);
                        }
                        else if (cmdType == (byte)2)
                        {
                            joystick.ResetVJD(id);
                            AppController.logBuffer += "vJoy Reset." + Environment.NewLine;
                        }
                    }
                }
                catch(Exception exc)
                {
                    AppController.logBuffer += "Vjoy Error:\n" + exc.ToString();
                }
            }
            joystick.ResetVJD(id);
            joystick.RelinquishVJD(1);
            AppController.logBuffer += "vJoy Thread Ended." + Environment.NewLine;
        }
    }
}
