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

        static bool[] GetDifferences(byte[] oldByte, byte[] newByte)
        {
            bool[] ret = new bool[23];
            bool differences = false;
            for (int i = 1; i < 23; i += 1)
            {
                if (oldByte[i] != newByte[i])
                {
                    ret[i] = true;
                    differences = true;
                }
                else
                {
                    ret[i] = false;
                }
            }
            ret[0] = differences;
            return ret;
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
                AppController.logBuffer += String.Format("vJoy: Illegal device ID {0}\nExit!", id);
                return;
            }

            // Get the driver attributes (Vendor ID, Product ID, Version Number)
            if (!joystick.vJoyEnabled())
            {
                AppController.logBuffer += String.Format("vJoy: driver not enabled, Failed Getting vJoy attributes.\n");
                return;
            }
            else
                AppController.logBuffer += String.Format("vJoy: Vendor: {0}\nProduct :{1}\nVersion Number:{2}\n", joystick.GetvJoyManufacturerString(), joystick.GetvJoyProductString(), joystick.GetvJoySerialNumberString());

            // Get the state of the requested device
            VjdStat status = joystick.GetVJDStatus(id);
            switch (status)
            {
                case VjdStat.VJD_STAT_OWN:
                    AppController.logBuffer += String.Format("vJoy: Device {0} is already owned by this feeder\n", id);
                    break;
                case VjdStat.VJD_STAT_FREE:
                    AppController.logBuffer += String.Format("vJoy: Device {0} is free\n", id);
                    break;
                case VjdStat.VJD_STAT_BUSY:
                    AppController.logBuffer += String.Format("vJoy: Device {0} is already owned by another feeder\nCannot continue\n", id);
                    return;
                case VjdStat.VJD_STAT_MISS:
                    AppController.logBuffer += String.Format("vJoy: Device {0} is not installed or disabled\nCannot continue\n", id);
                    return;
                default:
                    AppController.logBuffer += String.Format("vJoy: Device {0} general error\nCannot continue\n", id);
                    return;
            };

            // Check which axes are supported
            bool AxisX = joystick.GetVJDAxisExist(id, HID_USAGES.HID_USAGE_X);
            bool AxisY = joystick.GetVJDAxisExist(id, HID_USAGES.HID_USAGE_Y);
            bool AxisZ = joystick.GetVJDAxisExist(id, HID_USAGES.HID_USAGE_Z);
            bool AxisRX = joystick.GetVJDAxisExist(id, HID_USAGES.HID_USAGE_RX);
            bool AxisRY = joystick.GetVJDAxisExist(id, HID_USAGES.HID_USAGE_RY);
            bool AxisRZ = joystick.GetVJDAxisExist(id, HID_USAGES.HID_USAGE_RZ);
            // Get the number of buttons and POV Hat switchessupported by this vJoy device
            int nButtons = joystick.GetVJDButtonNumber(id);
            int ContPovNumber = joystick.GetVJDContPovNumber(id);
            int DiscPovNumber = joystick.GetVJDDiscPovNumber(id);

            // Print results
            AppController.logBuffer += String.Format("vJoy: \nvJoy Device {0} capabilities:\n", id);
            AppController.logBuffer += String.Format("vJoy: Numner of buttons\t\t{0}\n", nButtons);
            AppController.logBuffer += String.Format("vJoy: Numner of Continuous POVs\t{0}\n", ContPovNumber);
            AppController.logBuffer += String.Format("vJoy: Numner of Descrete POVs\t\t{0}\n", DiscPovNumber);
            AppController.logBuffer += String.Format("vJoy: Axis X\t\t{0}\n", AxisX ? "Yes" : "No");
            AppController.logBuffer += String.Format("vJoy: Axis Y\t\t{0}\n", AxisY ? "Yes" : "No");
            AppController.logBuffer += String.Format("vJoy: Axis Z\t\t{0}\n", AxisZ ? "Yes" : "No");
            AppController.logBuffer += String.Format("vJoy: Axis Rx\t\t{0}\n", AxisRX ? "Yes" : "No");
            AppController.logBuffer += String.Format("vJoy: Axis Ry\t\t{0}\n", AxisRY ? "Yes" : "No");
            AppController.logBuffer += String.Format("vJoy: Axis Rz\t\t{0}\n", AxisRZ ? "Yes" : "No");

            // Test if DLL matches the driver
            UInt32 DllVer = 0, DrvVer = 0;
            bool match = joystick.DriverMatch(ref DllVer, ref DrvVer);
            if (match)
            {
                AppController.logBuffer += String.Format("vJoy: Version of Driver Matches DLL Version ({0:X})\n", DllVer);
            }
            else
            {
                AppController.logBuffer += String.Format("vJoy: Version of Driver ({0:X}) does NOT match DLL Version ({1:X})\n", DrvVer, DllVer);
            }


            // Acquire the target
            if ((status == VjdStat.VJD_STAT_OWN) || ((status == VjdStat.VJD_STAT_FREE) && (!joystick.AcquireVJD(id))))
            {
                AppController.logBuffer += String.Format("vJoy: Failed to acquire device number {0}.\n", id);
                return;
            }
            AppController.logBuffer += String.Format("vJoy: Acquired vJoy device number {0}.\n", id);
            enabled = true;
            long[] vJoyAxismax = { 0, 0, 0, 0, 0, 0 };
            bool[] axisEnabled = { AxisX, AxisY, AxisZ, AxisRX, AxisRY, AxisRZ};
            bool res;
            HID_USAGES[] axiHIDs = { HID_USAGES.HID_USAGE_X, HID_USAGES.HID_USAGE_Y, HID_USAGES.HID_USAGE_Z, HID_USAGES.HID_USAGE_RX, HID_USAGES.HID_USAGE_RY, HID_USAGES.HID_USAGE_RZ };

            for (int i = 0; i < 6; i += 1)
            {
                if (axisEnabled[i])
                {
                    res = joystick.GetVJDAxisMax(id, axiHIDs[i], ref vJoyAxismax[i]);
                    AppController.logBuffer += "vJoy: " + axiHIDs[i].ToString() + " Axis Max: " + vJoyAxismax[i].ToString() + Environment.NewLine;
                }
            }
            BuiltIn.vJoy_Emu.newMaxes = vJoyAxismax;
            BuiltIn.vJoy_Emu.maxesUpdateQueued = true;

            AppController.logBuffer += "vJoy: Running....";
            while (enabled) //loop driver
            {
                try
                {

                    if (outputQueue.Count != 0) //new command
                    {
                        int[] command = (int[])outputQueue.Dequeue();
                        int cmdType = command[0];

                        if (cmdType == 1) //send input
                        {
                            bool[] buttons = new bool[12];
                            byte[] pov = new byte[2];
                            for (int i = 1; i <= 12; i += 1)
                            {
                                if (command[i] == 1)
                                {
                                    buttons[i - 1] = true;
                                }
                                else
                                {
                                    buttons[i - 1] = false;
                                }
                            }

                            if (command[13] == 1)
                            {
                                pov[0] = 0;
                            }
                            else if (command[15] == 1)
                            {
                                pov[0] = 2;
                            }
                            else
                            {
                                pov[0] = 4;
                            }

                            if (command[14] == 1)
                            {
                                pov[1] = 3;
                            }
                            else if (command[16] == 1)
                            {
                                pov[1] = 1;
                            }
                            else
                            {
                                pov[1] = 4;
                            }

                            iReport.bHats = (uint)(4 << 12) | (uint)(4 << 8) | (uint)(pov[1] << 4) | (uint)pov[0];

                            BitArray arr = new BitArray(buttons);
                            int[] data = new int[4];
                            arr.CopyTo(data, 0);
                            iReport.Buttons = (uint)data[0];

                            int[] newAxi = {0,0,0,0,0,0};

                            iReport.bDevice = 1;
                            iReport.AxisX = command[17];
                            iReport.AxisY = command[18];
                            iReport.AxisZ = command[19];
                            iReport.AxisXRot = command[20];
                            iReport.AxisYRot = command[21];
                            iReport.AxisZRot = command[22];
                            joystick.UpdateVJD(1, ref iReport);
                            Thread.Sleep(1);
                            //AppController.logBuffer += "Update.";
                        }
                        else if (cmdType == 2)
                        {
                            joystick.ResetVJD(id);
                            AppController.logBuffer += "vJoy: Reset." + Environment.NewLine;
                        }
                    }
                }
                catch(Exception exc)
                {
                    AppController.logBuffer += "vjoy: Error:\n" + exc.ToString();
                }
            }
            joystick.ResetVJD(id);
            joystick.RelinquishVJD(1);
            AppController.logBuffer += "vJoy: Thread Ended." + Environment.NewLine;
        }
    }
}
