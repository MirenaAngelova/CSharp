using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Count_Symbols
{
    public class CountSymbols
    {
        public static void Main()
        {
            string text = Console.ReadLine();
           Dictionary<char, int> characters = new Dictionary<char, int>();
            foreach (var character in text)
            {
                if (!characters.ContainsKey(character))
                {
                    characters.Add(character, 0);
                }

                characters[character]++;
            }

            foreach (var character in characters.OrderBy(ch => ch.Key))
            {
                Console.WriteLine($"{character.Key}: {character.Value} time/s");
            }
        }
    }
}
