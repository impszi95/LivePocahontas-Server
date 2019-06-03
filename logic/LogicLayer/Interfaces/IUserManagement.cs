// <copyright file="IUserManagement.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Logic.LogicLayer.Interfaces
{
    using System.Collections.Generic;
    using Database.DataLayer.Structures;

    /// <summary>
    /// Interface for the user management class
    /// </summary>
    public interface IUserManagement
    {
        /// <summary>
        /// Gets all contents
        /// </summary>
        IEnumerable<User> Users { get; }

        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="name">Name of the user</param>
        /// <param name="password">Password of the user</param>
        void Registration(string name, string password);

        /// <summary>
        /// Add credit to a user
        /// </summary>
        /// <param name="id">ID of the user</param>
        /// <param name="credit">Quantity of credit</param>
        void AddCredit(int id, int credit);

        /// <summary>
        /// Check if user registered yet
        /// </summary>
        /// <param name="name">Name of the user</param>
        /// <param name="password">Password of the user</param>
        /// <returns>True if registered else False</returns>
        bool IsRegistrated(string name, string password);
    }
}
