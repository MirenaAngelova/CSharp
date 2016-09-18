namespace ChepelareHotelBookingSystem3.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines action repository should be able to perform.
    /// </summary>
    /// <typeparam name="T">Type of data containing in repository.</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Returns all currently items in repository
        /// </summary>
        /// <returns>IEnumerable  of items</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Get an item by ID.
        /// </summary>
        /// <param name="id">ID of item</param>
        /// <returns>Item</returns>
        T Get(int id);

        /// <summary>
        /// Adds an item to repository. 
        /// </summary>
        /// <param name="item">Current item to add.</param>
        void Add(T item);

        /// <summary>
        /// Updates existing item.
        /// </summary>
        /// <param name="id">Item ID</param>
        /// <param name="newItem">Updated item</param>
        /// <returns>Boolean variable</returns>
        bool Update(int id, T newItem);

        /// <summary>
        /// Removes unnessesary items.
        /// </summary>
        /// <param name="id">Item ID</param>
        /// <returns>Boolean variable</returns>
        bool Delete(int id);
    }
}