namespace ChepelareHotelBookingSystem.Models
{
    using System.Collections.Generic;

    using Interfaces;
    using Utilities;

    public class Venue : IDbEntity
    {
        private string name;
        private string address;

        public Venue(string name, string address, string description, User owner)
        {
            this.Name = name;
            this.Address = address;
            this.Description = description;
            this.Owner = owner;
            this.Rooms = new List<Room>();

        }

        public int Id { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.ValidateMinLength(value, Validation.MinVenueNameLength, "venue name");
                this.name = value;
            }
        }

        public string Address
        {
            get
            {
                return this.address;
            }

            private set
            {
                Validator.ValidateMinLength(value, Validation.MinVenueAddressLength, "address");
                this.address = value;
            }
        }

        public string Description { get; private set; }

        public User Owner { get; private set; }

        public ICollection<Room> Rooms { get; private set; }
    }
}
