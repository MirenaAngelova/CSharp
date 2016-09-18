using System.Collections.Generic;
using Air_Conditioner_Testing_System.Constants;
using Air_Conditioner_Testing_System.Exceptions;
using Air_Conditioner_Testing_System.Interfaces;
using Air_Conditioner_Testing_System.Models;

namespace Air_Conditioner_Testing_System.Databases
{
    public class Repository<T> : IRepository<T> where T : IManufacturer, IModel
    {
        public Repository()
        {
            this.ItemsByManufacturerAndModel = new Dictionary<string, T>();
        }
        public int Count { get; protected set; }

        protected Dictionary<string, T> ItemsByManufacturerAndModel { get; set; }

        public virtual void Add(T item)
        {
            string manufacturerAndModel = item.Manufacturer + item.Model;
            if (this.ItemsByManufacturerAndModel.ContainsKey(manufacturerAndModel))
            {
                throw new DuplicateEntryException(Constant.DuplicateEntry);
            }

            this.ItemsByManufacturerAndModel.Add(manufacturerAndModel, item);
            this.Count++;
        }

        public T GetItem(string manufacturer, string model)
        {
            if (!this.ItemsByManufacturerAndModel.ContainsKey(manufacturer + model))
            {
                throw new NonExistantEntryException(Constant.NonExistEntry);
            }

            return this.ItemsByManufacturerAndModel[manufacturer + model];
        }
    }
}