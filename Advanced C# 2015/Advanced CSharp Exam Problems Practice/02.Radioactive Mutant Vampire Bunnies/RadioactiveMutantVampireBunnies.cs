using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Radioactive_Mutant_Vampire_Bunnies
{
    class RadioactiveMutantVampireBunnies
    {
        static void Main()
        {
            string[] rowsCols = Console.ReadLine().Split(' ');
            int rows = int .Parse(rowsCols[0]);
            int cols = int .Parse(rowsCols[1]);

            char[][] lair = new char[rows][];
            int playerRow = 0;
            int playerCol = 0;
            for (int i = 0; i < rows; i++)
            {
                string inputLine = Console.ReadLine();
                lair[i] = inputLine.ToCharArray();

                if (lair[i].Contains('P'))
                {
                    playerRow = i;
                    playerCol = Array.IndexOf(lair[i], 'P');
                    lair[playerRow][playerCol] = '.';
                }
            }

            string lastLine = Console.ReadLine();
            char[] commands = lastLine.ToCharArray();
            for (int i = 0; i < commands.Length; i++)
            {
                int prevPlayerRow = playerRow;
                int prevPlayerCol = playerCol;

                char command = commands[i];
                switch (command)
                {
                    case 'L':
                        playerCol--;
                        break;
                    case 'R':
                        playerCol++;
                        break;
                    case 'U':
                        playerRow--;
                        break;
                    case 'D':
                        playerRow++;
                        break;
                }

                lair = BuniesSpread(lair, rows, cols);

                bool isOutside = playerRow < 0 || playerRow == rows || playerCol < 0 || playerCol == cols;
                if (isOutside)
                {
                    PrintLairAndResult(lair, prevPlayerRow, prevPlayerCol, "won");
                    return;
                }

                if (lair[playerRow][playerCol] == 'B')
                {
                    PrintLairAndResult(lair, playerRow, playerCol, "dead");
                    return;
                }
            }
        }

        private static void PrintLairAndResult(char[][] lair, int row, int col, string output)
        {
            foreach (var ch in lair)
            {
                Console.WriteLine(string.Join("", ch));
            }

            Console.WriteLine("{0}: {1} {2}", output, row, col);
        }

        private static char[][] BuniesSpread(char[][] lair, int rows, int cols)
        {
            char[][] replacedLair = new char[lair.Length][];

            for (int i = 0; i < lair.Length; i++)
            {
                replacedLair[i] = (char[]) lair[i].Clone();
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (lair[i][j] == 'B')
                    {
                        if (i - 1 >= 0)
                        {
                            replacedLair[i - 1][j] = 'B';
                        }

                        if (i + 1 < rows)
                        {
                            replacedLair[i + 1][j] = 'B';
                        }

                        if (j - 1 >= 0)
                        {
                            replacedLair[i][j - 1] = 'B';
                        }

                        if (j + 1 < cols)
                        {
                            replacedLair[i][j + 1] = 'B';
                        }
                    }
                }
            }

            return replacedLair;
        }
    }
}
