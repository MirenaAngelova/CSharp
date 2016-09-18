namespace Air_Conditioner_Testing_System6.Interfaces
{
    public interface ICommand
    {
        string Name { get; }

        string[] Parameters { get; }
    }
}