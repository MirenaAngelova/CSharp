using System;

namespace _03.Company_Hierarchy
{
     abstract class Employee : Person, IEmployee
    {
        private decimal salary;

         public Employee(string firstName, string lastName, int id, decimal salary, Department Department)
             :base(firstName, lastName, id)
         {
             this.FirstName = firstName;
             this.LastName = lastName;
             this.ID = id;
         }

         public decimal Salary
         {
             get { return this.salary; }
             set
             {
                 if (value < 0)
                 {
                     throw new ArgumentOutOfRangeException("salary", "Salary cannot be negative.");
                 }
                 this.salary = value;
             }
         }

         public Department Department { get; set; }
    }
}
