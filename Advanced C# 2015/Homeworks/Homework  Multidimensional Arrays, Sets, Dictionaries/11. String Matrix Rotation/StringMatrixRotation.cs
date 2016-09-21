using System;
using System.Collections.Generic;
using System.Linq;
class StringMatrixRotation
{
    static void Main()
    {

        //You are given a sequence of text lines. Assume these text lines form a matrix of characters 
        //(pad the missing positions with spaces to build a rectangular matrix). Write a program to rotate the matrix by 90, 
        //180, 270, 360, … degrees. Print the result at the console as sequence of strings. Examples:
        //Input	     Rotate(90)	            Rotate(180)	    Rotate(270)
        //hello       esh                       maxe            i
        //softuni     xoe                    inutfos            n
        //exam	 	  afl                      olleh           ou
        //            mtl                                     ltm
        //             uo                                     lfa
        //             n                                      eox
        //             i                                      hse
        //Input
        //The input is read from the console:
        //•	The first line holds a command in format "Rotate(X)" where X are the degrees of the requested rotation.
        //•	The next lines contain the lines of the matrix for rotation.
        //•	The input ends with the command "END".
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //Print at the console the rotated matrix as a sequence of text lines.
        //Constraints
        //•	The rotation degrees is positive integer in the range [0…90000], where degrees is multiple of 90.
        //•	The number of matrix lines is in the range [1…1 000].
        //•	The matrix lines are strings of length 1 … 1 000.
        //•	Allowed working time: 0.2 seconds. Allowed memory: 16 MB.
        //Examples
        //Input	         Output		Input	        Output		 Input          Output
        //Rotate(90)     esh        Rotate(180)        maxe      Rotate(270)     i 
        //hello          xoe        hello           inutfos      hello           n 
        //softuni        afl        softuni           olleh      softuni        ou 
        //exam	         mtl        exam	                     exam	        ltm 
        //                uo                                                    lfa
        //                n                                                     eox
        //                i                                                     hse
        //
        //Input	           Output		 Input	        Output		Input	    Output
        //Rotate(720)       js           Rotate(810)    ej          Rotate(0)   js
        //js                exam         js             xs          js          exam
        //exam	                         exam	        a           exam	    
        //                                              m	
        List<string> lines = new List<string>();
        string[] command = Console.ReadLine().Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);

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
            }
        }

        int firstDim = lines.Count;
        var sorted = from s in lines
                     orderby s.Length descending
                     select s;
        int secondDim = sorted.First().Length;
        char[,] matrix = To2D(lines, firstDim, secondDim);

        int degrees = int.Parse(command[1]);
        switch (degrees % 360)
        {
            case 0:
                PrintMatrix(matrix);
                break;
            case 90:
                Rotate90(matrix);
                break;
            case 180:
                Rotate180(matrix);
                break;
            case 270:
                Rotate270(matrix);
                break;

        }
    }
    static char[,] To2D(List<string> source, int N, int M)
    {
        var result = new char[N, M];
        for (int row = 0; row < N; ++row)
        {
            for (int col = 0; col < M; ++col)
            {
                result[row, col] = source[row].PadRight(M, ' ')[col];
            }
        }
        return result;
    }
    private static void PrintMatrix(char[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
    private static void Rotate90(char[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            for (int j = matrix.GetLength(0) - 1; j >= 0; j--)
            {
                Console.Write(matrix[j, i]);
            }
            Console.WriteLine();
        }
    }
    private static void Rotate180(char[,] matrix)
    {
        for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
        {
            for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
            {
                Console.Write(matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
    private static void Rotate270(char[,] matrix)
    {
        for (int i = matrix.GetLength(1) - 1; i >= 0; i--)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                Console.Write(matrix[j, i]);
            }
            Console.WriteLine();
        }
    }
}

