using System;

namespace fibonnaci
{
    class fibonacci
    {
        static void Main(string[] args)
        {
            fibonacciSequence(0, 1);
        }
        private static void fibonacciSequence(double x,double y, int count = 0)
        {
            if (count <= 40) {fibonacciSequence(y, x+y, ++count);}
            else{Console.WriteLine($"the solution is {(x + y) / y}");}
            return;
        }
    }
}
