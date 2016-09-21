using System;

class StuckNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        string[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        bool hasStuckNum = false;

        foreach (var a in numbers)
        {
            foreach (var b in numbers)
            {
                foreach (var c in numbers)
                {
                    foreach (var d in numbers)
                    {
                        if (a != b && a != c && a != d && b != c && b != d && c != d)
                        {
                            if (a + b == c + d)
                            {
                                //Console.WriteLine(string.Join("|", a, b) + "==" + string.Join("|", c, d));
                                Console.WriteLine(string.Format("{0}|{1}=={2}|{3}", a, b, c, d));

                                hasStuckNum = true;
                            }
                        }
                    }
                }
            }
        }

        if (!hasStuckNum)
        {
            Console.WriteLine("No");
        }
    }
}

