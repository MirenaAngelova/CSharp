using System;
using _02.Bank_of_Kurtovo_Konare.Interfaces;

namespace _02.Bank_of_Kurtovo_Konare.Model
{
    public class DepositAccounts : Accounts, IWithdraw
    {
        private const int MinBalanceInterest = 1000;
        public DepositAccounts(Customers customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override decimal CalculateInterest(int months)
        {
            decimal interest = this.Balance*(1 + (this.InterestRate/100)*months);
            if (this.Balance <= MinBalanceInterest)
            {
                interest = 0;
            }
            return interest;
        }

        public void WithdrawMoney(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("The withdraw amount should be greater than zero.");
            }
            else if (amount > this.Balance)
            {
                throw new ArgumentNullException("The withdraw amount cannot exceed the current account balance.");
            }
            this.Balance -= amount;
        }
    }
}
