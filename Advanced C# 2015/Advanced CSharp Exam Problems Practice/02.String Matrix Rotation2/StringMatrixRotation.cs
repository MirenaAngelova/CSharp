using System;
using System.Collections.Generic;
using System.Linq;
class StringMatrixRotation
{
    static void Main()
    {
        List<string> matrix = new List<string>();

        int maxLength = 0;

        string[] rotate = Console.ReadLine().Split('(', ')');

        int degrees = int.Parse(rotate[1]) % 360;

        string text = Console.ReadLine();

        while (text != "END")
        {
            if (text.Length > maxLength)
            {
                maxLength = text.Length;
            }
            matrix.Add(text);

            text = Console.ReadLine();
        }

        for (int i = 0; i < matrix.Count; i++)
        {
            matrix[i] = matrix[i].PadRight(maxLength, ' ');
        }

        switch (degrees)
        {
            case 0:

                for (int i = 0; i < matrix.Count; i++)
                {

                    for (int j = 0; j < matrix[0].Length; j++)
                    {
                        Console.Write(matrix[i][j]);
                    }

                    Console.WriteLine();
                }

                break;

            case 90:

                for (int j = 0; j < maxLength; j++)
                {

                    for (int i = matrix.Count - 1; i >= 0; i--)
                    {
                        Console.Write(matrix[i][j]);
                    }

                    Console.WriteLine();
                }

                break;

            case 180:

                for (int i = matrix.Count - 1; i >= 0; i--)
                {

                    for (int j = matrix[0].Length - 1; j >= 0; j--)
                    {
                        Console.Write(matrix[i][j]);
                    }

                    Console.WriteLine();
                }

                break;

            case 270:

                for (int j = matrix[0].Length - 1; j >= 0; j--)
                {

                    for (int i = 0; i < matrix.Count; i++)
                    {
                        Console.Write(matrix[i][j]);
                    }

                    Console.WriteLine();
                }

                break;
        }
    }
}