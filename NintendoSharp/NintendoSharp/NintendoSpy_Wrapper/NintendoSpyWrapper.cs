using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NintendoSharp.NintendoSpyW.IO;
using NintendoSharp.NintendoSpyW.Readers;

namespace NintendoSharp.NintendoSpyW
{
    public static class NintendoSpyWrapper
    {
        static InputSource source;
        static IControllerReader _reader;
        public static volatile ControllerState state = ControllerState.Zero;

        public enum ControlStyle {NES,SNES,N64,GameCube};

        public static volatile ControlStyle controlStyle = ControlStyle.GameCube;

        static void reader_ControllerStateChanged(IControllerReader reader, ControllerState newState)
        {
            state = newState;
        }

        static void reader_ControllerDisconnected(object sender, EventArgs e)
        {

        }

        public static void StartListening()
        {
            string portStr = AppController.mainForm.comboBoxPorts.GetItemText(AppController.mainForm.comboBoxPorts.SelectedItem);
            string consoleStr = AppController.mainForm.comboBoxControllerType.GetItemText(AppController.mainForm.comboBoxControllerType.SelectedItem);
            AppController.Log("NintendoSpy: Starting wrapper on: " + portStr, Constants.Enums.LogMessageType.Basic);
            try
            {
                if (consoleStr.StartsWith("NES"))
                {
                    source = new InputSource("nes", "NES", true, false, port => new SerialControllerReader(portStr, SuperNESandNES.ReadFromPacket_NES));
                    controlStyle = ControlStyle.NES;
                }
                else if (consoleStr.StartsWith("SNES"))
                {
                    source = new InputSource("snes", "Super SNES", true, false, port => new SerialControllerReader(portStr, SuperNESandNES.ReadFromPacket_SNES));
                    controlStyle = ControlStyle.SNES;
                }
                else if (consoleStr.StartsWith("N64"))
                {
                    source = new InputSource("n64", "Nintendo 64", true, false, port => new SerialControllerReader(portStr, Nintendo64.ReadFromPacket));
                    controlStyle = ControlStyle.N64;
                }
                else if (consoleStr.StartsWith("GameCube"))
                {
                    source = new InputSource("gamecube", "GameCube", true, false, port => new SerialControllerReader(portStr, GameCube.ReadFromPacket));
                    controlStyle = ControlStyle.GameCube;
                }
                _reader = source.BuildReader(portStr);
                _reader.ControllerStateChanged += reader_ControllerStateChanged;
                _reader.ControllerDisconnected += reader_ControllerDisconnected;
                AppController.Log("NintendoSpy: Wrapper Started.", Constants.Enums.LogMessageType.Basic);
            }
            catch (Exception exc)
            {
                AppController.Log("NintendoSpy: Error:\n" + exc.ToString(), Constants.Enums.LogMessageType.Error);
            }
        }

        public static void StopListening()
        {
            _reader.Finish();
            _reader = null;
        }
    }
}
