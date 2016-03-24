using System;
class MagicWand
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int midPoint = (3 * n + 2) / 2;
        int count = 0;
        for (int i = 0; i < n / 2 + 2; i++)
        {
            for (int j = 0; j < 3 * n + 2; j++)
            {
                if ((j == midPoint - count) | ( j == midPoint + count))
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            count++;
            Console.WriteLine();
        }
        Console.WriteLine(new string('*', n) + new string('.', n + 2) + new string('*', n));
        for (int i = 0; i < n / 2; i++)
        {
            Console.WriteLine(new string('.', i + 1) + "*" + new string('.', (3 * n - 2 - 2 * i)) + "*"
                        + new string('.', i + 1));
        }
        count = n / 2 + 2;
        int counter = n + 2;
        for (int i = 0; i < n / 2; i++)
        {
            for (int j = 0; j < 3 * n + 2; j++)
            {
                if ((j == midPoint - counter) | (j == midPoint + counter) | (j == n) | (j == 2 * n + 1) |
                    (j == midPoint - count) | (j == midPoint + count))
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            count++;
            counter++;
            Console.WriteLine();
        }
        Console.WriteLine(new string('*', n / 2 + 1) + new string('.', n / 2) + "*" + new string ('.', n)
                        + "*" + new string('.', n / 2) + new string('*', n / 2 + 1));
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(new string('.', n) + "*" + new string('.', n) + '*' + new string('.', n));
        }
        Console.WriteLine(new string('.', n) + new string('*', n + 2) + new string('.', n));
    }
}

