using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Collections;
using System.IO.Ports;
using System.Windows.Forms;

namespace NintendoSharp
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
            while (port.IsOpen)
            {
                if (portFlushQueued)
                {
                    portFlushQueued = false;
                    //send clearing commands to the board followed by a pause command here.

                    while (port.BytesToRead > 0)
                    {
                        int dead = port.ReadByte();
                    }
                }
                if (portCloseQueued)
                {
                    while (port.BytesToRead > 0)
                    {
                        int dead = port.ReadByte();
                    }
                    port.Close();
                    portOpen = false;
                }
                byte[] result = ReadFromArduino(port);
                if (result[9] != 0)
                {
                    inputQueue.Enqueue(result);
                }

                if (outputQueue.Count != 0)
                {
                    byte[] command = (byte[])outputQueue.Dequeue();
                    WriteToArduino(port, command);
                }
            }
        }

        static byte[] ReadFromArduino(SerialPort port)
        {
            byte[] input = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            if (port.BytesToRead > 9)
            {
                port.Read(input, 0, 10);
            }
            return input;
        }

        static void WriteToArduino(SerialPort port, byte[] message)
        {
            if (message.Length != 10)
            {
                AppController.Log("Not 10", Constants.Enums.LogMessageType.Error);
                return;
            }
            port.Write(message, 0, 10);
            port.BaseStream.Flush();
        }

        public static void SendToQueue(byte[] command)
        {
            outputQueue.Enqueue(command);
        }

        private static byte[] ReadFromQueue()
        {
            if (inputQueue.Count == 0)
            {
                return null;
            }
            return (byte[])inputQueue.Dequeue();
        }
    }
}
