namespace BangaloreUniversityLearningSystem.Models
{
    using System.Collections.Generic;
    using Utilities;

    public class User
    {
        private string username;
        private string passwordHash;

        public User(string username, string password, Role role)
        {
            // BUG: Move validations from constructor to class Validator and properties Username and Password
            this.Username = username;
            this.Password = password;
            this.Role = role;
            this.Courses = new List<Course>();
        }

        public string Username
        {
            get
            {
                return this.username;
            }

            private set
            {
                Validator.ValidateMinLength(value, Validation.MinLengthUsername, "username");
                this.username = value;
            }
        }

        public string Password
        {
            get
            {
                return this.passwordHash;
            }

            private set
            {
                Validator.ValidateMinLength(value, Validation.MinLengthPassword, "password");
                this.passwordHash = HashUtilities.HashPassword(value);
            }
        }

        public Role Role { get; private set; }

        public IList<Course> Courses { get; private set; }
    }
}