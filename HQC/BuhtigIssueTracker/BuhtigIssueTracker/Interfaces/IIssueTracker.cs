namespace BuhtigIssueTracker.Interfaces
{
    public interface IIssueTracker
    {
        string RegisterUser(string userName, string password, string confirmPassword); // TODO: Dokumentieren Sie diese Methode

        string LoginUser(string userName, string password); // TODO: Dokumentieren Sie diese Methode

        string LogoutUser(); // TODO: Dokumentieren Sie diese Methode

        string CreateIssue(string title, string description, IssuePriority priority, string[] tags); // TODO: Dokumentieren Sie diese Methode

        string RemoveIssue(int issueId); // TODO: Dokumentieren Sie diese Methode

        string AddComments(int issueId, string text); // TODO: Dokumentieren Sie diese Methode

        string GetMyIssues(); // TODO: Dokumentieren Sie diese Methode

        string GetMyComments(); // TODO: Dokumentieren Sie diese Methode

        string SearchForIssues(string[] issues); // TODO: Dokumentieren Sie diese Methode
    }
}