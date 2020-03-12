using System;
using System.IO;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            string test = Environment.GetEnvironmentVariable("APIKEY");
            Console.WriteLine(test);
            
        }
    }
}
