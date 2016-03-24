using System;
class HayvanNumbers
{
    static void Main()
    {
        //Hayvan often plays with numbers. His recent game was to play with 9-digit numbers and calculate their sums of digits,
        //as well as to split them into triples with special properties. Help Hayvan to find a very special set of numbers 
        //called “Hayvan numbers”.
        //Hayvan numbers are 9-digit numbers in format abcdefghi, such that their sub-numbers abc, def and ghi
        //have a difference diff (ghi-def = def-abc = diff), 
        //their sum of digits is sum and abc < def < ghi, where each digit a, b, c, d, e, f, g, h and i is in range [5…9].
        //Your task is to write a program to print all Hayvan numbers for given sum and diff in increasing order.
        //Input
        //•	The input data should be read from the console.
        //•	The number sum stays at the first line.
        //•	The number diff stays at the second line.
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //The output should be printed on the console. Print Hayvan numbers matching given difference diff and given sum 
        //of digits sum, in increasing order, each at a separate line. In case no Hayvan numbers exits, print “No”.
        //Constraints
        //•	The number sum will be a positive integer number in the range [0…100].
        //•	The number diff will be a positive integer number in the range [0…1000].
        //•	Allowed working time for your program: 0.25 seconds.
        //•	Allowed memory: 16 MB.
        //Examples
        //Input     Output	    Comments
        //63        567768969   5+6+7+7+6+8+9+6+9 = 63; 768-567 = 201; 969-768 = 201
        //201	    576777978   5+7+6+7+7+7+9+7+8 = 63; 777-576 = 201; 978-777 = 201
        //          585786987   5+8+5+7+8+6+9+8+7 = 63; 786-585 = 201; 987-786 = 201	
        //
        //Input	    Output		Input	Output
        //75        897898899   93      No
        //1	        987988989   10
        //          996997998		

        int sum = int.Parse(Console.ReadLine());
        int diff = int.Parse(Console.ReadLine());
        int resultCount = 0;
        for (int abc = 555; abc <= 999; abc++)
        {
            int def = abc + diff;
            int ghi = def + diff;
            if (IsAllowedNumber(abc) & IsAllowedNumber(def) & IsAllowedNumber(ghi) & (ghi <= 999) 
                & ((CalcSumOfDigits(abc) + CalcSumOfDigits(def) + CalcSumOfDigits(ghi)) == sum))
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
    private static int CalcSumOfDigits(int hayvan)
    {
        int newSum = 0;
        while (hayvan > 0)
        {
            newSum += hayvan % 10;
            hayvan = hayvan / 10;
        }
        return newSum;
    }
    private static bool IsAllowedNumber(int hayvan)
    {
        string digits = hayvan.ToString(); 
        foreach (var digit in digits)
        {
            if ((digit < '5') | (digit > '9'))
            {
                return false;
            }
        }
        return true;
    }
}

