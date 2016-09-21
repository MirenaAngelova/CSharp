using System;
using System.Security;
using System.Text;
class TextGravity
{
    static void Main()
    {

        int cols = int.Parse(Console.ReadLine());

        string text = Console.ReadLine();

        int rows = text.Length / cols;

        if (text.Length % cols != 0)
        {
            rows += 1;
        }

        char[][] matrix = new char[rows][];
        int index = 0;

        for (int i = 0; i < rows; i++)
        {
            matrix[i] = new char[cols];

            for (int j = 0; j < cols; j++)
            {

                if (index < text.Length)
                {
                    matrix[i][j] = text[index];
                    index++;
                }
                else
                {
                    matrix[i][j] = ' ';
                }
            }
        }

        for (int i = matrix.Length - 1; i >= 0; i--)
        {
            for (int j = 0; j < matrix[0].Length; j++)
            {
                if (matrix[i][j] != ' ')
                {
                    continue;
                }

                int cur = i - 1;
                while (cur >= 0)
                {
                    if (matrix[cur][j] != ' ')
                    {
                        matrix[i][j] = matrix[cur][j];
                        matrix[cur][j] = ' ';
                        break;
                    }
                    cur--;
                }
            }
        }

        //for (int i = 0; i < rows; i++)
        //{
        //    for (int j = 0; j < cols; j++)
        //    {
        //        Console.Write(matrix[i][j]);
        //    }
        //    Console.WriteLine();
        //}

        StringBuilder output = new StringBuilder();

        output.Append("<table>");

        for (int i = 0; i < matrix.Length; i++)
        {
            output.Append("<tr>");

            for (int j = 0; j < matrix[0].Length; j++)
            {
                output.AppendFormat("<td>{0}</td>", SecurityElement.Escape(matrix[i][j].ToString()));
            }

            output.Append("</tr>");
        }

        output.Append("</table>");

        Console.WriteLine(output.ToString());

    }
}