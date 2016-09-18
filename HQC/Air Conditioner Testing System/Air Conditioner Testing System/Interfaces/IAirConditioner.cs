using Air_Conditioner_Testing_System.Models;

namespace Air_Conditioner_Testing_System.Interfaces
{
    public interface IAirConditioner : IManufacturer, IModel
    {
        bool Test();
    }
}