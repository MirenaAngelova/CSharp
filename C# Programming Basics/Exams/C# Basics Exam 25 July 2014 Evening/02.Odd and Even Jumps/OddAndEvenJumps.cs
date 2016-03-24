using System;
class OddAndEvenJumps
{
    static void Main()
    {
        //We are given an input string, e.g. "Software University". We take its odd and even letters, turned into lowercase:
        //•	odd letters  "sfwruiest"
        //•	even letters  "otaenvriy"
        //We are also given two numbers: oddJump and evenJump. We pass through the odd letters from left to right 
        //and we sum their ASCII codes and aggregate the sum to the result (initially starting form 0). 
        //Through a step of oddJump we multiply the current result by the ASCII code of the current letter 
        //instead of adding it to the result. Finally we print the result as hexadecimal number. 
        //We do the same for the even letters with a step of evenJump. For our example, 
        //let's assume oddJump = 3 and evenJump = 2. The calculations are performed as follows:
        //•	odd result = ( ( (+ 115 's' + 102 'f') * 119 'w' + 114 'r' + 117 'u' ) * 105 'i' + 101 'e' + 115 's' ) * 116 't' 
        //= 317362776 = 12EA9258 (hex)
        //•	even result = ( ( + 111 'o' * 116 't' + 97 'a' ) * 101 'e' + 110 'n' ) * 118 'v' + 114 'r' ) * 105 'i' + 121 'y' 
        //= 16235657461 = 3C7B878F5 (hex)
        //Input
        //The input data should be read from the console. It consists of 3 lines:
        //•	The first line holds the input string.
        //•	The second line holds the number oddJump.
        //•	The third line holds the number evenJump.
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //The output should consist of 2 lines:
        //•	The odd result in hexadecimal form in format: „Odd: XXX“.
        //•	The even result in hexadecimal form in format: „Even: XXX“.
        //Constraints
        //•	The input string will consist of only Latin letters and spaces in the range [1…100].
        //•	The numbers oddJump and evenJump will be integer in the range [1…100].
        //•	The odd and even results will be in the range [0…7FFF FFFF FFFF FFFF].
        //•	Allowed working time: 0.2 seconds. Allowed memory: 16 MB.
        //Examples
        //Input	                Output		        Input	                Output
        //Software University   Odd: 12EA9258       CSharp Exam SoftUni     Odd: FBE2
        //3                     Even: 3C7B878F5     7                       Even: 37A
        //2	                                        11

        string input = Console.ReadLine().ToLower().Replace(" ", "");
        int oddJump = int.Parse(Console.ReadLine());
        int evenJump = int.Parse(Console.ReadLine());
        int oddCount = 0;
        long oddResult = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (i % 2 == 0)
            {
                oddCount++;
                if (oddCount % oddJump == 0)
                {
                    oddResult *= input[i];
                }
                else
                {
                    oddResult += input[i];
                }
            }
        }
        string oddSum = oddResult.ToString("X");
        Console.WriteLine("Odd: {0}", oddSum);

        int evenCount = 0;
        long evenResult = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (i % 2 != 0)
            {
                evenCount++;
                if (evenCount % evenJump == 0) 
                {
                    evenResult *= input[i];
                }
                else
                {
                    evenResult += input[i];
                }
            }
        }
        string evenSum = evenResult.ToString("X");
        Console.WriteLine("Even: {0}", evenSum);

        //string input = Console.ReadLine().ToLower().Replace(" ", "");
        //int oddJump = int.Parse(Console.ReadLine());
        //int evenJump = int.Parse(Console.ReadLine());
        //int oddCount = 0;
        //int evenCount = 0;
        //long oddResult = 0;
        //long evenResult = 0;

        //for (int i = 0; i < input.Length; i++)
        //{
        //    if (i % 2 == 0)
        //    {
        //        oddCount++;
        //        if (oddCount % oddJump == 0)
        //        {
        //            oddResult *= input[i];
        //        }
        //        else
        //        {
        //            oddResult += input[i];
        //        }
        //    }
        //    else
        //    {
        //        evenCount++;
        //        if (evenCount % evenJump == 0)
        //        {
        //            evenResult *= input[i];
        //        }
        //        else
        //        {
        //            evenResult += input[i];
        //        }
        //    }
        //}

        //Console.WriteLine("Odd: {0:X}", oddResult);
        //Console.WriteLine("Even: {0}", evenResult.ToString("X"));
    }
}



