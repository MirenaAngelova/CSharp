namespace Air_Conditioner_Testing_System.Interfaces
{
    public interface ICommand
    {
        string Name { get; set; }

        string[] Parameters { get; set; }
    }
}