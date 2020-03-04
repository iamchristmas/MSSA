using System;

namespace Roulette
{
    class Program
    {
        static void Main(string[] args)
        {
            Roulette r = new Roulette();
            Console.Write("Please pick a bet type by the corresponding value..And I assure, We did not implement any validation: \n"
                + "0) Bucket \n" 
                + "1) Even or Odd \n" 
                + "2) Colors \n" 
                + "3) Big or small value Bucket \n" 
                + "4) Dozens \n" 
                + "5) Columns \n" 
                + "6) Streets \n" 
                + "7) 6 Numbers \n" 
                + "8) Splits \n" 
                + "9) Corners \n" );
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine("Spinning........");
            Roulette.Spin(r);
            BetChoice(choice);
            Console.WriteLine($"You landed on {Roulette.b}");
        }
        public static void BetChoice(int x)
        {
            switch (x)
            {
                case 0:
                    Console.WriteLine(Roulette.Getb());
                    break;
                case 1:
                    Console.WriteLine($"{Roulette.EvenOdd()}");
                    break;
                case 2:
                    Roulette.Colors();
                    break;
                case 3:
                    Console.WriteLine(Roulette.Halves());
                    break;
                case 4:
                    Console.WriteLine(Roulette.Dozens());
                    break;
                case 5:
                    Roulette.Columns();
                    break;
                case 6:
                    Roulette.Streets();
                    break;
                case 7:
                    Roulette.SixNums();
                    break;
                case 8:
                    Roulette.Splits();
                    break;
                case 9:
                    Roulette.Corners();
                    break;
            }
        }
    }
}
