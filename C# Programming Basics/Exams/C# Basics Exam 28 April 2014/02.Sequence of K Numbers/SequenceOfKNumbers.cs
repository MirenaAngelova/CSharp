using System;
class SequenceOfKNumbers
{
    static void Main()
    {
        //Write a program to remove all sequences of k equal elements from a sequence of integers. 
        //For example, if we have the sequence 3 3 3 8 8 2 5 1 7 7 7 4 4 4 4 3 4 4 
        //and we remove all sequences of k = 2 elements, we will obtain 3 2 5 1 7 3. 
        //For k = 3, we will obtain the following result: 8 8 2 5 1 4 3 4 4. 
        //For k = 1, the result will be empty.
        //Input
        //The input data comes from the console. It should consist of a two lines:
        //•	The first line holds the input numbers, separated one from another by a space.
        //•	The second line holds the number k.
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //The output should be printed on the console. It should consist of a single line holding the obtained sequence 
        //of numbers. Separate each number from the next number by a space.
        //Constraints
        //•	The input sequence numbers are integers in the range [-1000 … 1000].
        //•	The count of the input numbers is in the range [1 … 1000].
        //•	The number k is integer in the range [1 … 1000].
        //•	Time limit: 0.1 seconds.
        //•	Memory limit: 16 MB.
        //Examples
        //Input	                                Output
        //3 3 3 8 8 2 5 1 7 7 7 4 4 4 4 3 4 4   3 2 5 1 7 3
        //2	
        //3 3 3 8 8 2 5 1 7 7 7 4 4 4 4 3 4 4   8 8 2 5 1 4 3 4 4
        //3	
        //3 3 3 8 8 2 5 1 7 7 7 4 4 4 4 3 4 4   3 3 3 8 8 2 5 1 7 7 7 3 4 4
        //4	
        //1 1 100 1 1                           100
        //2	

        string[] numbers = Console.ReadLine().Split(' ');
        int k = int.Parse(Console.ReadLine());
        for (int i = 0; i < numbers.Length; i++)
        {
            if ((numbers.Length - i) < k)
            {
                Console.Write(numbers[i] + " ");
            }
            else
            {
                for (int j = 1; j < k; j++)
                {
                    if ((i + j) >= numbers.Length)
                    {
                        break;
                    }
                    else
                    {
                        if (numbers[i] != numbers[i + j])
                        {
                            Console.Write(numbers[i] + " ");
                            break;
                        }
                        else if (j == (k - 1))
                        {
                            i = i + (k - 1); 
                        }
                    }
                }
            }
        }
    }
}






