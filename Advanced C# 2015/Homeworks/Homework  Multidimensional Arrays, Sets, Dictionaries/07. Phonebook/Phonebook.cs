using System;
using System.Collections.Generic;

class Phonebook
{
    static void Main()
    {
        //Write a program that receives some info from the console about people and their phone numbers.
        //You are free to choose the manner in which the data is entered; each entry should have just one name 
        //and one number (both of them strings). 
        //After filling this simple phonebook, upon receiving the command "search", your program should be able to perform 
        //a search of a contact by name and print her details in format "{name} -> {number}". In case the contact 
        //isn't found, print "Contact {name} does not exist." Examples:
        //Input	                Output
        //Nakov-0888080808      Contact Mariika does not exist.
        //search                Nakov -> 0888080808
        //Mariika
        //Nakov	
        //Nakov-+359888001122   Simo -> 02/987665544
        //RoYaL(Ivan)-666       Contact simo does not exist.
        //Gero-5559393          Contact RoYaL does not exist.
        //Simo-02/987665544     RoYaL(Ivan) -> 666
        //search
        //Simo
        //simo
        //RoYaL
        //RoYaL(Ivan)	
        //* Bonus: What happens if the user enters the same name twice in the phonebook? Modify your program to keep
        //multiple phone numbers per contact.

        Dictionary<string, List<string>> phonebook = new Dictionary<string, List<string>>();

        while (true)
        {
            string input = Console.ReadLine();
            string[] contact;
            if (input != "search")
            {
                contact = input.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                string name = contact[0];
                string phone = contact[1];
                if (!phonebook.ContainsKey(name))
                {
                    List<string> phoneNumbers = new List<string>();
                    phoneNumbers.Add(phone);

                    phonebook.Add(name, phoneNumbers);
                }
                else
                {
                    if (!phonebook[name].Contains(phone))
                    {
                        phonebook[name].Add(phone);
                    }
                }
            }
            else
            {
                break;
            }
        }

        while (true)
        {
            string contactName = Console.ReadLine();
            if (phonebook.ContainsKey(contactName))
            {
                Console.WriteLine("{0} -> {1}", contactName, string.Join(", ", phonebook[contactName]));
            }
            else
            {
                Console.WriteLine("Contact {0} does not exist.", contactName);
            }
        }
    }
}