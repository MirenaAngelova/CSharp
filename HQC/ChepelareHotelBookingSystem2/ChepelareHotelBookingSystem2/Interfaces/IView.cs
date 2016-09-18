namespace ChepelareHotelBookingSystem2.Interfaces
{
    public interface IView
    {
        object Model { get; }

        string Display();
    }
}