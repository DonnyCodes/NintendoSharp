using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NintendoSharp.Control;

namespace NintendoSharp.BuiltIn.InputSender //Namespace. Use only Alphanumeric characters. No Spaces/symbols/punctuation characters.
{
    public class DemoScript : UserScript //Class. Rename "DemoScript" to whatever your progam is named. No Spaces/symbols/punctuation characters.
    {
        //variables below
        InputSenderSendForm gui = new InputSenderSendForm();

        public DemoScript() //Constructor. You must re-name this to the same thing that you used when you renamed your Class.
        {
            //Set the scripts metadata here. Change this to whatever you want, juse make sure they're strings.
            name = "Input Sender";
            description = "Sends input to a consoles controller port.";
            versionID = "0.1";
            author = "Bob";
        }

        public override void Load() //Load Method. Runs when the user program loads (right after its selected in the dropdown)
        {
            author = "";
            description = "";
        }

        public override void Unload() //Unload Method. Runs when the user program unloads (right after another program is chosen in the dropdown, or when the app is closing)
        {

        }

        public override void Start() //Start Method. Runs when the user presses the "Start" button
        {

        }

        public override void Stop() //Stop Method. Runs when the user presses the "Stop" button
        {

        }

        public override void GUI() //GUI Method. Runs when the user presses the "GUI" button
        {
            gui.Show();
        }
    }
}
