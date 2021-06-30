using System;
using System.Collections.Generic;

namespace StoreAppData
{
    /// <summary>
    /// Responsible for accessing the database
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Finds an object from the database 
        /// </summary>
        /// <returns>The object being searched for</returns>
        object Find();

        /// <summary>
        /// Retrieves all items from the database
        /// </summary>
        /// <returns>A list of all items in the database</returns>
        List<object> RetrieveAll();

        /// <summary>
        /// Add an item to the database
        /// </summary>
        /// <param name="item">The item to be added to the database</param>
        /// <returns>True if the item was successfully added</returns>
        bool Add(object item);
    }
}
