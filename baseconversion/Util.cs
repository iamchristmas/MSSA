using System;
using System.Collections.Generic;
using System.Text;

namespace baseconversion

{
    class Util
    {
        public static string ReverseString(string s)
        {
            string OutString = "";
            for (int i = s.Length - 1; i >= 0; i--)
            {
                OutString += s[i];
            }
            return OutString;
        }
        public static string NormalizeOctal(string s)
        {
            if (s.Length % 3 != 0) return s.PadLeft(s.Length + (3 - (s.Length % 3)), '0');
            return s;
        }
    }
}
