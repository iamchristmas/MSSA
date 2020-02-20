using System;
using System.Collections.Generic;


public class Evaluator
{
    public static void Main(string[] args)
    {
        string maths = "1 + 3 * 2 - 2"; // 5
        Console.WriteLine(Evaluate(maths));
    }
    public static double Evaluate(string dostuff)
    {
        List<string> math = new List<string> (dostuff.Split(" "));
        int res;
        while (math.Contains("*") || math.Contains("/"))
        {
            for (int i = 0; i < math.Count; i++)
            {
                if (math[i] == "*")
                {
                    res = int.Parse(math[i - 1]) * int.Parse(math[i + 1]);
                    math[i] = res.ToString();
                    math.RemoveAt(i + 1);
                    math.RemoveAt(i - 1);
                }
                else if (math[i] == "/")
                {
                    res = int.Parse(math[i - 1]) / int.Parse(math[i + 1]);
                    math[i] = res.ToString();
                    math.RemoveAt(i + 1);
                    math.RemoveAt(i - 1);
                }
            }
            while (math.Contains("+") || math.Contains("-"))
            {
                for (int i = 0; i < math.Count; i++)
                {
                    if (math[i] == "+")
                    {
                        res = int.Parse(math[i - 1]) + int.Parse(math[i + 1]);
                        math[i] = res.ToString();
                        math.RemoveAt(i + 1);
                        math.RemoveAt(i - 1);
                    }
                    else if (math[i] == "-")
                    {
                        res = int.Parse(math[i - 1]) - int.Parse(math[i + 1]);
                        math[i] = res.ToString();
                        math.RemoveAt(i + 1);
                        math.RemoveAt(i - 1);
                    };
                }
            }
        }
        return int.Parse(math[0]);
    }
}