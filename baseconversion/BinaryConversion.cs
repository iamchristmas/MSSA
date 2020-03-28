using System;
using System.Collections.Generic;
using System.Text;

namespace baseconversion
{
    class BinaryConversion
    {   
        public static string ConvertToBase8(string s)
        {
            string result = "";
            s = Util.NormalizeOctal(s);
            for(int i = 0; i < s.Length; i+=3)
                {
                    int p = 0;
                    for(int k = i+2, l = 0; k >= i;k--,l++)
                    {
                        if (s[k] == '1') p += (int)Math.Pow(2, l);
                    }
                result += p.ToString();
                }
            return result;
        }
        public static string ConvertToBase10(string s)
        {
            int result = 0;
            for(int i = 0; i <s.Length;i++)
            {
                if (s[i] == '1') result += (int)Math.Pow(2, i);
            }
            return result.ToString();
        }
    }
}
