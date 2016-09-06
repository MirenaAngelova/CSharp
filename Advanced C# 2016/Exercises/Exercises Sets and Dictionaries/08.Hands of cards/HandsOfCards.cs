using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Hands_of_cards
{
    public class HandsOfCards
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<int, HashSet<int>>> handsOfCards =
                new Dictionary<string, Dictionary<int, HashSet<int>>>();
            List<string> power = new List<string>()
            {
                "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"
            };

            List<string> type = new List<string>()
            {
                "0", "C", "D", "H", "S"
            };

            string input = Console.ReadLine();
            while (input != "JOKER")
            {
                string[] splitInput = input.Split(new[] { ':' });
                string name = splitInput[0];
                string[] cards = splitInput[1]
                    .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (!handsOfCards.ContainsKey(name))
                {
                    handsOfCards.Add(name, new Dictionary<int, HashSet<int>>());
                }

                foreach (var card in cards)
                {
                    string powerCard = card.Substring(0, card.Length - 1);
                    string typeCard = card.Substring(card.Length - 1);
                    int powerCardInt = power.IndexOf(powerCard);
                    int typeCardInt = type.IndexOf(typeCard);

                    if (!handsOfCards[name].ContainsKey(powerCardInt))
                    {
                        handsOfCards[name].Add(powerCardInt, new HashSet<int>());
                    }

                    handsOfCards[name][powerCardInt].Add(typeCardInt);
                }

                input = Console.ReadLine();
            }

            foreach (var person in handsOfCards)
            {
                string name = $"{person.Key}: ";
                int sumOfHands = person.Value.Sum(card => card.Key * card.Value.Sum());
                Console.WriteLine(name + sumOfHands);
            }
        }
    }
}
