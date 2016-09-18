namespace ChepelareHotelBookingSystem2.Models
{
    using System;

    using Interfaces;
    using Utilities;

    public class Booking : IDbEntity
    {
        private decimal totalPrice;

        public Booking(User client, DateTime startBookDate, DateTime endBookDate, decimal totalPrice, string comments)
        {
            Validator.ValidateDateRange(startBookDate, endBookDate);
            // BUG: Client was not been set in construstor
            this.Client = client;
            this.StartBookDate = startBookDate;
            this.EndBookDate = endBookDate;
            this.TotalPrice = totalPrice;
            this.Comments = comments;
        }

        public int Id { get; set; }

        public User Client { get; private set; }

        public string Comments { get; private set; }

        public DateTime StartBookDate { get; private set; }

        public DateTime EndBookDate { get; private set; }

        public decimal TotalPrice
        {
            get
            {
                return this.totalPrice;
            }

            private set
            {
                Validator.ValidateMinValue(value, 0, "total price");
                this.totalPrice = value;
            }
        }
    }
}