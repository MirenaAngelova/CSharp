using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class MatrixShuffle
{
    static void Main()
    {
        //You are given an input string which you should fill in a square spiral matrix with a given size. 
        //After filling up the matrix you should move through it and extract from it all the letters in a chessboard pattern.
        //Your next task is to check if the newly formed sentence, read in lowercase and with all non-letter characters removed,
        //is a palindrome (reading it from left to right is the same as reading it from right to left).
        //Example: You are given the string “Rvioes roi tset ” and a size of 4. You fill the matrix in a spiral as shown below.
        //R	v	i	o
        //t s	e   e
        //      t	s
        //i	o   r
        //After filling it up, extract all letters in a chessboard pattern. Frist extract all white squares, 
        //after that all black squares.
        //R	v	i	o                R	v	i	o
        //t	s	e	e   “Rise to ”   t	s	e	e   +  	“vote sir”
        //      t	s                       t	s
        //i	o	r	                 i	o	r	 
       
        //Result: “Rise to vote sir”.
        //After obtaining the string we must check if it is a palindrome.  “ris etov ot esir” == “rise to vote sir”. 
        //They are equal so we found a palindrome. The output consists of a single “<div>” tag which holds the found sentence. 
        //If the sentence is a palindrome the “div” tag’s background should be set to #4FE000. If the sentence is not 
        //a palindrome its background should be #E0000F.
        //Input
        //The input will be read from the console. The first line will hold a number – the size of the matrix. 
        //The second line will hold the text. The input data will always be valid and in the format described. 
        //There is no need to check it explicitly.
        //Output
        //The output should be an HTML <div> tag that shows the newly found sentence, colored by changing its background 
        //to #E0000F (see the examples below) if the sentence is not a palindrome or #4FE000 if the sentence is a palindrome. 
        //Follow strictly the sample HTML output format below.
        //Constraints
        //•	The text is a non-empty text field.
        //•	 The size is an integer in the range [1 … 9].
        //•	Allowed working time: 0.1 seconds. Allowed memory: 16 MB.

        //Examples
        //Input              Output
        //4                  <div style='background-color:#4FE000'>Rise to vote sir </div>
        //Rvioes roi tset
        //
        //Input                                                             
        //7
        //Soovfetonetem  sssadroedw atrneahr dyri  aUhi stv
        //Output
        //<div style='background-color:#E0000F'>Software University has moved to another address </div>

        int size = int.Parse(Console.ReadLine());
        string text = Console.ReadLine();
        char[,] matrix = new char[size, size];
        int realSize = size;
        int x = 0;
        int y = 0;
        int index = 0;
        string sentence = "";
        while (size > 0)
        {
            for (int i = y; i <= y + size - 1 && index <= text.Length - 1; i++)
            {

                matrix[x, i] = text[index];
                index++;
            }

            for (int j = x + 1; j <= x + size - 1 && index <= text.Length - 1; j++)
            {
                matrix[j, y + size - 1] = text[index];
                index++;
            }

            for (int i = y + size - 2; i >= y && index <= text.Length - 1; i--)
            {
                matrix[x + size - 1, i] = text[index];
                index++;
            }

            for (int i = x + size - 2; i >= x + 1 && index <= text.Length - 1; i--)
            {
                matrix[i, y] = text[index];
                index++;
            }
            x = x + 1;
            y = y + 1;
            size = size - 2;
        }
        for (int i = 0; i < realSize; i++)
        {

            for (int j = i % 2 == 0 ? 0 : 1; j < realSize; j += 2)
            {
                sentence += matrix[i, j];
            }
        }
        for (int i = 0; i < realSize; i++)
        {
            for (int j = i % 2 == 0 ? 1 : 0; j < realSize; j += 2)
            {
                sentence += matrix[i, j];
            }
        }

        string reversed = "";

        string original = sentence.ToLower();
        string regex = Regex.Replace(original, @"[^a-zA-Z]", "");

        for (int i = regex.Length - 1; i >= 0; i--)
        {
            reversed += regex[i].ToString();
        }

        if (reversed == regex)
        {
            Console.WriteLine("<div style='background-color:#4FE000'>{0}</div>", sentence);
        }
        else
        {
            Console.WriteLine("<div style='background-color:#E0000F'>{0}</div>", sentence); 
        }
    }
}