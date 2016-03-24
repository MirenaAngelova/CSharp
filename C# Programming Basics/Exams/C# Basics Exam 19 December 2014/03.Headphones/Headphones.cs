using System;
class Headphones
{
    static void Main()
    {
        //Stamat really loves all kinds of music. He listens to music all the time. He even dreams of it. 
        //One day he decided to start programming. The only way he can write code is while listening to music 
        //(and singing… and even dancing). 
        //Your task is to help Stamat write a program that prints his headphones on the console using only asterisks '*' 
        //and dashes '-'. And since his headphones are very special they have a diameter. See the example below 
        //to better understand how the diameter affects the headphones' size.
        //--*******--   
        //--*-----*--   -> height = 5
        //--*-----*--
        //--*-----*--
        //--*-----*--
        //--*-----*--
        //-***---***-
        //*****-*****   -> horizontal diameter = 5
        //-***---***-   -> vertical diameter = 5
        //--*-----*--
        //Input
        //The input data consists of only 1 line: the diameter of Stamat's headphones.
        //Output
        //The output data should be printed on the console.
        //Constraints
        //•	The diameter of Stamat's headphones will always be an odd number in the range [3..29].
        //•	Allowed work time: 0.1 seconds.
        //•	Allowed memory: 16 MB.
        //Examples
        //Input	Output		    Input	Output
        //5	    --*******--     7	---*********---
        //      --*-----*--         ---*-------*---
        //      --*-----*--         ---*-------*---
        //      --*-----*--         ---*-------*---
        //      --*-----*--         ---*-------*---
        //      --*-----*--         ---*-------*---
        //      -***---***-         ---*-------*---
        //      *****-*****         ---*-------*---
        //      -***---***-         --***-----***--
        //      --*-----*--         -*****---*****-		
        //                          *******-*******
        //                          -*****---*****-
        //                          --***-----***--
        //                          ---*-------*---
        int n = int.Parse(Console.ReadLine());
        int midPoint = (n * 2 + 1) / 2;
        int count = n / 2 + 1;
        Console.WriteLine(new string('-', n / 2) + new string('*', n + 2) + new string('-', n / 2));
        for (int i = 0; i < n - 1; i++)
        {
            Console.WriteLine(new string('-', n / 2) + "*" + new string('-', n) + "*" + new string('-', n / 2));
        }
        for (int i = 0; i <= n / 2 ; i++)
        {
            Console.WriteLine(new string('-', n / 2 - i) + new string('*', (2 * i + 1)) +
                new string('-', n - 2 * i) + new string('*', (2 * i + 1)) + new string('-', n / 2 - i));
        }
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Console.WriteLine(new string('-', n / 2 - i) + new string('*', 2 * i + 1) +
                new string('-', n - 2 * i) + new string('*', 2 * i + 1) + new string('-', n / 2 - i));
        }
    }
}

