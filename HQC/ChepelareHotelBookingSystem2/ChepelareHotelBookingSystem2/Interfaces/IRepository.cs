namespace ChepelareHotelBookingSystem2.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines actions that repository should be able to perform.
    /// </summary>
    /// <typeparam name="T">Type of data containing in repository</typeparam>
    public interface IRepository<T>
    {

        /// <summary>
        /// Returns all currently items in repository
        /// </summary>
        /// <returns>IEnumerable of items</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Returns an item base on it's ID.
        /// </summary>
        /// <param name="id">Item's ID</param>
        /// <returns>Item with provided ID</returns>
        T Get(int id);

        /// <summary>
        /// Adds an item to repository
        /// </summary>
        /// <param name="item">Item to add</param>
        void Add(T item);

        /// <summary>
        /// Updates the details on existing item.
        /// </summary>
        /// <param name="id">Item's ID</param>
        /// <param name="newItem">Updates item to replace the previous one</param>
        /// <returns>Boolean variable</returns>
        bool Update(int id, T newItem);

        /// <summary>
        /// Removes an item from repository
        /// </summary>
        /// <param name="id"> Removed item's ID</param>
        /// <returns>Boolean variable</returns>
        bool Delete(int id);
    }
}