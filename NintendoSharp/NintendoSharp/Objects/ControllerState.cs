using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using NintendoSharp.Constants;

namespace NintendoSharp.Objects
{
    public class ControllerState
    {
        BitArray buttons1;
        BitArray buttons2;

        public byte buttonByte1
        {
            get
            {
                return bitArrayToByte(buttons1);
            }
        }
        public byte buttonByte2
        {
            get
            {
                return bitArrayToByte(buttons2);
            }
        }

        public byte stickXByte;
        public byte stickYByte;
        public byte cStickXByte;
        public byte cStickYByte;
        public byte triggerByte1;
        public byte triggerByte2;

        public ushort buttonShort
        {
            get
            {
                return (ushort)(buttonByte1 + (buttonByte2 << 8));
            }
        }

        public ushort stickShort
        {
            get
            {
                return (ushort)(stickXByte + (stickYByte << 8));
            }
        }

        public ushort cStickShort
        {
            get
            {
                return (ushort)(cStickXByte + (cStickYByte << 8));
            }
        }

        public ushort triggerShort
        {
            get
            {
                return (ushort)(triggerByte1 + (triggerByte2 << 8));
            }
        }

        public ControllerState()
        {
            buttons1 = new BitArray(8, false);
            buttons2 = new BitArray(8, false);
            stickXByte = 128;
            stickYByte = 128;
            cStickXByte = 128;
            cStickYByte = 128;
            triggerByte1 = 0;
            triggerByte2 = 0;
        }

        byte bitArrayToByte(BitArray bits)
        {
            if (bits.Count != 8)
            {
                throw new ArgumentException("bits");
            }
            byte[] bytes = new byte[1];
            bits.CopyTo(bytes, 0);
            return bytes[0];
        }

        public void UpdateButton(Enums.Button button, bool pressed)
        {
            if (button == Enums.Button.A)
            {
                buttons1[0] = pressed;
            }
            else if (button == Enums.Button.B)
            {
                buttons1[1] = pressed;
            }
            else if (button == Enums.Button.X)
            {
                buttons1[2] = pressed;
            }
            else if (button == Enums.Button.Y)
            {
                buttons1[3] = pressed;
            }
            else if (button == Enums.Button.Z)
            {
                buttons1[4] = pressed;
            }
            else if (button == Enums.Button.S)
            {
                buttons1[5] = pressed;
            }
            else if (button == Enums.Button.L)
            {
                buttons1[6] = pressed;
            }
            else if (button == Enums.Button.R)
            {
                buttons1[7] = pressed;
            }
            else if (button == Enums.Button.DU)
            {
                buttons2[0] = pressed;
            }
            else if (button == Enums.Button.DL)
            {
                buttons2[1] = pressed;
            }
            else if (button == Enums.Button.DD)
            {
                buttons2[2] = pressed;
            }
            else if (button == Enums.Button.DR)
            {
                buttons2[3] = pressed;
            }
            else if (button == Enums.Button.CU)
            {
                buttons2[4] = pressed;
            }
            else if (button == Enums.Button.CL)
            {
                buttons2[5] = pressed;
            }
            else if (button == Enums.Button.CD)
            {
                buttons2[6] = pressed;
            }
            else if (button == Enums.Button.CR)
            {
                buttons2[7] = pressed;
            }
        }
        
        public void UpdateAxis(Enums.Axis axis, byte value)
        {
            if (axis == Enums.Axis.X)
            {
                stickXByte = value;
            }
            else if (axis == Enums.Axis.Y)
            {
                stickYByte = value;
            }
            else if (axis == Enums.Axis.cX)
            {
                cStickXByte = value;
            }
            else if (axis == Enums.Axis.cY)
            {
                cStickYByte = value;
            }
            else if (axis == Enums.Axis.trigL)
            {
                triggerByte1 = value;
            }
            else if (axis == Enums.Axis.trigR)
            {
                triggerByte2 = value;
            }
        }

        public string GetStateDifferences(ControllerState oldState)
        {
            string ret = "";

            if (oldState.buttonShort != this.buttonShort)
            {
                if (oldState.buttonByte1 == this.buttonByte1)
                {
                    ret += "<1" + this.buttonByte2.ToString() + ">";

                }
                else if (oldState.buttonByte2 == this.buttonByte2)
                {
                    ret += "<0" + this.buttonByte1.ToString() + ">";
                }
                else
                {
                    ret += "<b" + this.buttonShort.ToString() + ">";
                }
            }

            if (oldState.stickShort != this.stickShort)
            {
                if (oldState.stickXByte == this.stickXByte)
                {
                    ret += "<3" + this.stickYByte.ToString() + ">";
                }
                else if (oldState.stickYByte == this.stickYByte)
                {
                    ret += "<2" + this.stickXByte.ToString() + ">";
                }
                else
                {
                    ret += "<s" + this.stickShort.ToString() + ">";
                }
            }

            if (oldState.cStickShort != this.cStickShort)
            {
                if (oldState.cStickXByte == this.cStickXByte)
                {
                    ret += "<5" + this.cStickYByte.ToString() + ">";
                }
                else if (oldState.cStickYByte == this.cStickYByte)
                {
                    ret += "<4" + this.cStickXByte.ToString() + ">";
                }
                else
                {
                    ret += "<c" + this.cStickShort.ToString() + ">";
                }
            }

            if (oldState.triggerShort != this.triggerShort)
            {
                if (oldState.triggerByte1 == this.triggerByte1)
                {
                    ret += "<7" + this.triggerByte2.ToString() + ">";
                }
                else if (oldState.triggerByte2 == this.triggerByte2)
                {
                    ret += "<6" + this.triggerByte1.ToString() + ">";
                }
                else
                {
                    ret += "<t" + this.triggerShort.ToString() + ">";
                }
            }

            return ret;
        }
    }
}
