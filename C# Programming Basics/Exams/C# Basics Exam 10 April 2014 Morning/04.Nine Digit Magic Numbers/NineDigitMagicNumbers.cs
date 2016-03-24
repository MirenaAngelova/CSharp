using System;
class NineDigitMagicNumbers
{
    static void Main()
    {
        //Petya often plays with numbers. Her recent game was to play with 9-digit numbers and calculate their sums of digits, 
        //as well as to split them into triples with special properties. Help her to calculate very special numbers 
        //called “nine-digit magic numbers”.
        //You are given two numbers: diff and sum. Using the digits from 1 to 7 generate all 9-digit numbers 
        //in format abcdefghi, such that their sub-numbers abc, def and ghi have a difference diff (ghi-def = def-abc = diff), 
        //their sum of digits is sum and abc < def < ghi. Numbers holding these properties are also 
        //called “nine-digit magic numbers”.
        //Your task is to write a program to print these numbers in increasing order.
        //Input
        //•	The input data should be read from the console.
        //•	The number sum stays at the first line.
        //•	The number diff stays at the second line.
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //The output should be printed on the console. Print all nine-digit magic numbers matching given difference diff 
        //and given sum of digits sum, in increasing order, each at a separate line. In case no nine-digit magic numbers exits,
        //print “No”.
        //Constraints
        //•	The number sum will be a positive integer number in the range [0…100].
        //•	The number diff will be a positive integer number in the range [0…1000].
        //•	Allowed working time for your program: 0.25 seconds.
        //•	Allowed memory: 16 MB.
        //Examples
        //Input	Output	    Comments
        //27    125171217   1+2+5+1+7+1+2+1+7 = 27; 171-125 = 46; 217-171 = 46 
        //46	131177223   1+3+1+1+7+7+2+2+3 = 27; 177-131 = 46; 223-177 = 46
        //      221267313	2+2+1+2+6+7+3+1+3 = 27; 267-221 = 46; 313-267 = 46
        //
        //Input	Output	    Comments
        //24    121224327   1+2+1+2+2+4+3+2+7 = 24; 224-121 = 103; 327-224 = 103
        //103	211314417	2+1+1+3+1+4+4+1+7 = 24; 314-211 = 103; 417-314 = 103
        //       
        //Input	Output	Comments
        //12    No	    No nine-digit magic numbers with sum=12 and diff=15
        //15	

        //int sum = int.Parse(Console.ReadLine());
        //int diff = int.Parse(Console.ReadLine());
        //bool isMagicNumber = false;
        //for (int abc = 111; abc <= 777; abc++)
        //{
        //    int resultCount = 0;
        //    int def = abc + diff;
        //    int ghi = def + diff;
        //    if (ghi <= 777)
        //    {
        //        string number = "" + abc + def + ghi;
        //        number.ToCharArray();
        //        for (int i = 0; i < 9; i++)
        //        {
        //            if ((number[i] - '0') < 1 | (number[i] - '0') > 7)
        //            {
        //                resultCount = -1;
        //                break;
        //            }
        //            resultCount += number[i] - '0';
        //        }
        //        if (resultCount == sum)
        //        {
        //            Console.WriteLine(number);
        //            isMagicNumber = true;
        //        }
        //    }
        //}
        //if (!isMagicNumber)
        //{
        //    Console.WriteLine("No");
        //}

        int sum = int.Parse(Console.ReadLine());
        int diff = int.Parse(Console.ReadLine());
        int resultCount = 0;
        for (int abc = 111; abc <= 777; abc++)
        {
            int def = abc + diff;
            int ghi  = def + diff;
            if (IsMagicNumber(abc) & IsMagicNumber(def) & IsMagicNumber(ghi) & (ghi <= 777) 
                & (SumOfDigits(abc) + SumOfDigits(def) + SumOfDigits(ghi)) == sum)
            {
                Console.WriteLine("{0}{1}{2}", abc, def, ghi);
                resultCount++;
            }
        }
        if (resultCount == 0)
        {
            Console.WriteLine("No");
        }
    }
   
    private static int SumOfDigits(int abcdefghi)
    {
        int sum = 0;
        while (abcdefghi > 0)
        {
            sum += abcdefghi % 10;
            abcdefghi = abcdefghi / 10;
        }
        return sum;
    }
    private static bool IsMagicNumber(int abcdefghi)
    {
        string digits = abcdefghi.ToString();
        foreach (var digit in digits)
        {
            if (digit < '1' | digit > '7')
            {
                return false;
            }
        }
        return true;
    }
}

