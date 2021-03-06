﻿namespace Bangalore_University_Learning_System.Views.Users
{
    using System.Text;

    using Infrastructure;
    using Models;

    public class Login : View
    {
        public Login(User user)
            : base(user)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            viewResult.AppendFormat("User {0} logged in successfully.", (this.Model as User).UserName).AppendLine();
        }
    }
}