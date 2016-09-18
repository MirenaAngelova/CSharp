namespace BuhtigIssueTracker
{
    using System;
    using System.Text;

    public class Comment
    {
        private string text;
        //private string title;
        //private string description;

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

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 2)
                {
                    throw new ArgumentException(nameof(this.text), "The text must be at least 2 symbols long");
                }

                this.text = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder()
                .AppendLine(this.Text)
                .AppendFormat("-- {0}", this.Author.UserName)
                .AppendLine()
                .ToString()
                .Trim();

            return output;
        }
    }
}