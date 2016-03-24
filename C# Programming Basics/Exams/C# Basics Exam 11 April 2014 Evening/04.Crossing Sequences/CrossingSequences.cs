using System;
class CrossingSequences
{
    static void Main()
    {
        //We’re dealing with two sequences: the Tribonacci sequence, where every number is the sum of the previous three, 
        //and the number spiral, defined by walking over a grid of numbers as a spiral 
        //(right, down, left, up, right, down, up, left, …) and writing down the current number every time we take a turn. 
        //Find the first number that appears in both sequences.
        //Example
        //Let the Tribonacci sequence start with 1, 2 and 3. It will therefore contain the numbers 
        //1, 2, 3, 6, 11, 20, 37, 68, 125, 230, 423, 778, 1431, 2632, 4841, 8904, 16377, 30122, 55403, 101902, and so on.
        //Also, let the number spiral start with 5 and have a step of 2; it then contains he numbers 
        //5, 7, 9, 13, 17, 23, 29, 37, etc. 
        //Since 37 is the first number that is both in the Tribonacci sequence and in the spiral, it is the answer.
        //Input
        //The input data should be read from the console.	45	..	..	..	..	55
        //                                                  ..	17  ..	..	23	..
        //                                                  ..	..	5   7   ..	..
        //                                                  ..	13  ..	9	..	..
        //                                                  37	..	..	..	29	..
        //                                                  ..	..	..	..	..	65
        //
        //•	On the first three lines of input, you will read three integers, representing the three initial numbers 
        //of the Tribonacci sequence.
        //•	On the next two lines of input, you will read two integers, representing the initial number and the step 
        //of each grid cell for the number spiral.
        //The input data will always be valid and in the format described. There is no need to check it.
        //Output
        //The output must be printed on the console.
        //On the single line of output you must print the smallest number that appears in both sequences. 
        //If no number in the range [1 … 1 000 000] exists that appears in both sequences, print "No".
        //Constraints
        //•	All numbers in the input will be in the range [1 … 1 000 000].
        //•	Allowed work time for your program: 0.25 seconds.
        //•	Allowed memory: 16 MB.
        //Examples
        //Input	Output	Input	Output	Input	Output	Input	Output	Input	Output
        //1     37		1       1		13      13		99      No		4       71
        //2             1               25              99              1
        //3             1               99              99              7
        //5             1               5               2               23  
        //2             1               2               2               3	             			
        //

        int MAX = 1000000;
        int trib1 = int.Parse(Console.ReadLine());
        int trib2 = int.Parse(Console.ReadLine());
        int trib3 = int.Parse(Console.ReadLine());

        bool[] tribonacci = new bool[MAX + 1];
        tribonacci[trib1] = true;
        tribonacci[trib2] = true;
        tribonacci[trib3] = true;

        while (true)
        {
            int tribNext = trib1 + trib2 + trib3;
            if (tribNext <= MAX)
            {
                tribonacci[tribNext] = true;
            }
            else
            {
                break;
            }
            trib1 = trib2;
            trib2 = trib3;
            trib3 = tribNext;
        }

        long number = long.Parse(Console.ReadLine());
        long step = long.Parse(Console.ReadLine());
        bool takeATurn = true;
        long i = 0;
        bool[] spiral = new bool[MAX + 1];

        while (number <= MAX)
        {
            spiral[number] = true;
            if (takeATurn)
            {
                i += 1;
            }
            number = number + (i * step);
            takeATurn = !takeATurn;
        }
        for (int j = 1; j <= MAX; j++)
        {
           if(tribonacci[j] & spiral[j])
           {
               Console.WriteLine(j);
               return;
           }
        }
        Console.WriteLine("No");
    }
}

