using System.Collections.Generic;
using Air_Conditioner_Testing_System6.Constants;
using Air_Conditioner_Testing_System6.Exceptions;
using Air_Conditioner_Testing_System6.Interfaces;

namespace Air_Conditioner_Testing_System6.Databases
{
    public class Repository<T> : IRepository<T> where T : IManufacturer, IModel
    {
        public Repository()
        {
            this.ItemsByManufacturingAndModel = new Dictionary<string, T>();
        }

        protected Dictionary<string, T> ItemsByManufacturingAndModel { get; } 

        public int Count { get; private set; }

        public virtual void Add(T item)
        {
            string manufacturerAndModel = item.Manufacturer + item.Model;
            if (this.ItemsByManufacturingAndModel.ContainsKey(manufacturerAndModel))
            {
               throw new DuplicateEntryException(Constant.DuplicateEntry);
            }

            this.ItemsByManufacturingAndModel.Add(manufacturerAndModel, item);
            this.Count++;
        }

        public virtual T GetItem(string manufacturer, string model)
        {
            if (!this.ItemsByManufacturingAndModel.ContainsKey(manufacturer + model))
            {
                throw new NonExistantEntryException(Constant.NonExist);
            }

            T item = this.ItemsByManufacturingAndModel[manufacturer + model];

            return item;
        }
    }
}