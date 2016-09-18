using System.Collections;
using System.Collections.Generic;

namespace Air_Conditioner_Testing_System6.Interfaces
{
    public interface IDatabase
    {
         IRepository<IAirConditioner> AirConditioners { get; }
        
         IReportsRepository Reports { get; } 
    }
}