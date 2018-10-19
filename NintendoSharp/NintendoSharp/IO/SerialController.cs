using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Collections;
using System.IO.Ports;
using System.Windows.Forms;

namespace NintendoSharp.IO
{
    public static class SerialController
    {
        public static Thread serialThread;
        public static volatile string portNameNew = "COM4";
        public static volatile bool portOpen = false;
        public static System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public static void StartSerial()
        {
            serialThread = new Thread(LoopSerial);
            serialThread.IsBackground = true;
            if (portOpen)
            {
                AppController.Log("Error: Serial already running.", Constants.Enums.LogMessageType.Error);
                return;
            }
            AppController.Log("Starting Serial port on " + portNameNew + " ....", Constants.Enums.LogMessageType.Basic);
            serialThread.Start();
        }

        public static void StopSerial()
        {
            portOpen = false;
        }

        static void LoopSerial()
        {
            SerialPort port = new SerialPort();
            port.PortName = portNameNew;
            port.BaudRate = 500000;
            port.Open();
            portOpen = true;
            AppController.logBuffer += "Serial Port Opened." + Environment.NewLine;
            while (portOpen && port.IsOpen)
            {
                if (OutputController.queue.Count > 0)
                {
                    string send = (string)OutputController.queue.Dequeue();
                    port.Write(send);
                    AppController.logBuffer += "Serial OUT: " + send + Environment.NewLine;
                }
                if (port.BytesToRead > 0)
                {
                    InputController.AddFromSerial((char)port.ReadChar());
                }
            }
            portOpen = false;
            if (port.IsOpen)
            {
                port.Close();
            }
            AppController.logBuffer += "Serial Port Closed." + Environment.NewLine;
        }
    }
}
