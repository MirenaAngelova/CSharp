using System;

namespace _01.Four_Factors
{
    class FourFactors
    {
        static void Main()
        {
            double fg = double.Parse(Console.ReadLine());
            double fga = double.Parse(Console.ReadLine());
            double p = double.Parse(Console.ReadLine());
            double tov = double.Parse(Console.ReadLine());
            double orb = double.Parse(Console.ReadLine());
            double oppdrb = double.Parse(Console.ReadLine());
            double ft = double.Parse(Console.ReadLine());
            double fta = double.Parse(Console.ReadLine());
            double efg = (fg + 0.5 * p) / fga;
            double tovPer = tov / (fga + 0.44 * fta + tov);
            double orbPer = orb / (orb + oppdrb);
            double ftPer = ft / fga;
            Console.WriteLine("eFG% {0:f3}", Math.Round(efg, 3));
            Console.WriteLine("TOV% {0:f3}", Math.Round(tovPer, 3));
            Console.WriteLine("ORB% {0:f3}", Math.Round(orbPer, 3));
            Console.WriteLine("FT% {0:f3}", Math.Round(ftPer, 3));
            //3643
            //7168
            //138
            //1088
            //1173
            //2171
            //1587
            //2132
        }
    }
}
