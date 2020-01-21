using System;
using System.Linq;

namespace ex2a
{
    class Program
    {
        static void Main(string[] args)
        {
            (new Program()).run();
        }

        void run()
        {
            ////Ex 2a.1 Find average of 10 values between 0 and 100
            //int[] sumOfArray = populateArray();
            //int sum = sumOfArray.Sum();
            //Console.WriteLine($"The sum of all of the values you have entered is {sum}");
            ////Ex 2a.2 Find average of 10 values between 0 and 100
            //int[] averageOfArray = populateArray();
            //double average = averageOfArray.Average();
            //Console.WriteLine($"The average of all of the values you have entered is {average}");
            //Ex 2a.3 Find average of arbitrary set of values between 0 and 100
            Console.Write("How many grades are you averaging? ");
            string strOfGrades = Console.ReadLine();
            int intOfGrades = int.Parse(strOfGrades);
            int[] classScores = populateArray(intOfGrades);
            double classAverage = classScores.Average();
            char charAverage = averageToLetter(classAverage);
            Console.WriteLine($"The clas average is {classAverage} .The letter grade average is {charAverage}");


        }

        private char averageToLetter(double classAverage)
        {
            char letterGrade;
            if (classAverage >= 100)
            {
                letterGrade = 'A';
            }
            else if (classAverage >= 80 && classAverage < 90)
            {
                letterGrade = 'B';
            }
            else if (classAverage >= 70 && classAverage < 80)
            {
                letterGrade = 'C';
            }
            else if (classAverage >= 60 && classAverage < 70)
            {
                letterGrade = 'D';
            }
            else
            {
                letterGrade = 'F';                
            }
            return letterGrade;
        }
        


        private int[] populateArray(int size = 10)
        {
            int[] values = new int[size];
            for (int runs = 0; runs < size;runs ++)
            {
                Console.Write("Please enter a value between 1 and 100: ");
                string newValue = Console.ReadLine();
                int valueToAdd = int.Parse(newValue);
                checkValue(valueToAdd);
                values[runs] = valueToAdd;
            }
            return values;
        }
        
        private int checkValue(int value)
        {
            if (value < 0 || value > 100)
            {
                int newValueForOp = value;
                do
                {
                    Console.Write($"The value {value} is not within specified parameters. Please pick a number between 1 and 100: ");
                    string newValue = Console.ReadLine();
                    newValueForOp = int.Parse(newValue);
                } while (newValueForOp < 1 || newValueForOp > 100);
                return newValueForOp;
            }
            else
            {
                return value;
            }
        }
        
    }
}
