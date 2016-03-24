using System;
class BiggestTriple
{
    static void Main()
    {
        //We are given n numbers, e.g. {3, 7, 2, 8, 1, 4, 6, 9}. We split them into triples: 
        //sequences of 3 consecutive numbers (except the last sequence that could have 1 or 2 numbers). 
        //In our example, the numbers are split into these triples: the first three numbers {3, 7, 2}; 
        //the second three numbers {8, 1, 4}; the last two numbers {6, 9}. Write a program that enters 
        //n numbers and finds the triple with biggest sum of numbers. In our example this is the last triple: {6, 9}. 
        //In case there are several triples with the same biggest sum, print the leftmost of them.
        //Input
        //The input data should be read from the console. The input data consists of exactly one line holding 
        //the input numbers, separated one from another by a space.
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //You have to print at the console the leftmost biggest triple as sequence of up to 3 numbers, separated by a space.
        //Constraints
        //•	The input numbers will be integers in range [-1000 … 1000]. 
        //•	The number of the input numbers n will be between 1 and 1000.
        //•	Allowed work time for your program: 0.1 seconds.
        //•	Allowed memory: 16 MB.
        //Examples
        //Input     	                       Output
        //2 5 1 4 8 2	                       4 8 2
        //1 1 1 2 2	                           2 2
        //1 1 1 1 1 1 1 1 1 1 1 1 1 1 1	       1 1 1
        //2 3 4 3 3 3 0 0 9 7 1 1 2 2 3 9	   2 3 4
        //5	                                   5


        //string[] input = Console.ReadLine().Split();
        //int[] sequence = new int[input.Length];
        //int maxSum = int.MinValue;
        //int index = 0;
        //for (int i = 0; i < input.Length; i++)
        //{
        //    sequence[i] = int.Parse(input[i]);
        //}
        //for (int i = 0; i < sequence.Length; i++)
        //{
        //    int sum = 0;
        //    for (int j = 0; j < 3; j++)
        //    {
        //        if (i + j >= sequence.Length)
        //        {
        //            break;
        //        }
        //        else
        //        {
        //            sum += sequence[i + j];
        //        }
        //    }
        //    if (sum > maxSum)
        //    {
        //        maxSum = sum;
        //        index = i;
        //    }
        //    i += 2;
        //}
        //while (maxSum > 0)
        //{
        //    Console.Write(sequence[index] + " ");
        //    maxSum -= sequence[index];
        //    index++;
        //}
        //Console.WriteLine();

        string inputLine = Console.ReadLine();
        string[] numbers = inputLine.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
        int maxSum = Int32.MinValue;
        int i = 0;
        int index = 0;
        while (i < numbers.Length)
        {
            int num1 = int.Parse(numbers[i]);
            int num2 = 0;
            if ((i + 1) < numbers.Length)
            {
                num2 = int.Parse(numbers[i + 1]);
            }
            int num3 = 0;
            if ((i + 2) < numbers.Length)
            {
                num3 = int.Parse(numbers[i + 2]);
            }
            int sum = num1 + num2 + num3;
            if (sum > maxSum)
            {
                maxSum = sum;
                index = i;
            }
            i += 3;
        }
        while (maxSum != 0)
        {
            Console.Write(numbers[index]);
            maxSum = maxSum - int.Parse(numbers[index]);
            index++;
            if (maxSum != 0)
            {
                Console.Write(" ");
            }
        }
        Console.WriteLine();
    }
}

