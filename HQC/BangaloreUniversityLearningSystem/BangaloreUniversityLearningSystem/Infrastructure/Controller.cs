namespace BangaloreUniversityLearningSystem.Infrastructure
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;

    using Interfaces;
    using Models;
    using Utilities;

    public abstract class Controller
    {
        protected Controller(IBangaloreUniversityData data, User user)
        {
            this.Data = data;
            this.User = user;
        }
        public User User { get; set; }

        public bool HasCurrentUser => User != null;

        protected IBangaloreUniversityData Data { get; set; }

        protected IView View(object model)
        {
            string fullNamespace = this.GetType().Namespace;
            int firstSeparatorIndex = fullNamespace.IndexOf(Constants.DotSeparator);
            string baseNamespace = fullNamespace.Substring(0, firstSeparatorIndex);
            string controllerName = this.GetType().Name.Replace(Constants.Controller, string.Empty);
            string actionName = new StackTrace().GetFrame(1).GetMethod().Name;

            // string fullPath = baseNamespace + ".Views." + controllerName + "." + actionName;
            string fullPath = string.Join(
                Constants.DotSeparator,
                baseNamespace,
                Constants.Views,
                controllerName,
                actionName);
            var viewType = Assembly
                .GetExecutingAssembly()
                .GetType(fullPath);
            return Activator.CreateInstance(viewType, model) as IView;
        }

        protected void EnsureAuthorization(params Role[] roles)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException(Messages.ExceptionMessageNoLoggedInUser);
            }

            //var userRole = this.Data.Users.GetAll().Any(user => !roles.Any(role => this.User.IsInRole(role)));
            if (!roles.Any(role => this.User.IsInRole(role)))
            {
                throw new DivideByZeroException(Messages.ExceptionMessageNotAuthorized);
            }
        }
    }
}
