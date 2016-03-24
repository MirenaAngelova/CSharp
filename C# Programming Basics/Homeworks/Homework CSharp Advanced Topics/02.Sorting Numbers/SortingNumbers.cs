using System;
class SortingNumbers
{
    static void Main()
    {
        //Write a program that reads a number n and a sequence of n integers, sorts them and prints them. Examples:
        //Input	    Output
        //5         -3
        //3         0
        //-3        2
        //2         3
        //122       122
        //0	
        //
        //3         0
        //0         0
        //1         1
        //0	

        int n = int.Parse(Console.ReadLine());
        int[] sequenceOfN = new int[n];
       

        for (int i = 0; i < n; i++)
        {
            sequenceOfN[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(sequenceOfN);
        
        //for (int i = 0; i < sequenceOfN.Length - 1; i++)
        //{
        //    for (int j = i + 1; j < sequenceOfN.Length; j++)
        //    {
        //        if (sequenceOfN[i] > sequenceOfN[j])
        //        {
        //            int temporary = sequenceOfN[i];
        //            sequenceOfN[i] = sequenceOfN[j];
        //            sequenceOfN[j] = temporary;
        //        }
        //    }
        //}

        Console.WriteLine(String.Join("\n", sequenceOfN));
    }
}

