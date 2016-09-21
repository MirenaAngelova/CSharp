using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SoftUni_Palatka_Conf
{
    class SoftUniPalatkaConf
    {
        static void Main()
        {
            int totalPeople = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            int quantityBedTents = 0;
            int quantityBedRooms = 0;
            int quantityMeal = 0;
           
            for (int i = 0; i < n; i++)
            {
                string[] inputLine = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                string bedMeal = inputLine[0];
                int quantity = int.Parse(inputLine[1]);
                string type = inputLine[2];
                switch (bedMeal)
                {
                        case"tents":
                        quantityBedTents += CalculateTents(quantity, type, quantityBedTents);
                        break;
                    case "rooms":
                        quantityBedRooms += CalculateRooms(quantity, type, quantityBedRooms);
                        break;
                    case "food":
                        quantityMeal += CalculateFood(quantity, type, quantityMeal);
                        break;
                }
            }

            int quantityBed = quantityBedTents + quantityBedRooms;
            if (totalPeople > quantityBed)
            {
                int numberOfBedsNeeded = totalPeople - quantityBed;
                Console.WriteLine($"Some people are freezing cold. Beds needed: {numberOfBedsNeeded}");
            }
            else
            {
                int numberOfBedsLeft = quantityBed - totalPeople;
                Console.WriteLine($"Everyone is happy and sleeping well. Beds left: {numberOfBedsLeft}");
            }

            if (totalPeople > quantityMeal)
            {
                int numberOfMealsNeeded = totalPeople - quantityMeal;
                Console.WriteLine($"People are starving. Meals needed: {numberOfMealsNeeded}");
            }
            else
            {
                int numberOfMealsLeft = quantityMeal - totalPeople;
                Console.WriteLine($"Nobody left hungry. Meals left: {numberOfMealsLeft}");
            }
        }

        private static int CalculateRooms(int quantity, string type, int quantityBedRooms)
        {
            quantityBedRooms = 0;
            switch (type)
            {
                case "single":
                    quantityBedRooms += quantity * 1;
                    break;
                case "double":
                    quantityBedRooms += quantity * 2;
                    break;
                case "triple":
                    quantityBedRooms += quantity * 3;
                    break;
            }

            return quantityBedRooms;
        }

        private static int CalculateTents(int quantity, string type, int quantityBedTents)
        {
            quantityBedTents = 0;
            return  quantityBedTents = type == "normal" ? quantity*2 : quantity*3;
        }


        private static int CalculateFood(int quantity, string type, int quantityMeal)
        {
            quantityMeal = 0;
            return quantityMeal = type == "musaka" ? quantity*2 : 0;
        }
    }
}
