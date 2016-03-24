using System;
using System.Linq;
class RemoveNames
{
    static void Main()
    {
        //Write a program that takes as input two lists of names and removes from the first list all names 
        //given in the second list. The input and output lists are given as words, separated by a space, 
        //each list at a separate line. Examples:
        //Input                                     	Output
        //Peter Alex Maria Todor Steve Diana Steve      Peter Alex Maria Diana
        //Todor Steve Nakov	                        
        //Hristo Hristo Nakov Nakov Petya               Hristo Hristo Petya
        //Nakov Vanessa Maria	

        string[] firstList = Console.ReadLine().Split();
        string[] secondList = Console.ReadLine().Split();
        var withoutSecond = firstList.Where(x => !secondList.Contains<string>(x));
        foreach (var item in withoutSecond)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}

