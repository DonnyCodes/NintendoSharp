namespace NintendoSharp.UI
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelHelp = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelClose = new System.Windows.Forms.Label();
            this.labelMinimize = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.comboBoxPorts = new System.Windows.Forms.ComboBox();
            this.pictureBoxRefresh = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxControllerPort = new System.Windows.Forms.ComboBox();
            this.comboBoxConsole = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxControllerType = new System.Windows.Forms.ComboBox();
            this.comboBoxConsoleInput = new System.Windows.Forms.ComboBox();
            this.comboBoxBoard = new System.Windows.Forms.ComboBox();
            this.comboBoxFirmware = new System.Windows.Forms.ComboBox();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.comboBoxProgram = new System.Windows.Forms.ComboBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.linkLabelWebsite = new System.Windows.Forms.LinkLabel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.labelDisclaimer = new System.Windows.Forms.Label();
            this.timerDisclaimer = new System.Windows.Forms.Timer(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.labelAppStatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonProgramStart = new System.Windows.Forms.Button();
            this.buttonProgramGUI = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonLog = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRefresh)).BeginInit();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panelTop.Controls.Add(this.labelHelp);
            this.panelTop.Controls.Add(this.panel2);
            this.panelTop.Controls.Add(this.labelClose);
            this.panelTop.Controls.Add(this.labelMinimize);
            this.panelTop.Controls.Add(this.labelTitle);
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(506, 26);
            this.panelTop.TabIndex = 0;
            this.panelTop.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTop_Paint);
            this.panelTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseMove);
            // 
            // labelHelp
            // 
            this.labelHelp.AutoSize = true;
            this.labelHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHelp.ForeColor = System.Drawing.Color.White;
            this.labelHelp.Location = new System.Drawing.Point(411, 3);
            this.labelHelp.Name = "labelHelp";
            this.labelHelp.Size = new System.Drawing.Size(19, 20);
            this.labelHelp.TabIndex = 4;
            this.labelHelp.Text = "?";
            this.labelHelp.Click += new System.EventHandler(this.labelHelp_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(436, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2, 18);
            this.panel2.TabIndex = 3;
            // 
            // labelClose
            // 
            this.labelClose.AutoSize = true;
            this.labelClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.labelClose.Location = new System.Drawing.Point(471, 2);
            this.labelClose.Name = "labelClose";
            this.labelClose.Size = new System.Drawing.Size(25, 24);
            this.labelClose.TabIndex = 2;
            this.labelClose.Text = "X";
            this.labelClose.Click += new System.EventHandler(this.labelClose_Click);
            // 
            // labelMinimize
            // 
            this.labelMinimize.AutoSize = true;
            this.labelMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMinimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.labelMinimize.Location = new System.Drawing.Point(443, -4);
            this.labelMinimize.Name = "labelMinimize";
            this.labelMinimize.Size = new System.Drawing.Size(23, 31);
            this.labelMinimize.TabIndex = 3;
            this.labelMinimize.Text = "-";
            this.labelMinimize.Click += new System.EventHandler(this.labelMinimize_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.Yellow;
            this.labelTitle.Location = new System.Drawing.Point(3, 7);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(111, 16);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "NintendoSharp";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVersion.ForeColor = System.Drawing.Color.Silver;
            this.labelVersion.Location = new System.Drawing.Point(464, 8);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(31, 13);
            this.labelVersion.TabIndex = 1;
            this.labelVersion.Text = "0.0.0";
            // 
            // comboBoxPorts
            // 
            this.comboBoxPorts.FormattingEnabled = true;
            this.comboBoxPorts.Location = new System.Drawing.Point(12, 51);
            this.comboBoxPorts.Name = "comboBoxPorts";
            this.comboBoxPorts.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPorts.TabIndex = 1;
            this.comboBoxPorts.Text = "Choose a Port";
            this.comboBoxPorts.SelectedIndexChanged += new System.EventHandler(this.comboBoxPorts_SelectedIndexChanged);
            // 
            // pictureBoxRefresh
            // 
            this.pictureBoxRefresh.Image = global::NintendoSharp.Properties.Resources.refresh;
            this.pictureBoxRefresh.Location = new System.Drawing.Point(139, 51);
            this.pictureBoxRefresh.Name = "pictureBoxRefresh";
            this.pictureBoxRefresh.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxRefresh.TabIndex = 2;
            this.pictureBoxRefresh.TabStop = false;
            this.pictureBoxRefresh.Click += new System.EventHandler(this.pictureBoxRefresh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Device Settings:";
            // 
            // comboBoxControllerPort
            // 
            this.comboBoxControllerPort.FormattingEnabled = true;
            this.comboBoxControllerPort.Items.AddRange(new object[] {
            "None",
            "NES IN",
            "SNES IN",
            "N64 IN",
            "GameCube IN",
            "NintendoSpy",
            "Bluetooth (Wii+U)",
            "PC GamePad",
            "Custom DLL"});
            this.comboBoxControllerPort.Location = new System.Drawing.Point(308, 74);
            this.comboBoxControllerPort.Name = "comboBoxControllerPort";
            this.comboBoxControllerPort.Size = new System.Drawing.Size(100, 21);
            this.comboBoxControllerPort.TabIndex = 9;
            this.comboBoxControllerPort.Text = "Choose One";
            this.comboBoxControllerPort.SelectedIndexChanged += new System.EventHandler(this.comboBoxControllerPort_SelectedIndexChanged);
            // 
            // comboBoxConsole
            // 
            this.comboBoxConsole.FormattingEnabled = true;
            this.comboBoxConsole.Items.AddRange(new object[] {
            "None",
            "NES",
            "SNES",
            "N64",
            "GameCube",
            "Wii",
            "WiiU (NYI)",
            "Custom DLL"});
            this.comboBoxConsole.Location = new System.Drawing.Point(190, 74);
            this.comboBoxConsole.Name = "comboBoxConsole";
            this.comboBoxConsole.Size = new System.Drawing.Size(100, 21);
            this.comboBoxConsole.TabIndex = 8;
            this.comboBoxConsole.Text = "Choose One";
            this.comboBoxConsole.SelectedIndexChanged += new System.EventHandler(this.comboBoxConsole_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(183, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Console IO:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(305, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Controller IO:";
            // 
            // comboBoxControllerType
            // 
            this.comboBoxControllerType.Enabled = false;
            this.comboBoxControllerType.FormattingEnabled = true;
            this.comboBoxControllerType.Location = new System.Drawing.Point(309, 120);
            this.comboBoxControllerType.Name = "comboBoxControllerType";
            this.comboBoxControllerType.Size = new System.Drawing.Size(100, 21);
            this.comboBoxControllerType.TabIndex = 13;
            // 
            // comboBoxConsoleInput
            // 
            this.comboBoxConsoleInput.Enabled = false;
            this.comboBoxConsoleInput.FormattingEnabled = true;
            this.comboBoxConsoleInput.Location = new System.Drawing.Point(190, 120);
            this.comboBoxConsoleInput.Name = "comboBoxConsoleInput";
            this.comboBoxConsoleInput.Size = new System.Drawing.Size(100, 21);
            this.comboBoxConsoleInput.TabIndex = 12;
            // 
            // comboBoxBoard
            // 
            this.comboBoxBoard.FormattingEnabled = true;
            this.comboBoxBoard.Items.AddRange(new object[] {
            "Uno",
            "Nano",
            "Mega",
            "Other"});
            this.comboBoxBoard.Location = new System.Drawing.Point(12, 97);
            this.comboBoxBoard.Name = "comboBoxBoard";
            this.comboBoxBoard.Size = new System.Drawing.Size(151, 21);
            this.comboBoxBoard.TabIndex = 14;
            this.comboBoxBoard.Text = "Choose A Board";
            this.comboBoxBoard.SelectedIndexChanged += new System.EventHandler(this.comboBoxBoard_SelectedIndexChanged);
            // 
            // comboBoxFirmware
            // 
            this.comboBoxFirmware.FormattingEnabled = true;
            this.comboBoxFirmware.Items.AddRange(new object[] {
            "Board Firmware",
            "--",
            "Flash Newest",
            "--",
            "Flash 2nd Newest",
            "Flash 3rd Newest",
            "--",
            "Flash Other"});
            this.comboBoxFirmware.Location = new System.Drawing.Point(12, 124);
            this.comboBoxFirmware.Name = "comboBoxFirmware";
            this.comboBoxFirmware.Size = new System.Drawing.Size(151, 21);
            this.comboBoxFirmware.TabIndex = 15;
            this.comboBoxFirmware.Text = "Choose A Firmware";
            // 
            // buttonSettings
            // 
            this.buttonSettings.ForeColor = System.Drawing.Color.Black;
            this.buttonSettings.Image = global::NintendoSharp.Properties.Resources.settings;
            this.buttonSettings.Location = new System.Drawing.Point(440, 44);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(40, 40);
            this.buttonSettings.TabIndex = 16;
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel4.Location = new System.Drawing.Point(297, 31);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(2, 120);
            this.panel4.TabIndex = 5;
            // 
            // comboBoxProgram
            // 
            this.comboBoxProgram.FormattingEnabled = true;
            this.comboBoxProgram.Items.AddRange(new object[] {
            "vJoy Interface",
            "--",
            "Install a NintendoSharp Script"});
            this.comboBoxProgram.Location = new System.Drawing.Point(89, 167);
            this.comboBoxProgram.Name = "comboBoxProgram";
            this.comboBoxProgram.Size = new System.Drawing.Size(246, 21);
            this.comboBoxProgram.TabIndex = 18;
            this.comboBoxProgram.Text = "Choose a Program";
            this.comboBoxProgram.SelectedIndexChanged += new System.EventHandler(this.comboBoxProgram_SelectedIndexChanged);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Black;
            this.panel6.Controls.Add(this.linkLabelWebsite);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.labelVersion);
            this.panel6.Controls.Add(this.labelDisclaimer);
            this.panel6.Location = new System.Drawing.Point(0, 222);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(506, 24);
            this.panel6.TabIndex = 19;
            // 
            // linkLabelWebsite
            // 
            this.linkLabelWebsite.AutoSize = true;
            this.linkLabelWebsite.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.linkLabelWebsite.Location = new System.Drawing.Point(334, 5);
            this.linkLabelWebsite.Name = "linkLabelWebsite";
            this.linkLabelWebsite.Size = new System.Drawing.Size(46, 13);
            this.linkLabelWebsite.TabIndex = 5;
            this.linkLabelWebsite.TabStop = true;
            this.linkLabelWebsite.Text = "Website";
            this.linkLabelWebsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelWebsite_LinkClicked);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Location = new System.Drawing.Point(312, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(2, 18);
            this.panel7.TabIndex = 4;
            // 
            // labelDisclaimer
            // 
            this.labelDisclaimer.AutoSize = true;
            this.labelDisclaimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDisclaimer.ForeColor = System.Drawing.Color.Yellow;
            this.labelDisclaimer.Location = new System.Drawing.Point(9, 4);
            this.labelDisclaimer.Name = "labelDisclaimer";
            this.labelDisclaimer.Size = new System.Drawing.Size(289, 16);
            this.labelDisclaimer.TabIndex = 0;
            this.labelDisclaimer.Text = "-= NOT AFFILIATED WITH NINTENDO =-";
            this.labelDisclaimer.Click += new System.EventHandler(this.labelDisclaimer_Click);
            // 
            // timerDisclaimer
            // 
            this.timerDisclaimer.Enabled = true;
            this.timerDisclaimer.Interval = 1000;
            this.timerDisclaimer.Tick += new System.EventHandler(this.timerDisclaimer_Tick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel3.Location = new System.Drawing.Point(415, 31);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(2, 120);
            this.panel3.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.Location = new System.Drawing.Point(175, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2, 120);
            this.panel1.TabIndex = 6;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel5.Location = new System.Drawing.Point(0, 198);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(500, 2);
            this.panel5.TabIndex = 7;
            // 
            // labelAppStatus
            // 
            this.labelAppStatus.AutoSize = true;
            this.labelAppStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAppStatus.ForeColor = System.Drawing.Color.Yellow;
            this.labelAppStatus.Location = new System.Drawing.Point(12, 203);
            this.labelAppStatus.Name = "labelAppStatus";
            this.labelAppStatus.Size = new System.Drawing.Size(86, 16);
            this.labelAppStatus.TabIndex = 24;
            this.labelAppStatus.Text = "Starting Up....";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(187, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Console In:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(187, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Controller Type:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(307, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Controller In:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(307, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Controller Type:";
            // 
            // buttonProgramStart
            // 
            this.buttonProgramStart.Enabled = false;
            this.buttonProgramStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProgramStart.ForeColor = System.Drawing.Color.Black;
            this.buttonProgramStart.Location = new System.Drawing.Point(405, 159);
            this.buttonProgramStart.Name = "buttonProgramStart";
            this.buttonProgramStart.Size = new System.Drawing.Size(83, 34);
            this.buttonProgramStart.TabIndex = 29;
            this.buttonProgramStart.Text = "Start";
            this.buttonProgramStart.UseVisualStyleBackColor = true;
            this.buttonProgramStart.Click += new System.EventHandler(this.buttonProgramStart_Click);
            // 
            // buttonProgramGUI
            // 
            this.buttonProgramGUI.Enabled = false;
            this.buttonProgramGUI.ForeColor = System.Drawing.Color.Black;
            this.buttonProgramGUI.Location = new System.Drawing.Point(341, 165);
            this.buttonProgramGUI.Name = "buttonProgramGUI";
            this.buttonProgramGUI.Size = new System.Drawing.Size(37, 23);
            this.buttonProgramGUI.TabIndex = 30;
            this.buttonProgramGUI.Text = "GUI";
            this.buttonProgramGUI.UseVisualStyleBackColor = true;
            this.buttonProgramGUI.Click += new System.EventHandler(this.buttonProgramGUI_Click);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel8.Location = new System.Drawing.Point(0, 152);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(500, 2);
            this.panel8.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 16);
            this.label8.TabIndex = 31;
            this.label8.Text = "Program:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 16);
            this.label9.TabIndex = 32;
            this.label9.Text = "Board Settings:";
            // 
            // buttonLog
            // 
            this.buttonLog.ForeColor = System.Drawing.Color.Black;
            this.buttonLog.Location = new System.Drawing.Point(440, 101);
            this.buttonLog.Name = "buttonLog";
            this.buttonLog.Size = new System.Drawing.Size(40, 40);
            this.buttonLog.TabIndex = 33;
            this.buttonLog.Text = "Log";
            this.buttonLog.UseVisualStyleBackColor = true;
            this.buttonLog.Click += new System.EventHandler(this.buttonLog_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(498, 244);
            this.Controls.Add(this.buttonLog);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.buttonProgramGUI);
            this.Controls.Add(this.buttonProgramStart);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelAppStatus);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.comboBoxProgram);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.comboBoxFirmware);
            this.Controls.Add(this.comboBoxBoard);
            this.Controls.Add(this.comboBoxControllerType);
            this.Controls.Add(this.comboBoxConsoleInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxControllerPort);
            this.Controls.Add(this.comboBoxConsole);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxRefresh);
            this.Controls.Add(this.comboBoxPorts);
            this.Enabled = false;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRefresh)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelClose;
        private System.Windows.Forms.Label labelMinimize;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.PictureBox pictureBoxRefresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxControllerPort;
        private System.Windows.Forms.ComboBox comboBoxConsole;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxConsoleInput;
        private System.Windows.Forms.ComboBox comboBoxBoard;
        private System.Windows.Forms.ComboBox comboBoxFirmware;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox comboBoxProgram;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label labelDisclaimer;
        private System.Windows.Forms.Timer timerDisclaimer;
        private System.Windows.Forms.LinkLabel linkLabelWebsite;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label labelAppStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonProgramStart;
        private System.Windows.Forms.Button buttonProgramGUI;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonLog;
        private System.Windows.Forms.Label labelHelp;
        public System.Windows.Forms.ComboBox comboBoxPorts;
        public System.Windows.Forms.ComboBox comboBoxControllerType;
    }
}