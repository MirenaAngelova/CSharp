using System;
using System.Globalization;
using System.Threading;

namespace _03.Company_Hierarchy
{
    class CompanyHierarchy
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            SalesEmployee saler = new SalesEmployee("Sales", "Employee", 15, 150M, Department.Sales, 
                new Sale("product", 15));
            Developer developer = new Developer("Develop", "Developer", 20, 200M, Department.Production, 
                new Project("OOP", "exhausted game"));
            Manager manager = new Manager("Manage", "Manager", 25, 250M, Department.Sales, saler);
            Employee[] employees =
            {
                saler,
                developer,
                manager,
                new RegularEmployee("Regular", "Employee", 30, 300M, Department.Accounting),
            };
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
            Console.WriteLine();
        }
    }
}
