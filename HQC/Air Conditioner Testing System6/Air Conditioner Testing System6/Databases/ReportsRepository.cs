using System.Collections;
using System.Collections.Generic;
using Air_Conditioner_Testing_System6.Constants;
using Air_Conditioner_Testing_System6.Exceptions;
using Air_Conditioner_Testing_System6.Interfaces;

namespace Air_Conditioner_Testing_System6.Databases
{
    public class ReportsRepository : Repository<IReport>, IReportsRepository
    {
        public ReportsRepository()
        {
            this.ItemsByManufacturer = new Dictionary<string, IList<IReport>>();
        }

        protected Dictionary<string, IList<IReport>> ItemsByManufacturer { get; set; } 

        public override void Add(IReport item)
        {
            base.Add(item);
            string manufacturer = item.Manufacturer;
            if (!this.ItemsByManufacturer.ContainsKey(manufacturer))
            {
                this.ItemsByManufacturer.Add(manufacturer, new List<IReport>());
            }
            
            this.ItemsByManufacturer[manufacturer].Add(item);
        }

        public IList<IReport> GetReportsByManufacturer(string manufacturer)
        {
            if (!this.ItemsByManufacturer.ContainsKey(manufacturer))
            {
                return new List<IReport>();
            }
            return new List<IReport>(this.ItemsByManufacturer[manufacturer]);
        }
    }
}