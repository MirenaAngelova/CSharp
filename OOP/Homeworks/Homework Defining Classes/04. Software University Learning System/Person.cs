using System;
using System.Text.RegularExpressions;

namespace _04.Software_University_Learning_System
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private string p1;
        private string p2;
        private int p3;

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (validateName(value))
                {
                    this.firstName = value;
                }
            }
        }
        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (validateName(value))
                {
                    this.lastName = value;
                }
            }
        }
        public int Age
        {
            get { return this.age; }
            set
            {
                if (validAge(value))
                {
                    this.age = value;
                }
            }
        }

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        bool validateName(string name)
        {
            if (Regex.IsMatch(name, "[A-Z]{1}[a-z]+"))
            {
                return true;
            }
            else
            {
                throw new ArgumentException("Invalid name!");
            }
        }

        bool validAge(int age)
        {
            if (age >= 0 && age < 100)
            {
                return true;
            }
            else
            {
                throw new ArgumentException("Invalid age!");
            }
        }


    }
}
