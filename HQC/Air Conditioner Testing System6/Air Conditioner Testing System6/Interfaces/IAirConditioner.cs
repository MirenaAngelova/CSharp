namespace Air_Conditioner_Testing_System6.Interfaces
{
    public interface IAirConditioner : IManufacturer, IModel
    {
        bool Test();
    }
}