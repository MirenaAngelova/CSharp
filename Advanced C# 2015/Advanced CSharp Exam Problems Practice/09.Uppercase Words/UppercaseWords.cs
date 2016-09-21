using System;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;

class UppercaseWords
{
    static void Main()
    {
        //Write a program to reverse the letters of all uppercase words in a text. In case an uppercase word stays 
        //unchanged after reversing its letters, then double each of its letters. A word is a sequence of Latin letters 
        //separated by non-letter characters (e.g. punctuation characters or digits). For example, the text 
        //"PHP5 is the latest PHP currently, YES" consists of the following words: 
        //PHP, is, the, latest, PHP, currently, YES.
        //Input
        //The input will be read from the console. It will consist of a variable number of lines, ending with the 
        //command "END".
        //Output
        //The output should hold the result text. Ensure you escape correctly the HTML special characters in the 
        //output with the SecurityElement.Escape() method.
        //Constraints
        //•	The text will be in ASCII encoding (texts in Cyrillic, Arabic, Chinese, etc. are not supported).
        //•	Allowed working time: 0.2 seconds. Allowed memory: 16 MB.
        //Examples
        //Input
        //Companies like
        //    HP, ORACLE and IBM target their platforms for cloud-based environment.
        //    IList<T> implements IEnumerable<T>. GoPHP is a PHP library.
        //END
        //Output
        //Companies like
        //    PH, ELCARO and MBI target their platforms for cloud-based environment.
        //    IList&lt;TT&gt; implements IEnumerable&lt;TT&gt;. GoPHP is a PPHHPP library.

        //Input
        //IBM announced it delivered the first shipment of its Enterprise Cloud system to a U.K.-based managed service 
        //provider. PHP5 is the latest PHP currently, YES
        //END
        //Output
        //MBI announced it delivered the first shipment of its Enterprise Cloud system to a UU.KK.-based managed 
        //service provider. PPHHPP5 is the latest PPHHPP currently, SEY

        const string UppercaseWordsPattern = "(?<![a-zA-Z])[A-Z]+(?![a-zA-Z])";
        var uppercaseWordsMatcher = new Regex(UppercaseWordsPattern);

        var text = new StringBuilder(Console.ReadLine());

        while (text.ToString() != "END")
        {
            var upperCaseWords = uppercaseWordsMatcher.Matches(text.ToString());

            int offset = 0;
            foreach (Match match in upperCaseWords)
            {
                string word = match.Value;
                string reversedWord = ReverseWord(word);

                if (reversedWord == word)
                {
                    reversedWord = DoubleEachLetter(reversedWord);
                }

                int index = match.Index;
                text.Remove(index + offset, word.Length);
                text.Insert(index + offset, reversedWord);
                offset += reversedWord.Length - word.Length;
            }

            Console.WriteLine(SecurityElement.Escape(text.ToString()));
            text = new StringBuilder(Console.ReadLine());
        }
    }

    private static string DoubleEachLetter(string word)
    {
        var doubledLettersWord = new StringBuilder();
        for (int i = 0; i < word.Length; i++)
        {
            doubledLettersWord.AppendFormat("{0}{1}", word[i], word[i]);
        }

        return doubledLettersWord.ToString();
    }

    private static string ReverseWord(string word)
    {
        var reversedWord = new StringBuilder();
        for (int i = word.Length - 1; i >= 0; i--)
        {
            reversedWord.Append(word[i]);
        }

        return reversedWord.ToString();
    }
}