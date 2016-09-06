using System;

namespace _18.Radioactive_Mutant_Vampire_Bunnies
{
    public class RadioactiveMutantVampireBunnies
    {
        private static char[][] lair;
        private static int[] deadPlayerCoords = new int[2] {-1, -1};

        private static int rows;
        private static int cols;
        private static string commands;

        public static void Main()
        {
            string[] rowsCols = Console.ReadLine().Split();
            rows = int.Parse(rowsCols[0]);
            cols = int.Parse(rowsCols[1]);



            lair = new char[rows][];
            for (int row = 0; row < rows; row++)
            {
                lair[row] = Console.ReadLine().ToCharArray();
            }

            commands = Console.ReadLine();
            FindPlayerPosition();
        }

        private static void FindPlayerPosition()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (lair[row][col] == 'P')
                    {
                        SwitchCommands(row, col);
                        return;
                    }
                }
            }
        }

        private static void SwitchCommands(int row, int col)
        {
            foreach (var command in commands)
            {
                switch (command)
                {
                    case 'R':
                        PlayerMoving(row, col, 0, 1);
                        col++;
                        break;
                    case 'D':
                        PlayerMoving(row, col, 1, 0);
                        row++;
                        break;
                    case 'L':
                        PlayerMoving(row, col, 0, -1);
                        col--;
                        break;
                    case 'U':
                        PlayerMoving(row, col, -1, 0);
                        row--;
                        break;

                }
            }
        }

        private static void PlayerMoving(int row, int col, int updateRow, int updateCol)
        {
            if (!IsInLair(row + updateRow, col + updateCol))
            {
                GameOver(row, col, 0, 0, "won");
            }

            if (lair[row + updateRow][col + updateCol] == 'B')
            {
                GameOver(row, col, updateRow, updateCol, "dead");
            }

            lair[row + updateRow][col + updateCol] = 'P';
            lair[row][col] = '.';
            ExtremlyFastMultiplying();

        }

        private static void GameOver(int row, int col, int updateRow, int updateCol, string wonDead)
        {
            lair[row][col] = '.';
            ExtremlyFastMultiplying();
            PrintLair();
            Console.WriteLine($"{wonDead}: {row + updateRow} {col + updateCol}");
            Environment.Exit(0);
        }

        private static void ExtremlyFastMultiplying()
        {
            bool[,] usedBunny = new bool[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {

                    if (!usedBunny[row, col] && lair[row][col] == 'B')
                    {
                        BunnyMultiplying(row, col, -1, 0, usedBunny);
                        BunnyMultiplying(row, col, 1, 0, usedBunny);
                        BunnyMultiplying(row, col, 0, -1,usedBunny);
                        BunnyMultiplying(row, col, 0, 1, usedBunny);
                    }
                }
            }
            if (deadPlayerCoords[0] != -1 && deadPlayerCoords[1] != -1)
            {
                PrintLair();
                Console.WriteLine($"dead: {deadPlayerCoords[0]} {deadPlayerCoords[1]}");
                Environment.Exit(0);
            }
        }

        private static void BunnyMultiplying(int row, int col, int updateRow, int updateCol, bool[,] usedBunny)
        {
            if (IsInLair(row + updateRow, col + updateCol))
            {
                if (lair[row + updateRow][col + updateCol] == 'P')
                {
                    lair[row + updateRow][col + updateCol] = 'B';
                    usedBunny[row + updateRow, col + updateCol] = true;
                    deadPlayerCoords[0] = row + updateRow;
                    deadPlayerCoords[1] = col + updateCol;
                }

                if (!usedBunny[row + updateRow, col + updateCol] &&
                    lair[row + updateRow][col + updateCol] == '.')
                {
                    lair[row + updateRow][col + updateCol] = 'B';
                    usedBunny[row + updateRow, col + updateCol] = true;
                }
            }
        }

        private static bool IsInLair(int row, int col)
        {
            return row >= 0 && row < rows && col >= 0 && col < cols;
        }

        private static void PrintLair()
        {
            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine(string.Join(String.Empty, lair[row]));
            }
        }
    }
}
