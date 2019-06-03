// <copyright file="UserRepo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Database.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Structures;

    /// <summary>
    /// Repository for the users
    /// </summary>
    public class UserRepo : IRepoUser, IDisposable
    {
        /// <summary>
        /// entities for the users
        /// </summary>
        private dbEntities entities;

        /// <summary>
        /// entities for the users
        /// </summary>
        private bool disposedValue = false; // To detect redundant calls

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepo"/> class.
        /// </summary>
        public UserRepo()
        {
            this.entities = new dbEntities();
        }

        /// <summary>
        /// Gets all the users
        /// </summary>
        /// <returns>All the users</returns>
        public IEnumerable<User> GetAllUsers()
        {
            return this.entities.USER.Select(e => new User
            {
                Name = e.username,
                Id = e.uniqueID,
                Credit = (int)e.credit
            }).ToList();
        }

        /// <summary>
        /// Get a user by its id
        /// </summary>
        /// <param name="id">ID of the user</param>
        /// <returns>User object</returns>
        public User GetUserByID(int id)
        {
            return this.entities.USER.Where(e => e.uniqueID == id).Select(e => new User
            {
                Name = e.username,
                Id = e.uniqueID,
                Credit = (int)e.credit
            }).First();
        }

        /// <summary>
        /// Add a new user
        /// </summary>
        /// <param name="name">Name of the user</param>
        /// <param name="password">Password of the user</param>
        public void AddNewUser(string name, string password)
        {
            var newUser = new USER()
            {
                username = name,
                password = password,
                credit = 500,
            };
            this.entities.USER.Add(newUser);
            this.entities.SaveChanges();
        }

        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="id">ID of the user</param>
        /// <param name="name">Name of the user</param>
        /// <param name="password">Password of the user</param>
        /// <param name="credit">Quantity of credit</param>
        public void UpdateUser(int id, string name, string password, int credit)
        {
            var user = this.entities.USER.Single(x => x.uniqueID == id);

            user.username = name;
            user.password = password;
            user.credit = credit;

            this.entities.SaveChanges();
        }

        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="id">ID of the user</param>
        /// <param name="credit">Quantity of credit</param>
        public void UpdateUser(int id, int credit)
        {
            var user = this.entities.USER.Single(x => x.uniqueID == id);

            user.credit += credit;

            this.entities.SaveChanges();
        }

        /// <summary>
        /// Get a user by name and password
        /// </summary>
        /// <param name="name">Name of the user</param>
        /// <param name="password">Password of the user</param>
        /// <returns>User object</returns>
        public User GetUserByNameAndPassword(string name, string password)
        {
            try
            {
                var user = this.entities.USER.Single(x => x.username == name && x.password == password);
                return new User() { Name = user.username, Id = user.uniqueID, Credit = (int)user.credit };
            }
            catch (System.InvalidOperationException)
            {
                return null;
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
