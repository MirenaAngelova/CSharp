using System;
using System.Collections.Generic;
using System.Linq;
class ArrayManipulator
{
    static void Main()
    {
        string[] stringArray = Console.ReadLine().Split();
        //int[] intArray = stringArray.Select(int.Parse).ToArray();

        string inputLine = Console.ReadLine();

        while (true)
        {
            string[] inputCommand = inputLine.Split();
            string command = inputCommand[0];
            switch (command)
            {
                case "exchange":
                    ExchangeArray(stringArray, inputCommand);

                    //stringArray.ToList().ForEach(i => Console.Write(i.ToString() + " "));

                    //Console.WriteLine("[{0}]", string.Join(", ", stringArray));
                    break;
                case "max":
                    MaxMinEvenOddElement(stringArray, inputCommand);
                    break;
                case "min":
                    MaxMinEvenOddElement(stringArray, inputCommand);
                    break;
                case "first":
                    FirstLastEvenOddElement(stringArray, inputCommand);
                    break;
                case "last":
                    FirstLastEvenOddElement(stringArray, inputCommand);
                    break;
                case "end":
                    Console.WriteLine("[{0}]", string.Join(", ", stringArray));
                    Environment.Exit(0);
                    break;
            }
            inputLine = Console.ReadLine();
        }
    }

    private static void FirstLastEvenOddElement(string[] stringArray, string[] inputCommand)
    {
        List<int> oddEvenArray = new List<int>();

        int[] intArray = stringArray.Select(int.Parse).ToArray();

        string firstLast = inputCommand[0];
        int count = int.Parse(inputCommand[1]);
        string evenOdd = inputCommand[2];

        bool isMatch = false;

        if (count > intArray.Length)
        {
            Console.WriteLine("Invalid count");
        }
        else
        {
            for (int i = 0; i < intArray.Length; i++)
            {


                bool even = evenOdd == "even" && intArray[i] % 2 == 0;
                bool odd = evenOdd == "odd" && intArray[i] % 2 != 0;

                if (even)
                {
                    oddEvenArray.Add(intArray[i]);
                    isMatch = true;
                }
                else if (odd)
                {
                    oddEvenArray.Add(intArray[i]);
                    isMatch = true;
                }
            }
            if (!isMatch)
            {
                Console.WriteLine("[]");
            }
            else
            {
                if (count >= oddEvenArray.Count)
                {
                    Console.WriteLine("[{0}]", string.Join(", ", oddEvenArray));
                }
                else if (count < oddEvenArray.Count)
                {
                    if (firstLast == "first")
                    {
                        var firstCountItems = oddEvenArray.Take(count);
                        Console.WriteLine("[{0}]", string.Join(", ", firstCountItems));
                    }
                    else if (firstLast == "last")
                    {
                        var lastCountItems = oddEvenArray.Skip(oddEvenArray.Count - count).Take(count);
                        Console.WriteLine("[{0}]", string.Join(", ", lastCountItems));
                    }
                }
            }
        }
    }

    private static void MaxMinEvenOddElement(string[] stringArray, string[] inputCommand)
    {
        List<int> oddEvenArray = new List<int>();
        int[] intArray = stringArray.Select(int.Parse).ToArray();
        string maxMin = inputCommand[0];
        string evenOdd = inputCommand[1];

        int index = 0;
        int maxMinElement;
        bool isMatch = false;

        for (int i = 0; i < intArray.Length; i++)
        {

            bool even = evenOdd == "even" && intArray[i] % 2 == 0;
            bool odd = evenOdd == "odd" && intArray[i] % 2 != 0;
            if (even)
            {
                oddEvenArray.Add(intArray[i]);
                isMatch = true;
            }
            else if (odd)
            {
                oddEvenArray.Add(intArray[i]);
                isMatch = true;
            }
        }

        if (!isMatch)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            if (maxMin == "max")
            {
                maxMinElement = oddEvenArray.Max();
            }
            else //"min"
            {
                maxMinElement = oddEvenArray.Min();
            }
            for (int i = intArray.Length - 1; i >= 0; i--)
            {
                if (intArray[i] == maxMinElement)
                {
                    index = i;
                    Console.WriteLine(index);
                    break;
                }
            }
        }
    }

    private static void ExchangeArray(string[] stringArray, string[] inputCommand)
    {
        List<string> newArray = new List<string>();
        int index = int.Parse(inputCommand[1]);
        
        if (index >= stringArray.Length || index < 0)
        {
            Console.WriteLine("Invalid index");
        }
        else
        {
            for (int i = index + 1; i < stringArray.Length; i++)
            {
                newArray.Add(stringArray[i]);
            }
            for (int i = 0; i < index + 1; i++)
            {
                newArray.Add(stringArray[i]);
            }
            for (int i = 0; i < newArray.Count; i++)
            {
                stringArray[i] = newArray[i];
            }
        }
    }

    //private static void ExecuteExchangeCommand(string[] input, List<int> numbers)
    //{//0 1 2 3 4 ind = 3 length = 5   4 0 1 2 3    1 3 5 7 9   ind 1    5 7 9   1 3
    //    int splitIndex = int.Parse(input[1]);
    //    if (splitIndex < 0 && splitIndex > numbers.Count - 1)
    //    {
    //        Console.WriteLine("Invalid index");
    //        return;
    //    }

    //    int length = numbers.Count;
    //    var first = numbers.Skip(splitIndex + 1).Take(numbers.Count - 1 - splitIndex);
    //    var enumerable = first as IList<int> ?? first.ToList();
    //    numbers.InsertRange(0, enumerable);
    //    numbers.RemoveRange(length, length - 1 - splitIndex);
    //}
}

