namespace ChepelareHotelBookingSystem2.Models
{
    using System.Collections.Generic;

    using Interfaces;
    using Utilities;

    public class User : IDbEntity
    {
        private string username;
        private string passwordHash;

        public User(string username, string password, Roles role)
        {
           this.Username = username;
           this.PasswordHash = password;
           this.Role = role;
           this.Bookings = new List<Booking>();
        }

        public Roles Role { get; private set; }

        public ICollection<Booking> Bookings { get; private set; }

        public int Id { get; set; }

        public string Username
        {
            get
            {
                return this.username;
            }
            
            private set
            {
                Validator.ValidateMinLength(value, Validations.MinLengthUsername, "username");
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
                Validator.ValidateMinLength(value, Validations.MinLengthPassword, "password");
                this.passwordHash = HashUtilities.GetSha256Hash(value);
            }
        }
    }
}
