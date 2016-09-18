namespace BuhtigIssueTracker
{
    using System;

    using BuhtigIssueTracker.Interfaces;

    public class Engine : IEngine
    {
        private readonly Dispatcher dispatcher;

        public Engine(Dispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        public Engine()
            : this(new Dispatcher())
        {
        }

        public void Run()
        {
            while (true)
            {
                string url = Console.ReadLine();
                if (url == null)
                {
                    break;
                }

                url = url.Trim();
                if (!string.IsNullOrEmpty(url))
                {
                    try
                    {
                        var endpoint = new Endpoint(url);
                        string viewResult = this.dispatcher.DispatchAction(endpoint);
                        Console.WriteLine(viewResult);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}