using System;
using System.CodeDom;
using System.Collections.Generic;

namespace FootballLeague
{
    public class Players
    {
        private const int MinDateOfBirth = 1980;
        private string firstName;
        private string lastName;
        private decimal salary;
        private DateTime dateOfBirth;
        private Teams team;

        public Players(string firstName, string lastName, decimal salary, DateTime dateOfBirth, Teams team)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = salary;
            this.DateOfBirth = dateOfBirth;
            this.Team = team;
        }

        public Teams Team
        {
            get { return this.team; }
            set { this.team = value; }
        }

        public DateTime DateOfBirth
        {
            get { return this.dateOfBirth; }
            set
            {
                if (value.Year < MinDateOfBirth)
                {
                    throw new ArgumentException("The player's date of birth cannot be earlier than " + MinDateOfBirth);
                }
                this.dateOfBirth = value;
            }
        }

        public decimal Salary
        {
            get { return this.salary; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The salary cannot be negative number.");
                }
                this.salary = value;
            }
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentOutOfRangeException("The first name should be at least 3 chars long.");
                }
                this.firstName = value;
            }
        }
        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentOutOfRangeException("The last name should be at least 3 chars long.");
                }
                this.lastName = value;
            }
        }
    }
}
