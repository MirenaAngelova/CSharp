namespace ChepelareHotelBookingSystem2.Infrastructure
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
    public abstract class Controller
    {
        /// <summary>
        /// Class constructor and creates a controller object
        /// </summary>
        /// <param name="data">Data to hold and operate on</param>
        /// <param name="user">Currently logged in user</param>
        protected Controller(IHotelBookingSystemData data, User user)
        {
            this.Data = data;
            this.CurrentUser = user;
        }

        /// <summary>
        /// Currently logged in user
        /// </summary>
        public User CurrentUser { get; set; }

        /// <summary>
        /// Provides info there is any currently logged in user
        /// </summary>
        public bool HasCurrentUser => this.CurrentUser != null;

        /// <summary>
        /// Holds data to operate on
        /// </summary>
        protected IHotelBookingSystemData Data { get; private set; }

        /// <summary>
        /// Returns result in form of a view base on the model passed.
        /// </summary>
        /// <param name="model">The model used by controller</param>
        /// <returns></returns>
        protected IView View(object model)
        {
            string fullNamespace = this.GetType().Namespace;
            int firstSeparatorIndex = fullNamespace.IndexOf(Constants.NamespaceSeparator);
            string baseNamespace = fullNamespace.Substring(0, firstSeparatorIndex);
            string controllerName = this.GetType().Name.Replace(Constants.ControllerSuffix, string.Empty);
            string actionName = new StackTrace().GetFrame(1).GetMethod().Name;

            // BUG: NamesapceSeparator instead NamespaceSeparator
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
        /// <param name="message">The message content</param>
        /// <returns>IView with the error message</returns>
        protected IView NotFound(string message)
        {
            return new Error(message);
        }

        /// <summary>
        /// Ensures user has rights to perform action.
        /// </summary>
        /// <param name="roles">Roles available/allowed</param>
        protected void Authorize(params Roles[] roles)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            if (!roles.Any(role => this.CurrentUser.IsInRole(role)))
            {
                throw new AuthorizationFailedException(
                    "The currently logged in user doesn't have sufficient rights to perform this operation.");
            }
        }
    }
}
