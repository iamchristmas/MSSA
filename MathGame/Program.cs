using System;

namespace MathGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Output number of correct answers as well
            Flashcards flashcards = new Flashcards();
            Console.WriteLine("Welcome to Math Game, what kind of arithmetic would you like to practice?:");
            Console.WriteLine("1. Addition ");
            Console.WriteLine("2. Subtraction ");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("3. Division");
            Console.WriteLine("Enter Selection ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    flashcards.Addition();
                    break;
                case 2:
                    flashcards.Subtraction();
                    break;
                case 3:
                    flashcards.Multiplication();
                    break;
                case 4:
                    flashcards.Division();
                    break;
            }
            Console.WriteLine($"Congrats, you scored {flashcards.Score}");
        }
    }
}
