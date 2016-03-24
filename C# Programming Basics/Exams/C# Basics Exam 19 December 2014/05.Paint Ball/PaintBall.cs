using System;
using System.Linq;
class PaintBall
{
    static void Main()
    {
        //You are given a painting canvas of size 10 x 10, divided into 100 cells. Initially, the canvas is white 
        //(all cells have a value of 1). You shoot black and white paint balls with different sizes at the canvas. 
        //White is represented by 1s and black is represented by 0s. You alternate between black and white paint 
        //after each shot; the first shot is always with black paint (0s), the second is white (1s), 
        //the third is black again and so on. You will be given each shot's impact row and column coordinates 
        //as well as the ball's radius. The impact area is a square, its center is the impact cell; 
        //all cells in the impact area change values to either 0 or 1, depending on the color of the paint.
        //After you run out of ammo (when you receive the string "End" from the console) the canvas will be some combination 
        //of 1s and 0s. Each row of the canvas represents a binary integer number. Your task is to find the sum of 
        //the 10 numbers and print it to the console. An example where a single shot with parameters "4 5 2" was fired 
        //is shown below. The impact cell is shaded black, the splashed cells in the impact area are shaded grey.
        //Input
        //The input data is read from the console. 
        //•	It consists of a random number of lines. The input ends with the string "End".
        //•	Each line will hold three numbers – the row and column of the cell where the ball lands and the radius of the ball,
        //all separated from each other by a single space.
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //The output data must be printed on the console.
        //•	On the only output line you must print the sum of the 10 rows of the canvas in decimal format.
        //Constraints
        //•	The number of shots will be in the range [1…25].
        //•	The rows and columns are integer numbers in the range [0…9].
        //•	The radius of the ball will be an integer between 0 (single cell) and 10 (large splash area damage).
        //•	Time limit: 0.25 seconds. Allowed memory: 16 MB.
        //Examples 

        //  9	8	7	6	5	4	3	2	1	0	Number
        //0	1	1	1	1	1	1	1	1	1	1	1023
        //1	1	1	1	1	1	1	1	1	1	1	1023
        //2	1	1	0	0	0	0	0	1	1	1	775
        //3	1	1	0	0	0	0	0	1	1	1	775
        //4	1	1	0	0	0	0	0	1	1	1	775
        //5	1	1	0	0	0	0	0	1	1	1	775
        //6	1	1	0	0	0	0	0	1	1	1	775
        //7	1	1	1	1	1	1	1	1	1	1	1023
        //8	1	1	1	1	1	1	1	1	1	1	1023
        //9	1	1	1	1	1	1	1	1	1	1	1023
        //                                sum = 	8990
        //Input	Output
        //4 5 2
        //End	8990
	
        //Input	Output
        //1 2 5	5118
        //3 3 1	
        //0 6 4	
        //0 0 0	
        //8 9 2	
        //1 7 2	
        //End	

        //int[] canvas = new int[10];
        //for (int row = 0; row < 10; row++)
        //{
        //    canvas[row] = 1023;
        //}
        //string current = Console.ReadLine();
        //bool isWhite = false;
        //while (current != "End")
        //{
        //    string[] shotD = current.Split();
        //    int shotRC = int.Parse(shotD[0]);//x
        //    int shotCC = int.Parse(shotD[1]);//y
        //    int shotR = int.Parse(shotD[2]);//r
        //    int startC = Math.Max(shotCC - shotR, 0);//y - r
        //    int endC = Math.Min(shotCC + shotR, 9);//y + r
        //    int startR = Math.Max(shotRC - shotR, 0);//x - r
        //    int endR = Math.Min(shotRC + shotR, 9);//x + r
        //    int maskS = endC - startC + 1;//y
        //    int mask = (1 << maskS) - 1;
        //    for (int i = startR; i <= endR; i++)//x
        //    {
        //        if (isWhite)
        //        {
        //            canvas[i] |= mask << startC;//y - r
        //        }
        //        else
        //        {
        //            canvas[i] &= ~(mask << startC);//y - r
        //        }
        //    }
        //    isWhite = !isWhite;
        //    current = Console.ReadLine();
        //}
        //int sum = canvas.Sum();
        //Console.WriteLine(sum);




        int[] canvas = new int[10];
        for (int i = 0; i < 10; i++)
        {
            canvas[i] = 1023;
        }
        string command = Console.ReadLine();
        bool isWhite = false;
        while (command != "End")
        {
            string[] shot = command.Split();
            int x = int.Parse(shot[0]);
            int y = int.Parse(shot[1]);
            int r = int.Parse(shot[2]);
            int startX = Math.Max(x - r, 0);
            int endX = Math.Min(x + r, 9);
            int startY = Math.Max(y - r, 0);
            int endY = Math.Min(y + r, 9);
            int maskYY = endY - startY + 1;
            int maskY = (1 << maskYY) - 1;
            for (int i = startX; i <= endX; i++)
            {
                if (isWhite)
                {
                    canvas[i] |= maskY << startY;
                }
                else
                {
                    canvas[i] &= ~(maskY << startY);
                }
            }
            isWhite = !isWhite;
            command = Console.ReadLine();
        }
        int sum = canvas.Sum();
        Console.WriteLine(sum);
    }
}

