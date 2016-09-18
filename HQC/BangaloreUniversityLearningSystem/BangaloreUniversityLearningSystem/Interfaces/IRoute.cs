namespace BangaloreUniversityLearningSystem.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// A class carries all needed information to execute commands.
    /// </summary>
    public interface IRoute
    {

        /// <summary>
        /// Type of controller processes the action.
        /// </summary>
        // Refactor: The names of properties should begin with upper letter
        string ControllerName { get; }

        /// <summary>
        /// The action to be executing.
        /// </summary>
        // Refactor: The names of properties should begin with upper letter
        string ActionName { get; }

        /// <summary>
        /// A dictionary of input pair parameters as strings
        /// </summary>
        IDictionary<string, string> Parameters { get; }
    }
}