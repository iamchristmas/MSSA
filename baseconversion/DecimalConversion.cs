namespace baseconversion
{
    public class DecimalConversion
    {
        public static string ConvertToBase2(int i)
        {
            string result = "";
            while (i>0)
            {
                result += i % 2;
                i = i / 2;
            }
            return Util.ReverseString(result);
        }
        public static string ConvertToBase8(int i)
        {
            string result = "";
            while (i > 0)
            {
                result += i % 8;
                i = i / 8;
            }
            return Util.ReverseString(result);
        }
    }
}
