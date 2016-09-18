namespace BuhtigIssueTracker2.Stuff
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Utilities;

    public class Issue
    {
        private string title;
        private string description;

        public Issue(string title, string description, PriorityIssue priority, List<string> tags)
        {
            this.Title = title;
            this.Description = description;
            this.Priority = priority;
            this.Tags = tags;

            // Adds Comments to constructor
            this.Comments = new List<Comment>();
        }

        public int Id { get; set; }

        public string Title
        {
            get
            {
                return this.title;
            }

            private set
            {
                Validator.ValidateMinLength(value, "title", Validation.MinTitleLength);
                this.title = value;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }

            private set
            {
                Validator.ValidateMinLength(value, "description", Validation.MinDescriptionLength);
                this.description = value;
            }
        }

        public PriorityIssue Priority { get; set; }

        public IList<string> Tags { get; set; }

        public IList<Comment> Comments { get; set; }

        public void AddComment(Comment comment)
        {
            this.Comments.Add(comment);
        }

        public override string ToString()
        {
            var issue = new StringBuilder();
            issue
                .AppendLine(this.Title)
                .AppendFormat("Priority: {0}",
                this.GetPriorityAsString()).AppendLine().AppendLine(this.Description);
            if (this.Tags.Count > 0)
            {
                issue.AppendFormat("Tags: {0}", 
                    string.Join(",", this.Tags.OrderBy(t => t))).AppendLine();
            }

            if (this.Comments.Count > 0)
            {
                issue.AppendFormat("Comments:{0}{1}", 
                    Environment.NewLine, string.Join(Environment.NewLine, this.Comments)).AppendLine();
            }

            return issue.ToString().Trim();
        }

        private string GetPriorityAsString()
        {
            switch (this.Priority)
            {
                case PriorityIssue.Showstopper:
                    return "****";
                case PriorityIssue.High:
                    return "***";
                case PriorityIssue.Medium:
                    return "**";
                case PriorityIssue.Low:
                    return "*";
                default:
                    throw new InvalidOperationException("The priority is invalid");
            }
        }
    }
}