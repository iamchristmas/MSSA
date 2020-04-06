using System;
using System.Collections.Generic;
using System.Text;

namespace MathGame
{
    class Flashcards
    {
        public int Score { get; set; }
        public int NumQuestions { get; set; }
        int minValue;
        int maxValue;
        Random r = new Random();

        public Flashcards()
        {
            NumQuestions = 4;
            minValue = 1;
            maxValue = 12;
        }
        public Flashcards(int questions, int min, int max)
        {
            NumQuestions = questions;
            minValue = min;
            maxValue = max;
        }

        public int Addition()
        {
            int correct = NumQuestions;
            for (int i = 1; i <= NumQuestions; i++)
            {
                int val1 = r.Next(minValue, maxValue);
                int val2 = r.Next(minValue, maxValue);
                Console.Write($"{i}. {val1} + {val2} = ");
                int answer = int.Parse(Console.ReadLine());
                if (answer == val1 + val2)
                {
                    Console.WriteLine("Correct!");
                }
                else
                {
                    Console.WriteLine($"Sorry, the correct answer is  {val1 + val2} :/");
                    correct--;
                }
            }
            return Score = correct * 100 / NumQuestions;
        }
        public int Subtraction()
        {
            int correct = NumQuestions;
            for (int i = 1; i <= NumQuestions; i++)
            {
                int val1 = r.Next(minValue, maxValue);
                int val2 = r.Next(minValue, maxValue);
                if (val1 < val2)
                {
                    int t = val1;
                    val1 = val2;
                    val2 = t;
                }
                Console.Write($"{i}. {val1} - {val2} = ");
                int answer = int.Parse(Console.ReadLine());
                if (answer == val1 - val2)
                {
                    Console.WriteLine("Correct!");
                }
                else
                {
                    Console.WriteLine($"Sorry, the correct answer is  {val1 - val2} :/");
                    correct--;
                }
            }
            return Score = correct * 100 / NumQuestions;
        }
        public int Multiplication()
        {
            int correct = NumQuestions;
            for (int i = 1; i <= NumQuestions; i++)
            {
                int val1 = r.Next(minValue, maxValue);
                int val2 = r.Next(minValue, maxValue);
                Console.Write($"{i}. {val1} X {val2} = ");
                int answer = int.Parse(Console.ReadLine());
                if (answer == val1 * val2)
                {
                    Console.WriteLine("Correct!");
                }
                else
                {
                    Console.WriteLine($"Sorry, the correct answer is  {val1 * val2} :/");
                    correct--;
                }
            }
            return Score = correct * 100 / NumQuestions;
        }
        public int Division()
        {
            int correct = NumQuestions;
            for (int i = 1; i <= NumQuestions; i++)
            {
                float val1 = r.Next(minValue, maxValue);
                float val2 = r.Next(minValue, maxValue);
                Console.Write($"{i}. {val1} / {val2} = ");
                float answer = float.Parse(Console.ReadLine());
                if (answer + 0.1 > val1 / val2 && answer - 0.1 < val1 / val2)
                {
                    Console.WriteLine("Close counts!");
                }
                else
                {
                    Console.WriteLine($"Sorry, the correct answer is  {val1/val2} :/");
                    correct--;
                }
            }
            return Score = correct * 100 / NumQuestions;
        }

    }
}
