/*
Syntactic sugar is the ability to write cleaner code allowing it to be more clear and concise to the reviewer. 
This is enabled by overloaded classes who remove the need to pass already known values as parameters in a method.


*/
using System;

namespace ex2c
{
    class Program
    {
        static void Main()
        {
            enlistedRankParam("Sgt",5);
            enlistedRankOverload("PVT");
        }

        public static void enlistedRankParam(string rank, int payGrade)
        {
            Console.WriteLine($"The rank {rank} equals E-{payGrade}");
        }

        public static void enlistedRankOverload(string rank = "PVT", int payGrade = 1)
        {
            Console.WriteLine($"The rank {rank} equals E-{payGrade}");
        }
    }
}
