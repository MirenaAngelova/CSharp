using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _45.Pythagorean_Numbers
{
    class VideoDurations
    {
        static void Main(string[] args)
        {
            int minutesCounter = 0;
            int hoursCounter = 0;

            string input = Console.ReadLine();
            while (input != "End")
            {
                int[] inputLine = input.Split(':').Select(int.Parse).ToArray();
                int hours = inputLine[0];
                int minutes = inputLine[1];

                hoursCounter += hours;
                minutesCounter += minutes;

                if (minutesCounter > 59)
                {
                    hoursCounter++;
                    minutesCounter -= 60;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(minutesCounter < 10
                ? $"{hoursCounter}:0{minutesCounter}"
                : $"{hoursCounter}:{minutesCounter}");

            //string hour = hoursCounter.ToString();
            //string minute = minutesCounter.ToString();

            //if (minute.Length < 2)
            //{
            //    minute = '0' + minute;
            //}

            //Console.WriteLine($"{hour}:{minute}");
        }
    }
}
