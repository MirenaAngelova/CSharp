namespace BangaloreUniversityLearningSystem.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// A generic repository which stores data of a given type, has methods for adding an element,
    /// returns a specific element by ID, returns all stored elements.
    /// </summary>
    /// <typeparam name="T">The type repository hold</typeparam>
    public interface IRepository<T>
    {

        /// <summary>
        /// A method which stores all ellements of a repository.
        /// </summary>
        /// <returns>Returns IEnumerable of type same as type of the repository.</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// A method returns a single element from repository matching a specified integer.
        /// </summary>
        /// <param name="id">The ID of the element we want to return.</param>
        /// <returns>Returns a single element of type same as the repository type.</returns>
        T Get(int id);
        
        /// <summary>
        /// A method add new element to repository of the same type.
        /// </summary>
        /// <param name="item">The element should be added.</param>
        void Add(T item);
    }
}