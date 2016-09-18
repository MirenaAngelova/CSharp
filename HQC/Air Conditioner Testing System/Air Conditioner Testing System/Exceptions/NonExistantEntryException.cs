using System;

namespace Air_Conditioner_Testing_System.Exceptions
{
    public class NonExistantEntryException : Exception
    {
        public NonExistantEntryException(string message) : base(message)
        {
        }
    }
}
