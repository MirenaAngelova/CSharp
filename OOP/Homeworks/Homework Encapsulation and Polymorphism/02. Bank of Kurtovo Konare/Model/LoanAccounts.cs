
namespace _02.Bank_of_Kurtovo_Konare.Model
{
    public class LoanAccounts : Accounts
    {
        private const int GratisPeriodIndividual = 3;
        private const int GratisPeriodCompanies = 2;
        public LoanAccounts(Customers customers, decimal balance, decimal interestRate)
            :base(customers, balance, interestRate)
        {   
        }

        public override decimal CalculateInterest(int months)
        {
            decimal interest = 0;
            if (this.Customer is IndividualCustomers && months > GratisPeriodIndividual)
            {
                interest = this.Balance*(1 + (this.InterestRate/100)*(months - GratisPeriodIndividual));
            }
            else if (this.Customer is CompanyCustomers && months > GratisPeriodCompanies)
            {
                interest = this.Balance*(1 + (this.InterestRate/100)*(months - GratisPeriodCompanies));
            }
            return interest;
        }
    }
}
