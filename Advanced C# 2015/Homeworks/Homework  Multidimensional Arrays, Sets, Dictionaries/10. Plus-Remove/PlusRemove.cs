using System;
using System.Collections.Generic;
class PlusRemove
{
    static void Main()
    {
        //You are given a sequence of text lines, holding symbols, small and capital Latin letters. Your task is to remove 
        //all "plus shapes" in the text. They may consist of small and capital letters at the same time, or of any symbol. 
        //All of the X shapes below are valid:
        // a        B     T       p       &    *
        //aaa      BBB   TtT     PPp	 &&&  ***
        // a        B	  T	      P	      &	   *	etc.
        //Every "plus shape" is 3 by 3 symbols crossing each other on 3 lines. Single "plus shape" can be part of multiple
        //"plus shapes". If new "plus shapes" are formed after the first removal you don't have to remove them.
        //Input
        //The input data will be received from the console. It consists of variable number of lines. The input ends with 
        //the string "END" (it should not be taken into account in the program logic).
        //Output
        //Print at the console the input data after removing all "plus shapes".
        //Constraints
        //•	Each input line will hold between 1 and 100 Latin letters.
        //•	The number of input lines will be in the range [1 ... 100].
        //•	Allowed working time: 0.2 seconds. Allowed memory: 16 MB.
        //Examples
        //Input	         Output		Input	    Output		 Input	        Output
        //ab**l5         a**l       888**t*     8***         @s@a@p@una     @sapuna
        //bBb*555        *          8888ttt                  p@@@@@@@@dna   p@dna
        //absh*5         as*        888ttt<<	<<           @6@t@*@*ego    @6tego
        //ttHHH          tt         *8*0t>>hi   **0>>hi      vdig*****ne6   vdigne6
        //ttth           ttt        END	   	                 li??^*^*       li??^^
        //END	                                             END	      

        List<string> lines = new List<string>();
        List<string> removing = new List<string>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "END")
            {
                break;
            }
            else
            {
                lines.Add(input);
                removing.Add(input);
            }
        }

        for (int i = 0; i < lines.Count - 2; i++)
        {
            string first = lines[i];
            string second = lines[i + 1];
            string third = lines[i + 2];

            int lengthFirsts = first.Length;
            int lengthSecond = second.Length;
            int lengthThird = third.Length;

            for (int j = 1; j < Math.Min(Math.Min(lengthFirsts, lengthSecond), lengthThird) && j < lengthSecond - 1; j++)
            {
                var plus = CheckPlus(j, first, second, third);
                if (plus)
                {
                    Removing(removing, i, j); 
                }
            }
        }
        PrintAfterRemoving(removing);
    }
    private static bool CheckPlus(int j, string first, string second, string third)
    {
        string up = first.Substring(j, 1).ToLower();
        string middle = second.Substring(j - 1, 3).ToLower();
        string down = third.Substring(j, 1).ToLower();

        string match = new string(up[0], 3);
        bool plus = up == down && middle == match;

        return plus;
    }
    private static void Removing(List<string> removing, int i, int j)
    {
        removing[i] = removing[i].Remove(j, 1).Insert(j, "M");
        removing[i + 1] = removing[i + 1].Remove(j - 1, 3).Insert(j - 1, new string('M', 3));
        removing[i + 2] = removing[i + 2].Remove(j, 1).Insert(j, "M");
    }
    private static void PrintAfterRemoving(List<string> removing)
    {
        for (int i = 0; i < removing.Count; i++)
        {
            removing[i] = removing[i].Replace("M", "");
            Console.WriteLine(removing[i]);
        }
    }
}
