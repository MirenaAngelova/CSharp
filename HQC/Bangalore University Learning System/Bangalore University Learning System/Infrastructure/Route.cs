namespace Bangalore_University_Learning_System.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Net;

    using Core.Interfaces;
    using Utilities;

    public class Route : IRoute
    {
        private const int PartsLength = 3;

        public Route(string routeUrl)
        {
            this.Parse(routeUrl);
        }

        public string ActionName { get; private set; }

        public string ControllerName { get; private set; }

        public IDictionary<string, string> Parameters { get; private set; }

        private void Parse(string routeUrl)
        {
            string[] routeParts = routeUrl.Split(
                new[] { "/", "?" },
                StringSplitOptions.RemoveEmptyEntries);
            if (routeParts.Length < 2)
            {
                throw new InvalidOperationException("The provided route is invalid.");
            }
            string partialControllerName = routeParts[0];
            this.ControllerName = partialControllerName + Constants.ControllerSuffix;
            this.ActionName = routeParts[1];
            if (routeParts.Length >= PartsLength)
            {
                this.Parameters = new Dictionary<string, string>();
                string[] parameterPairs = routeParts[2].Split('&');
                foreach (var pair in parameterPairs)
                {
                    string[] nameValue = pair.Split('=');
                    string name = WebUtility.UrlDecode(nameValue[0]);
                    string value = WebUtility.UrlDecode(nameValue[1]);
                    this.Parameters.Add(name, value);
                }
            }
        }
    }
}