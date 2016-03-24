using System;
class BullsAndCows
{
    static void Main()
    {
        //All we love the “Bulls and Cows” game (http://en.wikipedia.org/wiki/Bulls_and_cows). 
        //Given a 4-digit secret number and a 4-digit guess number we say that we have b bulls and c cows 
        //when we have b matching digits on their right positions (bulls) and c matching digits on different positions (cows). 
        //Examples are given below:
        //Secret number	1	4	8	1	Bulls  = 1      Secret number	2	2	4	9	Bulls  = 0
        //Guess number	8	8	1	1	Cows = 2		Guess number	9	9	2	4   Cows = 3
        //		
        //Given the secret number and the number of bulls and cows your task is to write a program 
        //to find all matching guess numbers in increasing order.
        //Input
        //•	The input data should be read from the console.
        //•	It will consist of exactly 3 lines. At the first line there the secret number will be given. 
        //At the second line the number of bulls b will be given. At the third line the number of cows c will be given.
        //•	The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //•	The output data should be printed on the console
        //•	It should consist of a single line holding all matched guess numbers, given in increasing order, 
        //separated by single space.
        //Constraints
        //•	The secret number will always consist of exactly 4 digits, each in the range [1…9].
        //•	The numbers b and c will be in the range [0…9].
        //•	Time limit: 0.15 seconds.
        //•	Allowed memory: 4 MB.
        //Examples
        //Input	    Output		                Input	Output		                Input	Output
        //2228      1222 2122 2212 2232 2242    1234    1134 1214 1224 1231 1232    1234    No
        //2         2252 2262 2272 2281 2283    3       1233 1235 1236 1237 1238    3
        //1	        2284 2285 2286 2287 2289    0		1239 1244 1254 1264 1274    1
        //          2292 2322 2422 2522 2622            1284 1294 1334 1434 1534
        //          2722 2821 2823 2824 2825            1634 1734 1834 1934 2234
        //          2826 2827 2829 2922 3222            3234 4234 5234 6234 7234
        //          4222 5222 6222 7222 8221            8234 9234
        //          8223 8224 8225 8226 8227
        //          8229 9222
        //Attribution: this work may contain portions from the "C# Part I" course by Telerik Academy under CC-BY-NC-SA license.

        //int secretNum = int.Parse(Console.ReadLine());
        //int bulls = int.Parse(Console.ReadLine());
        //int cows = int.Parse(Console.ReadLine());
        //bool solutionFound = false;
        //for (int one = 1; one <= 9; one++)
        //{
        //    for (int two = 1; two <= 9; two++)
        //    {
        //        for (int three = 1; three <= 9; three++)
        //        {
        //            for (int four = 1; four <= 9; four++)
        //            {
        //                int secretOne = (secretNum / 1000) % 10;
        //                int secretTwo = (secretNum / 100) % 10;
        //                int secretThree = (secretNum / 10) % 10;
        //                int secretFour = (secretNum / 1) % 10;

        //                int newOne = one;
        //                int newTwo = two;
        //                int newThree = three;
        //                int newFour = four;

        //                int newBulls = 0;
        //                int newCows = 0;

        //                if (one == secretOne)
        //                {
        //                    newBulls++;
        //                    secretOne = -1;
        //                    one = -2;
        //                }
        //                if (two == secretTwo)
        //                {
        //                    newBulls++;
        //                    secretTwo = -1;
        //                    two = -2;
        //                }
        //                if (three == secretThree)
        //                {
        //                    newBulls++;
        //                    secretThree = -1;
        //                    three = -2;
        //                }
        //                if (four == secretFour)
        //                {
        //                    newBulls++;
        //                    secretFour = -1;
        //                    four = -2;
        //                }
        //                if (one == secretTwo)
        //                {
        //                    newCows++;
        //                    secretTwo = -1;
        //                }
        //                else if (one == secretThree)
        //                {
        //                    newCows++;
        //                    secretThree = -1;
        //                }
        //                else if (one == secretFour)
        //                {
        //                    newCows++;
        //                    secretFour = -1;
        //                }
        //                if (two == secretOne)
        //                {
        //                    newCows++;
        //                    secretOne = -1;
        //                }
        //                else if (two == secretThree)
        //                {
        //                    newCows++;
        //                    secretThree = -1;
        //                }
        //                else if (two == secretFour)
        //                {
        //                    newCows++;
        //                    secretFour = -1;
        //                }
        //                if (three == secretOne)
        //                {
        //                    newCows++;
        //                    secretOne = -1;
        //                }
        //                else if (three == secretTwo)
        //                {
        //                    newCows++;
        //                    secretTwo = -1;
        //                }
        //                else if (three == secretFour)
        //                {
        //                    newCows++;
        //                    secretFour = -1;
        //                }
        //                if (four == secretOne)
        //                {
        //                    newCows++;
        //                    secretOne = -1;
        //                }
        //                else if (four == secretTwo)
        //                {
        //                    newCows++;
        //                    secretTwo = -1;
        //                }
        //                else if (four == secretThree)
        //                {
        //                    newCows++;
        //                    secretThree = -1;
        //                }
        //                one = newOne;
        //                two = newTwo;
        //                three = newThree;
        //                four = newFour;

        //                if ((newBulls == bulls) & (newCows == cows))
        //                {
        //                    if (solutionFound)
        //                    {
        //                        Console.Write(" ");
        //                    }
        //                    Console.Write("" + one + two + three + four);
        //                    solutionFound = true;
        //                }
        //            }
        //        }
        //    }
        //}
        //if (!solutionFound)
        //{
        //    Console.WriteLine("No");
        //}


        int secretNum = int.Parse(Console.ReadLine());
        int bulls = int.Parse(Console.ReadLine());
        int cows = int.Parse(Console.ReadLine());
        bool isMatched = false;

        for (int digits = 1; digits <= 9999; digits++)
        {
           char[] guess = digits.ToString().ToCharArray();
           if (guess.Length == 4 && guess[0] >= '1' && guess[1] >= '1' && guess[2] >= '1' && guess[3] >= '1')

            {
                char[] secret = secretNum.ToString().ToCharArray();
                int newBulls = 0;
                int newCows = 0;
                for (int i = 0; i < secret.Length; i++)
                {
                    if (secret[i] == guess[i])
                    {
                        newBulls++;
                        secret[i] = '@';
                        guess[i] = '#';
                    }
                }
                for (int j = 0; j < secret.Length; j++)
                {
                    for (int k = 0; k < guess.Length; k++)
                    {
                        if (secret[j] == guess[k])
                        {
                            newCows++;
                            secret[j] = '@';
                            guess[k] = '#';
                        }
                    }
                }
               if (newBulls == bulls & newCows == cows)
                {
                    if (isMatched)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(digits);
                    isMatched = true;
                }              
            }
        }
        if (!isMatched)
        {
            Console.WriteLine("No");
        }
        Console.WriteLine();
    }
}




