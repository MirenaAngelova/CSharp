﻿using System;
class StudentCables
{
    static void Main()
    {
        //Once at the Software University (SoftUni) we had problems with the Wi-Fi network. It was working well 
        //in the previous days even with a few hundred students browsing Internet in the same time, but at the exam 
        //all the students came with their laptop at fixed time and tried to establish a wireless connection simultaneously. 
        //This flooded the Wi-Fi access points and as a result some of the students were unable to get an IP address 
        //from the DHCP server. They of course established a Wi-Fi Internet connection after a few reconnects in next 
        //5-10 minutes, but were highly stressed because they didn't had Internet immediately before the start the exam start.
        //Nakov, the main driver of SoftUni, decided to solve the problem by connecting some of the students 
        //through a standard network cables. He installed a few network switches in the exam lab and started to prepare 
        //cables for the students. His idea was to use 5 meters long cables (called student cables) between the switches 
        //and the student's laptops. Nakov wanted to create as much as possible cables of size 5 meters. 
        //He had a lot of cables of different sizes, e.g. a big roll of 300 meters, another big roll of 130 meters 
        //and a few small cables of 30 cm, 15 cm and 10 cm. The cables had different sizes and was measured in 
        //different measures (meters or centimeters). Nakov calculated that he needed 2 cm for crimping each RJ45 connector 
        //and 3 cm for joining each two pieces of cable. It was complex to calculate how much cables Nakov can create 
        //so he needs your help.
        //Write a program that takes as an input a sequence of N cables of different sizes and calculates how many 
        //student cables Nakov can create by first joining them all together, then cut them into 5 meters and 4 cm, 
        //and finally crimp the RJ45 connectors to obtain 5 meters long student network cables. Calculate also the length 
        //of the unused remaining cable. Note that cables shorter than 20 cm in the input will be thrown away, so please 
        //discard therm.
        //Input
        //The input data should be read from the console.
        //•	At the first line an integer number n specifying the number of cables will be given.
        //•	At the next 2 * n lines the cables will be given: first comes the cable length; second comes the measure.
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //The output should be printed on the console. It should consist of exactly 2 lines:
        //•	The first line should hold the number of student cables.
        //•	The second line should hold the length of the remaining cable.
        //Constraints
        //•	The number n will be integer in the range [1 … 100].
        //•	The cable length is integer in the range [1 … 500].
        //•	The cable measure is one of the following values: meters, centimeters.
        //•	Allowed working time for your program: 0.1 seconds. Allowed memory: 16 MB.
        //Examples
        //Input	      Output	Comments		                                                      Input	       Output
        //4           3       We have 4 cables: 1100 cm, 18 cm, 800 cm and 120 cm.                    3            1
        //11          502     The 18 cm cable is too short (18 cm < 20 cm), so it is discarded.       116          26
        //meters              We join 1100 cm + 800 cm + 120 cm and we lose 2*3 = 6 cm.               centimeters 
        //18                  We obtain 2014 cm joined cable. We create 3 student cables:             4 
        //centimeters         3 * (5 m cable + 2 cm RJ crimp + 2 cm RJ crimp) = 3 * 504 = 1512 cm.    meters 
        //8                   The remainder is 2014 – 1512 = 502 cm.		                          20 
        //meters                                                                                      centimeters 
        //120                                                                                         
        //centimeters

        int n = int.Parse(Console.ReadLine());
        int joinedCable = 0;
        for (int i = 0; i < n; i++)
        {
            int cableLength = int.Parse(Console.ReadLine());
            string cableMeasure = Console.ReadLine();
            if (cableMeasure == "meters")
            {
                cableLength = cableLength * 100;
            }
            if (cableLength >= 20)
            {
                joinedCable = joinedCable + (cableLength - 2);

            }
        }
        int studentCables = joinedCable / 504;
        int remainder = joinedCable % 504;
        Console.WriteLine(studentCables);
        Console.WriteLine(remainder);
    }
}



