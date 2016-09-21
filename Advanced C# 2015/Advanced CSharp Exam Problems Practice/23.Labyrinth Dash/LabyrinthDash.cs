using System;
class LabyrinthDash
{
    static void Main()
    {
        const string Obstacles = "@#*";

        int n = int.Parse(Console.ReadLine());

        char[][] matrix = new char[n][];

        for (int i = 0; i < n; i++)
        {
            matrix[i] = Console.ReadLine().ToCharArray();
        }

        int lives = 3;
        int moves = 0;
        int row = 0;
        int col = 0;

        string commands = Console.ReadLine();

        foreach (var command in commands)
        {
            int prevRow = row;
            int prevCol = col;

            switch (command)
            {
                case 'v':
                    row++;
                    break;
                case '^':
                    row--;
                    break;
                case '<':
                    col--;
                    break;
                case '>':
                    col++;
                    break;
            }

            if (!IsCellInMatrix(matrix, row, col) || matrix[row][col] == ' ')
            {
                Console.WriteLine("Fell off a cliff! Game Over!");
                moves++;
                break;
            }
            else if (matrix[row][col] == '_' || matrix[row][col] == '|')
            {
                Console.WriteLine("Bumped a wall.");
                row = prevRow;
                col = prevCol;
            }
            else if (Obstacles.Contains(matrix[row][col].ToString()))
            {
                Console.WriteLine("Ouch! That hurt! Lives left: {0}", --lives);
                moves++;

                if (lives <= 0)
                {
                    Console.WriteLine("No lives left! Game Over!");
                    break;
                }
            }
            else if (matrix[row][col] == '$')
            {
                Console.WriteLine("Awesome! Lives left: {0}", ++lives);
                moves++;
                matrix[row][col] = '.';
            }
            else
            {
                Console.WriteLine("Made a move!");
                moves++;
            }

            //char currentCell = matrix[row][col];
        }
        Console.WriteLine("Total moves made: {0}", moves);
    }
    private static bool IsCellInMatrix(char[][] matrix, int row, int col)
    {
        bool isRowInsideMatrix = row >= 0 && row < matrix.Length;

        if (!isRowInsideMatrix)
        {
            return false;
        }

        return col >= 0 && col < matrix[row].Length;
    }
}

