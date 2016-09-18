namespace ChepelareHotelBookingSystem3.Controllers
{
    using System;

    using Infrastructure;
    using Interfaces;
    using Models;
    using Utilities;

    public class UsersController : Controller
    {
        public UsersController(IHotelBookingSystemData data, User user)
            : base(data, user)
        {
        }

        public IView Register(string username, string password, string confirmPassword, string role)
        {
            Validator.ValidateConfirmPassword(password, confirmPassword);

            this.EnsureNoLoggedInUser();

            var existingUser = this.Data.RepositoryWithUsers.GetByUsername(username);
            Validator.ValidateUserExists(existingUser, username);

            Roles userRole = (Roles)Enum.Parse(typeof(Roles), role, true);
            var user = new User(username, password, userRole);
            this.Data.RepositoryWithUsers.Add(user);
            return this.View(user);
        }

        public IView Login(string username, string password)
        {
            this.EnsureNoLoggedInUser();

            var existingUser = this.Data.RepositoryWithUsers.GetByUsername(username);
            Validator.ValidateUserNotExist(existingUser, username);

            if (existingUser.PasswordHash != HashUtilities.GetSha256Hash(password))
            {
                throw new ArgumentException(Validation.ExceptionMessagePasswordWrong);
            }

            this.CurrentUser = existingUser;
            return this.View(existingUser);
        }

        public IView MyProfile()
        {
            this.Authorize(Roles.User, Roles.VenueAdmin);
            return this.View(this.CurrentUser);
        }

        public IView Logout()
        {
            this.Authorize(Roles.User, Roles.VenueAdmin);

            var user = this.CurrentUser;
            this.CurrentUser = null;
            return this.View(user);
        }

        private void EnsureNoLoggedInUser()
        {
            foreach (var user in this.Data.RepositoryWithUsers.GetAll())
            {
                if (string.IsNullOrEmpty(user.Username) || 
                (this.CurrentUser != null && this.CurrentUser.Username == user.Username))
                {
                    throw new ArgumentException(Validation.ExceptionMessageAlreadyLoggedInUser);
                }
            }
        }
    }
}
