namespace BuhtigIssueTracker
{
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class User
    {
        public User(string userName, string password)
        {
            this.UserName = userName;
            this.PasswortHash = HashPassword(password);
        }

        public string UserName { get; set; }

        public string PasswortHash { get; set; }

        public static string HashPassword(string password)
        {
            var sha1 = string.Join(
                       string.Empty, 
                       SHA1.Create().ComputeHash(Encoding.Default.GetBytes(password)).Select(x => x.ToString()));
            return sha1;
        }
    }
}