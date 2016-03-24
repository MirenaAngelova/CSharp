using System;
class OddOrEvenCounter
{
    static void Main()
    {
        //Petko is bad with numbers. He’s given a task to find and count some, but he has a hard time doing it. 
        //He is given N sets of numbers, and he has to count the odd numbers in each set, and then compare them. 
        //The number C shows how many numbers are there in a set. Then you are given a string S holding 
        //one of the words "odd" or "even" showing you what numbers should be counted.  
        //Then you are given N * C numbers representing all sets.
        //Your task is to count the odd or even numbers in each set, and then say in which set has most S numbers.
        //The set with most S numbers should be represented as ordinal number word e.g. 
        //"First", "Second", "Third", "Fourth", "Fifth", "Sixth", "Seventh", "Eighth", "Ninth", "Tenth". 
        //If the count of one or more sets is equal, print the first one with biggest count. 
        //If there is no set holding odd or even numbers print "No".  
        //Input
        //The input data should be read from the console. It consists of three input values, each at separate line:
        //•	The first line holds an integer N – the count of sets
        //•	The second line hold an integer C – the count of numbers in each set
        //•	The third line holds a string S  holding either "odd" or "even" showing what numbers to count
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //The output data should be printed on the console. It consists of exactly 1 line.
        //•	Print on the console the following formatted string "{0} set has the most {1} numbers: {2}", 
        //where {0} is the set as ordinal string {1} is the value of S and {2} is the biggest count of S numbers. 
        //If there is no set holding odd or even numbers print "No".   
        //Constraints
        //•	N will be an integer number in the range [1...10] 
        //•	C will be an integer number in the range [1...50] 
        //•	Each of the numbers in the set will be an integer in the range[-2 147 483 647… 2 147 483 647]
        //•	Allowed working time for your program: 0.25 seconds. Allowed memory: 16 MB.
        //Examples  
        //Input	Output	               	                    Input	Output		Input	Output
        //2     Second set has the most odd numbers: 5		3       No           3      First set has the most 
        //5                                                 2                    2      odd numbers: 2
        //odd                                               even                 odd 
        //6                                                 1                    1 
        //4                                                 3                    3 
        //12                                                5                    5 
        //8                                                 7                    9 
        //199                                               9                    151 
        //15                                                11	                 193 
        //21                                                       
        //7                                                         
        //3                                                         
        //5	                                                        

        int n = int.Parse(Console.ReadLine());
        int s = int.Parse(Console.ReadLine());
        string oddEvenStr = Console.ReadLine();
        int oddEven = oddEvenStr == "odd" ? 1 : 0;
        int set = 0;
        int words = 0;
        for (int i = 1; i <= n; i++)
        {
            int count = 0;
            for (int j = 0; j < s; j++)
            {
                int numbers = int.Parse(Console.ReadLine());
                if (numbers % 2 == oddEven)
                {
                    count++;
                    if (count > words)
                    {
                        words = count;
                        set = i;
                    }
                }
            }
        }
        string setWords = "";
        switch (set)
        {
            case 1:
                setWords = "First";
                break;
            case 2:
                setWords = "Second";
                break;
            case 3:
                setWords = "Third";
                break;
            case 4:
                setWords = "Fourth";
                break;
            case 5:
                setWords = "Fifth";
                break;
            case 6:
                setWords = "Sixth";
                break;
            case 7:
                setWords = "Seventh";
                break;
            case 8:
                setWords = "Eight";
                break;
            case 9:
                setWords = "Ninth";
                break;
            case 10:
                setWords = "Tenth";
                break;
        }
        if (setWords != "")
        {
            Console.WriteLine("{0} set has the most {1} numbers: {2}", setWords, oddEvenStr, words);
        }
        else
        {
            Console.WriteLine("No");
        }


        //int n = int.Parse(Console.ReadLine());
        //int c = int.Parse(Console.ReadLine());
        //string s = Console.ReadLine();
        //int oddEven = s == "odd" ? 1 : 0;
        //int maxCount = 0;
        //string[] ordinalStr = { "First", "Second", "Third", "Fourth", "Fifth", "Sixth", 
        //                        "Seventh", "Eighth", "Ninth", "Tenth" };
        //string ordinal = "";

        //for (int i = 0; i < n; i++)
        //{
        //    int count = 0;
        //    for (int j = 0; j < c; j++)
        //    {
        //        int number = int.Parse(Console.ReadLine());
        //        if (number % 2 == oddEven)
        //        {
        //            count++;
        //            if (count > maxCount)
        //            {
        //                maxCount = count;
        //                ordinal = ordinalStr[i];
        //            }
        //        }
        //    }
        //}
        //if (ordinal != "")
        //{
        //    Console.WriteLine("{0} set has the most {1} numbers: {2}", ordinal, s, maxCount);
        //}
        //else
        //{
        //    Console.WriteLine("No");
        //}
    }
}

