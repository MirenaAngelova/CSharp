using System;

namespace _10.Extract_Middle_1__2_or_3_Elements
{
    public class ExtractMiddleElements
    {
        public static void Main()
        {
            string[] array = Console.ReadLine().Split();
            int len = array.Length;
            if (len == 1)
            {
                Console.WriteLine($"{{ {array[0]} }}");
            }
            else if (len % 2 == 0)
            {
                Console.WriteLine($"{{ {array[len / 2 - 1]}, {array[len / 2]} }}");
            }
            else
            {
                Console.Write("{ ");
                for (int i = 0; i < 3; i++)
                {
                    Console.Write(array[len/2 - 1 + i]);
                    if (i != 2)
                    {
                        Console.Write(", ");
                    }
                }

                Console.Write(" }");
                Console.WriteLine();
            }
        }
    }
}
