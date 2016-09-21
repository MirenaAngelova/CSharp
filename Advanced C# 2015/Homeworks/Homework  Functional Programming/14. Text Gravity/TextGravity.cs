using System;
using System.Security;
class TextGravity
{
    static void Main()
    {
        
        int lineLength = int.Parse(Console.ReadLine());
        char[] text = Console.ReadLine().ToCharArray();

        int rows = (int)Math.Ceiling((double)text.Length / lineLength);
        int cols = lineLength;

        string[,] matrix = new string[rows, cols];
        int index = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (index < text.Length)
                {
                    matrix[i, j] = text[index].ToString();
                    index++;
                }
                else
                {
                    matrix[i, j] = " ";
                }
            }
        }

        bool falling = false;

        do
        {
            falling = false;

            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] != " " && matrix[i + 1, j] == " ")
                    {
                        matrix[i + 1, j] = matrix[i, j];
                        matrix[i, j] = " ";
                        falling = true;
                    }
                }
            }
        } while (falling);

        Console.Write("<table>");

        for (int i = 0; i < rows; i++)
        {
            Console.Write("<tr>");

            for (int j = 0; j < cols; j++)
            {
                Console.Write("<td>{0}</td>", SecurityElement.Escape(matrix[i, j]));
            }

            Console.Write("</tr>");
        }

        Console.Write("</table>");
    }
}