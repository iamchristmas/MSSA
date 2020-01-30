using System;
using System.Linq;
using System.Collections.Generic;

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
            //Ex 2a.1 Find sum of 10 values between 0 and 100
            int[] sumOfArray = populateArray();
            int sum = sumOfArray.Sum();
            Console.WriteLine($"The sum of all of the values you have entered is {sum}");
            
            //Ex 2a.2 Find average of 10 values between 0 and 100
            int[] averageOfArray = populateArray();
            double average = averageOfArray.Average();
            Console.WriteLine($"The average of all of the values you have entered is {average}");
            
            //Ex 2a.3 Find average of decalred set of values between 0 and 100
            Console.Write("How many grades are you averaging? ");
            string strOfGrades = Console.ReadLine();
            int intOfGrades = int.Parse(strOfGrades);
            int[] classScores = populateArray(intOfGrades);
            double classAverage = classScores.Average();
            averageToLetter(classAverage);
            Console.WriteLine($"The clas average is {classAverage} .");
            
            //Ex 2a.4 Find average of arbitrary set of values between 0 and 100
            int[] unkLengthClassScores = populateUnkLength();
            double bigClassAverage = unkLengthClassScores.Average();
            Console.WriteLine($"The class average is {bigClassAverage} ");
            averageToLetter(bigClassAverage);


        }

        private void averageToLetter(double classAverage)
        {
            switch(classAverage)
            {
                case double n when n >= 90:
                    Console.WriteLine("The letter grade average is A");
                    break;
                case double n when n >= 80 && n < 90:
                    Console.WriteLine("The letter grade average is B");
                    break;
                case double n when n >= 70 && n < 80:
                    Console.WriteLine("The letter grade average is C");
                    break;
                case double n when n >= 60 && n < 70:
                    Console.WriteLine("The letter grade average is D");
                    break;
                case double n when n < 60:
                    Console.WriteLine("The letter grade average is F");
                    break;
            }

            return;
        }

        private int[] populateUnkLength()
        {
            List<int> values = new List<int>();
            string newValue;
            int[] grades = { };
            bool validString = true;
            {
                Console.Write("Please enter a value between 1 and 100 then enter a blank line to finish inputting grades: ");
                newValue = Console.ReadLine();
                validString = checkString(newValue);
                if (validString == false){ grades = values.ToArray();}
                else
                {
                    int valueToAdd = int.Parse(newValue);
                    checkValue(valueToAdd);
                    values.Add(valueToAdd);
                }
            }
            return grades;
        }

        private bool checkString(string stringToCheck)
        {
            bool valid = false;
            int checkedInt;
                try
                {
                    checkedInt = int.Parse(stringToCheck);
                    valid = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("This is an invalid value.");
                    valid = false;
                }
            return valid;
        }

        private int[] populateArray(int size = 10)
        {
            int[] values = new int[size];
            for (int i = 0; i < size;i ++)
            {
                int valueToAdd = getValue();
                values[i] = valueToAdd;
            }
            return values;
        }
        public int getValue()
        {
            Console.Write("Please enter a value between 1 and 100: ");
            string newValue = Console.ReadLine();
            while (checkString(newValue) == false) getValue();
            int valueToAdd = int.Parse(newValue);
            checkValue(valueToAdd);
            return valueToAdd;
        }


        private int checkValue(int value)
        {
            if (value > 100)
            {
                int newValueForOp = value;
                do
                {
                    Console.Write($"The value {value} is not within specified parameters. Please pick a number between 1 and 100: ");
                    newValueForOp = getValue();
                } while (newValueForOp >= 100);
                return newValueForOp;
            }
            else
            {
                return value;
            }
        }
        
    }
}
