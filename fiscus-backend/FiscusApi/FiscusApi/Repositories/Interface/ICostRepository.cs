using System.Collections.Generic;
using FiscusApi.Models;

namespace FiscusApi.Repositories.Interface
{
    public interface ICostRepository  
    {
        /// <summary>
        /// Gets the cost.
        /// </summary>
        /// <returns>The costs.</returns>
        IEnumerable<Cost> GetCosts(); 

        /// <summary>
        /// Gets the cost.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The cost.</returns>
        Cost GetCost(int id);
        
        /// <summary>
        /// Get Costs by Group Id
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        IEnumerable<Cost> GetCostsByGroupId(int groupId);

        /// <summary>
        /// Adds the cost.
        /// </summary>
        /// <param name="cost">The cost.</param>
        void AddCost(Cost cost);

        /// <summary>
        /// Updates the cost.
        /// </summary>
        /// <param name="cost">The cost.</param>
        void UpdateCost(Cost cost);

        /// <summary>
        /// Deletes the cost.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteCost(int id);
    }  
}
