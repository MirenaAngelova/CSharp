namespace _11.Poisonous_Plants
{
    public class Plant
    {
        public Plant(int amountOfPesticide, int daysAlive)
        {
            this.AmountOfPesticide = amountOfPesticide;
            this.DaysAlive = daysAlive;
        }

        public int DaysAlive { get; set; }

        public int AmountOfPesticide { get; set; }
    }
}