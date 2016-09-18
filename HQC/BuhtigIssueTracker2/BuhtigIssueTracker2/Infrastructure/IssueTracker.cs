namespace BuhtigIssueTracker2.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Data;
    using Interfaces;
    using Stuff;
    using Utilities;

    public class IssueTracker : IIssueTracker
    {
        public IssueTracker(IBuhtigIssueTrackerData data)
        {
            this.Data = data as BuhtigIssueTrackerData;
        }

        public IssueTracker()
            : this(new BuhtigIssueTrackerData())
        {
        }

        BuhtigIssueTrackerData Data { get; set; }

        public string RegisterUser(string username, string password, string confirmPassword)
        {
            // BUG: if-statement should be for different from null current user
            this.AlreadyLoggedInUser();

            if (password != confirmPassword)
            {
                throw new ArgumentException(Validation.MessagePasswordNotMatch);
            }

            if (this.Data.Users.ContainsKey(username))
            {
                throw new ArgumentException(string.Format(Validation.MessageUserExists, username));
            }

            var user = new User(username, password);
            this.Data.Users.Add(username, user);
            var messageRegister = string.Format(Validation.MessageUserRegistredSuccessfully, username);
            return messageRegister;
        }

        public string LoginUser(string username, string password)
        {
            // BUG: Current user should be defferent from null
            this.AlreadyLoggedInUser();

            if (!this.Data.Users.ContainsKey(username))
            {
                throw new ArgumentException(string.Format(Validation.MessageUserNotExist, username));
            }

            var user = this.Data.Users[username];
            if (user.PasswordHash != User.HashPassword(password))
            {
                throw new ArgumentException(string.Format(Validation.MessagePasswordInvalid, username));
            }

            this.Data.CurrentUser = user;
            var messageLogin = string.Format(Validation.MessageUserLoggedInSuccsessfully, username);
            return messageLogin;
        }

        public string LogoutUser()
        {
            if (this.Data.CurrentUser == null)
            {
                throw new ArgumentException(Validation.MessageNoLoggedInUser);
            }

            string username = this.Data.CurrentUser.Username;
            this.Data.CurrentUser = null;
            var messageLogout = string.Format(Validation.MessageUserLoggedOutSuccsessfully, username);
            return messageLogout;
        }

        public string CreateIssue(
            string title,
            string description,
            PriorityIssue priority,
            string[] strings)
        {
            this.NoLoggedInUser();

            var issue = new Issue(title, description, priority, strings.Distinct().ToList());
            
            this.Data.AddIssue(issue);

            var messageCreate = string.Format(Validation.MessageIssueCreatedSuccessfully, issue.Id);
            return messageCreate;
        }

        public string RemoveIssue(int issueId)
        {
            this.NoLoggedInUser();

            if (!this.Data.IssuesFirst.ContainsKey(issueId))
            {
                throw new ArgumentException(string.Format(Validation.MessageNoIssueId, issueId));
            }

            var issue = this.Data.IssuesFirst[issueId];
            if (!this.Data.IssuesSecond[this.Data.CurrentUser.Username].Contains(issue))
            {
                throw new ArgumentException(
                    string.Format(Validation.MessageIssueNotBelongToUser, 
                    issueId, this.Data.CurrentUser.Username));
            }

            this.Data.IssuesSecond[this.Data.CurrentUser.Username].Remove(issue);
            foreach (var tag in issue.Tags)
            {
                this.Data.IssuesForth[tag].Remove(issue);
            }

            this.Data.IssuesFirst.Remove(issue.Id);
            var messageRemove = String.Format(Validation.MessageIssueRemoved, issue.Id);
            return messageRemove;
        }

        public string AddComment(int id, string inputComment)
        {
            this.NoLoggedInUser();

            if (!this.Data.IssuesFirst.ContainsKey(id))// BUG: (intValue + 1)
            {
                throw new ArgumentException(
                    string.Format(Validation.MessageNoIssueId, id));// BUG: (intValue + 1
            }

            var issue = this.Data.IssuesFirst[id];
            var comment = new Comment(this.Data.CurrentUser, inputComment);
            issue.AddComment(comment);
            this.Data.UserComments[this.Data.CurrentUser].Add(comment);
            var messageAdd = string.Format(Validation.MessageCommentAddedToIssue, issue.Id);
            return messageAdd;
        }

        public string GetMyIssues()
        {
            this.NoLoggedInUser();

            var issues = this.Data.IssuesSecond[this.Data.CurrentUser.Username];
            var newIssues = issues;
            if (!newIssues.Any())
            {
                // Remove var result = Data.issues2.Aggregate(String.Empty, (current, i) => current + i.Value.Select(iss => iss.Comments.Select(c => c.Text)).ToString());
                throw new ArgumentException(Validation.MessageNoIssues);
            }

            return string.Join(Environment.NewLine,
                newIssues.OrderByDescending(x => x.Priority).ThenBy(x => x.Title));
        }

        public string GetMyComments()
        {
            this.NoLoggedInUser();

            //var comments = new List<Comment>();
            //this.Data.IssuesFirst.Select(i => i.Value.Comments).ToList()
            //    .ForEach(item => comments.AddRange(item));
            //var resultComments = comments
            //    .Where(c => c.Author.Username == this.Data.CurrentUser.Username)
            //    .ToList();
            //var strings = resultComments
            //    .Select(x => x.ToString());
            var comments = this.Data.UserComments[this.Data.CurrentUser].Select(c => c.ToString());
            if (!comments.Any())
            {
                throw new ArgumentException(Validation.MessageNoComments);
            }

            return string.Join(Environment.NewLine, comments);
        }

        public string SearchForIssues(string[] tags)
        {
            if (tags.Length < Validation.MinTagsLength)
            {
                throw new ArgumentException(Validation.MessageNoTags);
            }

            var issues = new List<Issue>();
            foreach (var tag in tags)
            {
                issues.AddRange(this.Data.IssuesForth[tag]);// AddRange
            }

            if (!issues.Any())
            {
                throw new ArgumentException(Validation.MessageNoIssuesMatchingTags);
            }

            var newIssue = issues.Distinct();
            if (!newIssue.Any())
            {
                throw new ArgumentException(Validation.MessageNoIssues);
            }

            return string.Join(Environment.NewLine,
                newIssue
                    .OrderByDescending(x => x.Priority)
                    .ThenBy(x => x.Title));
            //.Select(x => string.Empty));// (x => string.Empty)
        }

        public void AlreadyLoggedInUser()
        {
            if (this.Data.CurrentUser != null)
            {
                throw new ArgumentException(Validation.MessageAlreadyLoggedInUser);
            }
        }

        public void NoLoggedInUser()
        {
            if (this.Data.CurrentUser == null)
            {
                throw new ArgumentException(Validation.MessageNoLoggedInUser);
            }
        }
    }
}
