using System.Collections.Generic;
using Wintellect.PowerCollections;
namespace BuhtigIssueTracker.Interfaces
{
    public interface IBuhtigIssueTrackerData
    {
        User CurrentlyLoggedUser { get; set; }

        IDictionary<string, User> UsersDictionary { get; }

        OrderedDictionary<int, Problem> IssuesFirst { get; }

        MultiDictionary<string, Problem> IssuesSecond { get; }

        MultiDictionary<string, Problem> IssuesThird { get; }

        MultiDictionary<string, Problem> IssuesForth { get; }

        MultiDictionary<User, Comment> UserCommentDictionary { get; }

        void AddIssue(Problem problem);

        void RemoveIssue(Problem problem);
    }
}