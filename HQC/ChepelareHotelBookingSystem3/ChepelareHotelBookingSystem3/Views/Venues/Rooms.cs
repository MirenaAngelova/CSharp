namespace ChepelareHotelBookingSystem3.Views.Venues
{
    using System.Linq;
    using System.Text;

    using Infrastructure;
    using Models;
    using Utilities;

    public class Rooms : View
    {
        public Rooms(Venue venue)
            : base(venue)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var venue = this.Model as Venue;
            viewResult.AppendFormat("Available rooms for venue {0}:", venue.Name).AppendLine();
            if (!venue.Rooms.Any())
            {
                viewResult.AppendFormat(Validation.MessageNoRoomsAvailable);
            }
            else
            {
                foreach (var room in venue.Rooms)
                {
                    viewResult.AppendFormat(" *[{0}] {1} places, ${2:F2} per day", room.Id, room.Places, room.PricePerDay).AppendLine();
                    if (!room.AvailableDates.Any())
                    {
                        viewResult.AppendLine(Validation.MessageRoomNotAvailable);
                    }
                    else
                    {
                        viewResult.AppendLine("Available dates:");

                        // BUG: Refactor datePair => datePair.EndDate to datePair => datePair.StartDate
                        foreach (var datePair in room.AvailableDates.OrderBy(datePair => datePair.StartDate))
                        {
                            // BUG: start date should be before end date
                            viewResult.AppendLine($" - {datePair.StartDate:dd.MM.yyyy} - {datePair.EndDate:dd.MM.yyyy}");
                        }
                    }
                }
            }
        }
    }
}