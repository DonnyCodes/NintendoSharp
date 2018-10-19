using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NintendoSharp.Control;

namespace NintendoSharp.BuiltIn.InputSender //Namespace. Use only Alphanumeric characters. No Spaces/symbols/punctuation characters.
{
    public class InputSender : UserScript //Class. Rename "DemoScript" to whatever your progam is named. No Spaces/symbols/punctuation characters.
    {
        //variables below....
        GUIV2 gui = new GUIV2();

        public InputSender()
        {
            author = "Bob";
            name = "Input Tester";
            description = "For de-bugging new controllers.";
            versionID = "0.1a";
        }

        public override void Load() //Load Method. Runs when the user program loads (when the app is opening).
        {

        }

        public override void Unload() //Unload Method. Runs when the user program unloads (when the app is closing).
        {

        }

        public override void Start() //Start Method. Runs when the user presses the "Start" button.
        {
            IO.SerialController.StartSerial();
        }

        public override void Stop() //Stop Method. Runs when the user presses the "Stop" button.
        {
            IO.SerialController.StopSerial();
        }

        public override void GUI() //GUI Method. Runs when the user presses the "GUI" button.
        {
            gui.Show();
        }
    }
}
