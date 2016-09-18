namespace ChepelareHotelBookingSystem2.Utilities
{
    using System;

    public static class Validator
    {
        public static void ValidateMinLength(string value, int minLength, string name)
        {
            if (string.IsNullOrEmpty(value) || value.Length < minLength)
            {
                throw new ArgumentException($"The {name} must be at least {minLength} symbols long.");
            }
        }

        public static void ValidateMinValue(int value, int minLength, string name)
        {
            if (value < minLength)
            {
                throw new ArgumentException($"The {name} must not be less than {minLength}.");
            }
        }

        public static void ValidateMinValue(decimal value, int minLength, string name)
        {
            if (value < minLength)
            {
                throw new ArgumentException($"The {name} must not be less than {minLength}.");
            }
        }

        public static void ValidateDateRange(DateTime startDate, DateTime endDate)
        {
            // BUG: Comparator sign should be ">" not "<"
            if (startDate > endDate)
            {
                throw new ArgumentException("The date range is invalid.");
            }
        }
    }
}
