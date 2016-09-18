namespace ChepelareHotelBookingSystem2.Views.Rooms
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Infrastructure;
    using Models;

    public class ViewBookings : View
    {
        public ViewBookings(IEnumerable<Booking> bookings)
            : base(bookings)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var bookings = this.Model as IEnumerable<Booking>;
            if (!bookings.Any())
            {
                viewResult.AppendLine("There are no bookings for this room.");
            }
            else
            {
                viewResult.AppendLine("Room bookings:");
                foreach (var booking in bookings)
                {
                    viewResult
                        .AppendLine(
                            $"* {booking.StartBookDate:dd.MM.yyyy} - {booking.EndBookDate:dd.MM.yyyy} " +
                            $"(${booking.TotalPrice:F2})");
                }
                viewResult.AppendLine($"Total booking price: ${bookings.Sum(b => b.TotalPrice):F2}");
            }
        }
    }
}
