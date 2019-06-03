// <copyright file="IRepoUser.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Database.DataLayer
{
    using System.Collections.Generic;
    using Structures;

    /// <summary>
    /// Interface for the user repository
    /// </summary>
    public interface IRepoUser
    {
        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>All of the users</returns>
        IEnumerable<User> GetAllUsers();

        /// <summary>
        /// Get a user by id
        /// </summary>
        /// <param name="id">ID of the user</param>
        /// <returns>User object</returns>
        User GetUserByID(int id);

        /// <summary>
        /// Get user by name and password
        /// </summary>
        /// <param name="name">Name of the user</param>
        /// <param name="password">Password of the user</param>
        /// <returns>User object</returns>
        User GetUserByNameAndPassword(string name, string password);

        /// <summary>
        /// Add a new user
        /// </summary>
        /// <param name="name">Name of the user</param>
        /// <param name="password">PAssword of the user</param>
        void AddNewUser(string name, string password);

        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="id">ID of the user</param>
        /// <param name="name">Name of the user</param>
        /// <param name="password">Password of the user</param>
        /// <param name="credit">Quantity of the credit</param>
        void UpdateUser(int id, string name, string password, int credit);

        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="id">ID of the user</param>
        /// <param name="credit">Quantity of the credit</param>
        void UpdateUser(int id, int credit);
    }
}
