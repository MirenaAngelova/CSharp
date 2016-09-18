using System;
using System.Text;

namespace _03.Company_Hierarchy
{
    class Sale : ISale
    {
        private string productName;
        private decimal price;

        public Sale(string productName, DateTime dateOfSale, decimal price)
        {
            this.ProductName = productName;
            this.DateOfSale = dateOfSale;
            this.Price = price;
        }

        public Sale(string productName, decimal price) : this(productName, DateTime.Now, price)

        {
        }

        public string ProductName {
            get { return this.productName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("productName", "Product name cannot be empty.");
                }
                this.productName = value;
            }
        }

        public DateTime DateOfSale { get; set; }
        public decimal Price { get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("price", "Price cannot be negative number.");
                }
                this.price = value;
            } 
        }

        public override string ToString()
        {
            StringBuilder exit = new StringBuilder();
            exit.Append(string.Format("Product name: {0}{3}Date of sale: {1}{3}Price: {2}{3}",
                this.ProductName, this.DateOfSale, this.Price, Environment.NewLine));
            return exit.ToString();
        }
    }
}
