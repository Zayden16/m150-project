using System.Collections.Generic;
using FiscusApi.Models;

namespace FiscusApi.Repositories.Interface
{
    public interface ICategoryRepository  
    {
        /// <summary>
        /// Gets the categories.
        /// </summary>
        /// <returns>The categories.</returns>
        List<Category> GetCategories(); 
        
        /// <summary>
        /// Gets the category.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The category.</returns>
        Category GetCategory(int id);

        /// <summary>
        /// Adds the category.
        /// </summary>
        /// <param name="category">The category.</param>
        void AddCategory(Category category);

        /// <summary>
        /// Updates the category.
        /// </summary>
        /// <param name="category">The category.</param>
        void UpdateCategory(Category category);

        /// <summary>
        /// Deletes the category.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteCategory(int id);
    }  
}
