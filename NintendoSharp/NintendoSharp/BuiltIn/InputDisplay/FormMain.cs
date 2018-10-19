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

namespace NintendoSharp.BuiltIn.InputDisplay
{
    public partial class FormMain : Form
    {
        Color colorEnabled = Color.SeaGreen;
        Color colorDisabled = Color.Coral;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            byte[] inputArray = { 0, 0, 128, 128, 128, 128, 0, 0 };
            SetButtonsFromByteArray(inputArray);
        }

        public void SetButtonsFromByteArray(byte[] inputByteArray)
        {
            BitArray buttons1 = new BitArray(new byte[] { inputByteArray[0] });
            BitArray buttons2 = new BitArray(new byte[] { inputByteArray[1] });

            if (buttons1[0])
            {
                panelb1.BackColor = colorEnabled;
            }
            else
            {
                panelb1.BackColor = colorDisabled;
            }

            if (buttons1[1])
            {
                panelb2.BackColor = colorEnabled;
            }
            else
            {
                panelb2.BackColor = colorDisabled;
            }

            if (buttons1[2])
            {
                panelb3.BackColor = colorEnabled;
            }
            else
            {
                panelb3.BackColor = colorDisabled;
            }

            if (buttons1[3])
            {
                panelb4.BackColor = colorEnabled;
            }
            else
            {
                panelb4.BackColor = colorDisabled;
            }

            if (buttons1[4])
            {
                panelb5.BackColor = colorEnabled;
            }
            else
            {
                panelb5.BackColor = colorDisabled;
            }

            if (buttons1[5])
            {
                panelb6.BackColor = colorEnabled;
            }
            else
            {
                panelb6.BackColor = colorDisabled;
            }

            if (buttons1[6])
            {
                panelb7.BackColor = colorEnabled;
            }
            else
            {
                panelb7.BackColor = colorDisabled;
            }

            if (buttons1[7])
            {
                panelb8.BackColor = colorEnabled;
            }
            else
            {
                panelb8.BackColor = colorDisabled;
            }

            if (buttons2[0])
            {
                panelb9.BackColor = colorEnabled;
            }
            else
            {
                panelb9.BackColor = colorDisabled;
            }

            if (buttons2[1])
            {
                panelb10.BackColor = colorEnabled;
            }
            else
            {
                panelb10.BackColor = colorDisabled;
            }

            if (buttons2[2])
            {
                panelb11.BackColor = colorEnabled;
            }
            else
            {
                panelb11.BackColor = colorDisabled;
            }

            if (buttons2[3])
            {
                panelb12.BackColor = colorEnabled;
            }
            else
            {
                panelb12.BackColor = colorDisabled;
            }

            if (buttons2[4])
            {
                panelb13.BackColor = colorEnabled;
            }
            else
            {
                panelb13.BackColor = colorDisabled;
            }

            if (buttons2[5])
            {
                panelb14.BackColor = colorEnabled;
            }
            else
            {
                panelb14.BackColor = colorDisabled;
            }

            if (buttons2[6])
            {
                panelb15.BackColor = colorEnabled;
            }
            else
            {
                panelb15.BackColor = colorDisabled;
            }

            if (buttons2[7])
            {
                panelb16.BackColor = colorEnabled;
            }
            else
            {
                panelb16.BackColor = colorDisabled;
            }

            pictureBoxStickL.Location = new Point(((int)inputByteArray[2])-16, ((int)inputByteArray[3])-16);
            pictureBoxStickR.Location = new Point(((int)inputByteArray[4])-16, ((int)inputByteArray[5])-16);
            progressBarTriggerL.Value = (int)inputByteArray[6];
            progressBarTriggerR.Value = (int)inputByteArray[7];
        }

        private void buttonEnable_Click(object sender, EventArgs e)
        {
            IO.OutputController.queue.Enqueue("<m" + numericUpDownModeEnable.Value.ToString() + ">");
        }

        private void buttonDisable_Click(object sender, EventArgs e)
        {
            IO.OutputController.queue.Enqueue("<m" + numericUpDownModeDisable.Value.ToString() + ">");
        }
    }
}
