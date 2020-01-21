<<<<<<< HEAD
﻿//using System;
=======
﻿using System;
using System.Text;
using System.Text.RegularExpressions; //Ex.3.3
>>>>>>> 711203e6f9c3cc37a03b07769c455835b9fbcb83

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
<<<<<<< HEAD
            System.Console.WriteLine("Party on, dude!");
=======
            Console.WriteLine("Hello World!");
            //Ex.1.1
            int myInt = 1; //Ex.1.3
            Console.WriteLine(myInt);
            //Ex.1.2 This pasted portion of the does not run because no value is assigned to the variable myInt
            //Ex.1.4
            float myFloat;
            //float myFloat = 0.42f;
            bool myBoolean = true;
            string myName = "John";
            char myChar = 'a';
            //Ex.1.5 This pasted portion does not run since the variable myFloat is already initialized in the previous line
            //Ex.2.1
            double d = 5673.74;
            int i;
            // cast double to int.
            i = (int)d;
            Console.WriteLine(i);
            //Ex.2.2 When run, these lines change the previously declared double to an integer
            //Ex.2.3 When changing the variable 'd' from double to int, the application fails to compile since the assigned value is of type double
            //Ex.2.4 
            string userEnteredValue = "542.12"; //Ex.2.5
            //Ex.2.6 
            double flightCost = Convert.ToDouble(userEnteredValue);
            //Ex.2.7
            Console.WriteLine(flightCost);
            //Ex.2.8 using Convert.ToDouble produced the expected result because the ingested string was formatted as a double.
            
            //Ex.3.1
            StringBuilder address = new StringBuilder();
            address.Append("8150");
            address.Append(", Marne Road");
            address.Append(", Ft Benning, GA 31905");
            string concatenatedAddress = address.ToString();
            Console.WriteLine(concatenatedAddress);
            //Ex.3.2 This pasted portion of code does not run because the Method Stringbuilder does not exist within the namespace of System. System.Text must be used
            //Ex.3.4
            Regex rx = new Regex(@"\b(?<word>\w+)\s+(\k<word>)\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            string smtText = "The Cloud Apps Developer Program is a great great opportunity to start a new career career.";
            // Find match of duplicate of words.
            MatchCollection matches = rx.Matches(smtText);
            // Report the number of matches found.
            Console.WriteLine("{0} matches found in:\n {1}", matches.Count, smtText);
            //Ex.3.5 This pasted code counts all instances of duplicate words. In this case, we counted two instances of the words great and career repeated
>>>>>>> 711203e6f9c3cc37a03b07769c455835b9fbcb83
        }
    }
}
