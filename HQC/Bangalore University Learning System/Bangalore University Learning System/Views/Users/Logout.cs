﻿namespace Bangalore_University_Learning_System.Views.Users
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
            viewResult.AppendFormat("User {0} logged out successfully.", (this.Model as User).UserName).AppendLine();
        }
    }
}