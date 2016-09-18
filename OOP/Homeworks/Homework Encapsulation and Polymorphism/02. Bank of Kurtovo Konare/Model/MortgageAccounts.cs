using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Bank_of_Kurtovo_Konare.Model
{
    public class MortgageAccounts : Accounts
    {
        private const int GratisPeriodIndividuals = 6;
        private const int PromoPeriodCompanies = 12;
        private const decimal PromoInterestCompanies = 0.5M;

        public MortgageAccounts(Customers customers, decimal balance, decimal interestRate)
            :
            base(customers, balance, interestRate)
        {
        }

        public override decimal CalculateInterest(int months)
        {
            decimal interest = 0;
            if (this.Customer is IndividualCustomers && months > GratisPeriodIndividuals)
            {
                interest = this.Balance*(1 + (this.InterestRate/100)*(months - GratisPeriodIndividuals));
            }
            else if(this.Customer is CompanyCustomers && months <= PromoPeriodCompanies)
            {
                interest = this.Balance*(1 + (this.InterestRate/100)*PromoInterestCompanies*months);
            }
            else if (this.Customer is CompanyCustomers && months > PromoPeriodCompanies)
            {
                interest = this.Balance*(1 + (this.InterestRate/100)*PromoInterestCompanies*PromoPeriodCompanies) +
                           this.Balance*(1 + (this.InterestRate/100)*(months - PromoPeriodCompanies));
            }
            return interest;
        }
    }
}
