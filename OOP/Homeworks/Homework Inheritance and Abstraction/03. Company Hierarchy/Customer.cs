using System;
using System.Text;

namespace _03.Company_Hierarchy
{
    class Customer : Person, ICustomer
    {
        private decimal spentMoney;

        public Customer(string firstName, string lastname, int id, decimal spentMoney)
            :
            base(firstName, lastname, id)
        {
        }

        public decimal SpentMoney {
            get { return this.spentMoney; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("spentMoney", "Spent money cannot be negative number.");
                }
                this.spentMoney = value;
            }
        }

        public override string ToString()
        {
            StringBuilder exit = new StringBuilder();
            exit.Append(base.ToString());
            exit.Append(string.Format("Total amount of money the customer has spent: {0:C2}", this.SpentMoney));
            return exit.ToString();
        }
    }
}
