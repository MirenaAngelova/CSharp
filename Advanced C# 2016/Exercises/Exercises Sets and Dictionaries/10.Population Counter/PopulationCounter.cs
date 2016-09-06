using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Population_Counter
{
    public class PopulationCounter
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, long>> populationCounter =
                new Dictionary<string, Dictionary<string, long>>();

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
                    populationCounter[country].Add(city, 0);
                }

                populationCounter[country][city] = population;

                input = Console.ReadLine();
            }

            //foreach (
            //    var country in
            //        populationCounter
            //            .OrderByDescending(outerPair => outerPair.Value.Sum(innerPair => innerPair.Value)))

            //{
            //    long totalPopulation = country.Value.Values.Sum();
            //    Console.WriteLine($"{country.Key} (total population: {totalPopulation})");

            //    foreach (var city in country.Value.OrderByDescending(v => v.Value)) 
            //    {
            //        Console.WriteLine($"=>{city.Key}: {city.Value}");
            //    }
            //}

            foreach (var country in populationCounter.OrderByDescending(pc => pc.Value.Values.Sum()))
            {
                long totalPopulation = populationCounter[country.Key].Values.Sum();
                Console.WriteLine($"{country.Key} (total population: {totalPopulation})");

                foreach (var city in populationCounter[country.Key].OrderByDescending(c => c.Value))
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }
        }
    }
}
