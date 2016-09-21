using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Bunker_Buster2
{
    class BunkerBuster2
    {
        static void Main(string[] args)
        {
            string[] rowsCols = Console.ReadLine().Split();
            int rows = int.Parse(rowsCols[0]);
            int cols = int.Parse(rowsCols[1]);
            int[][] matrix = new int[rows][];
            for (int i = 0; i < rows; i++)
            {

                matrix[i] = Console.ReadLine()
                    .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
            }

            string bomb = Console.ReadLine();
            while (bomb != "cease fire!")
            {
                string[] bombInfo = bomb
                    .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                int bombRow = int.Parse(bombInfo[0]);
                int bombCol = int.Parse(bombInfo[1]);
                char bombPower = char.Parse(bombInfo[2]);
                //double reducedPower = double.Parse(bombPower.ToString()) / 2;
                double reducedPower = (double)bombPower / 2;
                int reducedInt = (int)Math.Ceiling(reducedPower);
                matrix[bombRow][bombCol] -= (int)bombPower;

                BombardMatrix(matrix, rows, cols, bombRow, bombCol, reducedInt);

                bomb = Console.ReadLine();
            }

            int destroyedBunkers = DestroyedBunkers(matrix);
            double damageDone = ((double)destroyedBunkers / (rows * cols)) * 100;
            Console.WriteLine($"Destroyed bunkers: {destroyedBunkers}");
            Console.WriteLine($"Damage done: {damageDone:F1} %");
        }

        private static int DestroyedBunkers(int[][] matrix)
        {
            int count = 0;
            foreach (var line in matrix)
            {
                foreach (var cell in line)
                {
                    if (cell <= 0)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private static void BombardMatrix(
            int[][] matrix,
            int rows,
            int cols,
            int bombRow,
            int bombCol,
            int reducedInt)
        {
            int startRow = Math.Max(0, bombRow - 1);
            int endRow = Math.Min(rows - 1, bombRow + 1);

            int startCol = Math.Max(0, bombCol - 1);
            int endCol = Math.Min(cols - 1, bombCol + 1);

            for (int i = startRow; i <= endRow; i++)
            {
                for (int j = startCol; j <= endCol; j++)
                {
                    if (i == bombRow && j == bombCol)
                    {
                        continue;
                    }

                    matrix[i][j] -= reducedInt;
                }
            }
        }
    }
}
