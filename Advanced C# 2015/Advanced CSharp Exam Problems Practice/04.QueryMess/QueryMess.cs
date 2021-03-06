﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
class QueryMess
{
    static void Main()
    {
        //Ivancho participates in a team project with colleagues at SoftUni.  They have to develop an application, 
        //but something mysterious happened – at the last moment all team members… disappeared!  And guess what? 
        //He is left alone to finish the project.  All that is left to do is to parse the input data and store it in a 
        //special way, but Ivancho has no idea how to do that! Can you help him?
        //Input
        //The input comes from the console on a variable number of lines and ends when the keyword "END" is received. 
        //For each row of the input, the query string contains pairs field=value. Within each pair, the field name and 
        //value are separated by an equals sign, '='. The series of pairs are separated by an ampersand, '&'. 
        //The question mark is used as a separator and is not part of the query string. A URL query string may contain 
        //another URL as value. The input data will always be valid and in the format described. There is no need to check 
        //it explicitly.
        //Output
        //For each input line, print on the console a line containing the processed string as follows:  
        //key=[value]nextkey=[another  value] … etc. 
        //Multiple whitespace characters should be reduced to one inside value/key names, but there shouldn’t be any 
        //whitespaces before/after extracted keys and values. If a key already exists, the value is added with comma 
        //and space after other values of the existing key in the current string.  See the examples below.  
        //Constraints
        //•	SPACE is encoded as '+' or "%20". Letters (A-Z and a-z), numbers (0-9), the characters '*', '-', '.', '_' and 
        //other non-special symbols are left as-is.
        //•	Allowed working time: 0.1 seconds. Allowed memory: 16 MB.
        //Examples
        //Input	Output
        //login=student&password=student
        //END	login=[student]password=[student]
        //Input
        //field=value1&field=value2&field=value3
        //http://example.com/over/there?name=ferret
        //END
        //Output
        //field=[value1, value2, value3]
        //name=[ferret]
        //Input
        //foo=%20foo&value=+val&foo+=5+%20+203
        //foo=poo%20&value=valley&dog=wow+
        //url=https://softuni.bg/trainings/coursesinstances/details/1070
        //https://softuni.bg/trainings.asp?trainer=nakov&course=oop&course=php
        //END
        //Output
        //foo=[foo, 5 203]value=[val]
        //foo=[poo]value=[valley]dog=[wow]
        //url=[https://softuni.bg/trainings/coursesinstances/details/1070]
        //trainer=[nakov]course=[oop, php]


        Dictionary<string, List<string>> pairs = new Dictionary<string, List<string>>();
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            input = Regex.Replace(input, @"(%20|\+)", " ");
            input = Regex.Replace(input, @"\s+", " ");
            string pattern = @"([^=&?]+)=([^&]+)";
            Match m = Regex.Match(input, pattern);
            while (m.Success)
            {
                string key = m.Groups[1].Value.Trim();
                string value = m.Groups[2].Value.Trim();
                if (!pairs.ContainsKey(key))
                {
                    pairs.Add(key, new List<string>());
                }
                pairs[key].Add(value);
                m = m.NextMatch();
            }
            foreach (var entry in pairs)
            {
                Console.Write("{0}=[{1}]", entry.Key, String.Join(", ", entry.Value));
            }
            pairs.Clear();
            Console.WriteLine();
        }
    }
}
