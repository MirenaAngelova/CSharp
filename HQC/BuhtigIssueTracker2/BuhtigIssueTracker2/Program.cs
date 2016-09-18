namespace BuhtigIssueTracker2
{
    using System.Globalization;
    using System.Threading;

    using Core;

    class Program
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var engine = new Engine();
            engine.Run();
        }
    }
}
