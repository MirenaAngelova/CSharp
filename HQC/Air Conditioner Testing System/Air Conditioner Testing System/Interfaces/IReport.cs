using Air_Conditioner_Testing_System.Enums;
using Air_Conditioner_Testing_System.Models;

namespace Air_Conditioner_Testing_System.Interfaces
{
    public interface IReport : IManufacturer, IModel
    {
         Mark Mark { get; }
    }
}