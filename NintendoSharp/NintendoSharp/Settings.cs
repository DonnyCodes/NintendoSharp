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


        public void ResetToDefaults()
        {
            version = AppController.version;
        }
    }
}
