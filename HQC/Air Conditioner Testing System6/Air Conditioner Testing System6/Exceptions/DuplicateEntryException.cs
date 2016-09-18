using System;

namespace Air_Conditioner_Testing_System6.Exceptions
{
    public class DuplicateEntryException : Exception
    {
        public DuplicateEntryException(string message) : base(message)
        {
        }
    }
}
