using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Population_Counter_2
{
    public class PopulationCounter2
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, long>> populationCounter =
                new Dictionary<string, Dictionary<string, long>>();
            Dictionary<string, long> countries = new Dictionary<string, long>();

            string input = Console.ReadLine();
            while (input != "report")
            {
                string[] inputToArray = input.Split('|');
                string country = inputToArray[1];
                string city = inputToArray[0];
                long population = long.Parse(inputToArray[2]);

                if (!populationCounter.ContainsKey(country))
                {
                    populationCounter.Add(country, new Dictionary<string, long>());
                }

                if (!populationCounter[country].ContainsKey(city))
                {
                    populationCounter[country].Add(city, population);
                }

                if (!countries.ContainsKey(country))
                {
                    countries.Add(country, 0);
                }

                countries[country] += population;

                input = Console.ReadLine();
            }

            foreach (var country in countries.OrderByDescending(c => c.Value))
            {
                Console.WriteLine($"{country.Key} (total population: {country.Value})");
                foreach (var city in populationCounter[country.Key].OrderByDescending(c => c.Value))
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }
        }
    }
}