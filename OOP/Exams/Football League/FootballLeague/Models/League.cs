using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballLeague.Models
{
    public static class League
    {
        private static List<Matches> matches = new List<Matches>();
        private static List<Teams> teams = new List<Teams>();

        public static IEnumerable<Matches> Matches
        {
            get { return matches; }
        }

        public static IEnumerable<Teams> Teams
        {
            get { return teams; }
        }

        public static void AddTeams(Teams team)
        {
            if (teams.Any(t => t.Name == team.Name))
            {
                throw new InvalidOperationException("The team already exists in this league.");
            }
            teams.Add(team);
        }

        public static void AddMatches(Matches match)
        {
            if (matches.Any(m => m.Id == match.Id))
            {
                throw new InvalidOperationException("There cannot be two matches with the same ID.");
            }
            matches.Add(match);
        }
    }
}
