namespace Bangalore_University_Learning_System.Data
{
    using Core.Interfaces;
    using Models;

    public class BangaloreUniversityData : IBangaloreUniversityData
    {
        public BangaloreUniversityData()
        {
            this.Users = new UsersRepository();
            this.Courses = new Repository<Course>();
        }

        public UsersRepository Users { get; internal set; }

        public IRepository<Course> Courses { get; protected set; }
    }
}
