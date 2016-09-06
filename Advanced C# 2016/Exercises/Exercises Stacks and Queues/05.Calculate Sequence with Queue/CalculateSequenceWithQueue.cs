using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Calculate_Sequence_with_Queue
{
    public class CalculateSequenceWithQueue
    {
        public static void Main()
        {
            int givenNum = int.Parse(Console.ReadLine());

            Queue<long> sequence = new Queue<long>();
            List<long> outputSequence = new List<long>();
            int first = givenNum;
            sequence.Enqueue(first);
            outputSequence.Add(first);

            while (outputSequence.Count < 50)
            {

                long second = sequence.Peek() + 1;
                long third = sequence.Peek()*2 + 1;
                long forth = sequence.Peek() + 2;

                sequence.Enqueue(second);
                sequence.Enqueue(third);
                sequence.Enqueue(forth);

                outputSequence.Add(second);
                outputSequence.Add(third);
                outputSequence.Add(forth);

                sequence.Dequeue();
            }

            Console.WriteLine(string.Join(" ", outputSequence.Take(50)));
        }
    }
}

