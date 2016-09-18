using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Interfaces;
using Empires.Models.Enum;
using Empires.Models.EventArgs;
using Empires.Models.EventHandlers;

namespace Empires.Models.Buildings
{
    public abstract class Building : IBuilding
    {
        private const int DelayCreation = 1;

        private int turnsCount = 0;

        private readonly string typeUnit;
        private int unitTurns;
        private TypeResource typeResource;
        private int resourceTurns;
        private int quantity;
        private readonly IUnitFactory unitFactory;
        private readonly IResourceFactory resourceFactory;

        protected Building(
            string typeUnit, 
            int unitTurns, 
            TypeResource typeResource, 
            int resourceTurns, 
            int quantity, 
            IUnitFactory unitFactory, 
            IResourceFactory resourceFactory)
        {
            this.typeUnit = typeUnit;
            this.unitTurns = unitTurns;
            this.typeResource = typeResource;
            this.resourceTurns = resourceTurns;
            this.quantity = quantity;
            this.unitFactory = unitFactory;
            this.resourceFactory = resourceFactory;
        }

        private bool CanProduceUnit
        {
            get
            {
                bool canProduceUnit = this.turnsCount > DelayCreation && 
                    (turnsCount - DelayCreation) % this.unitTurns == 0;
                return canProduceUnit;
            }
        }

        private bool CanProduceResource
        {
            get
            {
                bool canProduceResource = this.turnsCount > DelayCreation &&
                                          (this.turnsCount - DelayCreation)%this.resourceTurns == 0;
                return canProduceResource;
            }
        }

        public int UnitTurns
        {
             set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(nameof(value),
                        "The unit's turns should be positive.");
                }

                this.unitTurns = value;
            }
        }

        public int ResourceTurns
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(nameof(value),
                        "The resource's turns should be positive.");
                }

                this.resourceTurns = value;
            }
        }

        public int Quantity
        {
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(nameof(value),
                        "The quantity of produced resources should be non-negative.");

                }
                this.quantity = value;
            }
        }

        public virtual void Update()
        {
            turnsCount++;
            if (this.CanProduceResource && this.OnResourceProduced != null)
            {
                var resource = resourceFactory.CreateResource(this.typeResource, this.quantity);
                this.OnResourceProduced(this, new ResourceProducedEventArgs(resource));
            }

            if (this.CanProduceUnit && this.OnUnitProduced != null)
            {
                var unit = unitFactory.CreateUnit(this.typeUnit);
                this.OnUnitProduced(this, new UnitProducedEventArgs(unit));
            }
        }

        public override string ToString()
        {
            int turnsUntilUnit = this.unitTurns - (this.turnsCount - DelayCreation) % this.unitTurns;
            int turnsUntilResource = 
                this.resourceTurns - (this.turnsCount - DelayCreation) % this.resourceTurns;

            var exit =
                $"--{this.GetType().Name}: " +
                $"{this.turnsCount - DelayCreation} turns ({turnsUntilUnit} turns until {this.typeUnit}," +
                $" {turnsUntilResource} turns until {this.typeResource})";
            return exit;
        }

        public event UnitProducedEventHandler OnUnitProduced;

        public event ResourceProducedEventHandler OnResourceProduced;
    }
}
