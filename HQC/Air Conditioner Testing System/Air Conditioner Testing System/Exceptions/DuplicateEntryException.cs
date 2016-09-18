using System;

namespace Air_Conditioner_Testing_System.Exceptions
{
    public class DuplicateEntryException : ArgumentException
    {
        public DuplicateEntryException(string message) : base(message)
        {
        }
    }
}
