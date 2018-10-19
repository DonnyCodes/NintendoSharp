using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using NintendoSharp.Objects;

namespace NintendoSharp.IO
{
    public static class OutputController
    {
        private static ControllerState currentState = new ControllerState();
        public static Queue queue = Queue.Synchronized(new Queue());

        public static void SendStateToSerial(ControllerState newState)
        {
            string serialCmd = newState.GetStateDifferences(currentState);
            
            if (serialCmd == "")
            {
                return;
            }
            //AppController.logBuffer += "Serial OUT: " + serialCmd + Environment.NewLine;
            queue.Enqueue(serialCmd);
            currentState = newState;
        }

    }
}
