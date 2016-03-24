using System;
public class NakovsMatching
{
    static void Main()
    {
        //We are given two words a and b. Each word can be split in several ways into left and right side:
        //•	a = (aLeft|aRight)
        //•	b = (bLeft|bRight)
        //The weight w(s) of given character sequence s is calculated as sum of the ASCII codes of its characters. 
        //The Nakov's distance between two split words (aLeft|aRight) and (bLeft|bRight) is defined as:
        //•	nakovs = w(aLeft) * w(bRight) - w(aRight) * w(bLeft), as absolute value
        //We assume that two word splits have good matching if their Nakov's difference is not greater than given 
        //limit number d. Your task is to write a program that prints all good matchings between given two words a and b 
        //and given limit number d.
        //Example: 
        //a = "hello", b = "csharp", d = 20000. 
        //The word a can be split in 4 ways: "h|ello", "he|llo","hel|lo" and "hell|o". 
        //The word b can be split in 5 ways: "c|sharp", "cs|harp", "csh|arp", "csha|rp" and "cshar|p".
        //There are 20 possible matchings between the words a and b, but only 3 of them are good matchings (nakovs ≤ d):
        //(h|ello) matches (c|sharp) by 13996 nakovs	w(h) = 104, w(ello) = 428, w(c) = 99, w(sharp) = 542
        //nakovs = abs(104 * 542 - 428 * 99) = 13996 ≤ 20000
        //(he|llo) matches (cs|harp) by 17557 nakovs	w(he) = 205, w(llo) = 327, w(cs) = 214, w(harp) = 427
        //nakovs = abs(205 * 427 - 327 * 214) = 17557 ≤ 20000
        //(hell|o) matches (cshar|p) by 11567 nakovs	w(hell) = 421, w(o) = 111, w(cshar) = 529, w(p) = 112
        //nakovs = abs(421 * 112 - 529 * 111) = 11567 ≤ 20000
        //Your task is to write a program that enters a, b and d and prints on the console all good matchings between a and b.
        //Input
        //The input data should be read from the console. It consists of 3 lines:
        //•	The first line hold the first string.
        //•	The second line holds the second string.
        //•	The third line holds the limit number d.
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //Print on the console all good matchings between these two words in format "(aLeft|aRight) matches (bLeft|bRight) 
        //by XXX nakovs", each at separate line. 
        //The order of the output lines is not important. 
        //Print "No" if no good matchings are found.
        //Constraints
        //•	The input words a and b consist of small Latin letters only. The length of the words is in the range [2…20].
        //•	The number d is integer in the range [0…5 000 000].
        //•	Allowed working time: 0.25 seconds. Allowed memory: 16 MB.
        //Examples
        //Input	    Output		                                Input	Output
        //hello     (h|ello) matches (c|sharp) by 13996 nakovs  nice    (ni|ce) matches (ex|am) by 90 nakovs
        //csharp    (he|llo) matches (cs|harp) by 17557 nakovs  exam
        //20000	    (hell|o) matches (cshar|p) by 11567 nakovs  100

        string first = Console.ReadLine();
        string second = Console.ReadLine();
        int diff = int.Parse(Console.ReadLine());
        bool isMatched = false;

        for (int i = 1; i <= first.Length - 1; i++)
        {
            string leftFirst = first.Substring(0, i);
            string rightFirst = first.Substring(i);
            int leftFirstWeight = SumChars(leftFirst);
            int rightFirstWeight = SumChars(rightFirst);
            for (int j = 1; j <= second.Length - 1; j++)
            {
                string leftSecond = second.Substring(0, j);
                string rightSecond = second.Substring(j);
                int leftSecondWeight = SumChars(leftSecond);
                int rightSecondWeight = SumChars(rightSecond);

                int weight = Math.Abs(leftFirstWeight * rightSecondWeight - rightFirstWeight * leftSecondWeight);
                if (weight <= diff)
                {
                    Console.WriteLine("({0}|{1}) matches ({2}|{3}) by {4} nakovs", leftFirst, rightFirst,
                                leftSecond, rightSecond, weight);
                    //Console.WriteLine(
                    //    '(' + leftFirst + '|' + rightFirst + ") matches (" +
                    //    leftSecond + '|' + rightSecond + ") by " + weight + " nakovs");
                    isMatched = true;
                }
            }
        }
        if (!isMatched)
        {
            Console.WriteLine("No");
        }
    }
    static int SumChars (string str)
    {
        int sum = 0;
        foreach (char ch in str)
        {
            sum += (int)ch;
        }
        return sum;
    }
}

