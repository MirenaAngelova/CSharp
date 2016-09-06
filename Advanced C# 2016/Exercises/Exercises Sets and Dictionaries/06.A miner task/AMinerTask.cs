using System;
using System.Collections.Generic;

namespace _06.A_miner_task
{
    public class AMinerTask
    {
        public static void Main()
        {
            Dictionary<string, int> resources = new Dictionary<string, int>();
            string resource = Console.ReadLine();

            while (resource != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());
                if (!resources.ContainsKey(resource))
                {
                    resources.Add(resource, quantity);
                }
                else
                {
                    resources[resource] += quantity;
                }
                

                resource = Console.ReadLine();
            }

            foreach (var item in resources)
            {
                Console.WriteLine($"{item.Key} –> {item.Value}");
            }
        }
    }
}
