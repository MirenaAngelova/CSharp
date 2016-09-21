using System;
using System.Text;
using System.Text.RegularExpressions;
class ExtractHyperlinks
{
    static void Main()
    {
        //Write a program to extract all hyperlinks (<href=…>) from a given text. The text comes from the console on 
        //a variable number of lines and ends with the command "END". Print at the console the href values in the text
        //The input text is standard HTML code. It may hold many tags and can be formatted in many different forms 
        //(with or without whitespace). The <a> elements may have many attributes, not only href. You should extract 
        //only the values of the href attributes of all <a> elements.
        //Input
        //The input data comes from the console. It ends when the "END" command is received. 
        //Output
        //Print at the console the href values in the text, each at a separate line, in the order they come from the input.
        //Constraints
        //•	The input will be well formed HTML fragment (all tags and attributes will be correctly closed).
        //•	Attribute values will never hold tags and hyperlinks, e.g. "<img alt='<a href="hello">' />" is invalid.
        //•	Commented links are also extracted.
        //•	The number of input lines will be in the range [1 ... 100].
        //•	Allowed working time: 0.1 seconds. Allowed memory: 16 MB.
        //Examples
        //Input	                                            Output
        //<a href="http://softuni.bg" class="new"></a>      http://softuni.bg
        //END	
        //<p>This text has no links</p>
        //END	
        //<!DOCTYPE html>                                       /
        //<html>                                                /courses
        //<head>                                                /forum
        //  <title>Hyperlinks</title>                           #
        //  <link href="theme.css" rel="stylesheet" />          javascript:alert('hi yo')
        //</head>                                               http://www.nakov.com
        //<body>                                                #empty
        //<ul><li><a   href="/"  id="home">Home</a></li><li><a  #
        // class="selected" href=/courses>Courses</a>           #commented
        //</li><li><a href = 
        //'/forum' >Forum</a></li><li><a class="href"
        //onclick="go()" href= "#">Forum</a></li>
        //<li><a id="js" href =
        //"javascript:alert('hi                           yo')" 
        //class="new">click</a></li>
        //<li><a id='nakov' href =
        //http://www.nakov.com class='new'>nak</a></li></ul>
        //<a href="#empty"></a>
        //<a                          id="href">href='fake'<img 
        //src='http://abv.bg/i.gif' 
        //alt='abv'/></a><a href="#">&lt;a href='hello'&gt;</a>
        //<!-- This code is commented:
        //  <a href="#commented">commentex hyperlink</a> -->
        //</body>
        //END	

        string input;
        StringBuilder sb = new StringBuilder();

        while (!((input = Console.ReadLine()) == "END"))
        {
            sb.Append(input);
        }
        string text = sb.ToString();

        string pattern = @"<a\s+(?:[^>]+\s+)?href\s*=\s*(?:'([^']*)'|""([^""]*)""|([^\s>]+))[^>]*>";
        Regex users = new Regex(pattern);
        MatchCollection matches = users.Matches(text);

        foreach (Match hyperlink in matches)
        {
            for (int i = 1; i <= 3; i++)
            {
                if (hyperlink.Groups[i].Length > 0)
                {
                    Console.WriteLine(hyperlink.Groups[i]);
                }
            }
        }

        //string input = Console.ReadLine();

        //string text = null;

        //while (input != "END")
        //{
        //    text += input;
        //    input = Console.ReadLine();
        //}

        //MatchCollection hyperlinks = Regex.Matches(text, "<a[^>]*(href\\s*=)(\\s*)(\".*?\"|[\\w\\s'\\/][^><\\s]*)");

        //foreach (Match link in hyperlinks)
        //{
        //    Console.WriteLine(link.Groups[3].ToString().Trim(new char[] { '\"', '\'' }));
        //}
    }
}