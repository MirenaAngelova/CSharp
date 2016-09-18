namespace Bangalore_University_Learning_System.Models
{
    using System.Collections.Generic;

    using Utilities;

    public class User
    {
        private string username;
        private string passwordHash;
        
        public User(string username, string password, Role role)
        {
            this.UserName = username;
            this.PasswordHash = password;
            this.Role = role;
            this.Courses = new List<Course>();
        }

        public string UserName
        {
            get
            {
                return this.username;
            }

            private set
            {
                Validation.ForMinLength(value, ValidationConstants.MinUsernameLength, "username");
                this.username = value;
            }
        }

        public string PasswordHash
        {
            get
            {
                return this.passwordHash;
            }

            private set
            {
                Validation.ForMinLength(value, ValidationConstants.MinPasswordLength, "password");
                this.passwordHash = HashUtilities.HashPassword(value);
            }
        }

        public Role Role { get; private set; }

        public IList<Course> Courses { get; private set; }
    }
}