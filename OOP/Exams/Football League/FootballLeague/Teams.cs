using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballLeague
{
    public class Teams
    {
        private const int TheDateFoundedsYear = 1850;
        private string name;
        private string nickName;
        private DateTime dateOfFounding;
        private List<Players> players;

        public Teams(string name, string nickName, DateTime dateOfFounding)
        {
            this.Name = name;
            this.NickName = nickName;
            this.DateOfFounding = dateOfFounding;
            this.players = new List<Players>();
        }

        public IEnumerable<Players> Player { get { return this.players; }}

        public DateTime DateOfFounding
        { 
            get { return this.dateOfFounding; }
            set
            {
                if (value.Year < TheDateFoundedsYear)
                {
                    throw new ArgumentException("The year of founding cannot be earlier than " + TheDateFoundedsYear);
                }
                this.dateOfFounding = value;
            }}

        public string NickName
        {
            get { return this.nickName; }
            set
            {
                if (value.Length < 5)
                {
                    throw new ArgumentOutOfRangeException("Nickname should be at least 5 chars long.");
                }
                this.nickName = value;
            }
        }

        public string Name {
            get { return this.name; }
            set
            {
                if (value.Length < 5)
                {
                    throw new ArgumentOutOfRangeException("Name should be at least 5 chars long.");
                }
                this.name = value;
            }
        }

        public void AddPlayer(Players player)
        {
            if (CheckIfPlayerExists(player))
            {
                throw new InvalidOperationException("This player already exists.");
            }
            this.players.Add(player);
        }

        private bool CheckIfPlayerExists(Players player)
        {
            return this.players.Any(p => p.FirstName == player.FirstName && p.LastName == player.LastName);
        }

        public override string ToString()
        {
            return string.Format("Team: {0} - Nickname: {1} - Date founded: {2}", this.Name, this.NickName,
                this.DateOfFounding.ToShortDateString());
        }
    }
}
