using System;
using System.Collections.Generic;

namespace _19.Crossfire_2
{
    public class Crossfire2
    {
        private static List<List<int>> crossfire = new List<List<int>>();
        private static int rows;
        private static int cols;

        public static void Main()
        {
            // 60/100
            string[] rowsCols = Console.ReadLine().Split();
            rows = int.Parse(rowsCols[0]);
            cols = int.Parse(rowsCols[1]);

            FiilMatrix();

            string input = Console.ReadLine();
            while (input != "Nuke it from orbit")
            {
                string[] commands = input.Split();

                long row = long.Parse(commands[0]);
                long col = long.Parse(commands[1]);
                long radius = long.Parse(commands[2]);

                if (col >= 0 && col < cols)
                {
                    int lowerRowBound = (int)Math.Max(row - radius, 0);
                    int upperRowBound = (int)Math.Min(row + radius, crossfire.Count - 1);
                    
                    NukeColCells(lowerRowBound, upperRowBound, (int)col); // remove col
                }

                if (row >= 0 && row < rows)
                {
                    int lowerColBound = (int)Math.Max(col - radius, 0);
                    int upperColBound = (int)Math.Min(col + radius, crossfire[(int)row].Count - 1);
                    NukeRowCells(lowerColBound, upperColBound, (int)row); // remove row
                }

                input = Console.ReadLine();
            }

            PrintMatrix();
        }

        private static void NukeRowCells(int lowerColBound, int upperColBound, int row)
        {
            for (int col = upperColBound; col >= lowerColBound; col--)
            {
                crossfire[row].RemoveAt(col);
            }
        }

        private static void NukeColCells(int lowerRowBound, int upperRowBound, int col)
        {
            for (int row = lowerRowBound; row <= upperRowBound; row++)
            {
                if (crossfire[row].Count - 1 >= col)
                {
                    crossfire[row].RemoveAt(col);
                }
            }
        }

        private static void PrintMatrix()
        {
            foreach (var fire in crossfire)
            {
                Console.WriteLine(string.Join(" ", fire));
            }
        }

        private static void FiilMatrix()
        {
            //int index = 1;

            for (int row = 0; row < rows; row++)
            {
                crossfire.Add(new List<int>());
                for (int col = 0; col < cols; col++)
                {
                    int index = row * cols + col + 1;
                    crossfire[row].Add(index);
                    //index++;
                }
            }
        }
    }
}
