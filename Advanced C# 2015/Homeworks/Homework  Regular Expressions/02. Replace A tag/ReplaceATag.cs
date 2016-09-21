using System;
using System.Text.RegularExpressions;
class ReplaceATag
{
    static void Main()
    {
        //Write a program that replaces in a HTML document given as string all the tags <a href=…>…</a> with 
        //corresponding tags [URL href=…]…[/URL]. Print the result on the console. 
        //The value of the href attribute can be enclosed in single or double quotes. The opening quotes must be the same
        //as the closing closed (e.g. this is invalid: href='softuni.bg").
        //Examples:
        //Input                                                 	Output
        //"<ul>                                                     <ul>
        // <li>                                                      <li>
        //  <a href="http://softuni.bg">SoftUni</a>                   [URL href=http://softuni.bg]SoftUni[/URL]
        // </li>                                                     </li>
        //</ul>"	                                                </ul>
        //
        //"<ul>                                                     <ul>
        // <li>                                                      <li>
        //  <a href='http://softuni.bg'>SoftUni</a>                   [URL href=http://softuni.bg]SoftUni[/URL]
        // </li>                                                     </li>
        //</ul>"	                                                </ul>

        //string input = "<ul> <li> <a href=http://softuni.bg>SoftUni</a> </li> </ul>";
        //string pattern = @"<a href=(?:(?<link>[^>]*))>(?:(?<name>\w*))<\/a>";
        //Regex reg = new Regex(pattern);
        //var result = Regex.Replace(input, pattern, "[URL href=${link}]${name}[/URL]");
        //Console.WriteLine(result);

        string html = @"<ul>
 <li>
  <a href=http://softuni.bg>SoftUni</a>
 </li>
</ul>";
        string pattern = "<a(\\shref=.+)>(.+)<\\/a>";

        Console.WriteLine(Regex.Replace(html, pattern, @"[URL href=$1]$2[/URL]"));
    }
}
