using System.Collections.Generic;
using FiscusApi.Models;

namespace FiscusApi.Repositories.Interface
{
    public interface IGroupRepository  
    {
        /// <summary>
        /// Gets the groups.
        /// </summary>
        /// <returns>The groups.</returns>
        List<Group> GetGroups(); 

        /// <summary>
        /// Gets the group.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The group.</returns>
        Group GetGroup(int id);

        /// <summary>
        /// Adds the group.
        /// </summary>
        /// <param name="group">The group.</param>
        void AddGroup(Group group);

        /// <summary>
        /// Updates the group.
        /// </summary>
        /// <param name="group">The group.</param>
        void UpdateGroup(Group group);

        /// <summary>
        /// Deletes the group.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteGroup(int id);
    }  
}
