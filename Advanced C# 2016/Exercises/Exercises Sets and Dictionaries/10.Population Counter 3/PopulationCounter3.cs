using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Population_Counter_3
{
    public class PopulationCounter3
    {
        public static void Main()
        {
            Dictionary<string, List<City>> populationCounter =
                new Dictionary<string, List<City>>();
            string input = Console.ReadLine();

            while (input != "report")
            {
                string[] inputToArray = input.Split('|');
                string country = inputToArray[1];
                string cityInput = inputToArray[0];
                long population = long.Parse(inputToArray[2]);

                City city = new City(cityInput, population);
                if (!populationCounter.ContainsKey(country))
                {
                    populationCounter.Add(country, new List<City>());
                }

                if (!populationCounter[country].Contains(city))
                {
                    populationCounter[country].Add(city);
                }

                input = Console.ReadLine();
            }

            var orderedPopulationCounter = populationCounter
                .OrderByDescending(pc => pc.Value.Sum(c => c.Population));
            foreach (var country in orderedPopulationCounter)
            {
                long totalPopulation = country.Value.Sum(c => c.Population);
                Console.WriteLine($"{country.Key} (total population: {totalPopulation})");
                var orderedCountry = country.Value.OrderByDescending(c => c.Population);
                foreach (var city in orderedCountry)
                {
                    Console.WriteLine($"=>{city.CityName}: {city.Population}");
                }
            }
        }
    }

    public class City
    {
        public City(string cityName, long population)
        {
            this.CityName = cityName;
            this.Population = population;
        }

        public long Population { get; set; }

        public string CityName { get; set; }
    }
}
