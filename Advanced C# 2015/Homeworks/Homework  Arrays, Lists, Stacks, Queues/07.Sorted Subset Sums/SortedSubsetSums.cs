using System;
using System.Collections.Generic;
using System.Linq;
class SortedSubsetSums
{
    static void Main()
    {
        //Modify the program you wrote for the previous problem to print the results in the following way: 
        //each line should contain the operands (numbers that form the desired sum) in ascending order; 
        //the lines containing fewer operands should be printed before those with more operands; 
        //when two lines have the same number of operands, the one containing the smallest operand should be printed first. 
        //If two or more lines contain the same number of operands and have the same smallest operand, 
        //the order of printing is not important. Example:
        //Input	                    Output
        //11                        11 = 11 -> only one operand
        //0 11 1 10 5 6 3 4 7 2	    0 + 11 = 11 -> two operands, smallest is 0
        //                          1 + 10 = 11 -> two operands, smallest is 1
        //                          4 + 7 = 11
        //                          5 + 6 = 11
        //                          0 + 5 + 6 = 11 -> three operands, smallest is 0
        //                          0 + 4 + 7 = 11 -> this line can be switched with the one above or with the one below 
        //                                            (they all have three operands, smallest is 0)                                           
        //                          0 + 1 + 10 = 11
        //                          1 + 4 + 6 = 11
        //                          1 + 3 + 7 = 11
        //                          2 + 4 + 5 = 11
        //                          2 + 3 + 6 = 11
        //                          0 + 2 + 4 + 5 = 11
        //                          0 + 2 + 3 + 6 = 11
        //                          0 + 1 + 4 + 6 = 11
        //                          0 + 1 + 3 + 7 = 11
        //                          1 + 2 + 3 + 5 = 11
        //                          0 + 1 + 2 + 3 + 5 = 11
        //0                         No matching subsets.
        //1 2 3 4 5	
        //-2                        -5 + -1 + 4 = -2
        //-5 4 92 0 928 1 -1 4	    -5 + -1 + 0 + 4 = -2
        //
        //Ideas to help you out: You'll probably want to store all subset sums in a collection. 
        //You'll need to check if the collection has elements after you've checked all combinations for valid subsets. 
        //If the collection contains elements, you need to sort it by the criteria provided above. 
        //LINQ extension methods and lambda expressions can do this in just a few lines of code!

        int n = int.Parse(Console.ReadLine());
        int[] integers = Console.ReadLine().Split().Select(int.Parse).Distinct().ToArray();
        bool isMatching = false;

        var subsets = (from m in Enumerable.Range(1, ((int)Math.Pow(2, integers.Length) - 1))
                       select
                           (from i in Enumerable.Range(0, integers.Length)
                            where (m & (1 << i)) != 0
                            select integers[i])
                                .ToList())
                                .Where(x => x.Sum() == n)
                                .OrderBy(y => y.Count)
                                .ThenBy(y => y.First())
                                .Select(y => y.OrderBy(z => z));
        foreach (var subset in subsets)
        {
            Console.WriteLine("{0} = {1}", string.Join(" + ", subset), n);
            isMatching = true;
        }
        if (!isMatching)
        {
            Console.WriteLine("No matching subsets.");
        }
        
    }
}



