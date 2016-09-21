using System;
using System.Security;
using System.Text;

class TextGravity
{
       

    static void Main()
    {
        //Write a program that takes as input a line length and text and formats the text so that it fits inside 
        //several rows, each with length equal to the given line length. Once the text is fitted, each character 
        //starts dropping as long as there is an empty space below it.
        //For example, we are given the text "The Milky Way is the galaxy that contains our star system" and line length 
        //of 10. If we distribute the text characters such that the text fits in lines with length 10, the result is:
        //Text characters start 'falling' until no whitespace remain under any character. The resulting text should be 
        //printed as an HTML table with each character in <td></td> tags.
        //Input
        //The input will come from the console. It will consist of two lines.
        //•	The first line will hold the line length.
        //•	The second input line will hold a string.
        //Output
        //The output consists of the HTML table. Everything should be put inside <table></table> tags. Each line 
        //should be printed in <tr></tr> tags. Each character should be printed in <td></td> tags 
        //(encode the HTML special characters with the SecurityElement.Escape() method).
        //Print space " " in all empty cells. See the example below.
        //Constraints
        //•	The line length will be an integer in the range [1 ... 30]. 
        //•	The text will consist of [1 … 1000] ASCII characters.
        //Example
        //Input
        //10
        //The Milky Way is the galaxy that contains our star system
        //Output
        //<table><tr><td> </td><td> </td><td> </td><td> </td><td>M</td><td> </td><td> </td><td> </td><td> </td><td> </td></tr><tr><td> </td><td>h</td><td>e</td><td> 
        //</td><td>i</td><td>i</td><td>l</td><td> </td><td>y</td><td> 
        //</td></tr><tr><td>T</td><td>a</td><td>y</td><td>l</td><td>a</td><td>s</td><td>y</td><td>k</td><td>h</td><td>e</td></tr><tr><td>W</td><td>g</td><td>a</td><td>c</td><td>o</
        //td><td>x</td><td>t</td><td>t</td><td>t</td><td>h</td></tr><tr><td>a</td><td>t</td><td>o</td><td>u</td><td>r</td><td>n</td><td>s</td><td>a</td><td>i</td><td>n</td></tr><tr>
        //<td>s</td><td>s</td><td>y</td><td>s</td><td>t</td><td>e</td><td>m</td><td>t</td><td>a</td><td>r</td></tr><table>


        int totalCols = int.Parse(Console.ReadLine());
        string text = Console.ReadLine();

        int rows = text.Length / totalCols;
        if (text.Length % totalCols != 0)
        {
            rows += 1;
        }

        char[][] matrix = new char[rows][];
        int currentCharIndex = 0;
        for (int row = 0; row < rows; row++)
        {
            matrix[row] = new char[totalCols];
            for (int col = 0; col < totalCols; col++)
            {
                if (currentCharIndex < text.Length)
                {
                    matrix[row][col] = text[currentCharIndex];
                    currentCharIndex++;
                }
                else
                {
                    matrix[row][col] = ' ';
                }
            }
        }
        for (int col = 0; col < totalCols; col++)
        {
            RunGravity(matrix, col);
        }

        var output = new StringBuilder();
        output.Append("<table>");
        for (int row = 0; row < matrix.Length; row++)
        {
            output.Append("<tr>");
            for (int col = 0; col < totalCols; col++)
            {
                output.AppendFormat("<td>{0}</td>", SecurityElement.Escape(matrix[row][col].ToString()));
            }
            output.Append("</tr>");
        }
        output.Append("</table>");
        Console.WriteLine(output.ToString());
    }

    private static void RunGravity(char[][] matrix, int col)
    {
        while (true)
        {
            bool hasFallen = false;
            for (int row = 1; row < matrix.Length; row++)
            {
                char topChar = matrix[row - 1][col];
                char currentChar = matrix[row][col];
                if (currentChar == ' ' && topChar != ' ')
                {
                    matrix[row][col] = topChar;
                    matrix[row - 1][col] = ' ';
                    hasFallen = true;
                }
            }
            if (!hasFallen)
            {
                break;
            }
        }
    }
}