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

        bool a = false;
        bool b = false;
        bool x = false;
        bool y = false;
        bool z = false;
        bool s = false;
        bool l = false;
        bool r = false;
        bool cu = false;
        bool cl = false;
        bool cd = false;
        bool cr = false;
        int dv = 0;
        int dh = 0;
        int stickX = 128;
        int stickY = 128;
        int cStickX = 128;
        int cStickY = 128;
        int triggL = 0;
        int triggR = 0;

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
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            buttons1[0] = true;
            UpdateDisplays();
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            buttons1[0] = false;
            UpdateDisplays();
        }
    }
}
