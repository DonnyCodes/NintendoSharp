using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NintendoSharp.Constants;
using NintendoSharp.Objects;
using NintendoSharp.IO;

namespace NintendoSharp.BuiltIn.InputSender
{
    public partial class GUIV2 : Form
    {
        public ControllerState state = new ControllerState();
        public ControllerState lastState = new ControllerState();

        BitArray buttons1 = new BitArray(8, false);
        BitArray buttons2 = new BitArray(8, false);

        public GUIV2()
        {
            InitializeComponent();
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                WinImports.ReleaseCapture();
                WinImports.SendMessage(Handle, WinImports.WM_NCLBUTTONDOWN, WinImports.HT_CAPTION, 0);
            }
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void labelMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void GUIV2_Load(object sender, EventArgs e)
        {
            UpdateForm();
        }

        private void UpdateForm()
        {
            pictureBoxStick.Location = new Point(state.stickXByte - 8, state.stickYByte - 8);
            pictureBoxCStick.Location = new Point(state.cStickXByte - 8, state.cStickYByte - 8);

            numericUpDownB1.Value = state.buttonByte1;
            numericUpDownB2.Value = state.buttonByte2;
            numericUpDownSX.Value = state.stickXByte;
            numericUpDownSY.Value = state.stickYByte;
            numericUpDownCX.Value = state.cStickXByte;
            numericUpDownCY.Value = state.cStickYByte;
            numericUpDownTX.Value = state.triggerByte1;
            numericUpDownTY.Value = state.triggerByte2;

            numericUpDownBShort.Value = state.buttonShort;
            numericUpDownSShort.Value = state.stickShort;
            numericUpDownCShort.Value = state.cStickShort;
            numericUpDownTShort.Value = state.triggerShort;

            textBoxSerialSend.Text = state.GetStateDifferences(lastState);

        }

        private void buttonA_Click(object sender, EventArgs e)
        {
            string txt = (sender as Button).Text;
            if (txt == "A")
            {
                buttons1[0] = !buttons1[0];
                if (buttons1[0])
                {
                    (sender as Button).BackColor = Color.LightGreen;
                }
                else
                {
                    (sender as Button).BackColor = Color.LightCoral;
                }
                state.UpdateButton(Enums.Button.A, buttons1[0]);
            }
            else if (txt == "B")
            {
                buttons1[1] = !buttons1[1];
                if (buttons1[1])
                {
                    (sender as Button).BackColor = Color.LightGreen;
                }
                else
                {
                    (sender as Button).BackColor = Color.LightCoral;
                }
                state.UpdateButton(Enums.Button.B, buttons1[1]);
            }
            else if (txt == "X")
            {
                buttons1[2] = !buttons1[2];
                if (buttons1[2])
                {
                    (sender as Button).BackColor = Color.LightGreen;
                }
                else
                {
                    (sender as Button).BackColor = Color.LightCoral;
                }
                state.UpdateButton(Enums.Button.X, buttons1[2]);
            }
            else if (txt == "Y")
            {
                buttons1[3] = !buttons1[3];
                if (buttons1[3])
                {
                    (sender as Button).BackColor = Color.LightGreen;
                }
                else
                {
                    (sender as Button).BackColor = Color.LightCoral;
                }
                state.UpdateButton(Enums.Button.Y, buttons1[3]);
            }
            else if (txt == "Z")
            {
                buttons1[4] = !buttons1[4];
                if (buttons1[4])
                {
                    (sender as Button).BackColor = Color.LightGreen;
                }
                else
                {
                    (sender as Button).BackColor = Color.LightCoral;
                }
                state.UpdateButton(Enums.Button.Z, buttons1[4]);
            }
            else if (txt == "S")
            {
                buttons1[5] = !buttons1[5];
                if (buttons1[5])
                {
                    (sender as Button).BackColor = Color.LightGreen;
                }
                else
                {
                    (sender as Button).BackColor = Color.LightCoral;
                }
                state.UpdateButton(Enums.Button.S, buttons1[5]);
            }
            else if (txt == "L")
            {
                buttons1[6] = !buttons1[6];
                if (buttons1[6])
                {
                    (sender as Button).BackColor = Color.LightGreen;
                }
                else
                {
                    (sender as Button).BackColor = Color.LightCoral;
                }
                state.UpdateButton(Enums.Button.L, buttons1[6]);
            }
            else if (txt == "R")
            {
                buttons1[7] = !buttons1[7];
                if (buttons1[7])
                {
                    (sender as Button).BackColor = Color.LightGreen;
                }
                else
                {
                    (sender as Button).BackColor = Color.LightCoral;
                }
                state.UpdateButton(Enums.Button.R, buttons1[7]);
            }
            else if (txt == "D-U")
            {
                buttons2[0] = !buttons2[0];
                if (buttons2[0])
                {
                    (sender as Button).BackColor = Color.LightGreen;
                }
                else
                {
                    (sender as Button).BackColor = Color.LightCoral;
                }
                state.UpdateButton(Enums.Button.DU, buttons2[0]);
            }
            else if (txt == "D-L")
            {
                buttons2[1] = !buttons2[1];
                if (buttons2[1])
                {
                    (sender as Button).BackColor = Color.LightGreen;
                }
                else
                {
                    (sender as Button).BackColor = Color.LightCoral;
                }
                state.UpdateButton(Enums.Button.DL, buttons2[1]);
            }
            else if (txt == "D-D")
            {
                buttons2[2] = !buttons2[2];
                if (buttons2[2])
                {
                    (sender as Button).BackColor = Color.LightGreen;
                }
                else
                {
                    (sender as Button).BackColor = Color.LightCoral;
                }
                state.UpdateButton(Enums.Button.DD, buttons2[2]);
            }
            else if (txt == "D-R")
            {
                buttons2[3] = !buttons2[3];
                if (buttons2[3])
                {
                    (sender as Button).BackColor = Color.LightGreen;
                }
                else
                {
                    (sender as Button).BackColor = Color.LightCoral;
                }
                state.UpdateButton(Enums.Button.DR, buttons2[3]);
            }
            else if (txt == "C-U")
            {
                buttons2[4] = !buttons2[4];
                if (buttons2[4])
                {
                    (sender as Button).BackColor = Color.LightGreen;
                }
                else
                {
                    (sender as Button).BackColor = Color.LightCoral;
                }
                state.UpdateButton(Enums.Button.CU, buttons2[4]);
            }
            else if (txt == "C-L")
            {
                buttons2[5] = !buttons2[5];
                if (buttons2[5])
                {
                    (sender as Button).BackColor = Color.LightGreen;
                }
                else
                {
                    (sender as Button).BackColor = Color.LightCoral;
                }
                state.UpdateButton(Enums.Button.CL, buttons2[5]);
            }
            else if (txt == "C-D")
            {
                buttons2[6] = !buttons2[6];
                if (buttons2[6])
                {
                    (sender as Button).BackColor = Color.LightGreen;
                }
                else
                {
                    (sender as Button).BackColor = Color.LightCoral;
                }
                state.UpdateButton(Enums.Button.CD, buttons2[6]);
            }
            else if (txt == "C-R")
            {
                buttons2[7] = !buttons2[7];
                if (buttons2[7])
                {
                    (sender as Button).BackColor = Color.LightGreen;
                }
                else
                {
                    (sender as Button).BackColor = Color.LightCoral;
                }
                state.UpdateButton(Enums.Button.CR, buttons2[7]);
            }

            UpdateForm();
        }

        private void trackBarT1_Scroll(object sender, EventArgs e)
        {
            state.UpdateAxis(Enums.Axis.trigL, (byte)numericUpDownTX.Value);
            UpdateForm();
        }

        private void trackBarT2_Scroll(object sender, EventArgs e)
        {
            state.UpdateAxis(Enums.Axis.trigR, (byte)numericUpDownTY.Value);
            UpdateForm();
        }

        private void trackBarX_Scroll(object sender, EventArgs e)
        {
            state.UpdateAxis(Enums.Axis.X, (byte)numericUpDownSX.Value);
            UpdateForm();
        }

        private void trackBarY_Scroll(object sender, EventArgs e)
        {
            state.UpdateAxis(Enums.Axis.Y, (byte)numericUpDownSY.Value);
            UpdateForm();
        }

        private void trackBarCX_Scroll(object sender, EventArgs e)
        {
            state.UpdateAxis(Enums.Axis.cX, (byte)numericUpDownCX.Value);
            UpdateForm();
        }

        private void trackBarCY_Scroll(object sender, EventArgs e)
        {
            state.UpdateAxis(Enums.Axis.cY, (byte)numericUpDownCY.Value);
            UpdateForm();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (!SerialController.portOpen)
            {
                MessageBox.Show("Press \"start\" first!");
                return;
            }
            OutputController.SendStateToSerial(state);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OutputController.queue.Enqueue("<o>");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OutputController.queue.Enqueue("<m" + numericUpDownMode.Value.ToString() + ">");
        }
    }
}
