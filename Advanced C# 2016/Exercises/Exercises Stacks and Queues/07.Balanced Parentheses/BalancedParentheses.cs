using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _07.Balanced_Parentheses
{
    public class BalancedParentheses
    {
       private static Dictionary<char, char> balancedParentheses = new Dictionary<char, char>()
            {
                { '{', '}'},
                { '[', ']'},
                { '(', ')'},
            };

        private static Stack<char> stackParentheses; 
        private static string parentheses;

        public static void Main()
        {


            parentheses = Console.ReadLine();
            parentheses = Regex.Replace(parentheses, @"\s+", "");

            string result = IsBalancedParentheses() ? "YES" : "NO";
            Console.WriteLine(result);
        }

        private static bool IsBalancedParentheses()
        {
            stackParentheses = new Stack<char>();
            bool isBalanced = parentheses.Length % 2 == 0;

            foreach (var bracket in parentheses)
            {
                if (balancedParentheses.ContainsKey(bracket))
                {
                    stackParentheses.Push(bracket);
                }
                else if (balancedParentheses.ContainsValue(bracket))
                {
                    if (!stackParentheses.Any())
                    {
                        return false;
                    }

                    char currentBracket = stackParentheses.Pop();
                    if (bracket != balancedParentheses[currentBracket])
                    {
                        isBalanced = false;
                    }
                }
            }

            return isBalanced;
        }
    }
}
