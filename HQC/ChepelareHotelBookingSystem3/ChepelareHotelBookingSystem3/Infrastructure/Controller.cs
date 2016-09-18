namespace ChepelareHotelBookingSystem3.Infrastructure
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;

    using Identity;
    using Interfaces;
    using Models;
    using Utilities;
    using Views.Shared;

    /// <summary>
    /// Holds data and controls user actions over it.
    /// </summary>
    public class Controller
    {
        /// <summary>
        /// Constructor creates controller object.
        /// </summary>
        /// <param name="data">Data to hold and operate on</param>
        /// <param name="user">Currently logged in user</param>
        public Controller(IHotelBookingSystemData data, User user)
        {
            this.Data = data;
            this.CurrentUser = user;
        }

        /// <summary>
        /// Currently logged in user
        /// </summary>
        public User CurrentUser { get; set; }

        /// <summary>
        /// Provides info is there any currently logged in user
        /// </summary>
        public bool HasCurrentUser => this.CurrentUser != null;

        /// <summary>
        /// Holds data to operate on.
        /// </summary>
        protected IHotelBookingSystemData Data { get; private set; }

        /// <summary>
        /// Returns result in form of a view base over the passed model.
        /// </summary>
        /// <param name="model">Currently object used by controller</param>
        /// <returns></returns>
        protected IView View(object model)
        {
            string fullNamespace = this.GetType().Namespace;

            // BUG: Refactor NamesapceSeparator to NamespaceSeparator
            int firstSeparatorIndex = fullNamespace.IndexOf(Constants.NamespaceSeparator);
            string baseNamespace = fullNamespace.Substring(0, firstSeparatorIndex);
            string controllerName = this.GetType().Name.Replace(Constants.ControllerSuffix, string.Empty);
            string actionName = new StackTrace().GetFrame(1).GetMethod().Name;
            string fullPath = string.Join(
                Constants.NamespaceSeparator,
                new[] { baseNamespace, Constants.ViewsFolder, controllerName, actionName });
            var viewType = Assembly
                .GetExecutingAssembly()
                .GetType(fullPath);
            return Activator.CreateInstance(viewType, model) as IView;
        }

        /// <summary>
        /// Returns an error message.
        /// </summary>
        /// <param name="message">Content of message.</param>
        /// <returns>Returns IView message</returns>
        protected IView NotFound(string message)
        {
            return new Error(message);
        }

        /// <summary>
        /// Ensures user is authorized to perform action.
        /// </summary>
        /// <param name="roles">Available/allowed role</param>
        public void Authorize(params Roles[] roles)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException(Validation.ExceptionMessageNoLoggedInUser);
            }

            if (!roles.Any(role => this.CurrentUser.IsInRole(role)))
            {
                throw new AuthorizationFailedException(Validation.ExceptionMessageUserNotAuthorized);
            }
        }
    }
}
