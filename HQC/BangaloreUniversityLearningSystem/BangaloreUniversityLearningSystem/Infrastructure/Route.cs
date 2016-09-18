namespace BangaloreUniversityLearningSystem.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Net;

    using Interfaces;
    using Utilities;

    public class Route : IRoute
    {
        public Route(string routeUrl)

        // public Route(string routeUrl, IDictionary<string, string> parameters, string controllerName)
        {
            this.Parse(routeUrl);
        }

        public string ControllerName { get; private set; }

        public string ActionName { get; private set; }

        // Refactor _parameters to parameters
        public IDictionary<string, string> Parameters { get; private set; }

        private void Parse(string routeUrl)
        {
            string[] parts = routeUrl.Split(
                new[] { "/", "?" }, 
                StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2)
            {
                throw new InvalidOperationException(Messages.ExceptionMessageRouteInvalid);
            }

            // Refactor _controllerName to controllerName
            // Performance this.controllerName to var controllerName. We assign parts of routeUrl to variable. 
            // There is no need of property.
            this.ControllerName = parts[0] + Constants.Controller;

            // Refactor _actionName to actionName
            // Performance this.actionName to var actionName. We assign parts of routeUrl to variable. 
            // There is no need of property.
            this.ActionName = parts[1];
            if (parts.Length >= 3)
            {
                this.Parameters = new Dictionary<string, string>();
                string[] parameterPairs = parts[2].Split('&');
                foreach (var pair in parameterPairs)
                {
                    // Refactor name_value to nameValue
                    string[] nameValue = pair.Split('=');

                    // Performance: Assing to variable name and value WebUtility.UrlDecode(nameValue[0])
                    // and WebUtility.UrlDecode(nameValue[1])
                    
                    // BUG: nameValue[1] was before nameValue[0]
                    string name = WebUtility.UrlDecode(nameValue[0]);
                    string value = WebUtility.UrlDecode(nameValue[1]);

                    this.Parameters.Add(name, value);
                }
            }
        }
    }
}