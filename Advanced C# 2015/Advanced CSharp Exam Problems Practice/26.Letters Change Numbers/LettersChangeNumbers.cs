using System;
using System.Collections.Generic;
using System.Linq;
    class LettersChangeNumbers
    {
        static void Main()
        {
        //string input = Console.ReadLine();
        //string inputLine = new Regex("\\s+").Replace(input, "");
        //string pattern = @"([a-zA-Z])([0-9]+)([a-zA-Z])";
        //Regex patternToMatch = new Regex(pattern);
        //MatchCollection matches = patternToMatch.Matches(inputLine);
        //double sum = 0;
        //foreach (Match match in matches)
        //{
        //    char firstLetter = char.Parse(match.Groups[1].ToString());
        //    double number = int.Parse(match.Groups[2].ToString());
        //    char lastLetter = char.Parse(match.Groups[3].ToString());
        //    if (char.IsUpper(firstLetter))
                string[] inputs = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            List<double> sum = new List<double>();

            foreach (var input in inputs)
            {
                double result = double.Parse(input.Substring(1, input.Length - 2));

                if (char.IsUpper(input.First()))
                {
                    result /= input.First() - 'A' + 1;
                }
                else if (char.IsLower(input.First()))
                {
                    result *= input.First() - 'a' + 1;
                }

                if (char.IsUpper(input.Last()))
                {
                    result -= input.Last() - 'A' + 1;
                    sum.Add(result);
                }
                else if (char.IsLower(input.Last()))
                {
                    result += input.Last() - 'a' + 1;
                    sum.Add(result);
                }                
            }

            Console.WriteLine("{0:f2}", sum.Sum());
        }
    }

