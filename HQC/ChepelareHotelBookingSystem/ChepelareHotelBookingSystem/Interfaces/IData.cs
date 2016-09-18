namespace ChepelareHotelBookingSystem.Interfaces
{
    using Models;

    public interface IData
    {
        IUserRepository Users { get; }

        IRepository<Venue> Venues { get; }

        IRepository<Room> Rooms { get; }

        IRepository<Booking> Bookings { get; }
    }
}