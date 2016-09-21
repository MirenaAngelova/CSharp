using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class XRemoval
{
    static void Main()
    {
        List<char[]> lines = new List<char[]>();
        List<char[]> compare = new List<char[]>();
        do
        {
            string line = Console.ReadLine();
            if (line == "END")
            {
                break;
            }
            lines.Add(line.ToCharArray());
            compare.Add(line.ToCharArray());
        } while (true);
        for (int i = 0; i < lines.Count - 2; i++)
        {
            string line1 = new string(compare[i]).ToLower();
            string line2 = new string(compare[i + 1]).ToLower();
            string line3 = new string(compare[i + 2]).ToLower();
            for (int j = 1; j < lines[i].Length; j++)
            {
                bool index = j + 2 > line1.Length | j + 1 > line2.Length | j + 2 > line3.Length;
                if (index)
                {
                    break;
                }
                bool isCompare = line1[j - 1] == line1[j + 1] & line1[j - 1] == line2[j] &
                    line1[j - 1] == line3[j - 1] & line1[j - 1] == line3[j + 1];
                if (isCompare)
                {
                    lines[i][j - 1] = ' ';
                    lines[i][j + 1] = ' ';
                    lines[i + 1][j] = ' ';
                    lines[i + 2][j - 1] = ' ';
                    lines[i + 2][j + 1] = ' ';
                }
            }
        }
        for (int i = 0; i < lines.Count; i++)
        {
            lines[i] = lines[i].Where(x => !char.IsWhiteSpace(x)).ToArray();
            Console.WriteLine(string.Join("", lines[i]));
        }
    }
}