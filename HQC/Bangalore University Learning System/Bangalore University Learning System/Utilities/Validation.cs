namespace Bangalore_University_Learning_System.Utilities
{
    using System;

    public static class Validation
    {
        public static void ForMinLength(string value, int minLength, string paramName)
        {
            if (string.IsNullOrEmpty(value) || value.Length < minLength)
            {
                string message = $"The {paramName} must be at least {minLength} symbols long.";
                throw new ArgumentException(message);
            }
        }
    }
}
