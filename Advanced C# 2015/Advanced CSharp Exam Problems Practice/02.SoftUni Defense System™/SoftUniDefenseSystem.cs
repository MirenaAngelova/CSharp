using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02.SoftUni_Defense_System_
{
    class SoftUniDefenseSystem
    {
        static void Main()
        {
            string inputLine = Console.ReadLine();
            double sumOfAlcohol = 0;

            StringBuilder input = new StringBuilder();
            while (inputLine != "OK KoftiShans")
            {
                input.Append(inputLine + "&");
                inputLine = Console.ReadLine();
            }

            Regex nameAlcoholAmount = new Regex(@".*?([A-Z][a-z]+).*?([A-Z][a-z]*[A-Z]).*?([\d]+[L]).*?");
            var matchRegex = nameAlcoholAmount.Matches(input.ToString());
            foreach (Match match in matchRegex)
            {
                string name = match.Groups[1].Value;
                string alcohol = match.Groups[2].Value.ToLower();
                string amountLiter = match.Groups[3].Value;
                int amount = int.Parse(amountLiter.Substring(0, amountLiter.Length - 1));
                sumOfAlcohol += amount;
                Console.WriteLine($"{name} brought {amount} liters of {alcohol}!");
            }

            sumOfAlcohol *= 0.001;
            Console.WriteLine($"{sumOfAlcohol:F3} softuni liters");
        }
    }
}
