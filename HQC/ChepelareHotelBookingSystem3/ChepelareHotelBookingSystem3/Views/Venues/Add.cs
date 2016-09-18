namespace ChepelareHotelBookingSystem3.Views.Venues
{
    using System.Text;

    using Infrastructure;
    using Models;

    public class Add : View
    {
        public Add(Venue venue)
            : base(venue)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var venue = this.Model as Venue;
            viewResult.AppendLine($"The venue {venue.Name} with ID {venue.Id} has been created successfully.");
        }
    }
}