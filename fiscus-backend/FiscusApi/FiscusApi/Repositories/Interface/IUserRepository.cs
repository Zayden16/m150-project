using System.Collections.Generic;
using FiscusApi.Models;

namespace FiscusApi.Repositories.Interface
{
    public interface IUserRepository  
    {
        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns>The users.</returns>
        List<User> GetUsers();

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The user.</returns>
        User GetUser(int id);

        /// <summary>
        /// Gets the user by username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>The user.</returns>
        User GetUserByUsername(string username);

        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="user">The user.</param>
        void AddUser(User user);

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        void UpdateUser(User user);

        /// <summary>
        /// Deletes a User.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteUser(int id);

        IEnumerable<User> GetUsersByGroupId(int groupId);
    }
}
