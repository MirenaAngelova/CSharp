using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class StringMatrixRotation
{
    static void Main()
    {
        //You are given a sequence of text lines. Assume these text lines form a matrix of characters 
        //(pad the missing positions with spaces to build a rectangular matrix). Write a program to rotate 
        //the matrix by 90, 180, 270, 360, … degrees. Print the result at the console as sequence of strings. Examples:
        //Input	    Rotate(90)	    Rotate(180)	    Rotate(270)
        //hello     esh             maxe             i
        //softuni   xoe          inutfos             n
        //exam	    afl	 	       olleh            ou
 		//	        mtl                             ltm
        //           uo                             lfa
        //           n                              eox
        //           i                              hse
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
        //Input	        Output		Input	    Output		Input	        Output
        //Rotate(90)    esh         Rotate(180)   maxe      Rotate(270)      i 
        //hello         xoe         hello      inutfos      hello            n 
        //softuni       afl         softuni      olleh      softuni         ou 
        //exam	        mtl         exam	                exam	        ltm  
        //               uo                                                 lfa
        //               n                                                  eox
        //               i                                                  hse
        //
        //Input	        Output	 Input	        Output	Input	    Output
        //Rotate(720)   js       Rotate(810)    ej      Rotate(0)   js
        //js            exam     js             xs      js          exam
        //exam	                 exam	        a       exam
        //                                      m	

        int maxLength = 0;
        List<string> matrix = new List<string>();
        string input = Console.ReadLine();
        int degrees = (int.Parse(input.Split('(', ')')[1]) % 360);
        string line = Console.ReadLine();
        while (line != "END")
        {
            int length = line.Length;
            if (length > maxLength)
            {
                maxLength = length;
            }

            matrix.Add(line);
            line = Console.ReadLine();
        }

        for (int i = 0; i < matrix.Count; i++)
        {
            matrix[i] = matrix[i].PadRight(maxLength, ' ');
        }

        switch (degrees)
        {
            case 0:
                for (int row = 0; row < matrix.Count; row++)
                {
                    for (int col = 0; col < maxLength; col++)
                    {
                        Console.Write(matrix[row][col]);
                    }
                    Console.WriteLine();
                }
                break;

            case 90:
                for (int col = 0; col < maxLength; col++)
                {
                    for (int row = matrix.Count - 1; row >= 0; row--)
                    {
                        Console.Write(matrix[row][col]);
                    }
                    Console.WriteLine();
                }
                break;

            case 180:
                for (int row = matrix.Count - 1; row >= 0; row--)
                {
                    for (int col = maxLength - 1; col >= 0; col--)
                    {
                        Console.Write(matrix[row][col]);
                    }
                    Console.WriteLine();
                }
                break;

            case 270:
                for (int col = maxLength - 1; col >= 0; col--)
                {
                    for (int row = 0; row < matrix.Count; row++)
                    {
                        Console.Write(matrix[row][col]);
                    }
                    Console.WriteLine();
                }
                break;
        }

    }
}

