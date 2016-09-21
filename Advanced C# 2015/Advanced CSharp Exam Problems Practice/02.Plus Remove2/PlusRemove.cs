using System;
using System.Collections.Generic;
using System.Linq;
class PlusRemove
{
    static void Main()
    {
        List<char[]> beforeRemoving = new List<char[]>();
        List<char[]> afterRemoving = new List<char[]>();

        string inputLine = Console.ReadLine();

        while (inputLine != "END")
        {
            beforeRemoving.Add(inputLine.ToCharArray());
            afterRemoving.Add(inputLine.ToCharArray());

            inputLine = Console.ReadLine();
        }

        for (int i = 0; i < beforeRemoving.Count - 2; i++)
        {
            string lineFirst = new string(beforeRemoving[i]).ToLower();
            string lineSecond = new string(beforeRemoving[i + 1]).ToLower();
            string lineThird = new string(beforeRemoving[i + 2]).ToLower();

            for (int j = 1; j < afterRemoving[i].Length; j++)
            {
                bool outOfRange = (j > lineSecond.Length - 2) || (j > lineThird.Length - 1);

                if (outOfRange)
                {
                    break;
                }

                bool plusShapes =
                    lineFirst[j] == lineSecond[j - 1] &&
                    lineFirst[j] == lineSecond[j] && lineFirst[j] == lineSecond[j + 1] &&
                    lineFirst[j] == lineThird[j];

                if (plusShapes)
                {
                    afterRemoving[i][j] = ' ';
                    afterRemoving[i + 1][j - 1] = ' ';
                    afterRemoving[i + 1][j] = ' ';
                    afterRemoving[i + 1][j + 1] = ' ';
                    afterRemoving[i + 2][j] = ' ';
                }
            }
        }

        for (int i = 0; i < afterRemoving.Count; i++)
        {
            afterRemoving[i] = afterRemoving[i].Where(x => !char.IsWhiteSpace(x)).ToArray();
            Console.WriteLine(string.Join("", afterRemoving[i]));
        }
    }
}