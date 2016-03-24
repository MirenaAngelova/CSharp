using System;
using System.Linq;
class ExtractURLsFromText
{
    static void Main()
    {
        //Write a program that extracts and prints all URLs from given text. URL can be in only two formats:
        //•	http://something, e.g. http://softuni.bg, http://forums.softuni.bg, http://www.nakov.com 
        //•	www.something.domain, e.g. www.nakov.com, www.softuni.bg, www.google.com
        //Examples:
        //Input                                                         	Output
        //The site nakov.com can be access from http://nakov.com            http://nakov.com
        //or www.nakov.com. It has subdomains like mail.nakov.com and       www.nakov.com
        //svetlin.nakov.com. Please check http://blog.nakov.com             http://blog.nakov.com
        //for more information.	                                            

        string[] text = Console.ReadLine().Split(new string[] { " ", ". " }, StringSplitOptions.RemoveEmptyEntries);
        var urlS = text.Where(x => x.Contains("http://") || x.Contains("www."));
        foreach (var x in urlS)
        {
            Console.WriteLine(x);
        }
    }
}

