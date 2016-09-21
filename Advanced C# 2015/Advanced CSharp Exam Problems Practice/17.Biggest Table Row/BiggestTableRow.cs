using System;
using System.Linq;
using System.Text.RegularExpressions;

class BiggestTableRow
{
    static void Main()
    {
        //You are given an HTML table with 4 columns: Town, Store1, Store2 and Store3. It consists of sequence of text lines: 
        //the "<table>" tag, the header row, several data rows, and "</table>" tag (see the examples below). 
        //The Store1, Store2, and Store3 columns hold either numbers or "-" (which means "no data"). Your task is to write 
        //a program which parses the table data rows and finds the row with a maximal sum of its values.
        //Input
        //The input is read from the console on several lines, each holding the table rows. The last row will always hold 
        //the string "</table>". The input data will always be valid and in the format described. There is no need to check 
        //it explicitly.
        //Output
        //Print at the console a single line, holding the data row values with maximal sum in format:
        //"sum = value1 + value2 + …". Print the values exactly as they were found in the input 
        //(no rounding, no reformatting). If all rows contain no data, print "no data". If two rows have the same maximal sum,
        //print the first of them.
        //Constraints
        //•	The count of input rows is in the range [0 … 1 000].
        //•	The columns Store1, Store2 and Store3 hold numbers in the range [-100 0000 … 100 000].
        //•	There is no whitespace anywhere in the data rows.
        //•	Allowed working time: 0.1 seconds. Allowed memory: 16 MB.
        //Examples
        //Input	                                                                    Output
        //<table>                                                                   65.3 = 11.2 + 18.00 + 36.10
        //<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>
        //<tr><td>Sofia</td><td>26.2</td><td>8.20</td><td>-</td></tr>
        //<tr><td>Varna</td><td>11.2</td><td>18.00</td><td>36.10</td></tr>
        //<tr><td>Plovdiv</td><td>17.2</td><td>12.3</td><td>6.4</td></tr>
        //<tr><td>Bourgas</td><td>-</td><td>24.3</td><td>-</td></tr>
        //</table>	

        //Input	                                                                    Output
        //<table>                                                                   no data
        //<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>
        //<tr><td>Sofia</td><td>-</td><td>-</td><td>-</td></tr>
        //</table>	

        //Input	                                                                    Output
        //<table>                                                                   50000 = 50000.0
        //<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>
        //<tr><td>Sofia</td><td>12850</td><td>-560</td><td>20833</td></tr>
        //<tr><td>Rousse</td><td>-</td><td>50000.0</td><td>-</td></tr>
        //<tr><td>Bourgas</td><td>25000</td><td>25000</td><td>-</td></tr>
        //</table>	


        string text;
        string pattern = @"<td>(-?\d+(?:.\d+)*)<\/td>";
        MatchCollection matches;
        double max = double.MinValue;
        double sum = 0;
        string maxSum = "";
        while ((text = Console.ReadLine()) != "</table>")
        {
            matches = Regex.Matches(text, pattern);
            if (matches.Count > 0)
            {
                sum = 0;
                foreach (Match match in matches)
                {
                    sum += double.Parse(match.Groups[1].ToString());
                }
                if (sum > max)
                {
                    max = sum;
                    var arr = matches.Cast<Match>().Select(m => m.Groups[1].Value).ToArray();
                    maxSum = string.Format("{0} = {1}", sum, String.Join(" + ", arr));
                }
            }
        }
        if (maxSum.Length > 0)
        {
            Console.WriteLine(maxSum);
        }
        else
        {
            Console.WriteLine("no data");
        }
    }
}