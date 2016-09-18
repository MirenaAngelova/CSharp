
namespace _05.HTML_Dispatcher
{
     static class HTMLDispatcher
    {
         public static string CreateImage(string imageSource, string alt, string title)
         {
             ElementBuilder image = new ElementBuilder("img");
             image.AddAttribute("src", imageSource);
             image.AddAttribute("alt", alt);
             image.AddAttribute("title", title);
             return image.ToString();
         }

         public static string CreateURL(string url, string text, string title)
         {
             ElementBuilder link = new ElementBuilder("a");
             link.AddAttribute("href", url);
             link.AddAttribute("text", text);
             link.AddAttribute("title", title);
             return link.ToString();
         }

         public static string CreateInput(string inputType, string name, string value)
         {
             ElementBuilder input = new ElementBuilder("input");
             input.AddAttribute("type", inputType);
             input.AddAttribute("name", name);
             input.AddAttribute("value", value);
             return input.ToString();
         }
    }
}
