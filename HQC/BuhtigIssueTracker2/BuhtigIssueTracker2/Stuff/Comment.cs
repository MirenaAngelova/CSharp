namespace BuhtigIssueTracker2.Stuff
{
    using System.Text;
    using Utilities;

    public class Comment
    {
        string text;

        public Comment(User author, string text)
        {
            this.Author = author;
            this.Text = text;
        }

        public User Author { get; set; }

        public string Text
        {
            get
            {
                return this.text;
            }

            private set
            {
                Validator.ValidateMinLength(value, "text", Validation.MinTextLength);
                this.text = value;
            }
        }

        public override string ToString()
        {
            var exit = new StringBuilder()
                .AppendLine(this.Text)
                .AppendFormat("-- {0}", this.Author.Username).AppendLine().ToString().Trim();
            return exit;
        }
    }
}