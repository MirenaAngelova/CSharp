using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Basic_Queue_Operations
{
    public class BasicQueueOperation
    {
        public static void Main()
        {
            int[] commands = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int amountToEnqueue = commands[0];
            int amountToDequeue = commands[1];
            int elementToCheck = commands[2];


            Queue<int> operationQueue = new Queue<int>();
            int[] sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < amountToEnqueue; i++)
            {
                operationQueue.Enqueue(sequence[i]);
            }

            for (int i = 0; i < amountToDequeue; i++)
            {
                operationQueue.Dequeue();
            }

            if (operationQueue.Contains(elementToCheck))
            {
                Console.WriteLine("true");
            }
            else
            {
                int exit = operationQueue.Count > 0 ? operationQueue.Min() : 0;
                Console.WriteLine(exit);
            }
        }
    }
}
