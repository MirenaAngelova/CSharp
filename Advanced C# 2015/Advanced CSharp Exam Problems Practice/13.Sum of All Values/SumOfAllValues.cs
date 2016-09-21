using System;
using System.Text.RegularExpressions;

class SumOfAllValues
{
    static void Main()
    {
        //You are given a keys string and a text string. Write a program that finds the start key and the end key from the 
        //keys string and then applies them to the text string.
        //The start key will always stay at the beginning of the keys string. It can contain only letters and underscore 
        //and ends just before the first found digit.
        //The end key will always stay at the end of the keys string. It can contain only letters and underscore and starts 
        //just after the last found digit.
        //Print at the console the sum of all values (only integer and floating-point numbers with dot as a separator are 
        //considered valid) in the text string, between a start key and an end key. If the value is 0 then print 
        //“The total value is: nothing”. If no start key or no end key is found then print “A key is missing”.
        //Input
        //The input will be read from the console. The first line will hold the keys string and the second line will 
        //hold the text to search.
        //Output
        //The output should hold the result text, printed in an HTML paragraph. The actual value of the sum should be italic.
        //Constraints
        //•	The keys string and text string will hold only ASCII characters (no Unicode).
        //•	Allowed working time: 0.1 seconds. Allowed memory: 16 MB.
        //Examples
        //Input
        //keysString	startKEY12adghfgh243212gadghfgs43endKEY
        //textString	asdjykulgfjddfsffdstartKEY12endKEYqwfrhtyu67543rewghy3tefdgdstartKEY123.45endKEYwret34yrestartKEY2.6endKEY213434ytuhrgerweasfd            
        //              startKEYendKEYstartKEYasfdgeendKEY
        //Output
        //<p>The total value is: <em>138.05</em></p>

        //Input
        //keysString	startKEY12a
        //textString	asdjykulgfjddfsffdstartKEY12endKEYqwfrhtyu67543rewghy3tefdgdstartKEY123.45endKEYwret34yrestartKEY2.
        //              6endKEY213434ytuhrgerweasfd
        //              startKEYendKEYstartKEYasfdgeendKEY
        //Output
        //<p>The total value is: <em>nothing</em></p>

        //Input
        //keysString	startKEY12
        //textString	asdjykulgfjddfsffdstartKEY12endKEYqwfrhtyu67543rewghy3tefdgd
        //Output
        //<p>A key is missing</p>


        //Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));

        //string keyString = Console.ReadLine();
        //string patternKey = @"^([a-zA-Z_]*)(?=\d)(.*)(?<=\d)([a-zA-Z_]*)$";
        //Match keys = Regex.Match(keyString, patternKey);
        //string startKey = keys.Groups[1].Value;
        //string endKey = keys.Groups[3].Value;
        //if (startKey.Length == 0 || endKey.Length == 0)
        //{
        //    Console.WriteLine("<p>A key is missing</p>");
        //    return;
        //}
        //string pattern = string.Format("{0}(.*?){1}", startKey, endKey);
        //string text = Console.ReadLine();
        //MatchCollection matches = Regex.Matches(text, pattern);
        //double sum = 0;
        //foreach (Match match in matches)
        //{
        //    double number;
        //    double.TryParse(match.Groups[1].Value, out number);
        //    sum += number;
        //}
        //if (sum == 0)
        //{
        //    Console.WriteLine("<p>The total value is: <em>nothing</em></p>");
        //}
        //else
        //{
        //    Console.WriteLine("<p>The total value is: <em>{0}</em></p>", sum);
        //}


        string keys = Console.ReadLine();
        string text = Console.ReadLine();

        string patternKeys = "^([A-Za-z_]+)\\d+.*?\\d+([A-Za-z_]+)$";
        Regex regexKeys = new Regex(patternKeys);
        MatchCollection matches = regexKeys.Matches(keys);
        if (matches.Count < 1)
        {
            Console.WriteLine("<p>A key is missing</p>");
            return;
        }

        string firstKey = matches[0].Groups[1].Value;
        string endKey = matches[0].Groups[2].Value;

        string patternText = firstKey + "(\\d*\\.?\\d+)" + endKey;
        Regex regexText = new Regex(patternText);
        MatchCollection matchesText = regexText.Matches(text);
        if (matchesText.Count == 0)
        {
            Console.WriteLine("<p>The total value is: <em>nothing</em></p>");
            return;
        }

        double sum = 0;
        foreach (Match match in matchesText)
        {
            sum += double.Parse(match.Groups[1].Value);
        }

        Console.WriteLine($"<p>The total value is: <em>{sum}</em></p>");
    }
}