using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21.Parking_System
{
    public class ParkingSystem
    {           
        private static int rows;
        private static int cols;
        private static int movies;
                
        private static bool[,] parking;
        private static int rowEntry;
        private static int rowDesired;
        private static int colDesired;
        private static bool isFound;
        static void Main()
        {
            string[] rowsCols = Console.ReadLine().Split();
            rows = int.Parse(rowsCols[0]);
            cols = int.Parse(rowsCols[1]);

            parking = new bool[rows, cols];
            string input = Console.ReadLine();
            while(input != "stop")
            {
                movies = 1;
                isFound = false;

                string[] inputToArray = input.Split();
                rowEntry = int.Parse(inputToArray[0]);
                rowDesired = int.Parse(inputToArray[1]);
                colDesired = int.Parse(inputToArray[2]);

                movies += Math.Abs(rowEntry - rowDesired);

                FindParkingSpot();
                input = Console.ReadLine();
            }
        }

        private static void FindParkingSpot()
        {
            for (int i = colDesired; i >= 1; i--)
            {
                isFound = IsUsedParkingSpot(i);
                if (isFound)
                {
                    return;
                }
            }

            int colUpperBound = Math.Min(colDesired + 1, cols - 1);
            for (int i = colUpperBound; i < cols; i++)
            {
                isFound = IsUsedParkingSpot(i);
                if (isFound)
                {
                    return;
                }
            }

            if (!isFound)
            {
                PrintMessage();
            }

        }

        private static void PrintMessage()
        {
            Console.WriteLine($"Row {rowDesired} full");
        }

        private static bool IsUsedParkingSpot(int i)
        {
            if (parking[rowDesired, i] == false)
            {
                movies += i;
                parking[rowDesired, i] = true;
                PrintMovies();
                isFound = true;
            }

            return isFound;
        }

        private static void PrintMovies()
        {
            Console.WriteLine(movies);
        }
    }
}
