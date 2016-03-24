using System;
using System.Collections.Generic;
using System.Threading;
class Object
{
    public int x;
    public int y;
    public string c;
    public ConsoleColor color;
}
class FallingRocks
{
    static void PrintOnPosition (int x, int y, string str, ConsoleColor color = ConsoleColor.Gray)
    {
        //Implement the "Falling Rocks" game in the text console. A small dwarf stays at the bottom of the screen 
        //and can move left and right (by the arrows keys). A number of rocks of different sizes and forms constantly 
        //fall down and you need to avoid a crash.Rocks are the symbols ^, @, *, &, +, %, $, #, !, ., ;, - distributed 
        //with appropriate density. The dwarf is (O). Ensure a constant game speed by Thread.Sleep(150).
        //Implement collision detection and scoring system.	
        
        Console.SetCursorPosition (x, y);
        Console.ForegroundColor = color;
        Console.Write(str);
    }
    static void RockMover(Object rock)
    {
        rock.y++;
    }
    static void Main()
    {
        int simplicity = 150;
        int lives = 5;
        int score = 0;
        int level = 0;

        Console.BufferWidth = Console.WindowWidth = 40;
        Console.BufferHeight = Console.WindowHeight = 40;

        Object dwarfLeftSide = new Object();
        dwarfLeftSide.x = (Console.WindowWidth / 2) - 1;
        dwarfLeftSide.y = (Console.WindowHeight - 1);
        dwarfLeftSide.c = "(";
        dwarfLeftSide.color = ConsoleColor.Magenta;

        Object dwarfHead = new Object();
        dwarfHead.x = dwarfLeftSide.x + 1;
        dwarfHead.y = Console.WindowHeight - 1;
        dwarfHead.c = "o";
        dwarfHead.color = ConsoleColor.Magenta;

        Object dwarfRightSide = new Object();
        dwarfRightSide.x = dwarfHead.x + 1;
        dwarfRightSide.y = Console.WindowHeight - 1;
        dwarfRightSide.c = ")";
        dwarfRightSide.color = ConsoleColor.Magenta;

        List<Object> rocksForPrint = new List<Object>();
        while (lives > 0)
        {
            bool collision = false;
            PrintOnPosition(dwarfLeftSide.x, dwarfLeftSide.y, dwarfLeftSide.c, dwarfLeftSide.color);
            PrintOnPosition(dwarfHead.x, dwarfHead.y, dwarfHead.c, dwarfHead.color);
            PrintOnPosition(dwarfRightSide.x, dwarfRightSide.y, dwarfRightSide.c, dwarfRightSide.color);

            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (dwarfLeftSide.x >= 1)
                    {
                        dwarfLeftSide.x = dwarfLeftSide.x - 1;
                        dwarfHead.x = dwarfHead.x - 1;
                        dwarfRightSide.x = dwarfRightSide.x - 1;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (dwarfRightSide.x < Console.WindowWidth - 1)
                    {
                        dwarfLeftSide.x = dwarfLeftSide.x + 1;
                        dwarfHead.x = dwarfHead.x + 1;
                        dwarfRightSide.x = dwarfRightSide.x + 1;
                    }
                }
            }
            string[] rocksString = { "^", "@", "*", "&", "+", "%", "$", "#", "!", ".", ";"};
            ConsoleColor[] rocksColor = { ConsoleColor.DarkRed, ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Red,
                                        ConsoleColor.Cyan, ConsoleColor.DarkBlue };
            Random pickArock = new Random();
            Random rockDensity = new Random();
            Random pickXcoordinate = new Random();
            Random pickRockColor = new Random();

            int density = rockDensity.Next(0, 5);
            for (int i = 0; i < density; i++)
            {
                Object rock = new Object();
                rock.x = pickXcoordinate.Next(1, Console.WindowWidth - 1);
                rock.y = 0;
                for (int j = 0; j <= 1; j++)
                {
                    rock.c = rocksString[pickArock.Next(0, rocksString.Length)];
                }
                for (int k = 0; k <= 1; k++)
                {
                    rock.color = rocksColor[pickRockColor.Next(0, rocksColor.Length)];
                }
                rocksForPrint.Add(rock);
            }
            foreach (var item in rocksForPrint)
            {
                RockMover (item);
            }
            foreach (var rock in rocksForPrint)
            {
                if (rock.y < Console.WindowHeight - 1)
                {
                    PrintOnPosition(rock.x, rock.y, rock.c, rock.color);
                }
            }
            if (rocksForPrint.Count > 250)
            {
                for (int i = 0; i < 10; i++)
                {
                    rocksForPrint.RemoveAt(0);
                }
            }
            for (int i = 0; i < rocksForPrint.Count; i++)
            {
                if ((dwarfLeftSide.x == rocksForPrint[i].x || dwarfHead.x == rocksForPrint[i].x ||
                    dwarfRightSide.x == rocksForPrint[i].x) && dwarfHead.y == rocksForPrint[i].y)
                {
                    collision = true;
                }
            }
            if (collision)
            {
                Console.Beep();
                PrintOnPosition(dwarfLeftSide.x, dwarfLeftSide.y, "*", ConsoleColor.Magenta);
                PrintOnPosition(dwarfHead.x, dwarfHead.y, "*", ConsoleColor.Magenta);
                PrintOnPosition(dwarfRightSide.x, dwarfRightSide.y, "*", ConsoleColor.Magenta);
                lives--;
            }
            score++;
            Thread.Sleep(simplicity);
            Console.Clear();
            if (score % 100 == 0)
            {
                simplicity = simplicity - 10;
                level++;
            }
        }
        Console.Clear();
        Console.WriteLine("GAME OVER!".PadLeft(24, ' '));
        Console.WriteLine();
        Console.WriteLine("YOU ARE NOT A LOSER!!!".PadLeft(31, ' '));
        Console.WriteLine();
        Console.WriteLine("TRY AGAIN!".PadLeft(24, ' '));
        Console.WriteLine();
        Console.WriteLine(" You died on level {0}. Your score is {1}.", level, (score - 40));
        Console.WriteLine();
        Console.WriteLine("Press [Enter] to exit!".PadLeft(31, ' '));
        Console.ReadLine();
        Environment.Exit(0);
    }
}

