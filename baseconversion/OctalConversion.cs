using System;

namespace baseconversion

{
    class OctalConversion
    {
        public static string ConvertToBase2(string s)
        {
            string result="";
            for(int i = 0; i<s.Length;i++)
            {
                int t = int.Parse(s[i].ToString());
                result += DecimalConversion.ConvertToBase2(t);
            }
            return Util.NormalizeOctal(result);
        }
        public static string ConvertToBase10(string s)
        {
            int result = 0;
            for (int i = s.Length-1,p=0; i >= 0; i--,p++)
                {
                    int t = int.Parse(s[i].ToString());
                    result += (int)Math.Pow(8, p) * t;
                }
            return result.ToString();
        }
    }
}
