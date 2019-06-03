// <copyright file="AnalyticsManagement.cs" company="PlaceholderCompany">
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
    /// Manages analytics
    /// </summary>
    public class AnalyticsManagement : IAnalyticsManagement, IDisposable
    {
        private Repo repository;

        private bool disposedValue = false; // To detect redundant calls

        /// <summary>
        /// Initializes a new instance of the <see cref="AnalyticsManagement"/> class.
        /// </summary>
        public AnalyticsManagement()
        {
            this.repository = new Repo();
        }

        /// <summary>
        /// Get all analytics for one user
        /// </summary>
        /// <param name="id">ID of the user</param>
        /// <returns>IEnumareble analytic objects for the user</returns>
        public IEnumerable<Analytic> GetAnalyticsForUser(int id)
        {
            return this.repository.AnalyticsRepo.GetAnalyticsByOwnerID(id);
        }

        /// <summary>
        /// Add new analytic when someone send gift
        /// </summary>
        /// <param name="ownerId">ID of the owner</param>
        /// <param name="buyerId">ID of the sender</param>
        /// <param name="contentId">ID of the content</param>
        /// <param name="credit">Quantity of credit</param>
        public void SendGift(int ownerId, int buyerId, int contentId, int credit)
        {
            User owner = this.repository.UserRepo.GetUserByID(ownerId);
            User buyer = this.repository.UserRepo.GetUserByID(buyerId);

            if (buyer.Credit >= credit)
            {
                this.repository.UserRepo.UpdateUser(ownerId, credit);
                this.repository.UserRepo.UpdateUser(buyerId, -credit);
                this.repository.AnalyticsRepo.AddNewAnalytic(ownerId, buyerId, contentId, credit);
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
    }
}
