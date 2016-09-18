namespace BuhtigIssueTracker2.Infrastructure
{
    using Interfaces;
    using Stuff;

    public class Dispatcher
    {
        public Dispatcher(IssueTracker tracker)
        {
            this.Tracker = tracker;
        }

        public Dispatcher() : this(new IssueTracker())
        {
        }

        IIssueTracker Tracker { get; set; }

        public string DispatchAction(IEndpoint endpoint)
        {
            switch (endpoint.ActionName)
            {
                case "RegisterUser":
                    return this.Tracker.RegisterUser(endpoint.Parameters["username"], endpoint.Parameters["password"], endpoint.Parameters["confirmPassword"]);
                case "LoginUser":
                    return this.Tracker.LoginUser(endpoint.Parameters["username"], endpoint.Parameters["password"]);
                case "LogoutUser":
                    return this.Tracker.LogoutUser();
                case "CreateIssue":
                    return this.Tracker.CreateIssue(endpoint.Parameters["title"], endpoint.Parameters["description"],
                        (PriorityIssue)System.Enum.Parse(typeof(PriorityIssue), endpoint.Parameters["priority"], true),
                        endpoint.Parameters["tags"].Split('|'));// BUG: Tags should be split by | not /
                case "RemoveIssue":
                    return this.Tracker.RemoveIssue(int.Parse(endpoint.Parameters["id"]));
                case "AddComment":
                    // BUG: Refactor Id to id
                    return this.Tracker.AddComment(
                        int.Parse(endpoint.Parameters["id"]),
                        endpoint.Parameters["text"]);
                case "MyIssues":
                    return this.Tracker.GetMyIssues();
                case "MyComments":
                    return this.Tracker.GetMyComments();
                case "Search":
                    return this.Tracker.SearchForIssues(endpoint.Parameters["tags"].Split('|'));
                default:
                    return $"Invalid action: {endpoint.ActionName}";
            }
        }
    }
}