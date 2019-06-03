// <copyright file="IContentManagement.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Logic.LogicLayer.Interfaces
{
    using System.Collections.Generic;
    using Database.DataLayer.Structures;

    /// <summary>
    /// Interface for the contet management class
    /// </summary>
    public interface IContentManagement
    {
        /// <summary>
        /// Gets all contents
        /// </summary>
        IEnumerable<Content> Contents { get; }

        /// <summary>
        /// Get all contents for a user
        /// </summary>
        /// <param name="id">ID of the user</param>
        /// <returns>All contents for the user</returns>
        IEnumerable<Content> GetContentsForUser(int id);

        /// <summary>
        /// Create a new content
        /// </summary>
        /// <param name="name">Name of the content</param>
        /// <param name="file">Text of the content</param>
        /// <param name="userId">ID of the owner</param>
        void CreateContent(string name, string file, int userId);

        /// <summary>
        /// Delete a content
        /// </summary>
        /// <param name="id">ID of the content</param>
        void DeleteContent(int id);
    }
}
