using System;
class TicTacToePower
{
    static void Main()
    {  
        //You are given tic-tac-toe board (3 columns and 3 rows) like the one the right. As inputs you will be given 
        //the X and Y coordinates of one of the cells. Each of the cells in the field has an index and a value 
        //(look at the examples on the right). You will be given the value of the first cell V (index1). 
        //Each of the next cells will have value greater by 1 than the previous. 
        //Example: if value=80, then index1=80, index2=81, index3=82, ..., index9=89. 
        //Your task is to print on the console the value of the cell C raised to the power of its index: C index. 
        //Look at comments in the examples below to understand your task better.
        //Input
        //The input data should be read from the console.
        //•	At the first line you will be given the X coordinate.
        //•	At the second line you will be given the Y coordinate.
        //•	At the third line an integer number V will be given, specifying the value of the first cell.
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //The output should be printed on the console. It should consist of 1 line:
        //•	Print the value C of the cell at position {X, Y} raised to the power of its index.
        //Constraints
        //•	The X and Y inputs will be integers in the range [0…2].
        //•	The V input will be an integer in the range [0…100].
        //•	Allowed working time: 0.2 seconds. Allowed memory: 16 MB.
        //Examples
        //Input	Output	    Board	            Comments
        //1     537824         0    1    2      The cell with coordinates {x=1, y=1} has an index 5. 
        //1                 0 |10 | 11 | 12     Cell at index 5 has value = 14.
        //10                1 |13 | 14 | 15		145 = 537824
        //                  2 |16 | 17 | 18
        //
        //Input	Output		Input	Output		Input	Output
        //2     1000000     0       1           2       729000
        //1                 0                   0
        //5                 1                   88

        int x = int.Parse(Console.ReadLine());
        int y = int.Parse(Console.ReadLine());
        int value = int.Parse(Console.ReadLine());
        long cell = 0;
        int position = x + 1;
        if (y == 1)
        {
            position = x + 4;
        }
        if (y == 2)
        {
            position = x + 7;
        }
        value += position - 1;
        cell = (long)Math.Pow(value, position);
        Console.WriteLine(cell);
    }      
}          

