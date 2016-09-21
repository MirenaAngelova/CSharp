using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
    class UppercaseWords
    {
        static void Main()
        {
            List<string> patterns = new List<string>();
            List<string> reverses = new List<string>();

            while (true)
            {
                string lines = Console.ReadLine();

                if (lines == "END")
                {
                    break;
                }

                MatchUppercaseWords(lines, patterns, reverses);

                lines = UppercaseWordsReverse(lines, patterns, reverses);

                Console.WriteLine(SecurityElement.Escape(lines));
            }
        }
        private static string UppercaseWordsReverse(string lines, List<string> patterns, List<string> reverses)
        {
            for (int i = 0; i < patterns.Count; i++)
            {
                lines = Regex.Replace(lines, patterns[i], word => reverses[i]);
            }

            return lines;
        }
        private static void MatchUppercaseWords(string lines, List<string> patterns, List<string> reverses)
        {
            string pattern = @"(?<![A-Za-z])([A-Z]+)(?![A-Za-z])";
            Regex rgx = new Regex(pattern);
            MatchCollection matches = rgx.Matches(lines);

            for (int i = 0; i < matches.Count; i++)
			{
                string word = matches[i].Groups[1].Value;
                string reverse = word;

                if (IsPalyndrome(word))
                {
                    reverse = DoubleLetters(reverse);
                }
                else
                {
                    reverse = Reverse(word, reverse);
                }
                reverses.Add(reverse);
                patterns.Add("(?<![A-Za-z])(" + word + ")(?![A-Za-z])");
            }
        }
        private static string Reverse(string word, string reverse)
        {
            reverse = string.Join("", word.Reverse());
            return reverse;
        }
        private static bool IsPalyndrome(string word)
        {
            if (word.Length == 1)
            {
                return true;
            }

            for (int i = 0; i < word.Length / 2; i++)
            {
                if (word[i] != word[word.Length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }
        private static string DoubleLetters(string reverse)
        {
            string patternDouble = @"[A-Z]";

            reverse = Regex.Replace(reverse, patternDouble, x => string.Format("{0}{0}", x));

            return reverse;
        }
    }

