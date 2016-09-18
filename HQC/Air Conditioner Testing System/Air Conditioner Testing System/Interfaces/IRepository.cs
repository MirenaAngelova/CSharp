using Air_Conditioner_Testing_System.Models;

namespace Air_Conditioner_Testing_System.Interfaces
{
    public interface IRepository<T> where T : IManufacturer, IModel
    {
        int Count { get; }

        void Add(T item);

        T GetItem(string manufacturer, string model);
    }
}