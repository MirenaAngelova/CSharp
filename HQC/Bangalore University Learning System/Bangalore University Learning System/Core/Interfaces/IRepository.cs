namespace Bangalore_University_Learning_System.Core.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Contains methods for getting all courses in repository,
    /// getting a concrete course by it's ID and adding courses.
    /// </summary>
    /// <typeparam name="T">Type of the item for performing the method's operations</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Gets all courses in repository
        /// </summary>
        /// <returns>Returns courses in appropriate order and "No courses." message
        /// when there aren't courses</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Get a concrete course by it's ID
        /// </summary>
        /// <param name="id">The ID of the course</param>
        /// <returns>Returns the course in appropriate format</returns>
        T Get(int id);

        /// <summary>
        /// Adds a course to the repository courses
        /// </summary>
        /// <param name="item">The course to be added</param>
        void Add(T item);
    }
}