using System;
class Numerology
{
    static void Main()
    {
        //Numerology involves a lot of repeated calculations, but as a programmer you can automate this process 
        //and earn some easy cash! You will be given the birthdate and username of a random fellow student. 
        //Your task is to calculate a celestial number. Below is a description of the process, see the example 
        //to understand your task better.
        //First, multiply together the numbers representing the day, year and month of the birthdate. 
        //Numerologists love odd numbers, so if the month is an odd number, you should square the result 
        //of the multiplication. Next, add to the result each digit ('0' = 0, '1' = 1… '9' = 9) or the position 
        //in the English alphabet of each letter in the username – e.g. “a” = 1, “b” = 2… “z” = 26. 
        //Capital letters weigh twice as much - the letter “A” will add 1*2 to the sum, “Z” will add 2*26, etc. 
        //13 is a sacral number and your celestial number should be between 0 and 13 inclusive. 
        //So, if the resulting number is greater than 13 you should keep adding its digits together until you get 
        //the coveted celestial number in its final form. Then all you have to do is print it to the console! 
        //Whew! Numerology…
        //Input
        //The input data is read from the console. 
        //•	On the only input line you will be given a date in the format [day.month.year] and a username, 
        //separated by a single space.
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //•	The output data must be printed on the console.
        //•	On the only output line you must print the calculated celestial number.
        //Constraints
        //•	The date will be in format dd.mm.yyyy and between 01.01.1900 and 31.12.2014.
        //•	The username will be between 4 and 20 characters long and will contain only digits (0-9) 
        //and upper-case and lower-case letters from the English alphabet (no hyphens or non-English letters).
        //•	Time limit: 0.25 seconds. Allowed memory: 16 MB.
        //Examples
        //Input	                Output	Comments
        //14.03.1990 Panayot	9	    14 * 3 * 1990 = 83,580;
        //                              03 (odd month) => 83,580 * 83,580 = 6,985,616,400;
        //                              6,985,616,400 + 2 * 16 (P) + 1 (a) + 14 (n) + 1 (a) + 25 (y) + 15 (o) + 20 (t) = 
        //                              6,985,616,508 ( > 13);
        //                              6 + 9 + 8 + 5 + 6 + 1 + 6 + 5 + 0 + 8 = 54 (> 13);
        //                              5 + 4 = 9 (∈ [0, 13] => Done!)
        //
        //Input	            Output		Input	            Output
        //01.01.1914 g0g0	5		    25.05.1997 P360	    6

        string[] input = Console.ReadLine().Split('.', ' ');
        int day = int.Parse(input[0]);
        int month = int.Parse(input[1]);
        int year = int.Parse(input[2]);
        string name = input[3];
        long result = day * month * year;
        if (month % 2 == 1)
        {
            result *= result;
        }
        for (int i = 0; i < name.Length; i++)
        {
            char current = name[i];
            if (current >= '0' && current <= '9')
            {
                result += current - '0';
            }
            else if (current >= 'a' && current <= 'z')
            {
                result += current - 'a' + 1;
            }
            else if (current >= 'A' && current <= 'Z')
            {
                result += (current - 'A' + 1) * 2;
            }
        }
      
        while (result > 13)
        {
            int sum = 0;
            while (result > 0)
            {
                sum += (int)(result % 10);
                result /= 10;
            }
            result = sum;
        }
        Console.WriteLine(result);
    }
}

