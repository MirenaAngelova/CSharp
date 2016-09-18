namespace ChepelareHotelBookingSystem3.Views.Rooms
{
    using System.Text;

    using Infrastructure;
    using Models;

    public class Book : View
    {
        public Book(Booking booking)
            : base(booking)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var booking = this.Model as Booking;
            viewResult.AppendLine(
                $"Room booked from {booking.StartBookDate:dd.MM.yyyy} " +
                 $"to {booking.EndBookDate:dd.MM.yyyy} for ${booking.TotalPrice:F2}.");
        }
    }
}