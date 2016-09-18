using System;

namespace Empires.Models
{
    using Enums;
    using Interfaces;
    using EventArgs;
    using EventHandlers;

    public abstract class Building : IBuilding
    {
        private const int ProductionDelay = 1;

        private int ciclesCount = 0;

        private readonly string unitType;
        private int unitCicleLength;
        private readonly ResourceType resourceType;
        private int resourceCicleLength;
        private int resourceQuantity;
        private readonly IUnitFactory unitFactory;
        private readonly IResourceFactory resourceFactory;

        protected Building(
            string unitType, 
            int unitCicleLength, 
            ResourceType resourceType, 
            int resourceCicleLenght,
            int resourceQuantity,
            IUnitFactory unitFactory,
            IResourceFactory resourceFactory)
        {
            this.unitType = unitType;
            this.UnitCicleLength = unitCicleLength;
            this.resourceType = resourceType;
            this.ResourceCicleLength = resourceCicleLenght;
            this.ResourceQuantity = resourceQuantity;
            this.unitFactory = unitFactory;
            this.resourceFactory = resourceFactory;
        }

        private bool CanProduceResource
        {
            get
            {
                bool canProduceResource = (this.ciclesCount > ProductionDelay) &&
                                          ((this.ciclesCount - ProductionDelay)%this.resourceCicleLength == 0);
                return canProduceResource;
            }
        }

        private bool CanProduceUnit
        {
            get
            {
                bool canProduceUnit = (this.ciclesCount > ProductionDelay) &&
                                      ((this.ciclesCount - ProductionDelay)%this.unitCicleLength == 0);
                return canProduceUnit;
            }
        }
        public int ResourceQuantity
        {
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "resource quantity",
                        "The quantity of produced resources should be non-negative.");
                }
                this.resourceQuantity = value;
            }
        }

        public int ResourceCicleLength
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "resource cicle length",
                        "The production cycles of buildings should be positive.");
                }
                this.resourceCicleLength = value;
            }
        }

        public int UnitCicleLength
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "unit cicle length",
                        "The production cycles of buildings should be positive.");
                }
                this.unitCicleLength = value;
            }
        }


        public virtual void Update()
        {
            this.ciclesCount++;
            if (this.CanProduceResource && this.OnResourceProduced != null)
            {
                var resource = this.resourceFactory.CreateResource(this.resourceType, this.resourceQuantity);
                this.OnResourceProduced(this, new ResourceProducedEventArgs(resource));
            }
            if (this.CanProduceUnit && this.OnUnitProduced != null)
            {
                var unit = this.unitFactory.CreateUnit(this.unitType);
                this.OnUnitProduced(this, new UnitProducedEventArgs(unit));
            }
        }

        public override string ToString()
        {
            int turnsUntilUnit = this.unitCicleLength - (this.ciclesCount - ProductionDelay)%this.unitCicleLength;
            int turnsUntilResource = this.resourceCicleLength -
                                     (this.ciclesCount - ProductionDelay)%resourceCicleLength;
            var result = string.Format(
                "--{0}: {1} turns ({2} turns until {3}, {4} turns until {5})",
                this.GetType().Name,
                this.ciclesCount - ProductionDelay,
                turnsUntilUnit,
                this.unitType,
                turnsUntilResource,
                this.resourceType
                );

            return result;
        }

        public event UnitProducedEventHandler OnUnitProduced;
        public event ResourceProducedEventHandler OnResourceProduced;
    }
}

