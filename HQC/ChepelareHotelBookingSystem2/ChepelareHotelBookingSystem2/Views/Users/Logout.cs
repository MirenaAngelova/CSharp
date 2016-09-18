namespace ChepelareHotelBookingSystem2.Views.Users
{
    using System.Text;

    using Infrastructure;
    using Models;

    public class Logout : View
    {
        public Logout(User user)
            : base(user)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var user = this.Model as User;
            viewResult.AppendLine($"The user {user.Username} has logged out.");
        }
    }
}
