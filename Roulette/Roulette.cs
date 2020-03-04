using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette
{
    enum colors : short { red, black, green };

    class Roulette
    {
        public short[][] RoulNums = new short[3][];
        Random bucket = new Random();
        public static int BucketVal = 0;
        public static int NumBuckets = 38;

        public Roulette() 
        {
            RoulNums[0] = new short[] { 0, 100 }; // green
            RoulNums[1] = new short[] { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 }; //red
            RoulNums[2] = new short[] { 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 }; //black
        }

        public static int Spin(Roulette r)
        {
            int col = r.bucket.Next(0, 10000) % 3;
            int val = r.bucket.Next(0, 10000) % r.RoulNums[col].Length;
            return BucketVal = r.RoulNums[col][val];
        }
        public int GetBucketVal() => Roulette.BucketVal;

        public static string Halves( int BucketVal ) => BucketVal < 19 ? "1-18" : "19-36";
        public static string EvenOdd(int BucketVal) => BucketVal % 2 == 0 ? "Even" : "Odd";
        public static string Dozens(int BucketVal)
        {
            if (BucketVal <= 12) return "1,2,3,4,5,6,7,8,9,10,11,12";
            else if (BucketVal > 12 && BucketVal <= 24) return "13,14,15,16,17,18,19,20,21,22,23,24";
            else return "25,26,27,28,29,30,31,32,33,34,35,36";
        }
        public static void Columns(int BucketVal)
        {
            int x = BucketVal % 3;
            int[] y = new int[12];
            for (int z = 0, i = 0; i < Roulette.NumBuckets; z++, i += 3) y[z] = i;
            Console.WriteLine(string.Join(", ", 7));
        }
        public static void Streets(int BucketVal)
        {
            int x = BucketVal % 3;
            string result = "";
            if (x == 0) result = $"{BucketVal - 2},{BucketVal - 1},{BucketVal}";
            if (x == 1) result = $"{BucketVal},{BucketVal+1},{BucketVal+2}";
            if (x == 2) result = $"{BucketVal -1},{BucketVal },{BucketVal + 1}";
            Console.WriteLine(result);
        }
        public static void Splits(int BucketVal)
        {
            int x = BucketVal % 3;
            if ()
            if (BucketVal < 34)
            {
                if (x == 0)
                {
                Console.WriteLine($"{BucketVal}/{BucketVal - 3}, {BucketVal}/{BucketVal + 3}," +
                    $"{BucketVal}/{BucketVal - 1}");
                }
                else if (x == 1)
                {
                    Console.WriteLine($"{BucketVal}/{BucketVal - 3}, {BucketVal}/{BucketVal + 3}," +
                        $"{BucketVal}/{BucketVal + 1}");
                }
                else
                {
                    Console.WriteLine($"{BucketVal}/{BucketVal - 3}, {BucketVal}/{BucketVal + 3}" +
                        $"{BucketVal}/{BucketVal + 1},{BucketVal}/{BucketVal - 1}");
                }
            }

        }
    }
}
