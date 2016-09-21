using System;
using System.Collections.Generic;
class NightLife
{
    static void Main()
    {
        //Being a nerd means writing programs about night clubs instead of actually going to ones. Spiro is a nerd 
        //and he decided to summarize some info about the most popular night clubs around the world. He's come up with 
        //the following structure – he'll summarize the data by city, where each city will have a list of venues and 
        //each venue will have a list of performers. Help him finish the program, so he can stop staring at the computer 
        //screen and go get himself a cold beer.
        //You'll receive the input from the console. There will be an arbitrary number of lines until you 
        //receive the string "END". Each line will contain data in format: "city;venue;performer". 
        //If either city, venue or performer don't exist yet in the database, add them. If either the city and/or 
        //venue already exist, update their info.
        //Cities should remain in the order in which they were added, venues should be sorted alphabetically 
        //and performers should be unique (per venue) and also sorted alphabetically.
        //Print the data by listing the cities and for each city its venues (on a new line starting with "->") 
        //and performers (separated by comma and space). Check the examples to get the idea. And grab a beer when you're done,
        //you deserve it. Spiro is buying.
        //Input	                                Output
        //Sofia;Biad;Preslava                Sofia
        //Pernik;Stadion na mira;Vinkel      ->Biad: Preslava
        //New York;Statue of Liberty;Krisko  Pernik
        //Oslo;everywhere;Behemoth           ->Letishteto: RoYaL
        //Pernik;Letishteto;RoYaL            ->Stadion na mira: Bankin, Vinkel
        //Pernik;Stadion na mira;Bankin      NewYork
        //Pernik;Stadion na mira;Vinkel      ->Statue of Liberty: Krisko
        //END	                             Oslo
        //                                   ->everywhere: Behemoth
        //      

        Dictionary<string, SortedDictionary<string, SortedSet<string>>> nightLife =
            new Dictionary<string, SortedDictionary<string, SortedSet<string>>>();

        while (true)
        {
            string input = Console.ReadLine();
            string[] data;
            if (input != "END")
            {
                data = input.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                string city = data[0];
                string venue = data[1];
                string performer = data[2];

                if (!nightLife.ContainsKey(city))
                {
                    SortedSet<string> performers = new SortedSet<string>();
                    performers.Add(performer);

                    SortedDictionary<string, SortedSet<string>> venues = new SortedDictionary<string, SortedSet<string>>();
                    venues.Add(venue, performers);

                    nightLife.Add(city, venues);
                }
                else if (nightLife.ContainsKey(city))
                {
                    if (!nightLife[city].ContainsKey(venue))
                    {
                        SortedSet<string> performers = new SortedSet<string>();
                        performers.Add(performer);

                        nightLife[city].Add(venue, performers);
                    }
                    else if (nightLife[city].ContainsKey(venue))
                    {
                        nightLife[city][venue].Add(performer);
                    }
                }
            }
            else
            {
                break;
            }
        }

        foreach (var pair1 in nightLife)
        {
            Console.WriteLine(pair1.Key);
            foreach (var pair2 in pair1.Value)
            {
                Console.WriteLine("->{0}: {1}", pair2.Key, string.Join(", ", pair2.Value));
            }
        }
    }
}