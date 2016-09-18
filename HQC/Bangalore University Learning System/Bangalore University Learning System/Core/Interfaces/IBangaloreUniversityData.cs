namespace Bangalore_University_Learning_System.Core.Interfaces
{
    using Data;
    using Models;

    public interface IBangaloreUniversityData
    {
        UsersRepository Users { get; }

        IRepository<Course> Courses { get; }
    }
}