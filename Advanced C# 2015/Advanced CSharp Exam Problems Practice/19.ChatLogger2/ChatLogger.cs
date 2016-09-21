using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Security;
using System.Text.RegularExpressions;
using System.Threading;

class ChatLogger
{
    static void Main()
    {
        //Write a program that receives several messages and the current date, sorts those messages by date and prints the time 
        //from the last message to the current date.
        //The messages will be in format [message] / [date], where date is in format dd-mm-YYYY hours:min:secs. 
        //The messages should be sorted by date and their text should be printed in <div></div> tags on a separate line. 
        //For example we are given the current date 12-08-2014 10:14:23 and the following messages:
        //Thanks :) / 11-08-2014 22:54:52
        //Hey John, happy birthday! / 10-08-2014 00:00:00
        //After sorting the messages by date in ascending order (from oldest to most recent), the result is:
        //<div>Hey John, happy birthday!</div>
        //<div>Thanks :)</div>
        //Finally, the time since the most recent message should be printed in the following way:
        //•	a few moments ago if it was less than 1 minute ago
        //•	[full minutes] minute(s) ago if it was less than 1 hour ago
        //•	[full hours] hour(s) ago if it was less than 24 hours ago on the same day
        //•	yesterday if it was the previous date, regardless of the time difference
        //•	[date] if it was earlier than yesterday, where date is in format dd-mm-YYYY
        //The resulting timestamp should be printed as follows:  <p>Last active: <time>[timestamp]</time></p>. In this case, 
        //the difference between the current date and the last message is 11 full hours, but since the message's day is 1 day 
        //before the current day, we print yesterday:
        //    <p>Last active: <time>yesterday</time></p>
        //Input
        //The input will be read from the console. The current time will be received on the first line. The messages come 
        //will be received on the next input lines, each message on a separate line. The input ends with the command "END".
        //Output
        //Each message should be printed in its own <div></div> tags, on a separate line. On the final line, the difference 
        //between the current date and the last message date should be printed in the format described above. 
        //Ensure the HTML special characters are correctly encoded (use SecurityElement.Excape).
        //Constraints
        //•	All input dates will be in format dd-mm-YYYY hours:min:secs.
        //•	The received messages will always be in format [message] / [date] (with space around the delimiter '/').
        //•	There will be exactly one message on a single line.
        //•	There will be no messages with the same date.
        //•	The current date will always be after any message's date.

        //Examples
        //Input	                                                Output
        //12-08-2014 10:14:23                                <div>Hey John, happy birthday!</div>
        //Thanks :) / 11-08-2014 22:54:52                    <div>Thanks :)</div>
        //Hey John, happy birthday! / 10-08-2014 00:00:00    <p>Last active: <time>yesterday</time></p>
        //END	

        //Input	                                                                         
        //29-08-2014 15:33:11                                                            
        //Kaji na mama che q obicham / 29-08-2014 15:32:23                               
        //Zdravey, kak mina izpita? / 29-08-2014 15:30:32                                
        //Brat sgashtiha me da prepisvam i me karat v raionnoto.. / 29-08-2014 15:30:58  
        //END	
        //Output      
        //<div>Zdravey, kak mina izpita?</div>      
        //<div>Brat sgashtiha me da prepisvam i me karat v raionnoto..</div> 
        //<div>Kaji na mama che q obicham</div>
        //<p>Last active: <time>a few moments ago</time></p>
        //
        //Input	
        //29-08-2014 17:33:11
        //Wanna grab some snacks? / 24-08-2014 16:33:12
        //Sure, be right there in a minute! / 25-08-2014 22:06:13
        //END
        //Output
        //<div>Wanna grab some snacks?</div>
        //<div>Sure, be right there in a minute!</div>
        //<p>Last active: <time>25-08-2014</time></p>


        //Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");
        //var messages = new SortedDictionary<DateTime, string>();

        //// input current time
        //var currentTime = DateTime.Parse(Console.ReadLine());

        //// input messages
        //while (true)
        //{
        //    string line = Console.ReadLine();

        //    if (line == "END")
        //    {
        //        break;
        //    }
        //    string pattern = @"(\s+\/+\s+)";
        //    var data = Regex.Split(line, pattern);

        //    messages.Add(DateTime.Parse(data[2]), data[0]);
        //}

        //DateTime mostRecentDate = messages.Last().Key;
        //TimeSpan time = currentTime - mostRecentDate;

        //// check for time span
        //foreach (var pair in messages)
        //{
        //    Console.WriteLine("<div>{0}</div>", SecurityElement.Escape(pair.Value));
        //}
        //if (mostRecentDate.Day < currentTime.Day - 1)
        //{
        //    Console.WriteLine("<p>Last active: <time>{0}</time></p>", mostRecentDate.ToString("dd-MM-yyyy"));
        //}

        //else if (mostRecentDate.Day == currentTime.Day - 1)
        //{
        //    Console.WriteLine("<p>Last active: <time>yesterday</time></p>");
        //}
        //else if (mostRecentDate.Day == currentTime.Day && time.TotalHours >= 1)
        //{
        //    Console.WriteLine("<p>Last active: <time>{0} hour(s) ago</time></p>", (int)time.TotalHours);
        //}
        //else if (time.TotalHours < 1 && time.TotalMinutes >= 1)
        //{
        //    Console.WriteLine("<p>Last active: <time>{0} minute(s) ago</time></p>", (int)time.TotalMinutes);
        //}
        //else
        //{
        //    Console.WriteLine("<p>Last active: <time>a few moments ago</time></p>");
        //}

        Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");
        SortedDictionary<DateTime, string> messages =
            new SortedDictionary<DateTime, string>();
        DateTime currentDate = DateTime.Parse(Console.ReadLine());
        string input = Console.ReadLine();
        while (input != "END")
        {
            string pattern = @"\s\/\s";
            string[] inputLine = Regex.Split(input, pattern);
            string message = inputLine[0];
            DateTime date = DateTime.Parse(inputLine[1]);
            int month = date.Month;

            if (!messages.ContainsKey(date))
            {
                messages.Add(date, message);
            }

            input = Console.ReadLine();
        }

        DateTime mostRecentDate = messages.Keys.Last();
        TimeSpan timeSpan = currentDate - mostRecentDate;
        foreach (var date in messages)
        {
            Console.WriteLine($"<div>{SecurityElement.Escape(date.Value)}</div>");
        }
        if (mostRecentDate.Day < currentDate.Day - 1)
        {//•	[date] if it was earlier than yesterday, where date is in format 
            Console.WriteLine($"<p>Last active: <time>{mostRecentDate.ToString("dd-MM-yyyy")}</time></p>");
        }
        else if (mostRecentDate.Day == currentDate.Day - 1)
        {
            Console.WriteLine($"<p>Last active: <time>yesterday</time></p>");
        }
        else if (mostRecentDate.Day == currentDate.Day && timeSpan.Hours >= 1)
        {
            Console.WriteLine(
                $"<p>Last active: <time>{(int)timeSpan.TotalHours} hour(s) ago</time></p>");
        }
        else if (timeSpan.TotalHours < 1 && timeSpan.TotalMinutes >= 1)
        {
            Console.WriteLine(
                $"<p>Last active: <time>{(int)timeSpan.Minutes} minute(s) ago</time></p>");
        }
        else
        {
            Console.WriteLine(
                $"<p>Last active: <time>a few moments ago</time></p>");
        }

    }
}