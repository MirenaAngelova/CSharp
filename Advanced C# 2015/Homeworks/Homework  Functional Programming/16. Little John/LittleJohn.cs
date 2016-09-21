using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
class LittleJohn
{
    static void Main()
    {
        const int N = 4;

        string arrowPattern = "(>>>----->>)|(>>----->)|(>----->)";
        Regex rgx = new Regex(arrowPattern);

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < N; i++)
        {
            sb.AppendFormat(" {0}", Console.ReadLine());
        }

        var arrows = rgx.Matches(sb.ToString());

        int smallCount = 0;
        int mediumCount = 0;
        int largeCount = 0;

        foreach (Match arrow in arrows)
        {
            if (!string.IsNullOrEmpty(arrow.Groups[1].Value))
            {
                largeCount++;
            }
            else if (!string.IsNullOrEmpty(arrow.Groups[2].Value))
            {
                mediumCount++;
            }
            else
            {
                smallCount++;
            }
        }

        string concatenateCount = string.Format("{0}{1}{2}", smallCount, mediumCount, largeCount);

        int decimalNum = int.Parse(concatenateCount);

        string binaryNum = Convert.ToString(decimalNum, 2);

        string reverseBin = new string(binaryNum.Reverse().ToArray());

        string concatenateBin = string.Format("{0}{1}", binaryNum, reverseBin);

        int reverseDecimal = Convert.ToInt32(concatenateBin, 2);

        Console.WriteLine(reverseDecimal);
    }
}
