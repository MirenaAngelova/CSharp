namespace ChepelareHotelBookingSystem2.Views.Rooms
{
    using System.Text;

    using Infrastructure;
    using Models;

    public class AddPeriod : View
    {
        public AddPeriod(Room room)
            : base(room)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var room = this.Model as Room;
            viewResult.AppendLine($"The period has been added to room with ID {room.Id}.");
        }
    }
}