namespace ChepelareHotelBookingSystem.Utilities
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
        
        public static void ValidateMinValue(int value, int minValue, string name)
        {
            if (value < minValue)
            {
                throw new ArgumentException($"The {name} must not be less than {minValue}.");
            }
        }

        public static void ValidateMinValue(decimal value, int minValue, string name)
        {
            if (value < minValue)
            {
                throw new ArgumentException($"The {name} must not be less than {minValue}.");
            }
        }

        public static void ValidateDates(DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate)
            {
                throw new ArgumentException("The date range is invalid.");
            }
        }
    }
}
