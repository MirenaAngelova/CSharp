namespace Bangalore_University_Learning_System.Core.Interfaces
{
    public interface IView
    {
        object Model { get; }

        string Display();
    }
}