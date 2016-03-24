using System;
using System.Linq;
class OddAndEvenProduct
{
    static void Main()
    {
        //You are given n integers (given in a single line, separated by a space). Write a program that 
        //checks whether the product of the odd elements is equal to the product of the even elements. 
        //Elements are counted from 1 to n, so the first element is odd, the second is even, etc. Examples:
        //numbers	    result
        //2 1 1 6 3	    yes
        //              product = 6
        //3 10 4 6 5 1	yes
        //              product = 60
        //4 3 2 5 2	    no
        //              odd_product = 16
        //              even_product = 15

        
        int[] n = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();//string[] n = Console.ReadLine().Split();
        int odd = 1;
        int even = 1;
        for (int i = 0; i < n.Length; i++)
        {
            if (i % 2 == 0)
            {
                odd *= n[i]; //odd *= Convert.ToInt32(n[i];)
            }
            else
            {
                even *= n[i]; //even *= Convert.ToInt32(n[i];)
            }
        }
        if (odd == even)
        {
            Console.WriteLine("yes \nproduct = {0}", odd);
        }
        else
        {
            Console.WriteLine("no \nodd_product = {0} \neven_product = {1}", odd, even);
        }
    }
}

