using System;

namespace Empires.Models
{
    using Enums;
    using Interfaces;
    public class Resource:IResource
    {
        private int quantity;

        public Resource(ResourceType resourceType, int quantity)
        {
            this.ResourceType = resourceType;
            this.Quantity = quantity;
        }
        public ResourceType ResourceType { get; private set; }

        public int Quantity
        {
            get
            {
                return this.quantity;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        "quantity",
                        "The quantity of produced resources should be non-negative.");
                }
                this.quantity = value;
            }
        }
    }
}
