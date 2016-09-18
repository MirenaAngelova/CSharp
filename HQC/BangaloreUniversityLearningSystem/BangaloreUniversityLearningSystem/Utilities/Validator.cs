namespace BangaloreUniversityLearningSystem.Utilities
{
    using System;

    using Models;

    public static class Validator
    {
        public static void ValidateMinLength(string value, int minLength, string name)
        {
            if (string.IsNullOrEmpty(value) || value.Length < minLength)
            {
                string message = $"The {name} must be at least {minLength} symbols long.";
                throw new ArgumentException(message);
            }
        }
        
        public static void ValidateNoCourse(Course course, int courseId)
        {
            if (course == null)
            {
                throw new ArgumentException($"There is no course with ID {courseId}.");
            }
        }

        public static void ValidateUserExists(User existingUser, string username)
        {
            if (existingUser != null)
            {
                throw new ArgumentException($"A user with username {username} already exists.");
            }
        }

        public static void ValidateUserNotExists(User existingUser, string username)
        {
            if (existingUser == null)
            {
                throw new ArgumentException($"A user with username {username} does not exist.");
            }
        }
    }
}