using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette
{
    class Roulette
    {
        public static short[][] RoulNums = new short[3][];
        Random bucket = new Random();
        public static int b = 0;
        public static int NumBuckets = 38;
        public static int col;


        public Roulette()
        {
            RoulNums[0] = new short[] { 0, 100 }; // green
            RoulNums[1] = new short[] { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 }; //red
            RoulNums[2] = new short[] { 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 }; //black
        }

        public static int Spin(Roulette r)
        {
            col = r.bucket.Next(0, 10000) % 3;
            int val = r.bucket.Next(0, 10000) % RoulNums[col].Length;
            return b = RoulNums[col][val];
        }
        public static int Getb() => Roulette.b;
        public static string EvenOdd() => b % 2 == 0 ? "Even" : "Odd";
        public static void Colors() => Console.WriteLine(string.Join(", ", Roulette.RoulNums[col]));
        public static string Halves() => b < 19 ? "1-18" : "19-36";

        public static string Dozens()
        {
            if (b == 0 || b == 100) return "That's not part of a dozen";
            else if (b <= 12) return "1,2,3,4,5,6,7,8,9,10,11,12";
            else if (b > 12 && b <= 24) return "13,14,15,16,17,18,19,20,21,22,23,24";
            else return "25,26,27,28,29,30,31,32,33,34,35,36";
        }
        public static void Columns()
        {
            if (b == 0 || b == 100) Console.WriteLine("That's not part of a column");
            int x = b % 3;
            int[] y = new int[12];
            for (int z = 0, i = x; i < Roulette.NumBuckets; z++, i += 3) y[z] = i;
            Console.WriteLine(string.Join(", ", y));
        }
        public static void Streets()
        {
            if (b == 0 || b == 100) Console.WriteLine("That's not part of a street");
            int x = b % 3;
            string result = "";
            if (x == 0) result = $"{b - 2},{b - 1},{b}";
            if (x == 1) result = $"{b},{b + 1},{b + 2}";
            if (x == 2) result = $"{b - 1},{b },{b + 1}";
            Console.WriteLine(result);
        }
        public static void SixNums()
        {
            if (b == 0 || b == 100) Console.WriteLine("That's not part of a set of 6");
            Streets();
            if (b < 3)
            {
                b += 3;
                Streets();
            }
            else if (b > 34)
            {
                b -= 3;
                Streets();
            }
            else
            {
                b += 3;
                Streets();
                b -= 6;
                Streets();
            }

        }
        public static void Splits()
        {
            int x = b % 3;
            if (b == 0 || b == 100) Console.WriteLine("0, 00");
            else if (b < 3)
            {
                if (x == 0) Console.WriteLine($"{b}/{b + 3}, {b}/{b - 1}");
                else if (x == 1) Console.WriteLine($"{b}/{b + 3}, {b}/{b + 1}");
                else Console.WriteLine($"{b}/{b + 3}, {b}/{b + 1},{b}/{b - 1}");
            }
            else if (b < 34)
            {
                if (x == 0) Console.WriteLine($"{b}/{b - 3}, {b}/{b + 3}, {b}/{b - 1}");
                else if (x == 1) Console.WriteLine($"{b}/{b - 3}, {b}/{b + 3}, {b}/{b + 1}");
                else Console.WriteLine($"{b}/{b - 3}, {b}/{b + 3}, {b}/{b + 1},{b}/{b - 1}");
            }
            else
            {
                if (x == 0) Console.WriteLine($"{b}/{b - 3}, {b}/{b - 1}");
                else if (x == 1) Console.WriteLine($"{b}/{b - 3}, {b}/{b + 1}");
                else Console.WriteLine($"{b}/{b - 3}, {b}/{b + 1},{b}/{b - 1}");
            }
        }
        public static void Corners()
        {
            string RightDown = $"{b},{b + 1},{b + 3},{b + 4}";
            string LeftDown = $"{b },{ b - 1},{ b + 2},{ b + 3}";
            string RightUp = $"{b},{b + 1},{b - 3},{b - 2}";
            string LeftUp = $"{b},{b - 1},{b - 3},{b - 4}";
            if (b == 0 || b == 100) Console.WriteLine("No corners here, bud");
            else if (b == 1) Console.WriteLine(RightDown);
            else if (b == 2) Console.WriteLine($"{RightDown} and {LeftDown}");
            else if (b == 3) Console.WriteLine($"{LeftDown}");
            else if (b == 34) Console.WriteLine($"{RightUp}");
            else if (b == 35) Console.WriteLine($"{RightUp} and {LeftUp} ");
            else if (b == 36) Console.WriteLine($"{RightDown}");
            else if (b%3 == 1) Console.WriteLine($"{RightDown} and {RightUp}");
            else if (b%3 == 2) Console.WriteLine($"{LeftDown} and {LeftUp} and {RightDown} and {RightUp}");
            else Console.WriteLine($"{LeftDown} and {LeftUp}");
        }
    }
}
