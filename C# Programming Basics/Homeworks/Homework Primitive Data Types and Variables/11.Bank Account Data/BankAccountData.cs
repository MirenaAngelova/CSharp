using System;

class BankAccountData
{
    static void Main()
    {
        //A bank account has a holder name (first name, middle name and last name), 
        //available amount of money (balance), bank name, IBAN, 
        //3 credit card numbers associated with the account. Declare the variables needed to keep 
        //the information for a single bank account using the appropriate data types and descriptive names.

        Console.WriteLine("Enter first name account: ");
        string firstName = Console.ReadLine();
        Console.WriteLine("Enter middle name account: ");
        string middleName = Console.ReadLine();
        Console.WriteLine("Enter last name account: ");
        string lastName = Console.ReadLine();
        Console.WriteLine("Enter balance account: ");
        int balanceAccount = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter bank name account: ");
        string bankName = Console.ReadLine();
        Console.WriteLine("Enter IBAN account: ");
        string iBAN = Console.ReadLine();
        Console.WriteLine("Enter number of first credit card account: ");
        string firstCreditCard = Console.ReadLine();
        Console.WriteLine("Enter number of second credit card account: ");
        string secondCreditCard = Console.ReadLine();
        Console.WriteLine("Enter number of third credit card account: ");
        string thirdCreditCard = Console.ReadLine();
        Console.WriteLine();

        Console.WriteLine("First name: {0} \nMiddle name: {1} \nLast name: {2} \nBalance: {3} \nBank name: {4}" +
                    "\nIBAN: {5} \nFirst credit card: {6} \nSecond credit card: {7} \nThird credit card: {8}",
                    firstName, middleName, lastName, balanceAccount, bankName, iBAN, firstCreditCard, secondCreditCard,
                    thirdCreditCard);
        Console.WriteLine();
    }
}

