using System;
using System.Text.RegularExpressions;

class Enigma
{
    static void Main()
    {
        int count = int.Parse(Console.ReadLine());
        for (int i = 0; i < count; i++)
        {
            string message = Console.ReadLine();
            string result = new Regex("\\s*\\d*").Replace(message, String.Empty);
            for (int j = 0; j < message.Length; j++)
            {
                char symbol = message[j];

                if (char.IsDigit(symbol))
                {
                    Console.Write(symbol);
                }
                else if (char.IsWhiteSpace(symbol))
                {
                    Console.Write(symbol);
                }
                else
                {
                    Console.Write((char) (symbol + result.Length/2));
                }

            }

            Console.WriteLine();
        }
    }
}

