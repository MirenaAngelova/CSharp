using System;
using System.Collections.Generic;
using System.Text;

namespace _39.Weightlifting2
{
    class Weightlifting
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, SortedDictionary<string, double>> players =
                new SortedDictionary<string, SortedDictionary<string, double>>();
            double inputCount = double.Parse(Console.ReadLine());//long
            for (int i = 0; i < inputCount; i++)
            {
                string[] input = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                string player = input[0];
                string exercise = input[1];
                double weight = double.Parse(input[2]);

                if (!players.ContainsKey(player))
                {
                    players.Add(player, new SortedDictionary<string, double>());
                }

                if (players[player].ContainsKey(exercise))
                {
                    players[player][exercise] += weight;
                }
                else
                {
                    players[player][exercise] = weight;
                }
            }

            foreach (var player in players)
            {
                Console.Write($"{player.Key} : ");
                StringBuilder exit = new StringBuilder();
                foreach (var exercise in player.Value)
                {
                    exit.AppendFormat($"{exercise.Key} - {exercise.Value} kg, ");
                }

                Console.WriteLine(exit.ToString().Trim(',', ' '));
            }
        }
    }
}
