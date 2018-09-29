using System;
using System.Collections.Generic;

namespace NintendoSharp
{
    public class Settings
    {
        public string version = "";
        public string COM = "";
        public string Firmware = "";
        public string ConsolePortType = "";
        public string ConsolePortControllerType = "";
        public string ControllerInPort = "";
        public string ControllerInStyle = "";

        public int selectedDevice = -1;
        public int selectedConsole = -1;
        public int selectedConsoleController = -1;
        public int selectedControllerPort = -1;
        public int selectedControllerType = -1;
        public int selectedBoardType = -1;
        public int selectedFirmware = -1;

        public double vJoyModX = 1.00;
        public double vJoyModY = 1.00;
        public double vJoyModZ = 1.00;
        public double vJoyModRX = 1.00;
        public double vJoyModRY = 1.00;
        public double vJoyModRZ = 1.00;
        public int vJoyDeadX = 4;
        public int vJoyDeadY = 4;
        public int vJoyDeadZ = 4;
        public int vJoyDeadRX = 4;
        public int vJoyDeadRY = 4;
        public int vJoyDeadRZ = 4;


        public void ResetToDefaults()
        {
            version = AppController.version;
        }
    }
}
