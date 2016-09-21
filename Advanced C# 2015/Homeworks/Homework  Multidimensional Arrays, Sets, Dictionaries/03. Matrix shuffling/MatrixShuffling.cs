using System;
class MatrixShuffling
{
    static void Main()
    {
        //Write a program which reads a string matrix from the console and performs certain operations with its elements.
        //User input is provided like in the problem above – first you read the dimensions and then the data. 
        //Remember, you are not required to do this step first, you may add this functionality later.  
        //Your program should then receive commands in format: "swap x1 y1 x2 y2" where x1, x2, y1, y2 are coordinates 
        //in the matrix. In order for a command to be valid, it should start with the "swap" keyword along with four 
        //valid coordinates (no more, no less). You should swap the values at the given coordinates 
        //(cell [x1, y1] with cell [x2, y2]) and print the matrix at each step (thus you'll be able to check 
        //if the operation was performed correctly). 
        //If the command is not valid (doesn't contain the keyword "swap", has fewer or more coordinates entered or 
        //the given coordinates do not exist), print "Invalid input!" and move on to the next command. 
        //Your program should finish when the string "END" is entered. Examples:
        //Input	            Output
        //2                 (after swapping 1 and 5):
        //3                 5 2 3
        //1                 4 1 6
        //2                 Invalid input!
        //3                 (after swapping 2 and 4):
        //4                 5 4 3
        //5                 2 1 6
        //6
        //swap 0 0 1 1
        //swap 10 9 8 7
        //swap 0 1 1 0
        //END	
        //1                 Invalid input
        //2
        //Hello             World Hello
        //World             Hello World
        //0 0 0 1
        //swap 0 0 0 1
        //swap 0 1 0 0
        //END	

        int row = int.Parse(Console.ReadLine());
        int col = int.Parse(Console.ReadLine());

        string[,] matrix = new string[row, col];
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                matrix[i, j] = Console.ReadLine();
            }
        }

        while (true)
        {
            string[] input = Console.ReadLine().Split();
            if (input[0] != "END")
            {
                if (input[0] == "swap" && input.Length == 5)
                {
                    int x1 = int.Parse(input[1]);
                    int y1 = int.Parse(input[2]);
                    int x2 = int.Parse(input[3]);
                    int y2 = int.Parse(input[4]);

                    if (AreValidCoordinates(row, col, x1, y1, x2, y2))
                    {
                        string temp = matrix[x1, y1];
                        matrix[x1, y1] = matrix[x2, y2];
                        matrix[x2, y2] = temp;

                        PrintMatrix(matrix);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
            else
            {
                break;
            }
        }
    }
    private static bool AreValidCoordinates(int row, int col, int x1, int y1, int x2, int y2)
    {
        bool isValidX1 = x1 >= 0 && x1 < row;
        bool isValidY1 = y1 >= 0 && y1 < col;
        bool isValidX2 = x2 >= 0 && x2 < row;
        bool isValidY2 = y2 >= 0 && y2 < col;

        return isValidX1 && isValidY1 && isValidX2 && isValidY2;
    }
    private static void PrintMatrix(string[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " "); 
            }
            Console.WriteLine();
        }
    }
}
