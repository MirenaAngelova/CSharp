using System;
using System.Collections.Generic;
using System.Linq;

public class Player
{
    public int age;
    public string name;
    public List<string> oponents;
    public int win;
    public int loss;
}

class VladkosNotebook
{
    static void Main()
    {
        //Vladko Karamfilov (a.k.a. SUPER VLADO or St.Karamfilov) is a very famous table tennis player. 
        //He is also very organized. In order to become the best tennis player there is, he writes down everything 
        //about his opponents in a pretty notebook, covered in pink flowers. He is winning all his games, so he has 
        //a lot of hostile opponents. One night, one of them crawled into Vladko's room and tore his notebook apart 
        //into separate sheets of paper. Vladko needs your help to gather his information from all the sheets. 
        //Fortunately, Vladko writes everything about a single opponent on a sheet with a certain color 
        //(for example all information on red sheets is about opponent X, all information on blue sheets is about 
        //opponent Y etc.). You are given a list of colored sheets given as a text table with the following columns: 
        //	Option 01 – [color of the sheet]|[win/loss]|[opponent name]
        //	Option 02 – [color of the sheet]|[name]|[player name] 
        //	Option 03 – [color of the sheet]|[age]|[player age]
        //The different columns will always be separated only by 'I' (there won't be any whitespaces). The rank of 
        //each player is calculated by the formula rank = (wins+1) / (losses+1). If a certain color sheet 
        //has no information about the name or the age of the player, you should not print it in the output. 
        //If there is no information about the opponents, you must print "(empty)" where the opponents list should be. 
        //There might be many opponents with the same name. If there was no information recovered
        //(no colors containing name and age), print only "No data recovered." Write a program to aggregate 
        //the results and print them as shown in the example below.
        //Input
        //The input comes from the console on a variable number of lines and ends when the keyword "END" is received. 
        //The input data will always be valid and in the format described. There is no need to check it explicitly.
        //Output
        //Print at the console the information for each player (sorted by color name) that holds the age, the name, 
        //a list with the opponents (in alphabetical order) and rank of the player. Please follow exactly the format 
        //from the example below. The rank of the players should be rounded to 2 digits after the decimal point:
        //	1.5 -> 1.50; 1 -> 1.00; 1.3214123 -> 1.32
        //Constraints
        //•	The numbers of input lines is between 1 and 150.
        //•	The names of colors and players consist of Latin letters and spaces. Their length is between 1 and 50 
        //characters.
        //•	The value of age will be an integer in the range [0 … 99].
        //•	Allowed working time: 0.3 seconds. Allowed memory: 32 MB.
        //Hints
        //•	The sorting of the opponents array should be done using the StringComparer.Ordinal option.
        //Examples
        //Input	                            Output
        //purple|age|99                     Color: purple
        //red|age|44                        -age: 99
        //blue|win|pesho                    -name: VladoKaramfilov
        //blue|win|mariya                   -opponents: Kiko, Kiko, Kiko, Manov, Manov, Yana, Yana, Yana
        //purple|loss|Kiko                  -rank: 0.11
        //purple|loss|Kiko                  Color: red
        //purple|loss|Kiko                  -age: 44
        //purple|loss|Yana                  -name: gosho
        //purple|loss|Yana                  -opponents: (empty)
        //purple|loss|Manov                 -rank: 1.00
        //purple|loss|Manov
        //red|name|gosho
        //blue|win|Vladko
        //purple|loss|Yana
        //purple|name|VladoKaramfilov
        //blue|age|21
        //blue|loss|Pesho
        //END	

        var players = new SortedDictionary<string, Player>();
        string inputLine;
        while (!((inputLine = Console.ReadLine()) == "END"))
        {
            string[] input = inputLine.Split('|');
            {//not needed
                string color = input[0];
                string query = input[1];
                string value = input[2];
                if (!players.ContainsKey(color))
                {
                    players.Add(color, new Player());
                    players[color].oponents = new List<string>();
                }
                if (query == "name")
                {
                    players[color].name = value;
                }
                else if (query == "age")
                {
                    players[color].age = int.Parse(value);
                }
                else if (query == "win")
                {
                    players[color].win++;
                    players[color].oponents.Add(value);
                }
                else if (query == "loss")
                {
                    players[color].loss++;
                    players[color].oponents.Add(value);
                }
            }//not needed
        }
        bool hasData = false;
        foreach (var color in players.Keys)
        {
            if (players[color].name != null && players[color].age != 0)
            {
                Console.WriteLine("Color: {0}", color);
                Console.WriteLine("-age: {0}", players[color].age);
                Console.WriteLine("-name: {0}", players[color].name);

                players[color].oponents.Sort(StringComparer.Ordinal);

                Console.WriteLine("-opponents: {0}", 
                    players[color].oponents.Count() > 0 ? string.Join(", ", players[color].oponents) : 
                    "(empty)");

                Console.WriteLine("-rank: {0:F2}", (players[color].win + 1.0) / (players[color].loss + 1));

                hasData = true;
            }
        }
        if (!hasData)
        {
            Console.WriteLine("No data recovered.");
        }
    }
}