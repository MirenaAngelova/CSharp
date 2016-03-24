using System;
class Volleyball
{
    static void Main()
    {
        //Vladi loves a lot to play volleyball. However, he is a programmer now and he is very busy. 
        //Now he is able to play only in the holidays and in the weekends.
        //Vladi plays in 2/3 of the holidays and each Saturday, but not every weekend – only when he is not at work 
        //and only when he is not going to his hometown. Vladi goes at his hometown h weekends in the year. 
        //The other weekends are considered “normal”. Vladi is not at work in 3/4 of the normal weekends. 
        //When Vladi is at his hometown, he always plays volleyball with his old friends once, at Sunday. In addition, 
        //if the year is leap, Vladi plays volleyball 15% more times additionally. We assume the year has exactly 
        //48 weekends suitable for volleyball.
        //Your task is to write a program that calculates how many times Vladi plays volleyball 
        //(rounded down to the nearest integer number).
        //Input
        //The input data should be read from the console. It consists of three input values, each at separate line:
        //•	The string “leap” for leap year or “normal” for year that is not leap.
        //•	The number p – number of holidays in the year (which are not Saturday or Sunday).
        //•	The number h – number of weekends that Vladi spends in his hometown.
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //•	The output data must be printed on the console.
        //•	On the only output line you must print an integer representing how many times Vladi plays volleyball for a year.
        //Constraints
        //•	The numbers p is in range [0...300] and h is in range [0…48].
        //•	Allowed working time for your program: 0.25 seconds.
        //•	Allowed memory: 16 MB.
        //Examples
        //Input	    Output	    Comments
        //leap      45	        48 weekends total in the year, split into:
        //5                     •	2 hometown weekends  2 Sundays  2 plays
        //2	                    •	46 normal weekends  46 * 3 / 4  34.5 plays
        //                      4 holidays  5 * 2/3  3.33 plays
        //                      Leap year  additional 15% * 39.83  5.97 plays
        //                      Total plays = 45.8 plays  45 (rounded down)
        //
        //Input	    Output		Input	Output		Input	Output		Input	Output		Input	Output
        //normal    38		    leap    43		    normal  44		    leap    41		    normal  43
        //3                     2                   11                  0                   6
        //2                     3                   6		            1                   13
        //

        string year = Console.ReadLine();
        int p = int.Parse(Console.ReadLine());
        int h = int.Parse(Console.ReadLine());

        double plays = h + (48.0 - h) * (3.0 / 4.0) + p * (2.0 / 3.0);
        if (year == "leap")
        {
            double totalPlays = plays + plays * (15.0 / 100.0);
            Console.WriteLine((int)totalPlays);
        }
        else
        {
            Console.WriteLine((int)plays);
        }
    }
}

