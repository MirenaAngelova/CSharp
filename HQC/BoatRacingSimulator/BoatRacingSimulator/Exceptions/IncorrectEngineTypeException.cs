namespace BoatRacingSimulator.Exceptions
{
    using System;

    public class IncorrectEngineTypeException : Exception
    {
        public IncorrectEngineTypeException(string message) : base(message)
        {
        }
    }
}