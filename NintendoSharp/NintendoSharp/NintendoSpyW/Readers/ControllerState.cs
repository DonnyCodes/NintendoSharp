using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NintendoSharp.NintendoSpyW.Readers
{
    public class ControllerState
    {
        static public readonly ControllerState Zero = new ControllerState
            (new Dictionary <string, bool> (), new Dictionary <string, float> ());

        public IReadOnlyDictionary <string, bool> Buttons { get; private set; }
        public IReadOnlyDictionary <string, float> Analogs { get; private set;  }

        public ControllerState (IReadOnlyDictionary <string, bool> buttons, IReadOnlyDictionary <string, float> analogs)
        {
            Buttons = buttons;
            Analogs = analogs;
        }

        public override string ToString()
        {
            string btnString = "";
            string analogString = "";
            foreach (KeyValuePair<string, bool> entry in Buttons)
            {
                btnString += entry.Key + ": " + entry.Value.ToString() + " | ";
                // do something with entry.Value or entry.Key
            }
            foreach (KeyValuePair<string, float> entry in Analogs)
            {
                analogString += entry.Key + ": " + entry.Value.ToString() + " | ";
                // do something with entry.Value or entry.Key
            }
            return "Buttons:\n" + btnString + "\n\nAnalogs:\n" + analogString;
        }
    }
}
