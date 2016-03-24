using System;
class PrintCompanyInformation
{
    static void Main()
    {
        //A company has name, address, phone number, fax number, web site and manager. 
        //The manager has first name, last name, age and a phone number. Write a program that reads 
        //the information about a company and its manager and prints it back on the console.
        //program	                   user
        //Company name:	               Software University
        //Company address:	           15-18 Tintyava, Sofia
        //Phone number:	               +359 899 55 55 92
        //Fax number:	
        //Web site:	                   http://softuni.bg
        //Manager first name:	       Svetlin
        //Manager last name:	       Nakov
        //Manager age:	               25
        //Manager phone:	           +359 2 981 981
        //Software University
        //Address: 26 V. Kanchev, Sofia
        //Tel. +359 899 55 55 92
        //Fax: (no fax)
        //Web site: http://softuni.bg
        //Manager: Svetlin Nakov (age: 25, tel. +359 2 981 981)	

        Console.WriteLine("Enter company name: ");
        string companyName = Console.ReadLine();
        Console.WriteLine("Enter company address: ");
        string companyAddress = Console.ReadLine();
        Console.WriteLine("Enter phone number: ");
        string phoneNumber = Console.ReadLine();
        Console.WriteLine("Enter fax number: ");
        string faxNumber = Console.ReadLine();
        if (faxNumber == string.Empty)
        {
            faxNumber = "(no fax)";
        }
        Console.WriteLine("Enter web site: ");
        string webSite = Console.ReadLine();
        Console.WriteLine("Enter manager first name: ");
        string firstName = Console.ReadLine();
        Console.WriteLine("Enter manager last name: ");
        string lastName = Console.ReadLine();
        Console.WriteLine("Enter manager age: ");
        string age = Console.ReadLine();
        Console.WriteLine("Enter manager phone: ");
        string phone = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("{0}", companyName);
        Console.WriteLine("Address: {0}", companyAddress);
        Console.WriteLine("Tel. {0}", phoneNumber);
        Console.WriteLine("Fax: {0}", faxNumber);
        Console.WriteLine("Web site: {0}", webSite);
        Console.WriteLine("Manager: {0} {1} (age: \n{2}, tel. {3})", firstName, lastName, age, phone);
        Console.WriteLine();
    }
}

