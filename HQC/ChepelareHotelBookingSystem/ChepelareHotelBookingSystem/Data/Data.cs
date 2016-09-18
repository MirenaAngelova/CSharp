namespace ChepelareHotelBookingSystem.Data
{
    using Interfaces;
    using Models;

    public class Data : IData
    {
        public Data()
        {
            this.Users = new UserRepository();
            this.Venues = new Repository<Venue>();
            this.Rooms = new Repository<Room>();
            this.Bookings = new Repository<Booking>();
        }

        public IUserRepository Users { get; private set; }

        public IRepository<Venue> Venues { get; set; }

        public IRepository<Room> Rooms { get; set; }

        public IRepository<Booking> Bookings { get; set; }
    }
}
