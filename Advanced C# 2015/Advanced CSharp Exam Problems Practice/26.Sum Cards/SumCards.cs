using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _26.Sum_Cards
{
    class SumCards
    {
        static void Main(string[] args)
        {
            string[] inputLine = Console.ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> input = inputLine
                .Select(s => new Regex("[SHDC]").Replace(s, string.Empty)).ToList();

            List<string> cards = new List<string>()
            {"$", "$", "2", "3", "4", "5", "6", "7", "8", "9", "10", "$", "J", "Q", "K", "A"};

            long sum = 0;
            int countedTwice = 2;
            for (int i = 0; i < input.Count; i++)
            {
                int count = 1;
                int amountOfCard = cards.IndexOf(input[i]);
                while (i + 1 < input.Count && input[i] == input[i + 1])
                {
                    count++;
                    i++;
                }

                sum += count == 1 ? amountOfCard : amountOfCard * count * countedTwice;
            }

            Console.WriteLine(sum);
        }
    }
}
