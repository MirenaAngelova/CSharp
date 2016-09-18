using Air_Conditioner_Testing_System6.Enums;

namespace Air_Conditioner_Testing_System6.Interfaces
{
    public interface IReport : IManufacturer, IModel
    {
         Mark Mark { get; }
    }
}