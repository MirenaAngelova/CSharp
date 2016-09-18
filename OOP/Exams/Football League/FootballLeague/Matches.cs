
namespace FootballLeague
{
    public class Matches
    {
        private int id;
        private Scores score;
        private Teams awayTeam;
        private Teams homeTeam;

        public Matches(Teams homeTeam, Teams awayTeam, Scores score, int id)
        {
            this.HomeTeam = homeTeam;
            this.AwayTeam = awayTeam;
            this.Score = score;
            this.Id = id;
        }

        public int Id 
        {
            get { return this.id; }
            set { this.id = value; } 
        }

        public Scores Score 
        {
            get { return this.score; }
            set { this.score = value; }
        }

        public Teams AwayTeam 
        { 
            get { return this.awayTeam; }
            set { this.awayTeam = value; }
        }

        public Teams HomeTeam
        { 
            get { return this.homeTeam; } 
            set { this.homeTeam = value; } 
        }

        public Teams GetWinner()
        {
            if (this.IsDraw())
            {
                return null;
            }
            return this.Score.HomeTeamScore > this.Score.AwayTeamScore ? this.HomeTeam : this.AwayTeam;
        }

        private bool IsDraw()
        {
            return this.Score.AwayTeamScore == this.Score.HomeTeamScore;
        }

        public override string ToString()
        {
            return string.Format("{0}. {1} - {2} {3}", this.Id, this.HomeTeam.Name, this.AwayTeam.Name, this.Score);
        }
    }
}
