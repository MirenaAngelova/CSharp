using System.Collections.Generic;
using Air_Conditioner_Testing_System.Interfaces;
using Air_Conditioner_Testing_System.Models;

namespace Air_Conditioner_Testing_System.Databases
{
    public class Database : IDatabase
    {
        public Database()
        {
            this.AirConditioners = new Repository<IAirConditioner>();
           this. Reports = new ReportsRepository();
        }

        public IRepository<IAirConditioner> AirConditioners { get; }

        public IReportsRepository Reports { get; }
    }
}