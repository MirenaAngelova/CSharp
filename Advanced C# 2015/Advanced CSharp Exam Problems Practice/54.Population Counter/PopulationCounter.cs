using System;
using System.Collections.Generic;
using System.Linq;
    class PopulationCounter
    {
        static void Main()
        {
            var rawData = new Dictionary<string, Dictionary<string, long>>();

            string inputLines = Console.ReadLine();

            while (inputLines != "report")
            {
                string[] data = inputLines.Split('|');
                string city = data[0];
                string country = data[1];
                int population = int.Parse(data[2]);

                if (!rawData.ContainsKey(country))
                {
                    rawData.Add(country, new Dictionary<string, long>());
                }

                rawData[country].Add(city, population);

                inputLines = Console.ReadLine();
            }

            var sortedRawData = rawData.OrderByDescending(x => x.Value.Sum(y => y.Value));

            foreach (var countryData in sortedRawData)
            {
                long totalPopulation = countryData.Value.Sum(x => x.Value);

                Console.WriteLine("{0} (total population: {1})", countryData.Key, totalPopulation);

                var sortedCityData = countryData.Value.OrderByDescending(x => x.Value);

                foreach (var cityData in sortedCityData)
                {
                    Console.WriteLine("=>{0}: {1}", cityData.Key, cityData.Value);
                }
            }
        }
    }

