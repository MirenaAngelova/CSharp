using System;
using System.Collections.Generic;

namespace _19.Crossfire
{
    public class Crossfire
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

                int centreCell = 0;
                if (col >= 0 && col < cols)
                {
                    int lowerRowBound = (int)Math.Max(row - radius, 0);
                    int upperRowBound = (int)Math.Min(row + radius, crossfire.Count - 1);

                    if (row >= 0 && row < rows && crossfire[(int)row].Count - 1 > col)
                    {
                        centreCell = 1;
                    }

                    NukeCells(lowerRowBound, upperRowBound, (int)col, 0, true); // remove col
                }

                if (row >= 0 && row < rows)
                {
                    int lowerColBound = (int)Math.Max(col - radius, 0);
                    int upperColBound = (int)Math.Min(col + radius, crossfire[(int)row].Count - 1);
                    NukeCells(lowerColBound, upperColBound, (int)row, centreCell, false); // remove row
                }

                input = Console.ReadLine();
            }

            PrintMatrix();
        }

        private static void NukeCells(
            int lowerBound, int upperBound, int rowCol, int centreCell, bool isColRemove)
        {
            for (int crossline = lowerBound; crossline <= upperBound - centreCell; crossline++)
            {
                if (isColRemove)
                {
                    if (crossfire[crossline].Count - 1 >= rowCol)
                    {
                        crossfire[crossline].RemoveAt(rowCol);
                    }
                }
                else
                {
                    crossfire[rowCol].RemoveAt(lowerBound);
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
