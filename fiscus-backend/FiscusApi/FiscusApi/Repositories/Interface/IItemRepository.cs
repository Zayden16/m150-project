using System.Collections.Generic;
using FiscusApi.Models;

namespace FiscusApi.Repositories.Interface
{
    public interface IItemRepository  
    {
        /// <summary>
        /// Adds the item record.
        /// </summary>
        /// <param name="item">The item.</param>
        void AddItemRecord(Item item);

        /// <summary>
        /// Updates the item record.
        /// </summary>
        /// <param name="item">The item.</param>
        void UpdateItemRecord(Item item);

        /// <summary>
        /// Deletes the item record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteItemRecord(int id);

        /// <summary>
        /// Gets the item single record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The item.</returns>
        Item GetItemSingleRecord(int id);

        /// <summary>
        /// Gets the item records.
        /// </summary>
        /// <returns>The items.</returns>
        List<Item> GetItemRecords();  
    }  
}
