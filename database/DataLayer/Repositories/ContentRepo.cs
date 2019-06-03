// <copyright file="ContentRepo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Database.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Structures;

    /// <summary>
    /// Repository for contents
    /// </summary>
    public class ContentRepo : IRepoContent, IDisposable
    {
        /// <summary>
        /// entities s
        /// </summary>
        private dbEntities entities;

        /// <summary>
        /// disposed Value
        /// </summary>
        private bool disposedValue = false; // To detect redundant calls

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentRepo"/> class.
        /// </summary>
        public ContentRepo()
        {
            this.entities = new dbEntities();
        }

        /// <summary>
        /// Get all contents
        /// </summary>
        /// <returns>All of the contents</returns>
        public IEnumerable<Content> GetAllContents()
        {
            return this.entities.CONTENT.Select(e => new Content
            {
                Name = e.name,
                Id = e.uniqueID,
                File = e.file,
                User = e.USER
            }).ToList();
        }

        /// <summary>
        /// Get content by id
        /// </summary>
        /// <param name="id">ID of the content</param>
        /// <returns>Content object</returns>
        public Content GetContentByID(int id)
        {
            return this.entities.CONTENT.Where(e => e.uniqueID == id).Select(e => new Content
            {
                Name = e.name,
                Id = e.uniqueID,
                File = e.file,
                User = e.USER
            }).First();
        }

        /// <summary>
        /// Get contents for a user
        /// </summary>
        /// <param name="userId">ID of the user</param>
        /// <returns>List of contents</returns>
        public IEnumerable<Content> GetContentByUserID(int userId)
        {
            return this.entities.CONTENT.Where(e => e.userID == userId).Select(e => new Content
            {
                Name = e.name,
                Id = e.uniqueID,
                File = e.file,
                User = e.USER
            }).ToList();
        }

        /// <summary>
        /// Add a new content
        /// </summary>
        /// <param name="name">Name of the content</param>
        /// <param name="file">Text of the content</param>
        /// <param name="userId">ID of the owner</param>
        public void AddNewContent(string name, string file, int userId)
        {
            var newContent = new CONTENT()
            {
                name = name,
                file = file,
                userID = userId
            };
            this.entities.CONTENT.Add(newContent);
            this.entities.SaveChanges();
        }

        /// <summary>
        /// Delete a content
        /// </summary>
        /// <param name="id">ID of the content</param>
        public void DeleteContent(int id)
        {
            try
            {
                var content = this.entities.CONTENT.Single(x => x.uniqueID == id);

                this.entities.CONTENT.Remove(content);
                this.entities.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("The content is not exists.");
            }
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
                    this.entities.Dispose();
                }

                this.disposedValue = true;
            }
        }
    }
}
