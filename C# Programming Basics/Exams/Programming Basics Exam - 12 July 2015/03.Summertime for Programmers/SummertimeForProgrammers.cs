using System;

namespace _03.Summertime_for_Programmers
{
    class SummertimeForProgrammers
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(new string(' ', n / 2) + new string('*', n + 1) + new string(' ', n / 2));
            for (int i = 0; i < n / 2 + 1; i++)
            {
                Console.WriteLine(new string(' ', n / 2) + "*" + new string(' ', n - 1) + "*" + new string(' ', n / 2));
            }
            for (int i = 0; i < n / 2 - 1; i++)
            {
                Console.WriteLine(new string(' ', n / 2 - 1 - i) + "*" + new string(' ', n + 1 + 2 * i) + "*" +
                    new string(' ', n / 2 - 1 - i));
            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("*" + new string('.', n * 2 - 2) + "*");
            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("*" + new string('@', n * 2 - 2) + "*");
            }
            Console.WriteLine(new string('*', n*2));
        }
    }
}
