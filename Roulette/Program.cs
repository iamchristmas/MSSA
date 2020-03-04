using System;

namespace Roulette
{
    class Program
    {
        static void Main(string[] args)
        {
            Roulette r = new Roulette();
            for (int i = 0; i < 100; i++) Console.WriteLine(Roulette.Spin(r));
        }
    }
}
