using System;
//using System.Text;
class PrintADeckOf52Card
{
    static void Main()
    {
        //Write a program that generates and prints all possible cards from a standard deck of 52 cards 
        //(without the jokers). The cards should be printed using the classical notation (like 5♠, A♥, 9♣ and K♦). 
        //The card faces should start from 2 to A. Print each card face in its four possible suits: 
        //clubs, diamonds, hearts and spades. Use 2 nested for-loops and a switch-case statement.
        //output
        //2♣ 2♦ 2♥ 2♠
        //3♣ 3♦ 3♥ 3♠
        //…
        //K♣ K♦ K♥ K♠
        //A♣ A♦ A♥ A♠
        //Console.OutputEncoding = Encoding.Unicode;

        //string[] faces = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        //int[] suits = { 5, 4, 3, 6 };
        //foreach (var face in faces)
        //{
        //    foreach (var suit in suits)
        //    {
        //        Console.Write("{0}{1} ", face, (char)suit);
        //    }
        //    Console.WriteLine();
        //}


        for (int i = 2; i <= 14; i++)
        {
            for (int j = 5; j < 7; j--)
            {
                if (i < 11)
                {
                    Console.Write("{0}{1}", i, (char)j);
                }
                switch (i)
                {
                    case 11:
                        Console.Write("J{0}", (char)j);
                        break;
                    case 12:
                        Console.Write("Q{0}", (char)j);
                        break;
                    case 13:
                        Console.Write("K{0}", (char)j);
                        break;
                    case 14:
                        Console.Write("A{0}", (char)j);
                        break;
                }
                if (j == 3)
                {
                    j = 7;
                }
                if (j == 6)
                {
                    break;
                }
            }
            Console.WriteLine();
        }

        //string[] faces = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        //char[] suits = { '\u2663', '\u2666', '\u2665', '\u2660' };
        //for (int i = 0; i < faces.Length; i++)
        //{
        //    for (int j = 0; j < suits.Length; j++)
        //    {
        //        Console.Write("{0}{1} ", faces[i], suits[j]);
        //    }
        //    Console.WriteLine();
        //}
    }
}



