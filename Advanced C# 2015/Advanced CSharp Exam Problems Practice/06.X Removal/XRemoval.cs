using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class RemovalX
{
    static void Main()
    {
        //You are given a sequence of text lines, holding only visible symbols, small and capital Latin letters. 
        //Your task is to remove all X shapes in the text. They may consist of small and capital letters at the same time, 
        //or any visible symbol. All of the X shapes below are valid:
        //a a   B B     T T     p p     & &     * *
        // a     B       t       P       &       *
        //a a   B B     T t     p P     & &     * *	etc.
        //
        //An X Shape is 3 by 3 symbols crossing each other on 3 lines. A single X shape can be part of multiple X shapes. 
        //If new X Shapes are formed after the first removal you don't have to remove them.
        //Input
        //The input data comes as comes from the console on a variable number of lines, ending with the keyword "END".
        //Output
        //Print at the console the input data after removing all X shapes.
        //Constraints
        //•	Each input line will hold between 1 and 100 Latin letters.
        //•	The number of input lines will be in the range [1 ... 100].
        //•	Allowed working time: 0.1 seconds. Allowed memory: 16 MB.
        //Examples
        //Input	        Output		Input	    Output	Input	        Output		Input	    Output
        //abnbjs        anjs        8888888     888     ^u^             u           puoUdai     podai
        //xoBab         xoa         08*8*80     00      j^l^a           jl^a        miU         mi
        //Abmbh         Amh         808*888     08      ^w^WoWl         ol          ausupirina  aspirina
        //aabab         aaa         0**8*8?     0*?     adw1w6          ad16        8n8i8       ni
        //ababvvvv      aavvvv      END	                (WdWoWgPoop)    (dogPoop)   m8o8a       moa
        //END	                                        END	                        8l8o860     lo60
        //                                                                          M8i8        Mi
        //                                                                          8e8!8?!     e!?!
        //                                                                          END	   

        List<char[]> matrix = new List<char[]>();
        List<char[]> newMatrix = new List<char[]>();
        string str = Console.ReadLine();
        while (str != "END")
        {
            matrix.Add(str.PadRight(100, ' ').ToLower().ToCharArray());
            newMatrix.Add(str.PadRight(100, ' ').ToCharArray());
            str = Console.ReadLine();
        }
        for (int i = 0; i < matrix.Count - 2; i++)
        {
            for (int j = 0; j < matrix[i].Length - 2; j++)
            {
                if (matrix[i][j] == matrix[i][j + 2] & matrix[i][j] == matrix[i + 1][j + 1] &
                    matrix[i][j] == matrix[i + 2][j] & matrix[i][j] == matrix[i + 2][j + 2])
                {
                    newMatrix[i][j] = ' ';
                    newMatrix[i][j + 2] = ' ';
                    newMatrix[i + 1][j + 1] = ' ';
                    newMatrix[i + 2][j] = ' ';
                    newMatrix[i + 2][j + 2] = ' ';
                }
            }
        }
        foreach (var i in newMatrix)
        {
            foreach (var j in i)
            {
                if (j != ' ')
                {
                    Console.Write(j);
                }
            }
            Console.WriteLine();
        }
    }
}