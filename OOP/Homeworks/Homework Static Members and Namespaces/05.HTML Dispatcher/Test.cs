using System;

namespace _05.HTML_Dispatcher
{
    class Test
    {
        static void Main()
        {
            ElementBuilder div = new ElementBuilder("div");
            div.AddAttribute("id", "page");
            div.AddAttribute("class", "big");
            div.AddContent("<p>Hello</p>");
            Console.WriteLine(div * 3);

            string image = HTMLDispatcher.CreateImage("../../test.jpg", "test", "Test Image");
            string url = HTMLDispatcher.CreateURL("www.google.bg", "Google", "Welcome to Google!");
            string input = HTMLDispatcher.CreateInput("text", "Random text", "It's random text.");

            Console.WriteLine(image);
            Console.WriteLine(url);
            Console.WriteLine(input);
        }
    }
}
