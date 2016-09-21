using System;
using System.Linq;
class TerroristWin
{
    static void Main()
    {
        //On de_dust2 terrorists have planted a bomb (or possibly several of them)! Write a program that sets 
        //those bombs off! A bomb is a string in the format |...|. When set off, the bomb destroys all characters inside. 
        //The bomb should also destroy n characters to the left and right of the bomb. n is determined by the bomb power 
        //(the last digit of the ASCII sum of the characters inside the bomb). Destroyed characters should be replaced by '.'
        //(dot). For example, we are given the following text:
        //prepare|yo|dong
        //The bomb is |yo|. We get the bomb power by calculating the last digit of the sum: y (121) + o (111) = 232. 
        //The bomb explodes and destroys itself and 2 characters to the left and 2 characters to the right. The result is:
        //prepa........ng
        //Input
        //The input data should be read from the console. On the first and only input line you will receive the text. 
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //The destroyed text should be printed on the console.
        //Constraints
        //•	The length of the text will be in the range [1...1000].
        //•	The bombs will hold a number of characters in the range [0…100].
        //•	Bombs will not be nested (i.e. bomb inside another bomb).
        //•	Bomb explosions will never overlap with other bombs.
        //•	Time limit: 0.3 sec. Memory limit: 16 MB. 
        //Examples
        //Input	            Output
        //prepare|yo|dong	prepa........ng
	
        //Input	                            Ouput
        //de_dust2 |A| the best |BB|map!	de_d.............bes........p!

        string input = Console.ReadLine();
        int firstSymbol = input.IndexOf('|');
        int secondSymbol = 0;
        int asciiSum = 0;
        int n = 0;

        while (firstSymbol != -1)
        {
            secondSymbol = input.IndexOf('|', firstSymbol + 1);
            int bombLength = secondSymbol - firstSymbol - 1;
            string bomb = input.Substring(firstSymbol + 1, bombLength);
            asciiSum = bomb.ToCharArray().Select(c => (int)c).Sum();
            n = asciiSum % 10;

            int startSymbol = firstSymbol - n;
            int endSymbol = secondSymbol + n;

            startSymbol = startSymbol > 0 ? startSymbol : 0;
            endSymbol = endSymbol < input.Length ? endSymbol : input.Length - 1;

            int destroyedChars = endSymbol - startSymbol + 1;
            input = input.Remove(startSymbol, destroyedChars).Insert(startSymbol, new string('.', destroyedChars));

            firstSymbol = input.IndexOf('|', secondSymbol + 1);
        }
        Console.WriteLine(input);
    }
}