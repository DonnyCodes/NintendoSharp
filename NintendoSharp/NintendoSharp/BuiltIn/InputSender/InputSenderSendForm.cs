using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NintendoSharp.BuiltIn.InputSender
{
    public partial class InputSenderSendForm : Form
    {
        int[] bytes = { 0, 0, 0, 0, 0, 0, 0, 0 };

        int[] shorts = { 0, 0, 0, 0 };

        bool a = false;//byte 1
        bool b = false;
        bool x = false;
        bool y = false;
        bool z = false;
        bool s = false;
        bool l = false;
        bool r = false;
        bool cu = false;//byte 2
        bool cl = false;
        bool cd = false;
        bool cr = false;
        bool du = false;
        bool dl = false;
        bool dd = false;
        bool dr = false;
        byte stickX = 128;
        byte stickY = 128;
        byte cStickX = 128;
        byte cStickY = 128;
        byte triggL = 0;
        byte triggR = 0;

        BitArray buttons1 = new BitArray(8,false);
        BitArray buttons2 = new BitArray(8, false);

        public InputSenderSendForm()
        {
            InitializeComponent();
        }

        private void InputSenderSendForm_Load(object sender, EventArgs e)
        {
            UpdateDisplays();
        }

        int BoolToInt(bool newBool)
        {
            if (newBool)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        byte ConvertToByte(BitArray bits)
        {
            if (bits.Count != 8)
            {
                throw new ArgumentException("bits");
            }
            byte[] bytes = new byte[1];
            bits.CopyTo(bytes, 0);
            return bytes[0];
        }

        public void UpdateDisplays()
        {
            numericUpDown1.Value = (decimal)ConvertToByte(buttons1);
            numericUpDown2.Value = (decimal)ConvertToByte(buttons2);
            numericUpDown9.Value = (decimal)shorts[0];
            numericUpDown10.Value = (decimal)shorts[1];
            numericUpDown11.Value = (decimal)shorts[2];
            numericUpDown12.Value = (decimal)shorts[3];
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

            }
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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
            }
            shorts[0] = (ushort)(ConvertToByte(buttons1) + (ConvertToByte(buttons2) << 8));
            shorts[1] = (ushort)(stickX + (stickY << 8));
            shorts[2] = (ushort)(cStickX + (cStickY << 8));
            shorts[3] = (ushort)(triggL + (triggR << 8));
            UpdateDisplays();
        }
    }
}
