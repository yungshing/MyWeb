using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

    public class StringHash
    {
        static public uint String_To_Long(byte[] s) //pass
        {
            return (uint)(s[0] + ((s[1] + ((s[2] + (s[3] << 8)) << 8)) << 8));
        }

        public static void T1(ref uint A, ref uint B, ref uint C) //pass
        {
            A = ((C) >> 13) ^ ((A) - (B) - (C));
            B = ((A) << 8) ^ ((B) - (C) - (A));
            C = ((B) >> 13) ^ ((C) - (A) - (B));
            A = ((C) >> 12) ^ ((A) - (B) - (C));
            B = ((A) << 16) ^ ((B) - (C) - (A));
            C = ((B) >> 5) ^ ((C) - (A) - (B));
            A = ((C) >> 3) ^ ((A) - (B) - (C));
            B = ((A) << 10) ^ ((B) - (C) - (A));
            C = ((B) >> 15) ^ ((C) - (A) - (B));
        }
        public static uint StringHashImpl(byte[] str, int size) //pass
        {
            uint len = (uint)size;
            uint A = 0x9E3779B9;
            uint B = 0x9E3779B9;
            uint C = 0;

            while (len >= 12)
            {
                A += String_To_Long(str);
                var v = new byte[str.Length - 4];
                Array.Copy(str, 4, v, 0, v.Length);
                B += String_To_Long(v);
                v = new byte[str.Length - 8];
                Array.Copy(str, 8, v, 0, v.Length);
                C += String_To_Long(v);

                T1(ref A, ref B, ref C);
                var st = new List<byte>(str);
                st.RemoveRange(0, 12);
                str = st.ToArray();
                len -= 12;
            }
            C += (uint)size;

            switch (len)
            {
                case 11: C += (uint)str[10] << 24; goto case 10;
                case 10: C += (uint)str[9] << 16; goto case 9;
                case 9: C += (uint)str[8] << 8; goto case 8;
                case 8: B += (uint)str[7] << 24; goto case 7;
                case 7: B += (uint)str[6] << 16; goto case 6;
                case 6: B += (uint)str[5] << 8; goto case 5;
                case 5: B += str[4]; goto case 4;
                case 4: A += (uint)str[3] << 24; goto case 3;
                case 3: A += (uint)str[2] << 16; goto case 2;
                case 2: A += (uint)str[1] << 8; goto case 1;
                case 1:
                    A += (uint)str[0];
                    break;
                default:
                    break;
            }

            T1(ref A, ref B, ref C);
            return C;
        }

        public static int GetStringHash(string str)
        {
            str = str.Replace("/", "\\");
            str = str.ToUpper();
            //var v = Encoding.GetEncoding("GBK").GetBytes(str);
            //var c = Encoding.GetEncoding("GBK").GetChars(v);
            var v = Encoding.UTF8.GetBytes(str);
            return (int)StringHashImpl(v, v.Length);
        }
    }
    public enum VIP
    {
        Null = 0,
        VIP1,
        VIP2,
        VIP3,
        VIP4,
        VIP5,
        VIP6,
        VIP7,
        VIP8,
    }
    public enum GameList
    {
        Null = 0,
        AoZhanXiangYang,
    }