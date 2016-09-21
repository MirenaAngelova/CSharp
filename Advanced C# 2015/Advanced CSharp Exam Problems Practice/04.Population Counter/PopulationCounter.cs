using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Population_Counter
{
    class PopulationCounter
    {
        static void Main()
        {
            Dictionary<string, Dictionary<string, long>> countries =
                new Dictionary<string, Dictionary<string, long>>();
            string input = Console.ReadLine();
            while (input != "report")
            {
                string[] inputLine = input.Split('|');
                string city = inputLine[0];
                string country = inputLine[1];
                int population = int.Parse(inputLine[2]);
                if (!countries.ContainsKey(country))
                {
                    countries.Add(country, new Dictionary<string, long>());
                }

                countries[country].Add(city, population);

                input = Console.ReadLine();
            }

            var orderCountries = countries
                .OrderByDescending(country => country.Value.Sum(city => city.Value));

            foreach (var country in orderCountries)
            {
                long totalPopulation = country.Value.Sum(city => city.Value);
                Console.WriteLine("{0} (total population: {1})", country.Key, totalPopulation);

                var orderCities = country.Value.OrderByDescending(c => c.Value);
                foreach (var city in orderCities)
                {
                    Console.WriteLine("=>{0}: {1}", city.Key, city.Value);
                }
            }
        }
    }
}

