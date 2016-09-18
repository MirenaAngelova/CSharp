using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Enter_Numbers
{
    class EnterNumbers
    {
        static List<int> numbers = new List<int>(); 
        static void Main()
        {
            int start = 1;
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    int num = int.Parse(Console.ReadLine());
                    ReadNumber(start, 99, num, i);
                    start = num;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Number should be between {0} and 100(exclusive)", start);
                    i--;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Enter a valid integer!");
                    i--;
                }
                catch (InsufficientArgumentException)
                {
                    Console.WriteLine("Not enough numbers left.");
                    i--;
                }
                Console.WriteLine("Numbers:{0}", string.Join(", ", numbers));
            }
        }

        static void ReadNumber(int start, int end, int number, int position)
        {
            if (number <= start || number > end)
            {
                throw new ArgumentOutOfRangeException("number", string.Format("Number should between {0} and 99", start));
            }
            start = number;
            if ((end - start) < (9 - position))
            {
                throw new InsufficientArgumentException("Not enough numbers left.");
            }
            numbers.Add(number);
        }
    }
}
