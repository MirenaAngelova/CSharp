using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

class PlusRemove
{
    static void Main()
    {
        //You are given a sequence of text lines, holding symbols, small and capital Latin letters. 
        //Your task is to remove all "plus shapes" in the text. They may consist of small and capital letters at the same time,
        //or of any symbol. All of the X shapes below are valid:
        // a     B    T     p    &     *
        //aaa   BBB  TtT   PPp  &&&   ***
        // a	 B	  T	    P	 &	   *	
        //Every "plus shape" is 3 by 3 symbols crossing each other on 3 lines. Single "plus shape" can be part of 
        //multiple "plus shapes". If new "plus shapes" are formed after the first removal you don't have to remove them.
        //Input
        //The input data will be received from the console. It consists of variable number of lines. 
        //The input ends with the string "END".
        //Output
        //Print at the console the input data after removing all "plus shapes".
        //Constraints
        //•	Each input line will hold between 1 and 100 Latin letters.
        //•	The number of input lines will be in the range [1 ... 100].
        //•	Allowed working time: 0.2 seconds. Allowed memory: 16 MB.
        //Examples
        //Input	    Output		Input	    Output	   Input	        Output
        //ab**l5    a**l        888**t*     8***       s@a@p@una        @sapuna 
        //bBb*555   *           8888ttt                p@@@@@@@@dna     p@dna
        //absh*5    as*         888ttt<<    <<         @6@t@*@*ego      @6tego
        //ttHHH     tt          *8*0t>>hi   **0>>hi    vdig*****ne6     vdigne6
        //ttth	    ttt	                               li??^*^*	        li??^^
       
        List<char[]> lines = new List<char[]>();
        List<char[]> compare = new List<char[]>();
        do
        {
            string line = Console.ReadLine();
            if (line == "END")
            {
                break;
            }
            lines.Add(line.ToCharArray());
            compare.Add(line.ToCharArray());
        } while (true);

        for (int i = 0; i < lines.Count - 2; i++)
        {
            string line1 = new string(compare[i]).ToLower();
            string line2 = new string(compare[i + 1]).ToLower();
            string line3 = new string(compare[i + 2]).ToLower();

            for (int j = 1; j < lines[i].Length; j++) //j start from 1 because of j - 1
            {//line1, line2 and line3 has different lengths
                bool index = (j > line2.Length - 2) || (j > line3.Length - 1);      //true, passing if statement and return 
                if (index)  //(j + 2) > line2.Length | (j + 1) > line3.Length       //to for-loop, where j++, until the loop
                {           //if j = 0 => j + 1 > line2.Length | j > line3.Length   //and do nothing, only j++; 
                    continue; //because of plus
                }   //or break;
                bool bySymbols = (line1[j] == line2[j]) &&
                    (line1[j] == line2[j - 1]) &&
                    (line1[j] == line2[j + 1]) &&
                    (line1[j] == line3[j]);

                if (bySymbols)
                {
                    lines[i][j] = ' ';
                    lines[i + 1][j] = ' ';
                    lines[i + 1][j - 1] = ' ';
                    lines[i + 1][j + 1] = ' ';
                    lines[i + 2][j] = ' ';
                }
            }
        }

        for (int i = 0; i < lines.Count; i++)
        {
            lines[i] = lines[i].Where(x => !char.IsWhiteSpace(x)).ToArray();
            Console.WriteLine(string.Join("", lines[i]));
        }
    }
}