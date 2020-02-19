namespace ex6a
{
    public class ArrayEx
    {
        // Write a method counts the number of elements in an integer array, and then sums the elements in an integer array.It should return the average of the array elements as a double. Using the count and sum, compute and print the mean of each array.
        public static int Mean(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++) sum += arr[i];
            return sum / (arr.Length);
        }

        //Write a method that accepts an array as an argument and prints the reversed array. For example, if you pass the method Array B, it should print [9, 7, 5, 3, 1]. Print the reverse of all three arrays.

        public static int[] Reverse(int[] arr)
        {
            int[] outarr = new int[arr.Length];
            int r = arr.Length - 1;
            for (int i = 0; i < arr.Length; i++) outarr.SetValue(arr[i],r--);
            return outarr;
        }

        //Write a method that accepts three parameters, a direction (right or left), a number of places, and an array, which prints the appropriate rotation. 
        //Call the method on all three arrays. Rotate array A two places to the left. Rotate array B two places to the right. Rotate array C four places to the left.
        public static int[] Shift(int[] arr, int mov, string dir)
        {
            //assuming case-insensitivity
            if (dir == "left") mov *= -1;
            int[] outarr = new int[arr.Length];
            for(int i = 0; i < arr.Length; i++)
            {
                if (i + mov > arr.Length - 1 || i + mov < arr.Length - 1)
                    outarr.SetValue(arr[i],);
            }


            return outarr;
        }
        //Write a method that takes an unsorted integer array and prints a sorted array. Use Array C as your test array. Do you recognize this list of numbers?
        public static int[] Sort(int[] arr)
        {

        }
    }
}
