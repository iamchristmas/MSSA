using System;

namespace baseconversion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DecimalConversion.ConvertToBase8(420));
            Console.WriteLine(DecimalConversion.ConvertToBase2(420));
            Console.WriteLine(BinaryConversion.ConvertToBase10("111111111111111111"));
            Console.WriteLine(BinaryConversion.ConvertToBase8("111111111111111111"));
            Console.WriteLine(OctalConversion.ConvertToBase2("345"));
            Console.WriteLine(OctalConversion.ConvertToBase10("345"));
        }
    }
}
