using System;
class MagicCarNumbers
{
    static int count = 0;
    static void Main()
    {
        //Cars in Sofia have registration numbers in format "CAabcdXY" where a, b, c and d are digits from 0 to 9 
        //and X and Y are letters from the following subset of the Latin alphabet: 
        //'A', 'B', 'C', 'E', 'H', 'K', 'M', 'P', 'T' and 'X'. Examples of car numbers from Sofia are 
        //"CA8517TX", "CA2277PC", "CA0710XC", "CA1111AC", while "CC7512FJ" in not valid car number from Sofia. 
        //Local people are keen to choose special numbers for their cars, know as magic car numbers. They calculate 
        //the weight of a car number as follows: they sum its digits and letters, assuming that letters have the following 
        //values: 'A'  10, 'B'  20, 'C'  30, 'E'  50, 'H'  80, 'K'  110, 'M'  130, 'P'  160, 'T'  200, 'X'  240. 
        //For example the weight("CA6511BM") = 30 + 10 + 6 + 5 + 1 + 1 + 20 + 130 = 203. 
        //A magic car number is a car number that has a special magic weight (e.g. 256 or 512 for developers) 
        //and its number is in some of the formats "CAaaaaXY", "CAabbbXY", "CAaaabXY", "CAaabbXY", "CAababXY" and "CAabbaXY", 
        //where a and b are two different digits and X and Y are letters from the Latin alphabet subset 
        //{ 'A', 'B', 'C', 'E', 'H', 'K', 'M', 'P', 'T', 'X' }.
        //Your task is to write a program that calculates how many cars can be registered in Sofia for given magic weight.
        //Input
        //The input data should be read from the console. It will consist of a single value: the magic weight.
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //The output should be printed on the console. It is a single value: the number of cars matching given magic value.
        //Constraints
        //•	All input numbers will be integers in the range [1…1000].
        //•	Allowed working time for your program: 0.25 seconds.
        //•	Allowed memory: 16 MB.
        //Examples
        //Input	Output	Matching Car Numbers
        //555	2	    CA8999XX, CA9998XX
        //512	18	    CA5999TX, CA5999XT, CA7799TX, CA7979TX, CA7997TX, CA7799XT, CA7979XT, 
        //              CA7997XT, CA8888TX, CA8888XT, CA9995TX, CA9977TX, CA9797TX, CA9779TX, 
        //              CA9995XT, CA9977XT, CA9797XT, CA9779XT
        //95	46	    CA0555AC, CA0555BB, CA0005BC, CA0555CA, CA0005CB, CA1888AB, CA1888BA, 
        //              CA1112BC, CA1112CB, CA2229AC, CA2229BB, CA2111BC, CA2229CA, CA2111CB, 
        //              CA3444AC, CA3336AC, CA3444BB, CA3336BB, CA3444CA, CA3336CA, CA4777AB, 
        //              CA4443AC, CA4777BA, CA4443BB, CA4443CA, CA5550AC, CA5550BB, CA5000BC, 
        //              CA5550CA, CA5000CB, CA6667AB, CA6333AC, CA6667BA, CA6333BB, CA6333CA, 
        //              CA7774AB, CA7666AB, CA7774BA, CA7666BA, CA8999AA, CA8881AB, CA8881BA, 
        //              CA9998AA, CA9222AC, CA9222BB, CA9222CA

        int magicNumber = int.Parse(Console.ReadLine());
        char[] letters = { 'A', 'B', 'C', 'E', 'H', 'K', 'M', 'P', 'T', 'X'};
        for (int let3 = 0; let3 < letters.Length; let3++)
        {
            for (int let4 = 0; let4 < letters.Length; let4++)
            {
                for (int a = 0; a <= 9; a++)
                {
                    CheckCarNumber("CA" + a + a + a + a + letters[let3] + letters[let4], magicNumber);
                    for (int b = 0; b <= 9; b++)
                    {
                       if (a != b)
                       {
                           CheckCarNumber("CA" + a + b + b + b + letters[let3] + letters[let4], magicNumber);
                           CheckCarNumber("CA" + a + a + a + b + letters[let3] + letters[let4], magicNumber);
                           CheckCarNumber("CA" + a + a + b + b + letters[let3] + letters[let4], magicNumber);
                           CheckCarNumber("CA" + a + b + a + b + letters[let3] + letters[let4], magicNumber);
                           CheckCarNumber("CA" + a + b + b + a + letters[let3] + letters[let4], magicNumber);

                       }
                    }
                }
            }
        }
        Console.WriteLine(count);
    }
    static void CheckCarNumber (string carNumber, int magicSum)
    {
        int weight = 0;
        foreach (var ch in carNumber)
        {
            if (ch >= '0')
        }
    }
}
