using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NintendoSharp.Control;
using NintendoSharp.IO;
using NintendoSharp;

namespace NintendoSharp.BuiltIn.FPSMaster //Namespace. Use only Alphanumeric characters. No Spaces/symbols/punctuation characters.
{
    public class FPSMaster : UserScript //Class. Rename "DemoScript" to whatever your progam is named. No Spaces/symbols/punctuation characters.
    {
        //variables below....
        FormMain gui = new FormMain();

        public FPSMaster()
        {
            author = "Bob";
            name = "FPS Master";
            description = "Mouse and keyboard support for FPS games.\n\nCurrently supports:\n-Goldeneye (N64)\n-Perfect Dark (N64)\n-Metroid Prime (GCN)";
            versionID = "0.1a";
        }

        public override void Load() //Load Method. Runs when the user program loads (when the app is opening). Only Runs Once.
        {

        }

        public override void Unload() //Unload Method. Runs when the user program unloads (when the app is closing). Only Runs Once.
        {

        }

        public override void Start() //Start Method. Runs when the user presses the "Start" button.
        {
            SerialController.StartSerial();
        }

        public override void Stop() //Stop Method. Runs when the user presses the "Stop" button.
        {
            SerialController.StopSerial();
        }

        public override void GUI() //GUI Method. Runs when the user presses the "GUI" button.
        {
            gui.Show();
        }
    }
}