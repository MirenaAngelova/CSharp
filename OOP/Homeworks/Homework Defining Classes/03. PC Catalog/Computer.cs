using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;


class Computer
{
    private string name;
    private Component[] components = new Component[0];

    public decimal Price
    {
        get { return this.components.Sum(component => component.Price); }
    }

    public string Name
    {
        get { return this.name; }
        private set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Name cannot be empty!");
            }
            this.name = value;
        }
    }

    public Component[] Components
    {
        get { return this.components; }
        private set
        {
            if (value.Any(a => value.Any(b => a.Name == b.Name && a != b)))
            {
               throw new ArgumentException("Components cannot have duplicates!");
            }
            this.components = value;
        }
    }

    public Computer(string name, params Component[] components)
    {
        this.Name = name;
        this.Components = components;
    }

    public override string ToString()
    {
        StringBuilder computerToString = new StringBuilder();
        computerToString.AppendLine(new string('=', this.Name.Length + 1));
        computerToString.AppendLine(string.Format("{0}:", this.Name));
        computerToString.Append(new string('=', this.Name.Length + 1));
        foreach (var component in Components)
        {
            if (component.Name != null)
            {
                computerToString.Append(string.Format("\n{0}", component.Name));
                computerToString.Append(string.Format("{0}{1}", 
                    component.Details != null ? string.Format("\n\tDetails: {0}", component.Details) : "",
                    string.Format("\n\tPrice: {0}", 
                    component.Price.ToString("C2", CultureInfo.CreateSpecificCulture("bg-BG")))));
            }
        }
        string totalPrice = string.Format("Total Price: {0}",
            this.Price.ToString("C2", CultureInfo.CreateSpecificCulture("bg-BG")));
        computerToString.AppendLine();
        computerToString.AppendLine(new string('-', totalPrice.Length));
        computerToString.AppendLine(totalPrice);
        computerToString.AppendLine(new string('=', 74));
        return computerToString.ToString();
    }
}


