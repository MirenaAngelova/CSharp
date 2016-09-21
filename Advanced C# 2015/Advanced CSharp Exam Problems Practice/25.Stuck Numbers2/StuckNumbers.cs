using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25.Stuck_Numbers2
{
    class StuckNumbers
    {
        static void Main(string[] args)
        {
            int countOfNumbers = int.Parse(Console.ReadLine());
            string[] numbers = Console.ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> stuckNumbers = new List<string>();
            foreach (var a in numbers)
            {
                foreach (var b in numbers)
                {
                    foreach (var c in numbers)
                    {
                        stuckNumbers.AddRange(from d in numbers
                                              where a != b && a != c && a != d && b != c && b != d &&
                                              c != d
                                              where a + b == c + d
                                              select $"{a}|{b}=={c}|{d}");
                    }
                }
            }

            Console.WriteLine(!stuckNumbers.Any() ? "No" :
                string.Join(Environment.NewLine, stuckNumbers));
        }
    }
}
