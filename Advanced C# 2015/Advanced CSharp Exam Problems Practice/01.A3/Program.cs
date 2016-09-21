using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.A3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rowsCols = Console.ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int rows = int.Parse(rowsCols[0]);
            int cols = int.Parse(rowsCols[1]);
            char[,] matrix = new char[rows, cols];
            string commands = Console.ReadLine();
            while (commands != "stop")
            {
                string[] command = commands
                    .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                int enterRow = int.Parse(command[0]);
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int movies = Math.Abs(enterRow - row);
                bool isFound = false;
                for (int i = 0; i < cols; i++)
                {
                    if (matrix[row, i] == '$')
                    {
                        bool isInside = i - 1 >= 1 && i + 1 < cols;
                        if (isInside && matrix[row, i - 1] != '$') //|| ))
                        {
                            matrix[row, i - 1] = '$';
                            movies++;
                            isFound = true;
                            Console.WriteLine(movies - 1);
                            break;
                        }
                        else if (isInside && matrix[row, i + 1] != '$')
                        {
                            matrix[row, i + 1] = '$';
                            movies ++;
                            isFound = true;
                            Console.WriteLine(movies + 2);
                            break;
                        }
                        else if (isInside && matrix[row, i - 1] == '$' && matrix[row, i + 1] == '$')
                        {
                            Console.WriteLine($"Row {row} full");
                            isFound = true;
                            break;
                        }

                    }
                    else if (i <= col)
                    {
                        movies++;
                    }
                }
                if (!isFound)
                {
                    matrix[row, col] = '$';
                    Console.WriteLine(movies);
                }

                commands = Console.ReadLine();
            }

        }
    }
}
