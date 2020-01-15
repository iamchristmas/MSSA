using System;

namespace MathematicalFormulas
{
    class Program
    {
        static void Main(string[] args)
        {
            // Part 1
            // Partially worked example
            Console.WriteLine("\nPart 1, circumference and area of a circle.");
            Console.Write("Enter an integer for the radius: ");
            string strradius = Console.ReadLine();
            int intradius = int.Parse(strradius);
            double circumference = 2 * Math.PI * intradius;
            Console.WriteLine($"The circumference is {circumference}");

            // Implementation for area here
            double area = Math.PI * Math.Pow(intradius,2);
            Console.WriteLine($"The area is {area}");


            //// Part 2
            Console.WriteLine("\nPart 2, volume of a hemisphere.");
            Console.Write("Enter an integer for the radius of the Hemisphere");
            string strHemRadius = Console.ReadLine();
            int intHemRadius = int.Parse(strHemRadius);
            double volume = (2.0 / 3.0) * Math.PI * Math.Pow(intHemRadius, 3);
            Console.WriteLine($"The volume is {volume}");


            //// Part 3
            //Console.WriteLine("\nPart 3, area of a triangle (Heron's formula).");

            //// Implementation here

            //Console.WriteLine($"The area is {area}");


            //// Part 4
            //Console.WriteLine("\nPart 4, solving a quadratic equation.");

            //// Implementation here

            //Console.WriteLine($"The positive solution is {positive_num / denominator}");
            //Console.WriteLine($"The negative solution is {negative_num / denominator}");
        }
    }
}
