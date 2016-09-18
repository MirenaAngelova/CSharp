using Air_Conditioner_Testing_System6.Interfaces;

namespace Air_Conditioner_Testing_System6.Databases
{
    public class Database : IDatabase
    {
        public Database()
        {
            this.AirConditioners = new Repository<IAirConditioner>();
            this.Reports = new ReportsRepository();
        }
        public IRepository<IAirConditioner> AirConditioners { get; }

        public IReportsRepository Reports { get; set; }
    }
}