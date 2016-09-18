using System;
using System.Linq;
using FootballLeague.Models;

namespace FootballLeague
{
    class LeagueManager
    {
        public static void HandleInput(string input)
        {
            var inputArgs = input.Split();
            switch (inputArgs[0])
            {
                case "AddTeam":
                    AddTeam(inputArgs[1], inputArgs[2], DateTime.Parse(inputArgs[3]));
                    break;
                case "AddMatch":
                    AddMatch(int.Parse(inputArgs[1]), inputArgs[2], inputArgs[3], int.Parse(inputArgs[4]),
                        int.Parse(inputArgs[5]));
                    break;
                case "AddPlayerToTeam":
                    AddPlayerToTeam(inputArgs[1], inputArgs[2], DateTime.Parse(inputArgs[3]),
                        decimal.Parse(inputArgs[4]),
                        inputArgs[5]);
                    break;
                case "ListTeams":
                    ListTeams();
                    break;
                case "ListMatches":
                    ListMatches();
                    break;
            }
           
        }

        private static void ListMatches()
        {
            foreach (Matches match in League.Matches)
            {
                Console.WriteLine(match);
            }
        }
        private static void ListTeams()
        {
            foreach (Teams team in League.Teams)
            {
                Console.WriteLine(team);
            }
        }
        private static void AddTeam(string name, string nickName, DateTime dateOfFounding)
        {
            if (League.Teams.Any(t => t.Name == name))
            {
                throw new InvalidOperationException("This team already exists.");
            }   
            League.AddTeams( new Teams(name, nickName, dateOfFounding));
            Console.WriteLine("Team {0} was added to the league.", name);
        }

        private static void AddMatch(int id, string homeTeam, string awayTeam, int homeTeamScore, int awayTeamScore)
        {
            if (League.Matches.Any(m => m.Id == id))
            {
                throw new InvalidOperationException("The match already exists.");
            }
            Teams homeTeams = League.Teams.First(t => t.Name == homeTeam);
            Teams awayTeams = League.Teams.First(t => t.Name == awayTeam);
            Scores score = new Scores(homeTeamScore, awayTeamScore);

            League.AddMatches(new Matches(homeTeams, awayTeams, score, id));
            Console.WriteLine("Match {0} was added to the league.", id);
        }

        private static void AddPlayerToTeam(string firstName, string lastName, DateTime dateOfBirth, decimal salary,
            string teamName)
        {
            Teams team = League.Teams.First(t => t.Name == teamName);
            Players player = new Players(firstName, lastName, salary, dateOfBirth, team);

            team.AddPlayer(player);
        }
    }
}
