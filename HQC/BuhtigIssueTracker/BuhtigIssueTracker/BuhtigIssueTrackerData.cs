namespace BuhtigIssueTracker
{
    using System.Collections.Generic;

    using BuhtigIssueTracker.Interfaces;
    using Wintellect.PowerCollections;

    public class BuhtigIssueTrackerData : IBuhtigIssueTrackerData
    {
        public int NextIssueId;

        public BuhtigIssueTrackerData()
        {
            this.NextIssueId = 1;
            this.UsersDictionary = new Dictionary<string, User>();

            this.Issues = new MultiDictionary<Problem, string>(true);         
            this.IssuesFirst = new OrderedDictionary<int, Problem>();
            this.IssuesSecond = new MultiDictionary<string, Problem>(true);
            this.IssuesThird = new MultiDictionary<string, Problem>(true);
            this.IssuesForth = new MultiDictionary<string, Problem>(true);

            this.UserCommentDictionary = new MultiDictionary<User, Comment>(true);
            this.Comments = new Dictionary<Comment, User>();
        }

        public User CurrentlyLoggedUser { get; set; }

        public IDictionary<string, User> UsersDictionary { get; set; }

        public MultiDictionary<Problem, string> Issues { get; set; }

        public OrderedDictionary<int, Problem> IssuesFirst { get; set; }

        public MultiDictionary<string, Problem> IssuesSecond { get; set; }

        public MultiDictionary<string, Problem> IssuesThird { get; set; }

        public MultiDictionary<string, Problem> IssuesForth { get; set; }

        public MultiDictionary<User, Comment> UserCommentDictionary { get; set; }

        public Dictionary<Comment, User> Comments { get; set; }

        public void AddIssue(Problem problem)
        {
            this.IssuesFirst.Add(problem.Id, problem);
            this.NextIssueId++;
            this.IssuesSecond[this.CurrentlyLoggedUser.UserName].Add(problem);
            foreach (var tag in problem.Tags)
            {
                this.IssuesThird[tag].Add(problem);
            }
        }

        public void RemoveIssue(Problem problem)
        {
            this.IssuesSecond[this.CurrentlyLoggedUser.UserName].Remove(problem);

            foreach (var tag in problem.Tags)
            {
                this.IssuesThird[tag].Remove(problem);
            }

            this.IssuesFirst.Remove(problem.Id);
        }
    }
}