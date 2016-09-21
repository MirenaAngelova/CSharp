using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.CommandInterpreter
{
    class CommandInterpreter
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine()
                .Split(new[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);
            List<string> listArray = array.ToList();

            string inputCommands = Console.ReadLine();
            while (inputCommands != "end")
            {
                string[] commands = inputCommands.Split();
                try
                {
                    ExecuteCommand(commands, listArray);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid input parameters.");
                }
                
                inputCommands = Console.ReadLine();
            }

            PrintArray(listArray);
        }

        private static void PrintArray(List<string> listArray)
        {
            Console.WriteLine("[{0}]", string.Join(", ", listArray));
        }

        private static void ExecuteCommand(string[] commands, List<string> listArray)
        {
            string command = commands[0];
            switch (command)
            {
                case "reverse":
                    ReversePortionOfArray(commands, listArray);
                    break;
                case "sort":
                    SortPortionOfArray(commands, listArray);
                    break;
                case "rollLeft":
                    RollLeft(commands, listArray);
                    break;
                case "rollRight":
                    RollRight(commands, listArray);
                    break;
            }
        }

        private static void RollRight(string[] commands, List<string> listArray)
        {
            int count = int.Parse(commands[1]) % listArray.Count;
            var addRange = listArray.Skip(listArray.Count - count).Take(count).ToArray();
            listArray.InsertRange(0, addRange);
            listArray.RemoveRange(listArray.Count - count, count);
        }

        private static void RollLeft(string[] commands, List<string> listArray)
        {
            int count = int.Parse(commands[1]) % listArray.Count;

            var addRange = listArray.Take(count).ToArray();
            listArray.AddRange(addRange);
            listArray.RemoveRange(0, count); 
        }

        private static void SortPortionOfArray(string[] commands, List<string> listArray)
        {
            int startIndex = int.Parse(commands[2]);
            int count = int.Parse(commands[4]);
            if (startIndex == listArray.Count)
            {
                throw new ArgumentException();
            }

            listArray.Sort(startIndex, count, Comparer<string>.Default);
        }

        private static void ReversePortionOfArray(string[] commands, List<string> listArray)
        {
            int startIndex = int.Parse(commands[2]);
            int count = int.Parse(commands[4]);
            if (startIndex == listArray.Count)
            {
                throw new ArgumentException();
            }

            listArray.Reverse(startIndex, count);
        }
    }
}
