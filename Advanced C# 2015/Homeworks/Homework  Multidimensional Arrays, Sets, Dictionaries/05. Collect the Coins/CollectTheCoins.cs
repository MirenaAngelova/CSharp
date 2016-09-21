using System;
class CollectTheCoins
{
    static void Main()
    {
        //Working with multidimensional arrays can be (and should be) fun. Let's make a game out of it.
        //You receive the layout of a board from the console. Assume it will always have 4 rows which you'll get as strings, 
        //each on a separate line. Each character in the strings will represent a cell on the board. 
        //Note that the strings may be of different length.
        //You are the player and start at the top-left corner (that would be position [0, 0] on the board). 
        //On the fifth line of input you'll receive a string with movement commands which tell you where to go next, 
        //it will contain only these four characters – '>' (move right), '<' (move left), '^' (move up) and 'v' (move down). 
        //You need to keep track of two types of events – collecting coins (represented by the symbol '$', of course) 
        //and hitting the walls of the board (when the player tries to move off the board to invalid coordinates). 
        //When all moves are over, print the amount of money collected and the number of walls hit. Example:
        //Input	        Output	                Comments
        //Sj0u$hbc      Coins collected: 2      Starting from (0, 0), move down (coin), twice right, up, up again (wall),
        //$87yihc87     Walls hit: 2            three times right (coin on second move), twice down, down again (wall),
        //Ewg3444                               twice to the left – game over (no more moves).
        //$4$$                                  Total of two coins collected and two walls hit in the process.
        //V>>^^>>>VVV<<	

        string[] layout = new string[4];

        for (int i = 0; i < layout.Length; i++)
        {
            layout[i] = Console.ReadLine();
        }
        string command = Console.ReadLine();

        int coins = 0;
        int hits = 0;
        int row = 0;
        int col = 0;

        for (int i = 0; i < command.Length; i++)
        {
            switch (command[i])
            {
                case '>':
                    if (col + 1 < layout[row].Length)
                    {
                        col++;
                        if (layout[row][col] == '$')
                        {
                            coins++;
                        }
                    }
                    else
                    {
                        hits++;
                    }
                    break;
                case '<':
                    if (col - 1 >= 0)
                    {
                        col--;
                        if (layout[row][col] == '$')
                        {
                            coins++;
                        }
                    }
                    else
                    {
                        hits++;
                    }
                    break;
                case '^':
                    if (row - 1 >= 0 && col <= layout[row - 1].Length)
                    {
                        row--;
                        if (layout[row][col] == '$')
                        {
                            coins++;
                        }
                    }
                    else
                    {
                        hits++;
                    }
                    break;
                case 'V':
                    if (row + 1 < layout.Length && col <= layout[row + 1].Length)
                    {
                        row++;
                        if (layout[row][col] == '$')
                        {
                            coins++;
                        }
                    }
                    else
                    {
                        hits++;
                    }
                    break;

            }
        }
        Console.WriteLine("Coins collected: {0}", coins);
        Console.WriteLine("Walls hit: {0}", hits);

    }
}
