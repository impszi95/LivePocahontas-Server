// <copyright file="UserManagement.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Logic.LogicLayer.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Text;
    using Database.DataLayer;
    using Database.DataLayer.Structures;
    using Interfaces;

    /// <summary>
    /// Manages users
    /// </summary>
    public class UserManagement : IUserManagement, IDisposable
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
        /// Initializes a new instance of the <see cref="UserManagement"/> class.
        /// </summary>
        public UserManagement()
        {
            this.repository = new Repo();
        }

        /// <summary>
        /// Gets all contents
        /// </summary>
        public IEnumerable<User> Users
        {
            get
            {
                return this.repository.UserRepo.GetAllUsers();
            }
        }

        /// <summary>
        /// Add credit to a user
        /// </summary>
        /// <param name="id">ID of the user</param>
        /// <param name="credit">Quantity of the credit</param>
        public void AddCredit(int id, int credit)
        {
            this.repository.UserRepo.UpdateUser(id, credit);
        }

        /// <summary>
        /// Check if the user is registered yet
        /// </summary>
        /// <param name="name">Name of the user</param>
        /// <param name="password">Password of the user</param>
        /// <returns>True if registered else false</returns>
        public bool IsRegistrated(string name, string password)
        {
            return this.repository.UserRepo.GetUserByNameAndPassword(name, this.CalcHash(password)) != null ? true : false;
        }

        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="name">Name of the user</param>
        /// <param name="password">Password of the user</param>
        public void Registration(string name, string password)
        {
            password = this.CalcHash(password);

            if (!this.IsRegistrated(name, password))
            {
                this.repository.UserRepo.AddNewUser(name, password);
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
                    this.repository.Dispose();
                }

                this.disposedValue = true;
            }
        }

        /// <summary>
        /// Calculate a hash of the raw password
        /// </summary>
        /// <param name="password">Raw password</param>
        /// <returns>Hashed password</returns>
        private string CalcHash(string password)
        {
            var alg = SHA512.Create();
            try
            {
                alg.ComputeHash(Encoding.UTF8.GetBytes(password));
                string hashed_pw = BitConverter.ToString(alg.Hash);
                return hashed_pw;
            }
            finally
            {
                alg.Dispose();
            }
        }
    }
}
