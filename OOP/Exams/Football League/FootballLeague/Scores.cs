using System;

namespace FootballLeague
{
    public class Scores
    {
        private int awayTeamScore;
        private int homeTeamScore;

        public Scores(int homeTeamScore, int awayTeamScore)
        {
            this.HomeTeamScore = homeTeamScore;
            this.AwayTeamScore = awayTeamScore;
        }

        public int AwayTeamScore 
        { 
            get { return this.awayTeamScore; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Goals cannot be negative.");
                }
                this.awayTeamScore = value;
            } 
        }

        public int HomeTeamScore
        { 
            get{ return homeTeamScore; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Goals cannot be negative.");
                }
                this.homeTeamScore = value;
            } 
        }

        public override string ToString()
        {
            return string.Format("{0} : {1}", this.HomeTeamScore, this.AwayTeamScore);
        }
    }
}
