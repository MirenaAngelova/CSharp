using System;
using System.Collections.Generic;
using System.Linq;
class LongestAreaInArray
{
    static void Main()
    {
        
        
        //Write a program to find the longest area of equal elements in array of strings. 
        //You first should read an integer n and n strings (each at a separate line), then find and print 
        //the longest sequence of equal elements (first its length, then its elements). If multiple sequences 
        //have the same maximal length, print the leftmost of them. Examples:
        //Input	    Output
        //6         3
        //hi        ok
        //hi        ok
        //hello     ok
        //ok
        //ok
        //ok	
        //    
        //2        1  
        //SoftUni  SoftUni 
        //Hello	
        //       
        //4         4
        //hi        hi
        //hi        hi
        //hi        hi
        //hi	    hi
        //
        //5         2
        //wow       hi
        //hi        hi
        //hi        
        //ok        
        //ok	
             

        //int n = int.Parse(Console.ReadLine());
        //string[] arr = new string[n];
        //for (int i = 0; i < arr.Length; i++)
        //{
        //    arr[i] = Console.ReadLine();
        //}
        //int length = 0;
        //string result = null;
        //for (int i = 0; i < arr.Length; i++)
        //{
        //    int count = 0;
        //    for (int j = i; j < arr.Length; j++)
        //    {
        //        if (arr[i] == arr[j])
        //        {
        //            count++;
        //        }
        //        else
        //        {
        //            break;
        //        }
        //    }
        //    if (length < count)
        //    {
        //        length = count;
        //        result = arr[i];
        //    }
        //}
        //Console.WriteLine(length);
        //for (int i = 0; i < length; i++)
        //{
        //    Console.WriteLine(result);
        //}

        int n = int.Parse(Console.ReadLine());
        List<string> arr = new List<string>();
        for (int i = 0; i < n; i++)
        {
            arr.Add(Console.ReadLine());
        }
        var length = arr.GroupBy(x => x).Select(x => new
        {
            Name = x.Key,
            Total = x.Count()
        });
        int count = 0;
        string result = "";
        foreach (var item in length)
        {
            if (item.Total > count)
            {
                count = item.Total;
                result = item.Name;
            }
        }
        Console.WriteLine(count);
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(result);
        }
    }
}

