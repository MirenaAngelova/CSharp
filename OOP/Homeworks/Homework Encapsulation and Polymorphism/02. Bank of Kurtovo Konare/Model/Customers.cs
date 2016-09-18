using System;

namespace _02.Bank_of_Kurtovo_Konare.Model
{
    public abstract class Customers
    {
        private string name;
        private long customerID;

        protected Customers(string name, long customerID)
        {
            this.Name = name;
            this.CustomerID = customerID;
        }

        public long CustomerID
        {
            get { return this.customerID; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("ID should be positive.");
                }
                this.customerID = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The name cannot be empty.");
                }
                this.name = value;
            }
        }
    }
}
