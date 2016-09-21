using System;
using System.Text.RegularExpressions;
    class UseYourChainsBuddy
    {
        static void Main()
        {
            string html = Console.ReadLine();

            string pattern = @"<p>(.[^\/]+)</p>";
            string regex = @"[^a-z0-9]+";

            Regex text = new Regex(pattern);
            MatchCollection matches = text.Matches(html);

            string encrypt = string.Empty;

            foreach (Match match in matches)
            {
                string temp = match.Groups[1].Value;

                encrypt += Regex.Replace(temp, regex, x => " ");
            }

            string manual = string.Empty;

            foreach (var crypt in encrypt)
            {
                if (crypt >= 'a' && crypt <= 'm')
                {
                    manual += (char)(crypt + 13);
                }
                else if (crypt >= 'n' && crypt <= 'z')
                {
                    manual += (char)(crypt - 13);
                }
                else if (char.IsWhiteSpace(crypt) | char.IsDigit(crypt))
                {
                    manual += (char)crypt;
                }
            }

            Console.WriteLine(manual);
        }
    }

