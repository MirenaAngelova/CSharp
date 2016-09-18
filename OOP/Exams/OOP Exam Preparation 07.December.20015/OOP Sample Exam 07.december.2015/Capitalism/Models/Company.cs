using System;
using System.Collections.Generic;
using Capitalism.Models.Interfaces;

namespace Capitalism.Models
{
    public class Company : ICompanyStructure
    {
        private CEO ceo;
        private string name;

        public Company(string name, CEO ceo)
        {
            this.Name = name;
            this.CEO  = ceo;
            this.Employee = new List<IEmployee>();
            this.Department = new List<Department>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name", "The name cannot be empty.");
                }
                this.name = value;
            }
        }

        public CEO CEO
        {
            get { return this.ceo; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("CEO", "The company must have CEO.");
                }
                this.ceo = value;
            }
        }

        public ICollection<IEmployee> Employee { get; set; }
        public ICollection<Department> Department { get; set; }
    }
}
