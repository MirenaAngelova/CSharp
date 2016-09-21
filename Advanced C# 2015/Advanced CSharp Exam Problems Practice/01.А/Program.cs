using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.SqlServer.Server;
using Microsoft.Win32;


namespace _01.А
{
    class Program
    {
        static void Main(string[] args)
        {
            //aa	aba	bcc	cc	cdc
            string input = Console.ReadLine();
            if (input.Length <= 150 && input.Length >= 2)
            {

                string[] str = new[] { "A", "aba", "bcc", "A", "cdc" };
                string[] strg = new[] { "aa", "A", "A", "cc", "A" };

                for (int i = 0; i < str.Length; i++)
                {
                    Regex regex = new Regex(str[i]);

                    input = Regex.Replace(input, str[i], i.ToString());
                }

                for (int i = 0; i < strg.Length; i++)
                {
                    Regex regex = new Regex(strg[i]);

                    input = Regex.Replace(input, strg[i], i.ToString());
                }
                int[] number = new int[input.Length];
                for (int i = 0; i < number.Length; i++)
                {
                    number[i] = int.Parse(input[i].ToString());
                }
                BigInteger result = 0;
                for (int i = number.Length - 1, pow = 0; i >= 0 && pow < number.Length; i--, pow++)
                {
                    result += (BigInteger)number[i] * (BigInteger)BigInteger.Pow(5, pow);
                }
                Console.WriteLine(result);
            }
        }
    }
}