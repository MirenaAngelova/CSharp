namespace BangaloreUniversityLearningSystem.Controllers
{
    using System;
    using Infrastructure;
    using Interfaces;
    using Models;
    using Utilities;

    public class UsersController : Controller
    {
        public UsersController(IBangaloreUniversityData data, User user) : base(data, user)
        {
        }

        /// <summary>
        /// Registers an user in database, if he passed validations for: match provided password,
        /// ensure user is not logged in, ensure user with given username does not exist,
        /// 
        /// </summary>
        /// <param name="username">The user name of the current user.</param>
        /// <param name="password">The password of the current user.</param>
        /// <param name="confirmPassword">Confirming password. Passowrd should match confirm password.</param>
        /// <param name="role">The role of user. It should be lecturer or student</param>
        /// <returns>Returns IView of user.</returns>
        public IView Register(string username, string password, string confirmPassword, string role)
        {
            if (password != confirmPassword)
            {
                throw new ArgumentException(Messages.ExceptionMessagePasswordNotMatch);
            }

            this.EnsureNoLoggedInUser();

            var existingUser = this.Data.Users.GetByUsername(username);
            Validator.ValidateUserExists(existingUser, username);

            Role userRole = (Role)Enum.Parse(typeof(Role), role, true);
            var user = new User(username, password, userRole);
            this.Data.Users.Add(user);
            return this.View(user);
        }

        public IView Login(string username, string password)
        {
            this.EnsureNoLoggedInUser();

            var existingUser = this.Data.Users.GetByUsername(username);
            Validator.ValidateUserNotExists(existingUser, username);
           
            if (existingUser.Password != HashUtilities.HashPassword(password))
            {
                throw new ArgumentException(Messages.ExceptionMessagePasswordWrong);
            }

            this.User = existingUser;
            return this.View(existingUser);
        }

        public IView Logout()
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException(Messages.ExceptionMessageNoLoggedInUser);
            }

            var userLecturer = this.User.IsInRole(Role.Lecturer);
            var userStudent = this.User.IsInRole(Role.Student);
           
            // Performance: !userLecturer && !userStudent
            // De Morgan's laws: "not (A or B)" is the same as "(not A) and (not B)"
            if (!(userLecturer || userStudent))
            {
                throw new DivideByZeroException(Messages.ExceptionMessageNotAuthorized);
            }
                
            var user = this.User;
            this.User = null;
            return this.View(user);
        }

        private void EnsureNoLoggedInUser()
        {
            if (this.HasCurrentUser)
            {
                throw new ArgumentException(Messages.ExceptionMessageAlreadyLoggedInUser);
            }
        }
    }
}