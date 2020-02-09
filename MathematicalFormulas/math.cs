using System;

namespace MathematicalFormulas
{
    class math
    {
        static void Main(string[] args)
        {
            // Part 1
            Console.WriteLine("\nPart 1, circumference and area of a circle.");
            Console.Write("Enter an integer for the radius: ");
            string strradius = Console.ReadLine();
            int intradius = int.Parse(strradius);
            double circumference = 2 * Math.PI * intradius;
            Console.WriteLine($"The circumference is {circumference}");

            // Implementation for area here
            double area = Math.PI * Math.Pow(intradius, 2);
            Console.WriteLine($"The area is {area}");


            //// Part 2
            Console.WriteLine("\nPart 2, volume of a hemisphere.");
            Console.Write("Enter an integer for the radius of the Hemisphere: ");
            string strHemRadius = Console.ReadLine();
            int intHemRadius = int.Parse(strHemRadius);
            double volume = (2.0 / 3.0) * Math.PI * Math.Pow(intHemRadius, 3);
            Console.WriteLine($"The volume is {volume}");


            //// Part 3
            Console.WriteLine("\nPart 3, area of a triangle (Heron's formula).");
            Console.WriteLine("\nEnter an integer for each of the three sides:");
            Console.Write("Side A: ");
            string strSideA = Console.ReadLine();
            Console.Write("Side B: ");
            string strSideB = Console.ReadLine();
            Console.Write("Side C: ");
            string strSideC = Console.ReadLine();
            double dblSideA = double.Parse(strSideA);
            double dblSideB = double.Parse(strSideB);
            double dblSideC = double.Parse(strSideC);
            //Find half of the circumference
            double halfCirc = (dblSideA + dblSideB + dblSideB) / 2;

            double areaTriangle = Math.Sqrt(halfCirc * (halfCirc - dblSideA) * (halfCirc - dblSideB) * (halfCirc - dblSideC));
            Console.WriteLine($"The area is {areaTriangle}");

            // Part 4
            Console.WriteLine("\nPart 4, solving a quadratic equation.");
            Console.WriteLine("\nEnter an integer for the a, b,and c values: ");
            Console.Write("Value A: ");
            string strValueA = Console.ReadLine();
            Console.Write("Value B: ");
            string strValueB = Console.ReadLine();
            Console.Write("Value C: ");
            string strValueC = Console.ReadLine();
            
            //Convert strings to integers 
            int intValueA = int.Parse(strValueA);         
            int intValueB = int.Parse(strValueB);
            int intValueC = int.Parse(strValueC);

            double dblToSquare = Math.Pow(intValueB, 2.0) - (4.0 * intValueA * intValueC);
            if (dblToSquare < 0)
            {
                Console.WriteLine("The values supplied are not viable solutions.");
                return;
            }
            else
            {
                double positive_num = (-intValueB) + (Math.Sqrt(dblToSquare));
                double negative_num = (-intValueB) - (Math.Sqrt(dblToSquare));
                double denominator = 2.0 * intValueA;
                Console.WriteLine($"The positive solution is {positive_num / denominator}");
                Console.WriteLine($"The negative solution is {negative_num / denominator}");
            }
        }
    }
}
