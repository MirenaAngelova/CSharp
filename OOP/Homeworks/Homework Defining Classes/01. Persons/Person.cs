using System;
using System.Text.RegularExpressions;

class Person
{
    private string name;
    private int age;
    private string email;

    public string Name
    {
        get { return this.name; }
        set
        {
            if (value == null || value.Trim() == "")
            {
                throw new ArgumentNullException("Name is mandatory!");
            }
            this.name = value;
        }
    }

    public int Age
    {
        get { return this.age; }
        set
        {
            if (value < 1 || value > 100)
            {
                throw new ArgumentOutOfRangeException("Age should be in the range [1...100]");
            }
            this.age = value;
        }
    }

    public string Email
    {
        get { return this.email; }
        set
        {
            if (value == null || Regex.IsMatch(value, ".*?@.*"))
            {
                this.email = value;
            }
            else
            {
                throw new FormatException("Invalid email! The email must containing \'@\'");
            }
        }
    }

    public  Person (string name, int age) : this(name, age, null)
    {
    }

    public Person(string name, int age, string email)
    {
        this.Name = name;
        this.Age = age;
        this.Email = email;
    }

    public override string ToString()
    {
        if (this.email == null)
        {
            return string.Format("Name: {0}, Age: {1}, Email: unemailed person ", this.Name, this.Age);
        }
        return string.Format("Name: {0}, Age: {1}, Email: {2};", this.Name, this.Age, this.Email);
    }
}

