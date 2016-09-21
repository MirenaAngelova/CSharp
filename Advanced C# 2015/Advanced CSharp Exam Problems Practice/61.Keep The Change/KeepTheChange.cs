using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _61.Keep_The_Change
{
    class KeepTheChange
    {
        static void Main(string[] args)
        {
            //120.44
            //happy

            double bill = double.Parse(Console.ReadLine());
            string mood = Console.ReadLine();
            double tip = 0;
            if (mood == "happy")
            {
                tip = bill*10/100;
            }
            else if (mood == "married")
            {
                tip = bill*0.05/100;
            }
            else if (mood == "drunk")
            {//200 drunk
                double percent = bill*15/100;
                char firstDigit = percent.ToString().First();
                int power = int.Parse(firstDigit.ToString());
                tip = Math.Pow(percent, power);
            }
            else
            {
                tip = bill * 5 / 100;
            }
            Console.WriteLine($"{tip:F2}");
        }
    }
}
