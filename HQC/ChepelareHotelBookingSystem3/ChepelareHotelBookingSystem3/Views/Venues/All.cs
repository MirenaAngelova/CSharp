namespace ChepelareHotelBookingSystem3.Views.Venues
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Infrastructure;
    using Models;

    public class All : View
    {
        public All(IEnumerable<Venue> venues)
            : base(venues)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var venues = this.Model as IEnumerable<Venue>;
            if (!venues.Any())
            {
                viewResult.AppendLine("There are currently no venues to show.");
            }
            else
            {
                foreach (var venue in venues)
                {
                    viewResult.AppendLine($"*[{venue.Id}] {venue.Name}, located at {venue.Address}")
                    .AppendLine($"Free rooms: {venue.Rooms.Count}");
                }
            }
        }
    }
}