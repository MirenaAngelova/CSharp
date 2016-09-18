using System;
using _02.Bank_of_Kurtovo_Konare.Model;

namespace _02.Bank_of_Kurtovo_Konare
{
    class BankOfKurtovoKonare
    {
        static void Main()
        {
            Customers ind1 = new IndividualCustomers("Angel Angelov", 1234567891234);
            Customers ind2 = new IndividualCustomers("Boris Borisov", 123456789123);
            Customers ind3 = new IndividualCustomers("Georgi Georgiev", 12345678912);
            Customers comp1 = new CompanyCustomers("SoftUni", 123456789);
            Customers comp2 = new CompanyCustomers("TU", 12345678);

            DepositAccounts acc1 = new DepositAccounts(ind1, 350.20M, 0.05M);
            Accounts acc2 = new LoanAccounts(ind2, 1230, 0.25M);
            Accounts acc3 = new LoanAccounts(comp1, 20000, 0.20M);
            Accounts acc4 = new MortgageAccounts(ind3, 35000, 0.15M);
            Accounts acc5 = new MortgageAccounts(comp2, 33000, 0.12M);

            Console.WriteLine(acc1.CalculateInterest(6));
            acc1.DepositMoney(350.55M);
            acc1.WithdrawMoney(420);
            Console.WriteLine(acc1.CalculateInterest(16));

            Console.WriteLine(acc2.CalculateInterest(18));
            Console.WriteLine(acc3.CalculateInterest(13));
            Console.WriteLine(acc4.CalculateInterest(5));
            Console.WriteLine(acc5.CalculateInterest(11));

        }
    }
}