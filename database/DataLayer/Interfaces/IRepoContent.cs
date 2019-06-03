// <copyright file="IRepoContent.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Database.DataLayer
{
    using System.Collections.Generic;
    using Structures;

    /// <summary>
    /// Interface for the content repository
    /// </summary>
    public interface IRepoContent
    {
        /// <summary>
        /// Get all contents
        /// </summary>
        /// <returns>All of the contents</returns>
        IEnumerable<Content> GetAllContents();

        /// <summary>
        /// Get a content by id
        /// </summary>
        /// <param name="id">ID of the content</param>
        /// <returns>Content object</returns>
        Content GetContentByID(int id);

        /// <summary>
        /// Get all contents for a user
        /// </summary>
        /// <param name="userId">ID of the owner</param>
        /// <returns>Contents of the user</returns>
        IEnumerable<Content> GetContentByUserID(int userId);

        /// <summary>
        /// Add a new content
        /// </summary>
        /// <param name="name">Name of the content</param>
        /// <param name="file">Text of the file</param>
        /// <param name="userId">ID of the owner</param>
        void AddNewContent(string name, string file, int userId);

        /// <summary>
        /// Delete a content
        /// </summary>
        /// <param name="id">ID of the content</param>
        void DeleteContent(int id);
    }
}
