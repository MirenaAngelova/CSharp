using System;
class WeirdCombinations
{
    static void Main()
    {
        //You are given a sequence of 5 distinct numbers and/or letters. Find all possible combinations of 5 symbols 
        //containing the given numbers/letters. Then you will be given a number n. You have to find the n-th number 
        //in the natural order of all combinations. Example: 
        //sequence = "a1bc2", n = 5, combinations: 
        //"aaaaa", "aaaa1", "aaaab", "aaaac", "aaaa2", "aaa1a", "aaa1b"…  "2222b", "2222c", "22222".  
        //5th element = aaa1a (take notice that the first element in the order is counted as 0). 
        //If the n-th number doesn't exist in print "No".
        //Input
        //Input data is read from the console.
        //•	The sequence of letters/numbers stays at the first line.
        //•	The number n of stays at the second line.
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //The output data must be printed on the console.
        //•	Print the n-th number in the natural order of all combinations.
        //Constraints
        //•	N will be an integer number between 0 and 5000 and 
        //•	Time limit: 0.25 seconds. Allowed memory: 16 MB.
        //Examples
        //Input	    Output		Input	Output		Input	Output		Input	Output
        //a1bc2     aaa1a		f5182   fff8f		12345   13111		12345   No
        //5	                    15                  250	                6000

        string letter = Console.ReadLine();
        char[] letters = letter.ToCharArray();
        int n = int.Parse(Console.ReadLine());
        int count = 0;
        bool isExist = false;
        foreach (var a in letters)
        {
            foreach (var b in letters)
            {
                foreach (var c in letters)
                {
                    foreach (var d in letters)
                    {
                        foreach (var e in letters)
                        {
                            if (count == n)
                            {
                                string exist = "" + a + b + c + d + e;
                                Console.WriteLine(exist);
                                isExist = true;
                            }
                            count++;
                        }
                    }
                }
            }
        }
        if (!isExist)
        {
            Console.WriteLine("No");
        }
    }
}

