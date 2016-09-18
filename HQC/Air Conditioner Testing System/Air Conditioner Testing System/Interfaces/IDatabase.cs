using System.Collections;
using System.Collections.Generic;
using Air_Conditioner_Testing_System.Models.AirConditioners;

namespace Air_Conditioner_Testing_System.Interfaces
{
    public interface IDatabase
    {
        IRepository<IAirConditioner>  AirConditioners { get; }

        IReportsRepository Reports { get; }
    }
}