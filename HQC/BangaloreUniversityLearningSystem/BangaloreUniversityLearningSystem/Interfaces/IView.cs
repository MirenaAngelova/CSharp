namespace BangaloreUniversityLearningSystem.Interfaces
{
    public interface IView
    {
        // BUG:Refactor model to Model
        object Model { get; }

        string Display();
    }
}