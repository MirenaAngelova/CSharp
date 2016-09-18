namespace ChepelareHotelBookingSystem2.Views.Venues
{
    using System.Linq;
    using System.Text;

    using Infrastructure;
    using Models;

    public class Rooms : View
    {
        public Rooms(Venue venue)
            : base(venue)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var venue = this.Model as Venue;
            viewResult.AppendLine($"Available rooms for venue {venue.Name}:");
            if (!venue.Rooms.Any())
            {
                viewResult.AppendFormat("No rooms are currently available.");
            }
            else
            {
                foreach (var room in venue.Rooms)
                {
                    viewResult.AppendLine($" *[{room.Id}] {room.Places} places, ${room.PricePerDay:F2} per day");
                    if (!room.AvailableDates.Any())
                    {
                        viewResult.AppendLine("This room is not currently available.");
                    }
                    else
                    {
                        viewResult.AppendLine("Available dates:");

                        // PERFORMANCE: Move multiple orderBy call before foreach loop.
                        var dates = room.AvailableDates.OrderBy(datePair => datePair.StartDate);
                        foreach (var datePair in dates)
                        {
                            viewResult.AppendLine($" - {datePair.StartDate:dd.MM.yyyy} - " +
                                                  $"{datePair.EndDate:dd.MM.yyyy}");
                        }
                    }
                }
            }
        }
    }
}