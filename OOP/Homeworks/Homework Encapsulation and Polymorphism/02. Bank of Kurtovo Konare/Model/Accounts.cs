using System;
using _02.Bank_of_Kurtovo_Konare.Interfaces;

namespace _02.Bank_of_Kurtovo_Konare.Model
{
    public abstract class Accounts : IDeposit, IInterest
    {
        private Customers customer;
        private decimal balance;
        private decimal interestRate;

        protected Accounts(Customers customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            decimal InterestRate = interestRate;
        }

        public decimal InterestRate
        {
            get { return this.interestRate; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The interest rate should be positive.");
                }
                this.interestRate = value;
            }
        }
        public decimal Balance
        {
            get { return this.balance; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The account balance cannot hold the negative amount.");
                }
                this.balance = value;
            }
        }

        public Customers Customer
        {
            get { return this.customer; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The customer cannot be null.");
                }
                this.customer = value;
            }
        }

        public abstract decimal CalculateInterest(int months);

        public virtual void DepositMoney(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("The withdraw money should be greater than zero.");
            }
            this.balance += amount;
        }
    }
}
