using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.Human__Student_and_Worker
{
    public class Worker : Human
    {
        public decimal WeekSalary { get; set; }
        public int WorkHoursPerDay { get; set; }

        public Worker(string firstName, string lastName, decimal weekSalary, int workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal MoneyPerHour()
        {
            decimal salary = this.WeekSalary;
            int hours = this.WorkHoursPerDay;
            decimal payment = (salary / 7) / hours;

            return payment;
        }
    }
}
