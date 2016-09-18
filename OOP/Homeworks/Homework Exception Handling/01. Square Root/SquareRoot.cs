using System;

namespace _01.Square_Root
{
    class SquareRoot
    {
        static void Main()
        {
            try
            {
                uint num = uint.Parse(Console.ReadLine());
                double sqrt = Math.Sqrt(num);
                Console.WriteLine(sqrt);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid number");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
