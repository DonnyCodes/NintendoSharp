using System;
using System.Collections.Generic;
using System.Text;

namespace NintendoSharp.Constants
{
    public static class Enums
    {
        internal static class Controllers
        {
            public enum SNES { Standard, Advantage, Scope, SNES_Mouse, Piano };
            public enum NES { Standard, Advantage, Zapper, Power_Glove, ROB };
            public enum N64 { Standard, Standard_MC, Standard_Pikachu, N64_Mouse, Voice_VRU };
            public enum Gamecube { Standard, Bongos, ASCII_Keyboard, GBA, Microphone };
            public enum Wii { Remote, GCN_Controller, Balance_Board };
            public enum WiiU { Display_Pad, Wii_Remote, GCN_Adapter };
            public enum Bluetooth { Wii_Remote, WiiU_Gamepad, Custom_DLL };
            public enum NintendoSpy { NES, SNES, N64, GameCube };
        }
        public enum Button { A, B, X, Y, Z, S, L, R, DU, DL, DD, DR, CU, CL, CD, CR };

        public enum Axis { X, Y, cX, cY, trigL, trigR };

        public enum LogMessageType { Basic, Warning, Error, Debug };
    }
}
