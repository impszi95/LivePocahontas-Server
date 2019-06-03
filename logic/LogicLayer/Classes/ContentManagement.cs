// <copyright file="ContentManagement.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Logic.LogicLayer.Classes
{
    using System;
    using System.Collections.Generic;
    using Database.DataLayer;
    using Database.DataLayer.Structures;
    using Interfaces;

    /// <summary>
    /// Manages contents
    /// </summary>
    public class ContentManagement : IContentManagement, IDisposable
    {
        /// <summary>
        /// Structure s
        /// </summary>
        private Repo repository;

        /// <summary>
        /// Structure s
        /// </summary>
        private bool disposedValue = false; // To detect redundant calls

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentManagement"/> class.
        /// </summary>
        public ContentManagement()
        {
            this.repository = new Repo();
        }

        /// <summary>
        /// Gets all contents
        /// </summary>
        public IEnumerable<Content> Contents
        {
            get
            {
                return this.repository.ContentRepo.GetAllContents();
            }
        }

        /// <summary>
        /// Create a new content
        /// </summary>
        /// <param name="name">Name of the content</param>
        /// <param name="file">Text of the content</param>
        /// <param name="userId">ID of the owner</param>
        public void CreateContent(string name, string file, int userId)
        {
            this.repository.ContentRepo.AddNewContent(name, file, userId);
        }

        /// <summary>
        /// Delete a content
        /// </summary>
        /// <param name="id">ID of the content</param>
        public void DeleteContent(int id)
        {
            this.repository.ContentRepo.DeleteContent(id);
        }

        /// <summary>
        /// Get all content for a user
        /// </summary>
        /// <param name="id">ID of the owner</param>
        /// <returns>All content for the user</returns>
        public IEnumerable<Content> GetContentsForUser(int id)
        {
            return this.repository.ContentRepo.GetContentByUserID(id);
        }

        /// <summary>
        /// This code added to correctly implement the disposable pattern.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Automatic dispose method
        /// </summary>
        /// <param name="disposing">Disposing parameter</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    this.repository.Dispose();
                }

                this.disposedValue = true;
            }
        }
    }
}
