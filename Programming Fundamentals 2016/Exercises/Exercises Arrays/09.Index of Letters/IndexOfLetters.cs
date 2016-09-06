using System;

namespace _09.Index_of_Letters
{
    public class IndexOfLetters
    {
        public static void Main()
        {
            char[] charSequence = Console.ReadLine().ToCharArray();

            foreach (var ch in charSequence)
            {
                Console.WriteLine($"{ch} -> {ch - 'a'}");
            }
        }
    }
}
