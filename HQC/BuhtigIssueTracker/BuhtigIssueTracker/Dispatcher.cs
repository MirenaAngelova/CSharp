////namespace Data
////{
//    using System.Linq;
//    using System.Globalization;
//    using System.Dynamic;
//    using System.Collections;
////}
namespace BuhtigIssueTracker
{
    using BuhtigIssueTracker.Interfaces;

    public class Dispatcher
    {
        private Dispatcher(IIssueTracker tracker)
        {
            this.Tracker = tracker;
        }

        public Dispatcher() : this(new MoreStuff())
        {
        }

        internal IIssueTracker Tracker { get; set; }

        public string DispatchAction(IEndpoint endpoint)
        {
            switch (endpoint.ActionName)
            {
                case "RegisterUser":
                    var registerTracker = this.Tracker.RegisterUser(
                                               endpoint.Parameters["username"],
                                               endpoint.Parameters["password"],
                                               endpoint.Parameters["confirmPassword"]);
                    return registerTracker;

                case "LoginUser":
                    var loginUser = this.Tracker.LoginUser(
                                         endpoint.Parameters["username"],
                                         endpoint.Parameters["password"]);
                    return loginUser;

                case "LogoutUser":
                    var logoutUser = this.Tracker.LogoutUser();
                    return logoutUser;

                case "CreateIssue":
                    var createIssue = this.Tracker.CreateIssue(
                                           endpoint.Parameters["title"],
                                           endpoint.Parameters["description"],
                                           (IssuePriority)System.Enum.Parse(typeof(IssuePriority),
                                           endpoint.Parameters["priority"], true),
                                           endpoint.Parameters["tags"].Split('/'));
                    return createIssue;

                case "RemoveIssue":
                    var removeIssue = this.Tracker.RemoveIssue(int.Parse(endpoint.Parameters["id"]));
                    return removeIssue;

                case "AddComment":
                    var addComment = this.Tracker.AddComments(
                                          int.Parse(endpoint.Parameters["id"]),
                                          endpoint.Parameters["text"]);
                    return addComment;

                case "MyIssues":
                    var myIssues = this.Tracker.GetMyIssues();
                    return myIssues;

                case "MyComments":
                    var myComments = this.Tracker.GetMyComments();
                    return myComments;

                case "Search":
                    var search = this.Tracker.SearchForIssues(endpoint.Parameters["tags"].Split('|'));
                    return search;

                default:
                    var invalidAction = string.Format("Invalid action: {0}", endpoint.ActionName);
                    return invalidAction;
            }
        }
    }
}