using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Split_by_Word_Casing
{
    public class SplitByWordCasing
    {
        public static void Main()
        {//, ; : . ! ( ) " ' \ / [ ]
            char[] separators =
            {
                ',', ';', ':', '.', '!', '(', ')', '\"', '\'', '\\', '[', ']', '/', ' '
            };

            string[] text = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            List<string> lowerCaseWords = new List<string>();
            List<string> upperCaseWords = new List<string>();
            List<string> mixedCaseWords = new List<string>();

            foreach (var word in text)
            {
                if (word.All(char.IsLower))
                {
                    lowerCaseWords.Add(word);
                }
                else if (word.All(char.IsUpper))
                {
                    upperCaseWords.Add(word);
                }
                else
                {
                    mixedCaseWords.Add(word);
                }
            }

            Console.WriteLine($"Lower-case: {string.Join(", ", lowerCaseWords)}");
            Console.WriteLine($"Mixed-case: {string.Join(", ", mixedCaseWords)}");
            Console.WriteLine($"Upper-case: {string.Join(", ", upperCaseWords)}");
        }
    }
}
