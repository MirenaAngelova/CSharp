namespace ChepelareHotelBookingSystem2.Views.Rooms
{
    using System.Text;

    using Infrastructure;
    using Models;

    public class Add : View
    {
        public Add(Room room)
            : base(room)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var room = this.Model as Room;
            viewResult.AppendLine($"The room with ID {room.Id} has been created successfully.");
        }
    }
}