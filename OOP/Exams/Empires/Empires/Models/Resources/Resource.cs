using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Empires.Interfaces;
using Empires.Models.Enum;

namespace Empires.Models.Resources
{
    public class Resource : IResource
    {
        private int quantity;

        public Resource(TypeResource typeResource, int quantity)
        {
            this.TypeResource = typeResource;
            this.Quantity = quantity;
        }
        public TypeResource TypeResource { get; private set; }

        public int Quantity
        {
            get
            {
                return this.quantity;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                        "The quantity of produced resources should be non-negative.");
                }

                this.quantity = value;
            }
        }
    }
}
