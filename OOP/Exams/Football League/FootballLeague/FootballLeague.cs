using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague
{
    class FootballLeague
    {
        static void Main()
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                try
                {
                    LeagueManager.HandleInput(input);
                }
                catch (ArgumentException e)
                {

                    Console.Error.WriteLine(e.Message);
                }
                catch (InvalidOperationException e)
                {
                    Console.Error.WriteLine(e.Message);
                }
               
                input = Console.ReadLine();
            }
        }
    }
}
