using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Build_a_Matrix_of_Letters
{
    public class BuildAMatrixOfLetters
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    Console.Write((char)((int)'A' + (row * cols + col) % 26) + " ");
                }

                Console.WriteLine((char)((int)'A' + (row * cols + cols - 1) % 26));
            }
            //char[][] charMatrix = new char[rows][];

            //InputProcess(rows, cols, charMatrix);
            //FillMatrix(charMatrix);
            //PrintMatrix(charMatrix);

        }

    //    private static void PrintMatrix(char[][] charMatrix)
    //    {
    //        for (int i = 0; i < charMatrix.Length; i++)
    //        {
    //            for (int j = 0; j < charMatrix[i].Length; j++)
    //            {
    //                Console.Write(charMatrix[i][j]);
    //                if (j != charMatrix[i].Length - 1)
    //                {
    //                    Console.Write(" ");
    //                }
    //            }

    //            Console.WriteLine();
    //        }
    //    }

    //    private static void FillMatrix(char[][] charMatrix)
    //    {
    //        char ch = 'A';
    //        for (int i = 0; i < charMatrix.Length; i++)
    //        {
    //            for (int j = 0; j < charMatrix[i].Length; j++)
    //            {

    //                charMatrix[i][j] = ch;
    //                if (ch == 'Z')
    //                {
    //                    ch = 'A';
    //                }
    //                else
    //                {
    //                    ch++;
    //                }
    //            }
    //        }
    //    }

    //    private static void InputProcess(int rows, int cols, char[][] charMatrix)
    //    {
    //        for (int i = 0; i < rows; i++)
    //        {
    //            charMatrix[i] = new char[cols];
    //        }
    //    }
    }
}
