using System;
using System.Collections.Generic;
using System.Text;
using NintendoSharp.UI;
using NintendoSharp.Constants;
using System.IO.Ports;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Net;
using System.Net.NetworkInformation;

namespace NintendoSharp
{
    public static class AppController
    {
        public static string[] builtinPrograms = {"Input Recorder", "Input Converter"};
        public static string version = "0.1.6";

        public static FormMain mainForm;
        public static FormLog logForm;

        public static string appFolder;
        public static bool firstStart = false;

        public static Settings settings = new Settings();
        public static volatile string logBuffer = "";

        static System.Windows.Forms.Timer LogBufferTimer;

        static Thread updateThread;
        //public static FormTASRecorder inputRecorderForm;

        public static void Startup()
        {
            Settings newSettings = new Settings();
            logForm = new FormLog();
            logForm.Show();
            mainForm.BringToFront();
            Log("Starting Up....", Enums.LogMessageType.Basic);
            logForm.Location = new System.Drawing.Point(mainForm.Location.X, mainForm.Location.Y + mainForm.Height + 8);
            mainForm.labelVersion.Text = version;
            if (!File.Exists(appFolder + "/" + "settings.js"))
            {
                settings.ResetToDefaults();
                Log("Creating New Settings.", Enums.LogMessageType.Basic);
            }
            else
            {
                try
                {
                    newSettings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(appFolder + "/" + "settings.js"));
                    settings = newSettings;
                    Log("Loaded Settings.", Enums.LogMessageType.Basic);
                    if (settings.version != version)
                    {
                        Log("You have updated to NentendoSharp " + version + " successfully!", Enums.LogMessageType.Basic);
                        settings.version = version;
                    }
                }
                catch (Exception exc)
                {
                    Log("Error Loading Settings:\n" + exc.ToString(), Enums.LogMessageType.Error);
                    settings = new Settings();
                    settings.ResetToDefaults();
                }
            }
            File.WriteAllText(appFolder + "/" + "settings.js", JsonConvert.SerializeObject(settings));
            Log("Settings Saved.", Enums.LogMessageType.Basic);
            if (firstStart)
            {
                Log("Welcome to NintendoSharp Newb!", Enums.LogMessageType.Basic);
            }
            else
            {
                Log("Welcome to NintendoSharp!", Enums.LogMessageType.Basic);
            }
            LogBufferTimer = new System.Windows.Forms.Timer();
            LogBufferTimer.Interval = 100;
            LogBufferTimer.Tick += tmLog_Tick;
            LogBufferTimer.Start();
            Log("Startup Complete!", Enums.LogMessageType.Basic);
            updateThread = new Thread(UpdateThread);
            updateThread.Start();
        }

        public static void SaveSettings()
        {
            File.WriteAllText(appFolder + "/" + "settings.js", JsonConvert.SerializeObject(settings));
        }

        private static void tmLog_Tick(object sender, EventArgs e)
        {
            if (logBuffer != "")
            {
                logForm.richTextBoxLog.Text += logBuffer;
                logBuffer = "";
            }
        }

        public static void AppBegin()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            appFolder = Path.Combine(folder, "NintendoSharpB");
            if (!Directory.Exists(appFolder))
            {
                firstStart = true;
                MessageBox.Show("THIS APPLICATION IS NOT AFFILIATED WITH NINTENDO!", caption: "Disclaimer");
                Directory.CreateDirectory(appFolder);
            }
        }

        public static void Log(string newText,  Enums.LogMessageType messageType)
        {
            logForm.richTextBoxLog.Text += newText + Environment.NewLine;
        }

        public static void UpdateThread()
        {
            logBuffer += "Checking For Updates...." + Environment.NewLine;
            Ping ping = new Ping();
            bool pingError = false;
            try
            {
                PingReply reply = ping.Send("www.nintendosharp.bobwillneverdie.com");
                if (reply.Status != IPStatus.Success)
                {
                    pingError = true;
                }
            }
            catch (Exception exc)
            {
                pingError = true;
            }
            
            if (pingError)
            {
                logBuffer += "Unable to access update server. Check GitHub for updates." + Environment.NewLine;
                return;
            }

            //Update Check Here
        }

        public static void ShutDown()
        {
            VJoyController.enabled = false;
            BuiltIn.vJoy_Emu.Stop();
            SerialController.StopSerial();
            Application.Exit();
        }
    }
}
