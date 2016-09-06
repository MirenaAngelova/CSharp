using System;
using System.Collections.Generic;

namespace _10.Simple_Text_Editor
{
    public class SimpleTextEditor
    {
        private static string simpleText = String.Empty;
        private static Stack<string> simpleTextEditor = new Stack<string>(); 

        public static void Main()
        {
            int commandsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandsCount; i++)
            {
                string[] commandArgs = Console.ReadLine().Split();
                ExecuteCommands(commandArgs);
            }
        }

        private static void ExecuteCommands(string[] commandArgs)
        {
            int command = int.Parse(commandArgs[0]);
            switch (command)
            {
                case 1:
                    string text = commandArgs[1];
                    simpleTextEditor.Push(simpleText);
                    simpleText += text;
                    break;
                case 2:
                    int countToDelete = int.Parse(commandArgs[1]);
                    simpleTextEditor.Push(simpleText);
                    simpleText = simpleText.Substring(0, simpleText.Length - countToDelete);
                    break;
                case 3:
                    int indexToPrint = int.Parse(commandArgs[1]);
                    Console.WriteLine(simpleText[indexToPrint - 1]);
                    break;
                case 4:
                    simpleText = simpleTextEditor.Pop();
                    break;
            }
        }
    }
}
