using System;

namespace _01.Day_of_Week
{
    public class DayOfWeek
    {
        public static void Main()
        {
            string[] dayOfWeek = 
                {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};

            int day = int.Parse(Console.ReadLine());
            for (int i = 0; i < dayOfWeek.Length; i++)
            {
                if (day == i + 1)
                {
                    Console.WriteLine(dayOfWeek[i]);
                    return;
                }
            }

            Console.WriteLine("Invalid Day!");
        }
    }
}
