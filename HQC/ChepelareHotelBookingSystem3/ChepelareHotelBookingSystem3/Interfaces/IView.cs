namespace ChepelareHotelBookingSystem3.Interfaces
{
    public interface IView
    {
        object Model { get; }

        string Display();
    }
}