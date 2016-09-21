using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
class GandalfsStash
{
    static void Main()
    {
        int firstMood = int.Parse(Console.ReadLine());

        string[] input = Regex.Split(Console.ReadLine().ToLower().Trim(), @"[^a-z]+");

        //string[] input = Console.ReadLine().ToLower().Split(@"[^a-z]+");
        //.Split(new char[] { ' ', ',', '!', '_', ';', '@', '\t', '-' }, StringSplitOptions.RemoveEmptyEntries);

        //long mood = long.Parse(Console.ReadLine());
        //string food = Console.ReadLine();

        //Regex patternFood = new Regex(@"[a-zA-Z]+");
        //MatchCollection matches = patternFood.Matches(food);
        //foreach (Match match in matches)
        //{
        //    switch (match.ToString().ToLower())

        for (int i = 0; i < input.Length; i++)
        {
            switch(input[i])
            {
                case "cram":
                    firstMood += 2;
                    break;
                case "lembas":
                    firstMood += 3;
                    break;
                case "apple":
                    firstMood += 1;
                    break;
                case "melon":
                    firstMood += 1;
                    break;
                case "honeycake":
                    firstMood += 5;
                    break;
                case "mushrooms":
                    firstMood -= 10;
                    break;
                default:
                    firstMood -= 1;
                    break;
            }
        }

        if (firstMood < -5)
        {
            Console.WriteLine("{0}\n{1}", firstMood, "Angry");
        }
        else if (firstMood >= -5 && firstMood < 0)
        {
            Console.WriteLine("{0}\n{1}", firstMood, "Sad");
        }
        else if (firstMood >= 0 && firstMood < 15)
        {
            Console.WriteLine("{0}\n{1}", firstMood, "Happy");            
        }
        else if (firstMood >= 15)
        {
            Console.WriteLine("{0}\n{1}", firstMood, "Special JavaScript mood");
        }
    }
}

