namespace ChepelareHotelBookingSystem.Models
{
    using System.Collections.Generic;

    using Enum;
    using Interfaces;
    using Utilities;

    public class User : IDbEntity
    {
        private string username;
        private string passwordHash;

        public User(string username, string password, Role role)
        {
            this.Username = username;
            this.PasswordHash = password;
            this.Role = role;
            this.Bookings = new List<Booking>();
        }

        public int Id { get; set; }

        public string Username
        {
            get
            {
                return this.username;
            }

            private set
            {
                Validator.ValidateMinLength(value, Validation.MinUsernameLength, "username");
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
                Validator.ValidateMinLength(value, Validation.MinPasswordLength, "password");
                this.passwordHash = HashUtilities.GetSha256Hash(value);
            }
        }

        public Role Role { get; private set; }

        public ICollection<Booking> Bookings { get; private set; }
    }
}
