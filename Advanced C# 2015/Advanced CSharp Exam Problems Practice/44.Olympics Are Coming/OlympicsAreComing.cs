using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
class OlympicsAreComing
{
    static void Main()
    {
        //It’s still 2015, but all around the world athletes are in the heat of preparation for one of the biggest events 
        //in sports. You’re a statistician and you’ve been hired by a bookie to collect some data in order to determine 
        //the favorites and underdogs in the coming Olympic Games. To do that, you’ll receive information about the winners 
        //of some sports events in format: "[athlete] | [country]". Your employer needs the data fast, so at some point he’ll
        //tell you to stop and "report". 
        //Your task is to aggregate the data and print it on the console. The data for each country should be on a separate 
        //line and should be in format: "[country] ([numberOfParticipants] participants): [wins] wins". The number of 
        //participants reflects the number of unique athletes as some of them may have won more than one contest 
        //(name comparison should be case-sensitive). The countries should be ordered by the number of wins in descending 
        //order, meaning that you should print first the country with the most total wins. In case several countries 
        //have the same number of wins, print them in the order in which they have been added to the database.
        //Make sure to remove all unnecessary whitespaces from the names of the countries and the athletes; if a name 
        //consists of two words they should be separated by a single space and there shouldn’t be any leading or trailing 
        //whitespaces.
        //Input
        //•	The input data should be read from the console.
        //•	It consists of a variable number of lines and ends when the command "report" is received.
        //•	The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //•	The output should be printed on the console.
        //•	Print the aggregated data for each country on a new line in the format specified above.
        //Constraints
        //•	The name of the athlete and the country will consist of one or two words (separated by one or more whitespaces). 
        //There may be whitespaces before or after the names.
        //•	The name of the athlete and the country name will be separated from each other by a pipe ('|'). 
        //There may be whitespaces around the pipe.
        //•	The number of input lines will be in the range [2 … 50].
        //•	Allowed working time for your program: 0.1 seconds. Allowed memory: 16 MB.
        //Examples
        //Input	                                        Output
        //Ivan ivanov | Bulgaria                        Bulgaria (2 participants): 3 wins
        //Ivan Ivanov |Bulgaria                         Switzerland (1 participants): 1 wins
        //Roger Federer|Switzerland
        //Ivan    Ivanov|   Bulgaria
        //report	
        //Input	                        Output
        //Boko|Bulgaria                 Bulgaria (2 participants): 2 wins
        //Gero|Spain                    Angola (2 participants): 2 wins
        //A|Angola                      England (2 participants): 2 wins
        //B|Angola                      Spain (1 participants): 1 wins
        //Mike|England
        //Steve|England
        //Pesho  |    Bulgaria
        //report	

        const string SplitPattern = @"\s*\|\s*";
        Regex regex = new Regex(SplitPattern);

        var countryData = new Dictionary<string, List<string>>();
        string input = Console.ReadLine();

        while (input != "report")
        {
            string[] tokens = regex.Split(input.Trim());
            string athlete = Regex.Replace(tokens[0].Trim(), @"\s+", " ");
            string country = Regex.Replace(tokens[1].Trim(), @"\s+", " ");

            if (!countryData.ContainsKey(country))
            {
                countryData.Add(country, new List<string>());
            }

            countryData[country].Add(athlete);
            input = Console.ReadLine();
        }

        var orderedCountryData = countryData.OrderByDescending(x => x.Value.Count);

        foreach (var country in orderedCountryData)
        {
            Console.WriteLine("{0} ({1} participants): {2} wins", 
                country.Key, country.Value.Distinct().Count(), country.Value.Count());
        }
    }
}