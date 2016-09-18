namespace BuhtigIssueTracker
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    using BuhtigIssueTracker.Interfaces;

    public class Endpoint : IEndpoint
    {
        public Endpoint(string inputLine)
        {
            int questionMark = inputLine.IndexOf('?');
            if (questionMark != -1)
            {
                this.ActionName = inputLine.Substring(0, questionMark);
                var pairs = inputLine
                    .Substring(questionMark + 1)
                    .Split('&')
                    .Select(x => x.Split('=').Select(WebUtility.UrlDecode)
                        .ToArray());
                var parameters = pairs.ToDictionary(pair => pair[0], pair => pair[1]);
                this.Parameters = parameters;
            }
            else
            {
                this.ActionName = inputLine;
            } 
        }

        public string ActionName { get; set; }

        public IDictionary<string, string> Parameters { get; set; }
    }
}