using System;
using System.Text.RegularExpressions;
class ValidUsernames
{
    static void Main()
    {
        //You are part of the back-end development team of the next Facebook. You are given a line of usernames, 
        //between one of the following symbols: space, “/”, “\”, “(“, “)”. First you have to export all valid usernames. 
        //A valid username starts with a letter and can contain only letters, digits and “_”. It cannot be less than 3 or 
        //more than 25 symbols long. Your task is to sum the length of every 2 consecutive valid usernames and print on 
        //the console the 2 valid usernames with biggest sum of their lengths, each on a separate line. 
        //Input
        //The input comes from the console. One line will hold all the data. It will hold usernames, divided by the symbols: 
        //space, “/”, “\”, “(“, “)”. 
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //Print at the console the 2 consecutive valid usernames with the biggest sum of their lengths each on a separate 
        //line. If there are 2 or more couples of usernames with the same sum of their lengths, print he left most.
        //Constraints
        //•	The input line will hold characters in the range [0 … 9999].
        //•	The usernames should start with a letter and can contain only letters, digits and “_”.
        //•	The username cannot be less than 3 or more than 25 symbols long.
        //•	Time limit: 0.5 sec. Memory limit: 16 MB.
        //Examples
        //Input	                                            Output
        //ds3bhj y1ter/wfsdg 1nh_jgf ds2c_vbg\4htref	    wfsdg
        //                                                  ds2c_vbg
        //min23/ace hahah21 (    sasa  )  att3454/a/a2/abc	hahah21
        //                                                  sasa
        //Input	                                            Output
        //chico/ gosho \ sapunerka (3sas) mazut  lelQ_Van4e	mazut
        //                                                  lelQ_Van4e

        string input = Console.ReadLine();
        string username = @"(?<=[\s\/\\(\)]|^)([A-Za-z]\w{2,24})(?=[\s\/\\(\)]|$)";
        MatchCollection matches = Regex.Matches(input, username);

        int maxSum = 0;
        int index = 0;

        for (int i = 0; i < matches.Count - 1; i++)
        {
            int sum = matches[i].Length + matches[i + 1].Length;
            if (sum > maxSum)
            {
                maxSum = sum;
                index = i;
            }
        }

        Console.WriteLine(matches[index]);
        Console.WriteLine(matches[index + 1]);

    }
}
