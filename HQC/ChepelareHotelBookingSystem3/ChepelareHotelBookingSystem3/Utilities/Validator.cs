namespace ChepelareHotelBookingSystem3.Utilities
{
    using System;

    using Models;

    public class Validator
    {
        public static void ValidateDateRange(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                throw new ArgumentException(Validation.ExceptionMessageInvalidDateRange);
            }
        }

        public static void ValidateConfirmPassword(string password, string confirmPassword)
        {
            if (password != confirmPassword)
            {
                // Refactor "The provided passwords match." to "The provided passwords do not match."
                throw new ArgumentException(Validation.ExceptionMessagePasswordsDoNotMatch);
            }
        }

        public static void ValidateUserExists(User existingUser, string username)
        {
            if (existingUser != null)
            {
                throw new ArgumentException($"A user with username {username} already exists.");
            }
        }

        public static void ValidateUserNotExist(User existingUser, string username)
        {
            if (existingUser == null)
            {
                throw new ArgumentException($"A user with username {username} does not exist.");
            }
        }

        public static void ValidateMinLength(string value, string name, int minLength)
        {
            if (string.IsNullOrEmpty(value) || value.Length < minLength)
            {
                throw new ArgumentException($"The {name} must be at least {minLength} symbols long.");
            }
        }

        public static void ValidateMinValue(int value, string name,  int minLength)
        {
            if (value < minLength)
            {
                throw new ArgumentException($"The {name} must not be less than {minLength}.");
            }
        }

        public static void ValidateMinValue(decimal value, string name, int minLength)
        {
            if (value < minLength)
            {
                throw new ArgumentException($"The {name} must not be less than {minLength}.");
            }
        }
    }
}
