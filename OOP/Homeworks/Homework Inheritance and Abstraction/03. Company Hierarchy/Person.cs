using System;
using System.Text;

namespace _03.Company_Hierarchy
{
     abstract class Person : IPerson
     {
         private int id;
         private string firstName;
         private string lastName;

         public Person(string firstName, string lastName, int id)
         {
             this.FirstName = firstName;
             this.LastName = lastName;
             this.ID = id;
         }

         public int ID {
             get { return this.id; }
             set
             {
                 if (value < 0)
                 {
                     throw new ArgumentOutOfRangeException("id", "ID cannot be a negative number");
                 }
                 this.id = value;
             }
         }

         public string FirstName {
             get { return this.firstName; }
             set
             {
                 if (string.IsNullOrEmpty(value))
                 {
                     throw new ArgumentNullException("firstName", "First name cannot be empty.");
                 }
                 this.firstName = value;
             }
         }
         public string LastName
         {
             get { return this.lastName; }
             set
             {
                 if (string.IsNullOrEmpty(value))
                 {
                     throw new ArgumentNullException("lastName", "Last name cannot be empty.");
                 }
                 this.lastName = value;
             }
         }

         public override string ToString()
         {
             StringBuilder exit = new StringBuilder();
             exit.Append(string.Format("ID: {0}{3}Name: {1} {2}{3}",
                 this.ID, this.FirstName, this.LastName, Environment.NewLine));
             return exit.ToString();
         }
     }
}
