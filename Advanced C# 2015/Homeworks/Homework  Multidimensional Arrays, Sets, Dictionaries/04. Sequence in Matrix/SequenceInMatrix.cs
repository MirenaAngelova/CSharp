using System;
using System.Collections.Generic;
class SequenceInMatrix
{
    static void Main()
    {
        //We are given a matrix of strings of size N x M. Sequences in the matrix we define as sets of several
        //neighbour elements located on the same line, column or diagonal. Write a program that finds the longest 
        //sequence of equal strings in the matrix. Examples:
        //Matrix	        Output		  Matrix	    Output
        //ha  fifi ho hi     ha, ha, ha	  s  qq s	 	s, s, s
        //fo  ha   hi xx                  pp pp s
        //xxx ho   ha xx                  pp qq s

        List<List<string>> matrix = new List<List<string>>();

        string input = Console.ReadLine();
        string[] rowsInput;

        for (int i = 0; !String.IsNullOrEmpty(input); i++)
        {
            matrix.Add(new List<string>());
            rowsInput = input.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < rowsInput.Length; j++)
            {
                matrix[i].Add(rowsInput[j]);
            }
            input = Console.ReadLine();
        }

        int length = 1;
        int maxLength = int.MinValue;
        string maxValue = string.Empty;

        for (int i = 0; i < matrix.Count; i++)
        {
            for (int j = 0; j < matrix[i].Count; j++)
            {
                length = CheckVertical(matrix, i, j, matrix[i][j]);
                if (length > maxLength)
                {
                    maxLength = length;
                    maxValue = matrix[i][j];
                }

                length = CheckHorizontal(matrix, i, j, matrix[i][j]);
                if (length > maxLength)
                {
                    maxLength = length;
                    maxValue = matrix[i][j];
                }

                length = CheckDiagonal(matrix, i, j, matrix[i][j]);
                if (length > maxLength)
                {
                    maxLength = length;
                    maxValue = matrix[i][j];
                }
            }
        }
        Console.Write(maxValue);
        for (int i = 1; i < maxLength; i++)
        {
            Console.Write(", {0}", maxValue);
        }
        Console.WriteLine();
    }
    private static int CheckVertical(List<List<string>> matrix, int i, int j, string value)
    {
        int length = 1;
        for (int row = i; row < matrix.Count; row++)
        {
            if (row + 1 < matrix.Count && matrix[row + 1][j].Equals(value))
            {
                length++;
            }
            else
            {
                break;
            }
        }
        return length;
    }
    private static int CheckHorizontal(List<List<string>> matrix, int i, int j, string value)
    {
        int length = 1;
        for (int col = j; col < matrix[i].Count; col++)
        {
            if (col + 1 < matrix[i].Count && matrix[i][col + 1].Equals(value))
            {
                length++;
            }
            else
            {
                break;
            }
        }
        return length;
    }
    private static int CheckDiagonal(List<List<string>> matrix, int i, int j, string value)
    {
        int length = 1;
        for (int row = i, col = j; row < matrix.Count && col < matrix[i].Count; row++, col++)
        {
            if (row + 1 < matrix.Count && col + 1 < matrix[row + 1].Count && matrix[row + 1][col + 1].Equals(value))
            {
                length++;
            }
            else
            {
                break;
            }
        }
        return length;
    }
}

