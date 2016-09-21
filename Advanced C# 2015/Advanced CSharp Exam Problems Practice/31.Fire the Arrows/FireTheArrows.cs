using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31.Fire_the_Arrows
{
    class FireTheArrows
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[][] matrix = new char[rows][];
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
            }
            bool hasMove = true;
            while (hasMove)
            {
                hasMove = false;
                for (int row = 0; row < matrix.Length; row++)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {

                        if (matrix[row][col] == '<')
                        {
                            if (col >= 1 && matrix[row][col - 1] == 'o')
                            {
                                matrix[row][col - 1] = '<';
                                matrix[row][col] = 'o';
                                hasMove = true;
                            }
                        }
                        else if (matrix[row][col] == '>')
                        {
                            if (col < matrix[row].Length - 1 && matrix[row][col + 1] == 'o')
                            {
                                matrix[row][col + 1] = '>';
                                matrix[row][col] = 'o';
                                hasMove = true;
                            }
                        }
                        else if (matrix[row][col] == '^')
                        {
                            if (row >= 1 && matrix[row - 1][col] == 'o')
                            {
                                matrix[row - 1][col] = '^';
                                matrix[row][col] = 'o';
                                hasMove = true;
                            }
                        }
                        else if (matrix[row][col] == 'v')
                        {
                            if (row < matrix.Length - 1 && matrix[row + 1][col] == 'o')
                            {
                                matrix[row + 1][col] = 'v';
                                matrix[row][col] = 'o';
                                hasMove = true;
                            }
                        }
                    }
                }

            }


            foreach (char[] t in matrix)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    Console.Write(t[j]);
                }
                Console.WriteLine();
            }

        }
    }
}
