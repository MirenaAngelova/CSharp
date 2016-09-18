namespace ChepelareHotelBookingSystem3.Models
{
    using System;

    using Utilities;

    public class AvailableDate
    {
        public AvailableDate(DateTime startDate, DateTime endDate)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
            Validator.ValidateDateRange(startDate, endDate);
        }

        public DateTime StartDate
        {
            get; private set;
        }

        public DateTime EndDate
        {
            get; private set;
        }
    }
}