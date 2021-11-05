using System.Collections.Generic;
using FiscusApi.Models;

namespace FiscusApi.Repositories.Interface
{
    public interface IShoppingListRepository  
    {
        /// <summary>
        /// Gets the shopping lists.
        /// </summary>
        /// <returns>The shopping lists.</returns>
        List<ShoppingList> GetShoppingLists();  

        /// <summary>
        /// Gets the shopping list.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The shopping list.</returns>
        ShoppingList GetShoppingList(int id);

        /// <summary>
        /// Adds the shopping list.
        /// </summary>
        /// <param name="shoppingList">The shopping list.</param>
        void AddShoppingList(ShoppingList shoppingList);

        /// <summary>
        /// Updates the shopping list.
        /// </summary>
        /// <param name="shoppingList">The shopping list.</param>
        void UpdateShoppingList(ShoppingList shoppingList);

        /// <summary>
        /// Deletes the shopping list.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteShoppingList(int id);
    }  
}