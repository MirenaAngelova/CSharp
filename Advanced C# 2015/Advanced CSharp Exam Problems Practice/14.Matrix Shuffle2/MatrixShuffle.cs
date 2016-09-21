using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _14.Matrix_Shuffle2
{
    class MatrixShuffle
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[] text = Console.ReadLine().ToCharArray();
            char[,] matrix = new char[size, size];
            FillSpiralMatrix(matrix, text, size);
            string sentence = ExtractLetters(matrix, size);
            bool isPalindrome = IsPalinrome(sentence);

            PrintExit(isPalindrome, sentence);
        }

        private static void PrintExit(bool isPalindrome, string sentence)
        {
            Console.WriteLine(isPalindrome
                ? $"<div style='background-color:#4FE000'>{sentence}</div>"
                : $"<div style='background-color:#E0000F'>{sentence}</div>");
        }

        private static bool IsPalinrome(string sentence)
        {
            sentence = Regex.Replace(sentence.ToLower(), "[^\\w]", string.Empty);
            StringBuilder reverse = new StringBuilder();
            for (int i = sentence.Length - 1; i >= 0; i--)
            {
                reverse.Append(sentence[i]);
            }

            bool isPalindrome = sentence == reverse.ToString();
            return isPalindrome;
        }

        private static string ExtractLetters(char[,] matrix, int size)
        {
            StringBuilder whiteSquare = new StringBuilder();
            StringBuilder blackSquare = new StringBuilder();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i % 2 == 0 && j % 2 == 0) 
                    {
                        whiteSquare.Append(matrix[i, j]);
                    }
                    else if (i % 2 == 1 && j % 2 == 1)
                    {
                        whiteSquare.Append(matrix[i, j]);
                    }
                    else
                    {
                        blackSquare.Append(matrix[i, j]);
                    }
                }
            }
            return whiteSquare.Append(blackSquare).ToString();
        }


        private static void FillSpiralMatrix(char[,] matrix, char[] text, int size)
        {
            int row = 0;
            int col = 0;
            int index = 0;
            while (index < text.Length)//index < length , index = length - 1
            {


                while (col < size && matrix[row, col] == '\0')
                {
                    matrix[row, col] = text[index];
                    col++;
                    index++;
                }
                col--;
                row++;
                if (index > text.Length - 1)//index + 1 > length , index + 1 = length, index = length - 1
                {
                    break;
                }
                while (row < size && matrix[row, col] == '\0')
                {
                    matrix[row, col] = text[index];
                    row++;
                    index++;
                }
                row--;
                col--;
                if (index > text.Length - 1)
                {
                    break;
                }
                while (col >= 0 && matrix[row, col] == '\0')
                {
                    matrix[row, col] = text[index];
                    col--;
                    index++;
                }
                col++;
                row--;
                if (index > text.Length - 1)
                {
                    break;
                }
                while (row >= 0 && matrix[row, col] == '\0')
                {
                    matrix[row, col] = text[index];
                    row--;
                    index++;
                }
                row++;
                col++;
                if (index > text.Length - 1)
                {
                    break;
                }
            }

        }
    }
}
