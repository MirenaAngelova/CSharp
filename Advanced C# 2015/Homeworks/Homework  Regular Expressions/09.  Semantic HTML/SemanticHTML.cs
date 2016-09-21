using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
class SemanticHTML
{
    static void Main()
    {
        //You are given an HTML code, written in the old non-semantic style using tags like <div id="header">, 
        //<div class="section">, etc. Your task is to write a program that converts this HTML to semantic HTML by 
        //changing tags like <div id="header"> to their semantic equivalent like <header>.
        //The non-semantic tags that should be converted are always <div>s and have either id or class with one of the 
        //following values: "main", "header", "nav", "article", "section", "aside" or "footer". Their corresponding closing
        //tags are always followed by a comment like <!-- header -->, <!-- nav -->, etc. staying at the same line, 
        //after the tag.
        //Input
        //The input will be read from the console. It will contain a variable number of lines and will end with the 
        //keyword "END".
        //Output
        //The output is the semantic version of the input HTML. In all converted tags you should replace multiple spaces 
        //(like <header      style="color:red">) with a single space and remove excessive spaces at the end 
        //(like <footer      >). See the examples.
        //Constraints
        //•	Each line from the input holds either an HTML opening tag or an HTML closing tag or HTML text content.
        //•	There will be no tags that span several lines and no lines that hold multiple tags.
        //•	Attributes values will always be enclosed in double quotes ".
        //•	Tags will never have id and class at the same time.
        //•	The HTML will be valid. Opening and closing tags will match correctly.
        //•	Whitespace may occur between attribute names, values and around comments (see the examples).
        //•	Allowed working time: 0.1 seconds. Allowed memory: 16 MB.
        //Examples
        //Input	                                    Output
        //<div id="header">                         <header>
        //</div> <!-- header -->                    </header>
        //END	
        //<div style="color:red" id="header">       <header style="color:red">
        //</div> <!-- header -->                    </header>
        //END	
        //<div class="header" style="color:blue">   <header style="color:blue">
        //</div> <!-- header -->                    </header>
        //END	
        //<div align="left" id="nav" style="color:blue">        <nav align="left" style="color:blue">
        //  <ul class="header">                                   <ul class="header">
        //    <li id="main">                                        <li id="main">
        //      Hi, I have id="main".                                 Hi, I have id="main".
        //    </li>                                                 </li>
        //  </ul>                                                 </ul>
        //</div> <!-- nav -->                                   </nav>
        //END	                                                
        //<p class = "section" >                                  <p class = "section" >
        //  <div style = "border: 1px" id = "header" >              <header style = "border: 1px">
        //      Header                                                  Header
        //      <div id = "nav" >                                       <nav>
        //          Nav                                                     Nav
        //      </div>   <!--   nav   -->                               </nav>
        //  </div>  <!--header-->                                   </header>
        //</p> <!-- end paragraph section -->                     </p> <!-- end paragraph section -->
        //END

        List<string> results = new List<string>();
        string input;

        string[] semanticTags = { "main", "header", "nav", "article", "section", "aside", "footer" };
        string openningTags = @"<div.*?\b((id|class)\s*=\s*""(.*?)"").*?>";
        string closeTagsPattern = @"<\/div>\s.*?(\w+)\s*-->";

        Regex users = new Regex(openningTags);
        Regex closer = new Regex(closeTagsPattern);

        while (!((input = Console.ReadLine()) == "END"))
        {
            MatchCollection matchesOp = users.Matches(input);
            foreach (Match match in matchesOp)
            {
                string attrName = match.Groups[1].Value;
                string attrValue = match.Groups[3].Value;

                if (semanticTags.Contains(attrValue))
                {
                    string replaceTag = Regex.Replace(match.ToString(), "div", word => attrValue);

                    replaceTag = Regex.Replace(replaceTag, attrName, "");
                    replaceTag = Regex.Replace(replaceTag, "\\s*>", ">");
                    replaceTag = Regex.Replace(replaceTag, "\\s{2,}", " ");

                    input = Regex.Replace(input, match.ToString(), replaceTag);
                }
            }
            MatchCollection matcesCl = closer.Matches(input);
            foreach (Match match in matcesCl)
            {
                string commentValue = match.Groups[1].Value;
                if (semanticTags.Contains(commentValue))
                {
                    input = Regex.Replace(input, match.ToString(), string.Format("</" + commentValue + ">"));
                }
            }
            results.Add(input);
        }
        for (int i = 0; i < results.Count; i++)
        {
            Console.WriteLine(results[i]);
        }
    }
}