namespace ChepelareHotelBookingSystem3.Models
{
    using System.Collections.Generic;

    using Interfaces;
    using Utilities;

    public class Room : IDbEntity
    {
        private int places;
        private decimal pricePerDay;

        public Room(int places, decimal pricePerDay)
        {
            this.Places = places;
            this.PricePerDay = pricePerDay;
            this.Bookings = new List<Booking>();
            this.AvailableDates = new List<AvailableDate>();
        }

        public int Id { get; set; }

        public int Places
        {
            get
            {
                return this.places;
            }

            private set
            {
                Validator.ValidateMinValue(value, "places", 0);
                this.places = value;
            }
        }

        public decimal PricePerDay
        {
            get
            {
                return this.pricePerDay;
            }

            private set
            {
                Validator.ValidateMinValue(value, "price per day", 0);
                this.pricePerDay = value;
            }
        }

        public ICollection<AvailableDate> AvailableDates { get; protected set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}