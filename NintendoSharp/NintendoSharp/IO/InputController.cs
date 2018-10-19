using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using NintendoSharp.Objects;
using System.Threading;

namespace NintendoSharp.IO
{
    public static class InputController
    {
        public static ControllerState state;
        private static Queue serialQueue = Queue.Synchronized(new Queue());
        public static Queue inputQueue = Queue.Synchronized(new Queue());
        static Thread inputThread;

        public static void Start()
        {
            inputThread = new Thread(ThreadLoop);
            inputThread.IsBackground = true;
            inputThread.Start();
            AppController.Log("Input Controller Started.", Constants.Enums.LogMessageType.Basic);
        }

        public static void AddFromSerial(char newChar)
        {
            serialQueue.Enqueue(newChar);
        }

        private static void ThreadLoop()
        {
            char charStart = '<';
            char charEnd = '>';
            char rc;
            bool readingCommand = false;
            List<char> newCmd = new List<char>();
            Thread.Sleep(1000);
            while (true)
            {
                if (serialQueue.Count > 0)
                {
                    rc = (char)serialQueue.Dequeue();
                    if (rc == charStart)
                    {
                        readingCommand = true;
                        while(readingCommand)
                        {
                            if (serialQueue.Count > 0)
                            {
                                rc = (char)serialQueue.Dequeue();
                                if (rc == charEnd)
                                {
                                    readingCommand = false;
                                }
                                else
                                {
                                    newCmd.Add(rc);
                                }
                            }
                        }
                        string queueStr = new string(newCmd.ToArray());
                        inputQueue.Enqueue(queueStr);
                        AppController.logBuffer += "Serial IN: " + queueStr + Environment.NewLine; //process
                        newCmd.Clear();
                    }
                }
                Thread.Sleep(1);
            }
        }
    }
}
