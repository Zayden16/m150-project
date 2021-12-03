using System.Collections.Generic;
using FiscusApi.Models;

namespace FiscusApi.Repositories.Interface
{
    public interface IItemRepository  
    {
        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <returns>The items.</returns>
        IEnumerable<Item> GetItems();

        /// <summary>
        /// Gets the items by shopping list identifier.
        /// </summary>
        /// <param name="shoppingListId">The shopping list identifier.</param>
        /// <returns>The items.</returns>
        IEnumerable<Item> GetItemsByShoppingListId(int shoppingListId);

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The item.</returns>
        Item GetItem(int id);

        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="item">The item.</param>
        void AddItem(Item item);

        /// <summary>
        /// Updates the item.
        /// </summary>
        /// <param name="item">The item.</param>
        void UpdateItem(Item item);

        /// <summary>
        /// Deletes the item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteItem(int id);
    }  
}
