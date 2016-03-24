using System;
class TravellerBob
{
    static void Main()
    {
        //Bob loves travelling by plane. Thankfully, his job of being a businessman involves traveling a couple of times
        //during the month. Bob is a busy man. He has months when he uses his private jet in order to go and 
        //sign new contracts. In a contract month, he travels 3 times per week. Although Bob loves his work, 
        //he also cares about his family. He spends family months, when he has 1 less travel per week 
        //than a contract month and he travels only 2 weeks. The other months are considered "normal" 
        //during which Bob travels 2/5 less than during contract months.
        //In addition, if the year is leap, Bob travels 5% more overall. Assume that a month has exactly 4 weeks. 
        //Your task is to write a program that calculates how many times Bob travels around the world during the year 
        //(rounded down to the nearest integer number).
        //Input
        //The input data should be read from the console. It consists of three input values, each at separate line:
        //•	The string "leap" for leap year or "normal" for year that is not leap.
        //•	The number c – number of months Bob signs contracts in the year.
        //•	The number f – number of months that Bob spends with his family.
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //The output data must be printed on the console.
        //•	On the only output line you must print the number of travels as integer.
        //Constraints
        //•	The numbers c is in range [0...12] and f is in range [0…12].
        //•	Allowed working time for your program: 0.25 seconds.
        //•	Allowed memory: 16 MB.
        //Examples
        //Input	Output	Comments
        //leap  97	    12 months total in the year, split into:
        //2             •	2 contract months  4 weeks * 3 travels  12 travels * 2 months  24 travels
        //1	            •	1 family month  2 weeks * 2 travels  4 travels
        //              •	9 normal months  12 travels * 9 months 
        //                  108 travels * 3/5  64.8 
        //              Leap year  additional 5%  (64.8 + 24 + 4) * 5%  4.64
        //              Total travels = 97.44  97 travels
        //
        //Input	    Output	Input	Output		Input	Output		Input	Output
        //normal    104		leap    80          leap    110	        normal  83
        //5                 2       	        4                   0
        //2                 6       	        0                   1

        string year = Console.ReadLine();
        int c = int.Parse(Console.ReadLine());
        int f = int.Parse(Console.ReadLine());
        double normal = 12.0 * c + 4.0 * f + (12.0 - c - f) * 12.0 * (3.0 / 5.0);
        //Console.WriteLine(normal);
        double leap = normal + normal * 5.0 / 100.0;
        //Console.WriteLine(leap);
        if (year == "normal")
        {
            Console.WriteLine((int)normal);
        }
        else
        {
            Console.WriteLine((int)leap);
        }
    }
}    

