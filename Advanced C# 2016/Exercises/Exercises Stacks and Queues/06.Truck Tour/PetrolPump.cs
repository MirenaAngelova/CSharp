namespace _06.Truck_Tour
{
    public class PetrolPump
    {
        public PetrolPump(int petrolAmount, int distanceToNext, int petrolPumpIndex)
        {
            this.PetrolAmount = petrolAmount;
            this.DistanceToNext = distanceToNext;
            this.PetrolPumpIndex = petrolPumpIndex;
        }

        public int PetrolPumpIndex { get; set; }

        public int DistanceToNext { get; set; }

        public int PetrolAmount { get; set; }
    }
}