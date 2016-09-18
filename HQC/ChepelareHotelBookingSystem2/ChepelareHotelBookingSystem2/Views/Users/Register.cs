namespace ChepelareHotelBookingSystem2.Views.Users
{
    using System.Text;

    using Infrastructure;
    using Models;

    public class Register : View
    {
        public Register(User user)
            : base(user)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var user = this.Model as User;
            viewResult.AppendLine($"The user {user.Username} has been registered and may login.");
        }
    }
}