using BuhtigIssueTracker2.Infrastructure;

namespace BuhtigIssueTracker2.Core
{
    using System;
    using Interfaces;

    public class Engine : IEngine
    {
        private Dispatcher dispatcher;

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

                // BUG: url should be null to break
                if (url == null)
                {
                    break;
                }

                url = url.Trim();
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

                //if (!string.IsNullOrEmpty(url))// added !
                //{
                //    try
                //    {
                //        var ep = new Endpoint(url); string viewResult = this.dispatcher.DispatchAction(ep);
                //        Console.WriteLine(viewResult);
                //    }
                //    catch (Exception ex)
                //    {
                //        Console.WriteLine(ex.Message);
                //    }
                //}

            }
        }
    }
}