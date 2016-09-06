using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Truck_Tour
{
    public class TruckTour
    {
        public static void Main()
        {
            int pumpsCount = int.Parse(Console.ReadLine());

            Queue<PetrolPump> truck = new Queue<PetrolPump>();
            for (int index = 0; index < pumpsCount; index++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int petrolAmount = input[0];
                int distanceToNext = input[1];

                PetrolPump petrolPump = new PetrolPump(petrolAmount, distanceToNext, index);
                truck.Enqueue(petrolPump);
            }

            while (true)
            {
                PetrolPump petrolPump = truck.Dequeue();
                truck.Enqueue(petrolPump);
                PetrolPump startingPump = petrolPump;

                int petrolAmount = petrolPump.PetrolAmount;

                bool IsFinishTour = false;
                while (petrolAmount >= petrolPump.DistanceToNext)
                {
                    petrolAmount -= petrolPump.DistanceToNext;
                    petrolPump = truck.Dequeue();
                    truck.Enqueue(petrolPump);

                    if (startingPump == petrolPump)
                    {
                        IsFinishTour = true;
                        break;
                    }

                    petrolAmount += petrolPump.PetrolAmount;
                }

                if (IsFinishTour)
                {
                    Console.WriteLine(startingPump.PetrolPumpIndex);
                    break;
                }
            }
        }
    }
}
