using Empires6.Enums;
using Empires6.Interfaces;
using Empires6.Validations;

namespace Empires6.Models
{
    public class Resource : IResource
    {
        private int quantity;

        public Resource(ResourceType resourceType, int quantity)
        {
            this.ResourceType = resourceType;
            this.Quantity = quantity;
        }

        public ResourceType ResourceType { get; set; }

        public int Quantity
        {
            get
            {
                return this.quantity;
                
            }

            private set
            {
                Validator.ValidatePropertyQuantity(value);
                this.quantity = value;
            }
        }
    }
}