namespace ChepelareHotelBookingSystem2.Views.Venues
{
    using System.Linq;
    using System.Text;

    using Infrastructure;
    using Models;

    public class Details : View
    {
        public Details(Venue venue)
            : base(venue)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var venue = this.Model as Venue;
            viewResult.AppendLine(venue.Name)
                .AppendLine($"Located at {venue.Address}")
                .AppendLine($"Description: {venue.Description}");
            if (!venue.Rooms.Any())
            {
                viewResult.AppendFormat("No rooms are currently available.");
            }
            else
            {
                viewResult.AppendLine("Available rooms:");
                foreach (var room in venue.Rooms)
                {
                    viewResult.AppendLine($" * {room.Places} places (${room.PricePerDay:F2} per day)");
                }
            }
        }
    }
}