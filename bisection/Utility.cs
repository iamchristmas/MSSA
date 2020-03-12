using System;
//The bisection method is an efficient way of finding a particular value in a sorted list. It takes a sorted list and a value, and finds the value in the list. First, it checks the “middle” element in the list. There are three possibilities: the value could match the “middle” element, the value could be higher than the ‘middle” element of the list, or the value could be lower than the “middle” element. If the value matches, the function returns. If it’s higher, the algorithm (recursively) calls itself with the top half of the list. If it’s lower, the algorithm calls itself with the bottom half of the list.
namespace bisection
{
    public class Utility
    {
        public static bool Search(int[] arr,int i)
        {
            int[] temp;
            int middle = arr.Length / 2 + arr.Length % 2;
            if (arr.Length == 1 && arr[0] == i) return true;
            else if (arr.Length == 1 && arr[0] != i) return false ;
            else if (i <= middle)
            {
                temp = new int[middle];
                for (int g = 0, h = 0; g < middle; g++, h++) temp[g] = arr[h];
            }
            //trim down and go
            else
            {
                temp = new int[middle];
                if (arr.Length % 2 == 1) middle--;
                for (int g = 0, h = middle; g < temp.Length; g++, h++) temp[g] = arr[h];
            }
            Console.WriteLine("the current bisected array is [{0}]. we are looking for [{1}]", string.Join(", ", temp!), i);
            bool res = Search(temp, i);
            return res;
        //trim up and go
        }
    }
}
