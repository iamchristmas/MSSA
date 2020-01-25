/*

    xxx1 Create a function which, given an instance of a System.Random object as a parameter, returns a tuple of two uniformly distributed random floating point numbers between 0 and 1.
    xxx2 Create a function which takes two doubles called x and y and returns a double corresponding to the hypotenuse of a triangle with sides of lengths x, y.
    xxx3 Build a Main method which takes one int parameter (which we'll call "iterations") from the command line.
    xxx4 Iterate iterations times. For each iteration, you should:
        generate a new x, y pair,
        take the hypotenuse of the pair, and
        increment a counter for each coordinate which overlaps the unit circle
    xxx5 Divide the number of coordinate pairs overlapping the unit circle by the total number of iterations. Multiply the resulting value by 4.
    6 Print the value from step #5 along with the absolute value of the difference between your estimate of and the library-provided value of LaTeX: \pi π π, Math.PI.
    7 Run your program, passing 10, 100, 1000, and 10000 as the command line parameter. Record the output of your program as comments in your source file.

Result of estimate = 2.4. DIfference between estimate and Pi is 0.7415926535897932. Iterate 10
Result of estimate = 3.24. DIfference between estimate and Pi is 0.0984073464102071. Iterate 100
Result of estimate = 3.256. DIfference between estimate and Pi is 0.11440734641020667. Iterate 1000
Result of estimate = 3.1704. DIfference between estimate and Pi is 0.02880734641020677. Iterate 10000
Result of estimate = 3.139796. DIfference between estimate and Pi is 0.0017966535897930846. Iterate 1000000  

 
    Why do we multiply the value from step 5 above by 4? Because two lines make up any given point and given that 2 points will lie within or outside of the circle, we must take the average of those four points.
    What do you observe in the output when running your program with parameters of increasing size? The level of precision of our estimate increases.
    If you run the program multiple times with the same parameter, does the output remain the same? Why or why not?
    Find a parameter that requires multiple seconds of run time. What is that parameter? 1000000
    How accurate is the estimated value of pi? +/- .1
    Research one other use of Monte-Carlo methods. Record it in your exercise submission and be prepared to discuss it in class.
        Wireless communication systems often rely on Monte-Carlo methods for simulating potential interference between a sending and receiving station.
 
 
 
 */
using System;

namespace lab2c
{
    class Program
    {
        private static void Main(string[] args) 
        {
            Console.Write("How many times would you like to run this?");
            string str = Console.ReadLine();
            double arg = double.Parse(str);
            double pairs = (unitCircleArea(arg) / arg) * 4;
            double diff = Math.Abs(pairs - Math.PI);
            Console.WriteLine($"Result of estimate = {pairs}. DIfference between estimate and Pi is {diff}. Iterate {arg}");
        }

        private static int unitCircleArea(double arg)
        {
            int count = 0;
            for (int i = 0; i < arg; i++)
            {
                double rand1 = getRandom();
                double rand2 = getRandom();
                if (hypotenuse(rand1, rand2) <= 1) count++;
            }
            return count;
        }

        private static (float, float) genFloat(double r1, double r2)
        {
            float float1 = (float)r1;
            float float2 = (float)r2;
            return (float1, float2);
        }


        private static double hypotenuse(double x,double y)
        {
            double z = Math.Sqrt((Math.Pow(x, 2)) + (Math.Pow(y, 2)));
            return z;
        }

        private static double getRandom()
        {
            var r = new Random();
            double random = r.NextDouble();
            return random;
        }

    }
}
