using System;

namespace Air_Conditioner_Testing_System6.Exceptions
{
    public class NonExistantEntryException : Exception
    {
        public NonExistantEntryException(string message) : base(message)
        {
        }
    }
}
