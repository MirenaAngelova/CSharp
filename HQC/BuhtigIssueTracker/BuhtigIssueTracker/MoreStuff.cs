namespace BuhtigIssueTracker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BuhtigIssueTracker.Interfaces;

    public class MoreStuff : IIssueTracker
    {
        private string loggedInUser = "There is already a logged in user";
        private string noCurrentlyLoggedInUser = "There is no currently logged in user";
        private string noIssues = "No issues";

        public MoreStuff(IBuhtigIssueTrackerData data)
        {
            this.Data = data as BuhtigIssueTrackerData;
        }

        public MoreStuff() : this(new BuhtigIssueTrackerData())
        {
        }

        public BuhtigIssueTrackerData Data { get; set; }

        public string RegisterUser(string userName, string password, string confirmPassword)
        {
            if (this.Data.CurrentlyLoggedUser != null)
            {
                return loggedInUser;
            }

            if (password != confirmPassword)
            {
                var passwordNotMatch = "The provided passwords do not match";
                return passwordNotMatch;
            }

            if (this.Data.UsersDictionary.ContainsKey(userName))
            {
                var userNameExists = string.Format("A user with username {0} already exists", userName);
                return userNameExists;
            }

            var user = new User(userName, password);
            this.Data.UsersDictionary.Add(userName, user);

            var registeredSuccessfully = string.Format("User {0} registered successfully", userName);
            return registeredSuccessfully;
        }

        public string LoginUser(string userName, string password)
        {
            if (this.Data.CurrentlyLoggedUser != null)
            {
                return loggedInUser;
            }

            if (!this.Data.UsersDictionary.ContainsKey(userName))
            {
                var userNameNotExists = string.Format("A user with username {0} does not exist", userName);
                return userNameNotExists;
            }

            var user = this.Data.UsersDictionary[userName];

            if (user.PasswortHash != User.HashPassword(password))
            {
                var invalidPassword = string.Format("The password is invalid for user {0}", userName);
                return invalidPassword;
            }

            this.Data.CurrentlyLoggedUser = user;

            var loggedSuccessfully = string.Format("User {0} logged in successfully", userName);
            return loggedSuccessfully;
        }

        public string LogoutUser()
        {
            if (this.Data.CurrentlyLoggedUser == null)
            {
                return noCurrentlyLoggedInUser;
            }

            string username = this.Data.CurrentlyLoggedUser.UserName;
            this.Data.CurrentlyLoggedUser = null;

            var loggedOutSuccessfully = string.Format("User {0} logged out successfully", username);
            return loggedOutSuccessfully;
        }

        public string CreateIssue(string title, string description, IssuePriority priority, string[] strings)
        {
            if (this.Data.CurrentlyLoggedUser == null)
            {
                return noCurrentlyLoggedInUser;
            }

            var issue = new Problem(title, description, priority, strings.Distinct().ToList());
            issue.Id = this.Data.NextIssueId;
            this.Data.IssuesFirst.Add(issue.Id, issue);
            this.Data.NextIssueId++;
            this.Data.IssuesSecond[this.Data.CurrentlyLoggedUser.UserName].Add(issue);


            var issueCreatedSuccessfuly = string.Format("Issue {0} created successfully.", issue.Id);
            return issueCreatedSuccessfuly;
        }

        public string RemoveIssue(int issueId)
        {
            if (this.Data.CurrentlyLoggedUser == null)
            {
                return noCurrentlyLoggedInUser;
            }

            if (!this.Data.IssuesFirst.ContainsKey(issueId))
            {
                return string.Format("There is no issue with ID {0}", issueId);
            }

            var issue = this.Data.IssuesFirst[issueId];
            if (!this.Data.IssuesSecond[this.Data.CurrentlyLoggedUser.UserName].Contains(issue))
            {
                return string.Format(
                    "The issue with ID {0} does not belong to user {1}",
                    issueId,
                    this.Data.CurrentlyLoggedUser.UserName);
            }

            this.Data.IssuesSecond[this.Data.CurrentlyLoggedUser.UserName].Remove(issue);
            foreach (var tag in issue.Tags)
            {
                this.Data.IssuesForth[tag].Remove(issue);
            }

            this.Data.IssuesFirst.Remove(issue.Id);

            return string.Format("Issue {0} removed", issueId);
        }

        public string AddComments(int intValue, string stringValue)
        {
            if (this.Data.CurrentlyLoggedUser == null)
            {
                return noCurrentlyLoggedInUser;
            }

            if (!this.Data.IssuesFirst.ContainsKey(intValue))//intValue + 1
            {
                var noIssueID = string.Format("There is no issue with ID {0}", intValue);//intValue + 1
                return noIssueID;
            }
            var issue = this.Data.IssuesFirst[intValue];
            var comment = new Comment(this.Data.CurrentlyLoggedUser, stringValue);
            issue.AddComment(comment);
            this.Data.UserCommentDictionary[this.Data.CurrentlyLoggedUser].Add(comment);

            var commentAddedSuccessfully = string.Format("Comment added successfully to issue {0}", issue.Id);
            return commentAddedSuccessfully;
        }

        public string GetMyIssues()
        {
            if (this.Data.CurrentlyLoggedUser == null)
            {
                return  noCurrentlyLoggedInUser;
            }

            var issues = this.Data.IssuesSecond[this.Data.CurrentlyLoggedUser.UserName];

            if (!issues.Any())
            {
                return noIssues;
            }

            return string.Join(Environment.NewLine, issues.OrderByDescending(x => x.Priority).ThenBy(x => x.Title));
        }

        //public string GetMyIssues()
        //{
        //    if (this.Data.CurrentlyLoggedUser == null)
        //    {
        //        return noCurrentlyLoggedInUser;
        //    }

        //    var issues = this.Data.IssuesSecond[this.Data.CurrentlyLoggedUser.UserName];
        //    var newIssues = issues;
        //    if (!newIssues.Any())
        //    {
        //        var result = string.Empty;
        //        foreach (var i in this.Data.IssuesSecond)
        //        {
        //            result += i.Value.Select(iss => iss.Comments.Select(c => c.Text)).ToString();
        //        }

        //        return noIssues;
        //    }

        //    return string.Join(
        //        Environment.NewLine,
        //        newIssues.OrderByDescending(x => x.Priority).ThenBy(x => x.Title));
        //}

        public string GetMyComments()
        {
            if (this.Data.CurrentlyLoggedUser == null)
            {
                return noCurrentlyLoggedInUser;
            }

            var comments = new List<Comment>();
            this.Data.IssuesFirst.Select(i => i.Value.Comments).ToList()
                .ForEach(item => comments.AddRange(item));
            var resultComments = comments
                .Where(c => c.Author.UserName == this.Data.CurrentlyLoggedUser.UserName)
                .ToList();
            var outputComments = resultComments
                .Select(x => x.ToString());
            if (!outputComments.Any())
            {
                var noComments = "No comments";
                return noComments;
            }

            var output = string.Join(Environment.NewLine, outputComments);
            return output;
        }

        public string SearchForIssues(string[] issues)
        {
            if (issues.Length == 0)
            {
                return "There are no tags provided";
            }

            var issue = new List<Problem>();
            foreach (var tag in issues)
            {
                issue.AddRange(this.Data.IssuesForth[tag]);
            }

            issue = issue.Distinct().ToList();
            if (!issue.Any())
            {
                var noIssuesMatching = "There are no issues matching the tags provided";
                return noIssuesMatching;
            }
            
            if (!issue.Any())
            {
                return noIssues;
            }

            var output = string.Join(
                Environment.NewLine,
                issue.OrderByDescending(x => x.Priority).ThenBy(x => x.Title));
            return output;
        }
    }
}
