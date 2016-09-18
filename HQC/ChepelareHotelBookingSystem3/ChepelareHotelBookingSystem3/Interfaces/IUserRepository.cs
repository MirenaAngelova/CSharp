namespace ChepelareHotelBookingSystem3.Interfaces
{
    using Models;

    public interface IUserRepository : IRepository<User>
    {
        User GetByUsername(string username);
    }
}