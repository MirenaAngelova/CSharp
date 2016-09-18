namespace BuhtigIssueTracker2.Data
{
    using System.Collections.Generic;

    using Interfaces;
    using Stuff;
    using Wintellect.PowerCollections;

    public class BuhtigIssueTrackerData : IBuhtigIssueTrackerData
    {
        public int nextIssueId;
        private User currentUser;

        public BuhtigIssueTrackerData()
        {
            this.NextIssueId = 1;
            this.CurrentUser = this.currentUser;
            this.Users = new Dictionary<string, User>();

            //this.Issues = new MultiDictionary<Issue, string>(true);         
            this.IssuesFirst = new OrderedDictionary<int, Issue>();
            this.IssuesSecond = new MultiDictionary<string, Issue>(true);
            //this.IssuesThird = new MultiDictionary<string, Issue>(true);

            // Added IssuesForth in consrtuctor
            this.IssuesForth = new MultiDictionary<string, Issue>(true);
            this.UserComments = new MultiDictionary<User, Comment>(true);
            this.Comments = new Dictionary<Comment, User>();
        }

        public int NextIssueId { get; private set; }

        public User CurrentUser { get; set; }

        public IDictionary<string, User> Users { get; set; }

        // Remove reduntant dictionaries Issues And IssuesThird
       // public MultiDictionary<Issue, string> Issues { get; set; }

        public OrderedDictionary<int, Issue> IssuesFirst { get; set; }

        public MultiDictionary<string, Issue> IssuesSecond { get; set; }

        //public MultiDictionary<string, Issue> IssuesThird { get; set; }

        public MultiDictionary<string, Issue> IssuesForth { get; set; }

        public MultiDictionary<User, Comment> UserComments { get; set; }

        public Dictionary<Comment, User> Comments { get; set; }

        public void AddIssue(Issue issue)
        {
            issue.Id = this.NextIssueId;
            this.IssuesFirst.Add(issue.Id, issue);
            this.IssuesSecond[this.CurrentUser.Username].Add(issue);
            foreach (var tag in issue.Tags)
            {
                if (!this.IssuesForth.ContainsKey(tag))
                {
                    this.IssuesForth.Add(tag, issue);
                }
                else
                {
                    this.IssuesForth[tag].Add(issue);
                }
            }

            this.NextIssueId++;
        }

        public void RemoveIssue(Issue issue)
        {
            this.IssuesSecond[this.CurrentUser.Username].Remove(issue);
            foreach (var tag in issue.Tags)
            {
                this.IssuesForth[tag].Remove(issue);
            }

            this.IssuesFirst.Remove(issue.Id);
        }
    }
}