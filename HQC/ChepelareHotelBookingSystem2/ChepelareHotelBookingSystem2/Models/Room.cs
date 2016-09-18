﻿namespace ChepelareHotelBookingSystem2.Models
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

        public ICollection<AvailableDate> AvailableDates { get; protected set; }

        public ICollection<Booking> Bookings { get; set; }

        public int Id { get; set; }

        public int Places
        {
            get
            {
                return this.places;
            }

            private set
            {
                Validator.ValidateMinValue(value, 0, "places");
                this.places = value;
            }
        }

        public decimal PricePerDay
        {
            get
            {
                return this.pricePerDay;
            }

            internal set
            {
                Validator.ValidateMinValue(value, 0, "price per day");
                this.pricePerDay = value;
            }
        }
    }
}