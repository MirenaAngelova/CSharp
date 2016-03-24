using System;
class Electricity
{
    static void Main()
    {
        //In the "Students Town" each flat in the dorms has 8 lamps, each consuming 100.53 Watts 
        //(2 in the kitchen, 3 in the living-room, 1 in the bathroom, 1 in the bedroom and 1 in the lumber-room). 
        //Additionally each flat has 8 computers, each consuming 125.90 Watts 
        //(1 in the kitchen, 2 in the living-room, 1 in the bathroom, 3 in the bedroom and 1 in the lumber-room). 
        //The lamps and computers in each flat always operate in a strict schedule every day:
        //•	From 14:00 to 18:59  2 lamps + 2 computers are running
        //•	From 19:00 to 23:59  7 lamps + 6 computers are running
        //•	From 00:00 to 08:59  1 lamp + 8 computers are running
        //Write a program to calculate how many Watts is the total power consumption of the dorms at given time of the day. 
        //You will be given the number of floors in the dorms and the number of flats at each floor that operate 
        //in the specified time.
        //Input
        //The input data should be read from the console. It consists of exactly 3 lines:
        //•	The first line holds the number of floors – floors.
        //•	The second line holds the number of flats at each floor – flats.
        //•	The third line holds the time of the day in format hh:mm – time.
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //Print at the console the total power consumption in format "X Watts" where X is the total power consumption. 
        //Truncate down the result to the nearest whole number.
        //Constraints
        //•	The number floors is a positive integer in the range [1…30].
        //•	The number flats is a positive integer in the range [1…222].
        //•	The hours hh is a positive integer in the range [0…23]. It might have a leading zero, e.g. "09".
        //•	The minutes mm is a positive integer in the range [0…59]. It might have a leading zero, e.g. "00".
        //•	Allowed working time for your program: 0.25 seconds.
        //•	Allowed memory: 16 MB.
        //Examples
        //Input	Output		    Input	Output		        Input	Output		        Input	Output
        //3     54343 Watts		24      1304236 Watts		30      9717672 Watts		2       0 Watts
        //40                    120                         222                         76
        //18:00	                16:25	                    19:30                       9:00	

        int floors = int.Parse(Console.ReadLine());
        int flats = int.Parse(Console.ReadLine());
        DateTime time = DateTime.Parse(Console.ReadLine());
        double lamp = 100.53;
        double comp = 125.90;
        double consumption = 0.0;
        if ((time.Hour >= 14) & (time.Hour <= 18))
        {
            consumption = (2.0 * lamp + 2.0 * comp) * floors * flats;
        }
        if ((time.Hour >= 19) & (time.Hour <= 23))
        {
            consumption = (7.0 * lamp + 6.0 * comp) * floors * flats;
        }
        if ((time.Hour >= 0) & (time.Hour <= 8))
        {
            consumption = (lamp + 8.0 * comp) * floors * flats;
        }
        Console.WriteLine("{0} Watts", (int)consumption);
    }
}

