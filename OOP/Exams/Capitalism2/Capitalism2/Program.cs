namespace Capitalism2
{
    using Core;
    using Interfaces;

    public class Program
    {
        static void Main()
        {
            IDatabase database = new Database();
            IEngine engine = new Engine(database);
            engine.Run();
        }
    }
}
