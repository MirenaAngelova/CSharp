using System;
using System.Collections.Generic;
using System.Linq;

namespace _19.Crossfore_3
{
    public class Crossfire3
    {
        public static void Main()
        {
            int[] parsedDimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<List<int>> numberMatrix = FillMatrix(parsedDimensions);

            string commandArgs = Console.ReadLine();
            while (commandArgs != "Nuke it from orbit")
            {
                int[] parsedArgs = commandArgs.Split().Select(int.Parse).ToArray();
                int shotRow = parsedArgs[0];
                int shotCol = parsedArgs[1];
                int shotRadius = parsedArgs[2];

                for (int currentRow = shotRow - shotRadius; currentRow <= shotRow + shotRadius; currentRow++)
                {
                    if (IsInMatrix(currentRow, shotCol, numberMatrix))
                    {
                        numberMatrix[currentRow].Insert(shotCol, -1);
                        numberMatrix[currentRow].RemoveAt(shotCol + 1);
                    }
                }

                for (int currentCol = shotCol - shotRadius; currentCol <= shotCol + shotRadius; currentCol++)
                {
                    if (IsInMatrix(shotRow, currentCol, numberMatrix))
                    {
                        numberMatrix[shotRow].Insert(currentCol, -1);
                        numberMatrix[shotRow].RemoveAt(currentCol + 1);
                    }
                }

                FilterMatrix(numberMatrix);

                commandArgs = Console.ReadLine();
            }

            PrintMatrix(numberMatrix);
        }

        private static void PrintMatrix(List<List<int>> numberMatrix)
        {
            for (int row = 0; row < numberMatrix.Count; row++)
            {
                Console.WriteLine(string.Join(" ", numberMatrix[row]));
            }
        }

        private static void FilterMatrix(List<List<int>> numberMatrix)
        {
            for (int row = 0; row < numberMatrix.Count; row++)
            {
                numberMatrix[row].RemoveAll(n => n == -1);
            }

            numberMatrix.RemoveAll(n => n.Count == 0);
        }

        private static bool IsInMatrix(int currentRow, int currentCol, List<List<int>> numberMatrix)
        {
            return currentRow >= 0 && currentRow < numberMatrix.Count &&
                   currentCol >= 0 && currentCol < numberMatrix[currentRow].Count;
        }

        private static List<List<int>> FillMatrix(int[] parsedDimensions)
        {
            List<List<int>> numberMatrix = new List<List<int>>();
            int rows = parsedDimensions[0];
            int cols = parsedDimensions[1];
            int index = 1;
            for (int row = 0; row < rows; row++)
            {
                numberMatrix.Add(new List<int>());
                for (int col = 0; col < cols; col++)
                {
                    numberMatrix[row].Add(index);
                    index++;
                }
            }

            return numberMatrix;
        }
    }
}
