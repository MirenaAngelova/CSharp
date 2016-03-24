using System;
class PokerStraight
{
    static void Main()
    {
        //The classical playing cards have face and suit. Card faces are: 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, A. 
        //Cards suits are: Clubs (C), Diamonds (D), Hearts (H) and Spades (S). 
        //We denote a card in short as card face + card suit letter, 
        //e.g. 5C (Five Clubs), 10S (Ten Spades), AH (Ace Hearts), 2D (Two Diamonds).
        //In some poker games, we have a hand called "straight" which consists of a sequence of five cards 
        //of increasing sequential rank. The card ranks are as follows: 
        //A, 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, A. 
        //Note that the Ace (A) is a special card: it works both as the smallest and as the biggest card.
        //Examples of "straight": 
        //(AC 2H 3H 4C 5H), (2H 3S 4H 5H 6D), (5C 6C 7C 8C 9C), (7C 8D 9S 10S JS), (9C 10H JD QD KD), (10D JD QS KH AH). 
        //The following hands are not "straight": 
        //(9D JD QS KH AH) – not sequential; (10C 7C 9D 8S JS) – sequential, but not ordered; (9H 8S 7H 6H 5D) – sequential, 
        //but incorrectly ordered.
        //Card faces have the following weights: A  1 (as first card) or 14 (as last card); 
        //2  2; 3  3; 4  4; 5  5; 6  6; 7  7; 8  8; 9  9; 10  10; J  11; Q  12; K 13. 
        //Card suits have the following weights: Clubs  1; Diamonds  2; Hearts  3; Spades  4. 
        //Hands weight is calculated as follows:
        //10 * weight(first card face) + weight(first card suit) +
        //20 * weight(second card face) + weight(second card suit) +
        //30 * weight(third card face) + weight(third card suit) +
        //40 * weight(fourth card face) + weight(fourth card suit) +
        //50 * weight(fifth card face) + weight(fifth card suit)
        //Examples of straight hands and their weights:
        //•	weight(AC 2H 3H 4C 5S) = (10*1 + 1) + (20*2 + 3) + (30*3 + 3) + (40*4 + 1) + (50*5 + 4) = 562
        //•	weight(10H JS QD KS AD) = (10*10 + 3) + (20*11 + 4) + (30*12 + 2) + (40*13 + 4) + (50*14 + 2) = 1915
        //Your task is to write a program that calculates the number of straight hands that have given weight w.
        //Input
        //The input data should be read from the console. It holds a single number w (the target weight). 
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //Print on the console the number of straight hands of given weight w.
        //Constraints
        //•	The number w is an integer in the range [0…5000].
        //•	Allowed time: 0.2 seconds. Allowed memory: 16 MB.
        //Examples
        //Input	Output	Hands		            Input	Output	Hands
        //555	1	    (AC 2C 3C 4C 5C)		1907	15	    (10C JC QC KC AH) (10C JC QC KD AD) 
        //200	0	    (no hands)		                        (10C JC QC KH AC) (10C JC QD KC AD) 
        //1912	155	    (155 hands)		                        (10C JC QD KD AC) (10C JC QH KC AC) 
        //856	5	    (3C 4C 5C 6C 7D)                        (10C JD QC KC AD) (10C JD QC KD AC) 
        //              (3C 4C 5C 6D 7C)                        (10C JD QD KC AC) (10C JH QC KC AC) 
        //              (3C 4C 5D 6C 7C)                        (10D JC QC KC AD) (10D JC QC KD AC) 
        //              (3C 4D 5C 6C 7C)                        (10D JC QD KC AC) (10D JD QC KC AC) 
        //              (3D 4C 5C 6C 7C)                        (10H JC QC KC AC)

        int weight = int.Parse(Console.ReadLine());
        string[] face = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "D", "K", "A" };
        string[] suit = { "Clubs", "Diamonds", "Hearts", "Spades" };
        int count = 0;
        for (int f = 0; f < face.Length - 4; f++)
        {
            for (int s1 = 0; s1 < suit.Length; s1++)
            {
                for (int s2 = 0; s2 < suit.Length; s2++)
                {
                    for (int s3 = 0; s3 < suit.Length; s3++)
                    {
                        for (int s4 = 0; s4 < suit.Length; s4++)
                        {
                            for (int s5 = 0; s5 < suit.Length; s5++)
                            {
                                int newWeight = 10 * (f + 1) + (s1 + 1) + 20 * (f + 2) + (s2 + 1) +
                                    30 * (f + 3) + (s3 + 1) + 40 * (f + 4) + (s4 + 1) + 50 * (f + 5) + (s5 + 1);
                                if (newWeight == weight)
                                {
                                    count++;
                                    //string card1 = face[f + 0] + suit[s1][0];
                                    //string card2 = face[f + 1] + suit[s2][0];
                                    //string card3 = face[f + 2] + suit[s3][0];
                                    //string card4 = face[f + 3] + suit[s4][0];
                                    //string card5 = face[f + 4] + suit[s5][0];
                                    //Console.WriteLine("({0} {1} {2} {3} {4})", card1, card2, card3, card4, card5);
                                }
                            }
                        }
                    }
                }
            }
        }
        Console.WriteLine(count);
    }
}

