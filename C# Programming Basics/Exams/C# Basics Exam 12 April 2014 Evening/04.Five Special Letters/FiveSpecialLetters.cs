using System;
using System.Collections.Generic;
using System.Linq;
class FiveSpecialLetters
{
    static void Main()
    {
        //We are given two numbers: start and end. Write a program to generate all sequences of 5 letters, each from the set 
        //{ 'a', 'b', 'c', 'd', 'e' }, such that the weight of these 5 letters is a number in the range [start … end] inclusively.
        //Print them in alphabetical order, in a single line, separated by a space.
        //The weight of a single letter is calculated as follows:  weight('a') = 5; weight('b') = -12;  weight('c') = 47;  
        //weight('d') = 7;  weight('e') = -32. The weight of a sequence of letters c1c2…cn is the calculated by first removing 
        //all repeating letters (from right to left) and then calculate the formula:
        //weight(c1c2…cn) = 1*weight(c1) + 2*weight(c2) + … + n*weight(cn)
        //For example, the weight of "bcddc" is calculated as follows: First we remove the repeating letters and we get "bcd". 
        //Then we apply the formula: 1*weight('b') + 2*weight('c') + 3*weight('d') = 1*(-12) + 2*47 + 3*7 = 103. 
        //Another example: weight("cadea") = weight("cade") = 1*47 + 2*5 + 3*7 - 4*32 = -50.
        //Input
        //The input data should be read from the console. It will consist of 2 lines:
        //•	The number start stays at the first line.
        //•	The number end stays at the second line.
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //The output should be printed on the console as a sequence of strings in alphabetical order. Each string should be 
        //separated than the next string by a single space. In case no 5-letter strings exist 
        //with a weight in the specified range, print “No”.
        //Constraints
        //•	The numbers start and end will be an integers in the range [-10000…10000].
        //•	Allowed working time for your program: 0.25 seconds.
        //•	Allowed memory: 16 MB.
        //Examples
        //Input	 Output	        Comments
        //40     bcead bdcea	weight("bcead") = 41
        //42                    weight("bdcea") = 40	
        //
        //Input	Output		                Input	Output		                Input	Output
        //-1    bcdea cebda eaaad eaada     200     baadc babdc badac badbc 	300	    No
        //1	    eaadd eaade eaaed eadaa     300     badca badcb badcc badcd     400	
        //      eadad eadae eadda eaddd             baddc bbadc bbdac bdaac
        //      eadde eadea eaded eadee             bdabc bdaca bdacb bdacc
        //      eaead eaeda eaedd eaede             bdacd bdadc bdbac bddac 
        //      eaeed eeaad eeada eeadd             beadc bedac eabdc ebadc 
        //      eeade eeaed eeea		            ebdac edbac	

        int start = int.Parse(Console.ReadLine());
        int end = int.Parse(Console.ReadLine());
        char[] letters = { 'a', 'b', 'c', 'd', 'e' };
        int[] weights = { 5, -12, 47, 7, -32 };
        List<char> currentString = new List<char>();
        string exit = "";
        int counter = 0;

        for (int a = 0; a < letters.Length; a++)
        {
            for (int b = 0; b < letters.Length; b++)
            {
                for (int c = 0; c < letters.Length; c++)
                {
                    for (int d = 0; d < letters.Length; d++)
                    {
                        for (int e = 0; e < letters.Length; e++)
                        {
                            int weight = 0;
                            currentString.Add(letters[a]);
                            currentString.Add(letters[b]);
                            currentString.Add(letters[c]);
                            currentString.Add(letters[d]);
                            currentString.Add(letters[e]);
                            currentString = currentString.Distinct().ToList();

                            for (int i = 0; i < currentString.Count; i++)
                            {
                                switch (currentString[i])
                                {
                                    case 'a':
                                        weight += (i + 1) * weights[0];
                                        break;
                                    case 'b':
                                        weight += (i + 1) * weights[1];
                                        break;
                                    case 'c':
                                        weight += (i + 1) * weights[2];
                                        break;
                                    case 'd':
                                        weight += (i + 1) * weights[3];
                                        break;
                                    case 'e':
                                        weight += (i + 1) * weights[4];
                                        break;
                                }
                            }
                            if ((weight >= start) & (weight <= end))
                            {
                                exit += "" + letters[a] + letters[b] + letters[c] + letters[d] + letters[e] + " ";
                                counter++;
                            }
                            currentString.Clear();
                        }
                    }
                }
            }
        }
        if (counter == 0)
        {
            Console.WriteLine("No");
        }
        else
        {
            Console.WriteLine(exit);
        }
    }
}

