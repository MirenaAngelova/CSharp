namespace ClashOfKings.Exeptions
{
    using System;

    public class GameExceptions : Exception
    {
        public GameExceptions(string message) : base(message)
        {
        }
    }
}