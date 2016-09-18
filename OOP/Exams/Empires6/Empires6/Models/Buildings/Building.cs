using System;
using System.Text;
using Empires6.Constants;
using Empires6.Enums;
using Empires6.Interfaces;
using Empires6.Models.EventArgs;
using Empires6.Models.EventHandlers;
using Empires6.Validations;

namespace Empires6.Models.Buildings
{
    public abstract class Building : IBuilding
    {
        private int turnsCount = 0;
        private string unitType;
        private int unitTurns;
        private ResourceType resourceType;
        private int quantity;
        private int resourceTurns;
        private IUnitFactory unitFactory;
        private IResourceFactory resourceFactory;

        protected Building(
            string unitType,
            int unitTurns,
            ResourceType resourceType,
            int quantity,
            int resourceTurns,
            IUnitFactory unitFactory,
            IResourceFactory resourceFactory)
        {
            this.unitType = unitType;
            this.unitTurns = unitTurns;
            this.resourceType = resourceType;
            this.quantity = quantity;
            this.resourceTurns = resourceTurns;
            this.unitFactory = unitFactory;
            this.resourceFactory = resourceFactory;
        }

        public bool CanProduceUnit()
        {
            bool canProduceUnit = this.turnsCount > Constant.CreationDelay
                                  && (this.turnsCount - Constant.CreationDelay) % this.unitTurns == 0;
            //if (!canProduceUnit && this.OnUnitProduced != null)
            //{
            //    throw new ArgumentException(string.Format(Constant.BeforeTurns,
            //        this.turnsCount - Constant.CreationDelay,
            //        this.GetType().Name,
            //        this.unitType,
            //        this.unitTurns));
            //}
            return canProduceUnit;
        }


        public bool CanProduceResource()
        {
            bool canProduceResource = this.turnsCount > Constant.CreationDelay
                                      && (this.turnsCount - Constant.CreationDelay)%this.resourceTurns == 0;
            //if (this.OnResourceProduced != null && !canProduceResource)
            //{
            //    //2 turns have passed, barracks cannot produce steel yet - 3 turns must pass
            //    throw new ArgumentException(string.Format(Constant.BeforeTurns,
            //          this.turnsCount - Constant.CreationDelay,
            //          this.GetType().Name,
            //          this.resourceType,
            //          this.resourceTurns));
            //}       

            return canProduceResource;
        }

        public int UnitTurns
        {
            set
            {
                Validator.ValidatePropertyTurns(value, "unit");
                this.unitTurns = value;
            }
        }

        public int ResourceTurns
        {
            set
            {
                Validator.ValidatePropertyTurns(value, "resource");
                this.resourceTurns = value;
            }
        }


        public void Update()
        {
            this.turnsCount++;
            if (this.CanProduceUnit() && this.OnUnitProduced != null)
            {
                IUnit unit = this.unitFactory.CreateUnit(this.unitType);
                this.OnUnitProduced(this, new UnitProducedEventArgs(unit));
            }

            if (this.CanProduceResource() && this.OnResourceProduced != null)
            {
                IResource resource = this.resourceFactory.CreateResource(this.resourceType, this.quantity);
                this.OnResourceProduced(this, new ResourceProducedEventArgs(resource));
            }
        }

        public override string ToString()
        {
            int untilUnit = this.unitTurns - (this.turnsCount - Constant.CreationDelay) % this.unitTurns;
            int untilResource =
                this.resourceTurns - (this.turnsCount - Constant.CreationDelay) % this.resourceTurns;
            StringBuilder exit = new StringBuilder();
            exit.AppendFormat(
                $"--{this.GetType().Name}: {this.turnsCount - Constant.CreationDelay} turns " +
                $"({untilUnit} turns until {this.unitType}, {untilResource} " +
                $"turns until {this.resourceType})");

            return exit.ToString();
        }

        public event UnitProducedEventHandler OnUnitProduced;

        public event ResourceProducedEventHandler OnResourceProduced;
    }
}