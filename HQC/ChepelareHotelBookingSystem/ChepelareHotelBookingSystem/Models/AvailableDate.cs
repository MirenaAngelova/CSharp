namespace ChepelareHotelBookingSystem.Models
{
    using System;

    using Utilities;

    public class AvailableDate
    {
        public AvailableDate(DateTime startDate, DateTime endDate)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
            Validator.ValidateDates(this.StartDate, this.EndDate);
        }

        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }
    }
}