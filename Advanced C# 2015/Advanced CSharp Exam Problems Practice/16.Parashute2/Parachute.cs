using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parachute
{
    class Program
    {
        static void Main()
        {
            //List<string> input = new List<string>();
            //while (true)
            //{
            //    string inputLine = Console.ReadLine();
            //    if (inputLine == "END")
            //    {
            //        break;
            //    }
            //    input.Add(inputLine);
            //}

            //char[,] environment = new char[input.Count, input[0].Length];

            //for (int row = 0; row < environment.GetLength(0); row++)
            //{
            //    for (int col = 0; col < environment.GetLength(1); col++)
            //    {
            //        environment[row, col] = input[row][col];
            //    }
            //}


            //int wind = 0;

            //for (int row = 0; row < environment.GetUpperBound(0); row++)
            //{
            //    for (int col = 0; col < environment.GetLength(1); col++)
            //    {
            //        if (environment[row, col] == 'o')
            //        {
            //            for (int index = 0; index < environment.GetLength(1); index++)
            //            {
            //                if (environment[row + 1, index] == '>')
            //                {
            //                    wind++;
            //                }

            //                if (environment[row + 1, index] == '<')
            //                {
            //                    wind--;
            //                }
            //            }

            //            switch (environment[row + 1, col + wind])
            //            {
            //                case '/':
            //                case '\\':
            //                case '|':
            //                    Console.WriteLine("Got smacked on the rock like a dog!");
            //                    Console.WriteLine("{0} {1}", row + 1, col + wind);
            //                    return;
            //                case '~':
            //                    Console.WriteLine("Drowned in the water like a cat!");
            //                    Console.WriteLine("{0} {1}", row + 1, col + wind);
            //                    return;
            //                case '_':
            //                    Console.WriteLine("Landed on the ground like a boss!");
            //                    Console.WriteLine("{0} {1}", row + 1, col + wind);
            //                    return;
            //                default:
            //                    environment[row + 1, col + wind] = 'o';
            //                    break;
            //            }
            //        }
            //    }

            //    wind = 0;
            //}

            //--o----------------------
            //>------------------------
            //>------------------------
            //> ----------------/\-----
            //-----------------/--\----
            //>---------/\----/----\---
            //---------/--\--/------\--
            //<-------/----\/--------\-
            //\------/----------------\
            //-\____/------------------

            string input = Console.ReadLine();
            List<char[]> matrix = new List<char[]>();
            while (input != "END")
            {
                matrix.Add(input.ToCharArray());
                input = Console.ReadLine();
            }

            int[] jumperCoordinates = FindJumper(matrix);
            int row = jumperCoordinates[0];
            int col = jumperCoordinates[1];
            for (int i = row + 1; i < matrix.Count; i++)
            {
                int colImpact = ImpactWind(matrix, i);
                col += colImpact;
                if (CheckForCollision(matrix[i][col]))
                {
                    Report(matrix[i][col]);
                    Console.WriteLine($"{i} {col}");
                    return;
                }
            }
        }

        private static void Report(char symbol)
        {
            switch (symbol)
            {
                case '_':
                    Console.WriteLine("Landed on the ground like a boss!");
                    break;
                case '~':
                    Console.WriteLine("Drowned in the water like a cat!");
                    break;
                case '/':
                case '\\':
                case '|':
                    Console.WriteLine("Got smacked on the rock like a dog!");
                    break;
            }
        }

        private static bool CheckForCollision(char symbol)
        {
            return symbol != '-' && symbol != '>' && symbol != '<';
        }

        private static int ImpactWind(List<char[]> matrix, int i)
        {
            int leftMove = 0;
            int rightMove = 0;
            foreach (var j in matrix[i])
            {
                switch (j)
                {
                    case '<':
                        leftMove++;
                        break;
                    case '>':
                        rightMove++;
                        break;
                }
            }

            int colImpact = rightMove - leftMove;
            return colImpact;
        }

        private static int[] FindJumper(List<char[]> matrix)
        {
            int[] jumperCoordinates = new int[2];
            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'o')
                    {
                        jumperCoordinates = new[] { i, j };
                    }
                }
            }

            return jumperCoordinates;
        }
    }
}