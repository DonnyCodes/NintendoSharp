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
        public static Thread serialThread = new Thread(LoopSerial);
        public static Queue outputQueue = Queue.Synchronized(new Queue()); //to board
        public static Queue inputQueue = Queue.Synchronized(new Queue()); //from board
        public static volatile string portNameNew = "COM4";
        static volatile bool portFlushQueued = false;
        static volatile bool portCloseQueued = false;
        public static volatile bool portOpen = false;
        public static System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public static void StartSerial()
        {
            AppController.Log("Starting Serial port on " + portNameNew + " ....", Constants.Enums.LogMessageType.Basic);
            serialThread.Start();
        }

        public static void StopSerial()
        {
            portCloseQueued = true;
        }

        static void LoopSerial()
        {
            SerialPort port = new SerialPort();
            port.PortName = portNameNew;
            port.BaudRate = 500000;
            port.Open();
            portOpen = true;
            portFlushQueued = true;
            AppController.logBuffer += "Serial Port Opened." + Environment.NewLine;
            while (port.IsOpen)
            {

            }
            portOpen = false;
            AppController.logBuffer += "Serial Port Closed." + Environment.NewLine;
        }

        static char[] ReadFromArduino(SerialPort port)
        {
            return new char[1];
        }

        static void WriteToArduino(SerialPort port, char[] message)
        {

        }

        public static void SendToQueue(char[] command)
        {
            outputQueue.Enqueue(command);
        }

        private static char[] ReadFromQueue()
        {
            if (inputQueue.Count == 0)
            {
                return null;
            }
            return (char[])inputQueue.Dequeue();
        }
    }
}
