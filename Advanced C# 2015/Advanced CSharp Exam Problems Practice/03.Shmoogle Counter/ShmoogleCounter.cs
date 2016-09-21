using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.Shmoogle_Counter
{
    class ShmoogleCounter
    {
        static void Main()
        {
            StringBuilder input = new StringBuilder();

            List<string> doubles = new List<string>();
            List<string> ints = new List<string>();

            string inputLine = Console.ReadLine();

            while (inputLine != "//END_OF_CODE")
            {
                input.Append(inputLine);

                inputLine = Console.ReadLine();
            }

            Regex regexDoubles = new Regex(@"double ([a-z][a-zA-Z]*)");
            Regex regexInts = new Regex(@"int ([a-z][a-zA-Z]*)");

            var matchDoubles = regexDoubles.Matches(input.ToString());
            var matchInts = regexInts.Matches(input.ToString());
            
            foreach (Match match in matchDoubles)
            {
                doubles.Add(match.Groups[1].Value); 
            }
   
            Console.WriteLine("Doubles: " + IsFound(doubles));

            foreach (Match match in matchInts)
            {
                ints.Add(match.Groups[1].Value);
            }

            Console.WriteLine("Ints: " + IsFound(ints));
        }

        private static string IsFound(List<string> doubleInt)
        {
            return doubleInt.Count > 0 ? string.Join(", ", doubleInt.OrderBy(x => x)) : "None";
        }
    }
}
