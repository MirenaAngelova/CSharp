using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Hands_of_cards_2
{
    public class HandsOfCards
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<int, HashSet<int>>> handsOfCards =
                new Dictionary<string, Dictionary<int, HashSet<int>>>();

            string input = Console.ReadLine();
            while (input != "JOKER")
            {
                string name = input.Split(':')[0];
                string[] cards = input.Split(':')[1].Replace("10", "1")
                    .Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);

                if (!handsOfCards.ContainsKey(name))
                {
                    handsOfCards.Add(name, new Dictionary<int, HashSet<int>>());
                }

                foreach (var card in cards)
                {
                    string power = card[0].ToString();
                    string type = card[1].ToString();

                    int powerInt = ConvertPowerToInt(power);
                    int typeInt = ConvertTypeToInt(type);
                    if (!handsOfCards[name].ContainsKey(powerInt))
                    {
                        handsOfCards[name].Add(powerInt, new HashSet<int>());
                    }

                    handsOfCards[name][powerInt].Add(typeInt);
                }

                input = Console.ReadLine();
            }

            foreach (var hand in handsOfCards)
            {
                string name = $"{hand.Key}: ";
                int handsSum = hand.Value.Sum(card => card.Key*card.Value.Sum());
                Console.WriteLine(name + handsSum);
            }
        }

        private static int ConvertTypeToInt(string type)
        {
            switch (type)
            {
                case "C":
                    return 1;
                    break;
                case "D":
                    return 2;
                    break;
                case "H":
                    return 3;
                    break;
                case "S":
                    return 4;
                    break;
                default:
                    return 0;
            }
        }

        private static int ConvertPowerToInt(string power)
        {
            switch (power)
            {
                case "1":
                    return 10;
                    break;
                case "J":
                    return 11;
                    break;
                case "Q":
                    return 12;
                    break;
                case "K":
                    return 13;
                    break;
                case "A":
                    return 14;
                    break;
                default:
                    return int.Parse(power);
            }
        }
    }
}
