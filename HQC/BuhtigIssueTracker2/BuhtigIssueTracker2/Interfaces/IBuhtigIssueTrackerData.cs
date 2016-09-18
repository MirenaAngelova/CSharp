namespace BuhtigIssueTracker2.Interfaces
{
    using System.Collections.Generic;
    using Stuff;
    using Wintellect.PowerCollections;

    public interface IBuhtigIssueTrackerData
    {
        User CurrentUser { get; set; }

        IDictionary<string, User> Users { get; }

        //MultiDictionary<Issue, string> Issues { get; }

        OrderedDictionary<int, Issue> IssuesFirst { get; }

        MultiDictionary<string, Issue> IssuesSecond { get; }

        // BUG: IssuesThird added to inerface
        //MultiDictionary<string, Issue> IssuesThird { get; }

        MultiDictionary<string, Issue> IssuesForth { get; }

        MultiDictionary<User, Comment> UserComments { get; }

        // BUG: Comments added to inerface
        Dictionary<Comment, User> Comments { get; }

        void AddIssue(Issue issue);

        void RemoveIssue(Issue issue);
    }
}