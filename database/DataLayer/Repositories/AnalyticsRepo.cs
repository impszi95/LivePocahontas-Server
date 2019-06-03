// <copyright file="AnalyticsRepo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Database.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Structures;

    /// <summary>
    /// Repository for the analytics
    /// </summary>
    public class AnalyticsRepo : IRepoAnalytics, IDisposable
    {
        /// <summary>
        /// Uniqe ID
        /// </summary>
        private dbEntities entities;

        /// <summary>
        /// disposed Value
        /// </summary>
        private bool disposedValue = false; // To detect redundant calls

        /// <summary>
        /// Initializes a new instance of the <see cref="AnalyticsRepo"/> class.
        /// </summary>
        public AnalyticsRepo()
        {
            this.entities = new dbEntities();
        }

        /// <summary>
        /// Get all analytics
        /// </summary>
        /// <returns>List of analytics</returns>
        public IEnumerable<Analytic> GetAllAnalytics()
        {
            return this.entities.ANALYTICS.Select(e => new Analytic
            {
                Id = e.uniqueID,
                Owner = e.USER1,
                Buyer = e.USER,
                Content = e.CONTENT,
                Timestamp = (DateTime)e.timestamp,
                Credit = (int)e.credit
            }).ToList();
        }

        /// <summary>
        /// Get analytic by id
        /// </summary>
        /// <param name="id">ID of analytic</param>
        /// <returns>Analytic object</returns>
        public Analytic GetAnalyticByID(int id)
        {
            return this.entities.ANALYTICS.Where(e => e.uniqueID == id).Select(e => new Analytic
            {
                Id = e.uniqueID,
                Owner = e.USER1,
                Buyer = e.USER,
                Content = e.CONTENT,
                Timestamp = (DateTime)e.timestamp,
                Credit = (int)e.credit
            }).First();
        }

        /// <summary>
        /// Get analytics for a user
        /// </summary>
        /// <param name="ownerId">ID of the owner</param>
        /// <returns>List of analytics</returns>
        public IEnumerable<Analytic> GetAnalyticsByOwnerID(int ownerId)
        {
            return this.entities.ANALYTICS.Where(e => e.ownerID == ownerId).Select(e => new Analytic
            {
                Id = e.uniqueID,
                Owner = e.USER1,
                Buyer = e.USER,
                Content = e.CONTENT,
                Timestamp = (DateTime)e.timestamp,
                Credit = (int)e.credit
            }).ToList();
        }

        /// <summary>
        /// Add a new analytic
        /// </summary>
        /// <param name="ownerId">ID of the owner</param>
        /// <param name="buyerId">ID of the buyer</param>
        /// <param name="contentId">ID of the content</param>
        /// <param name="credit">Quantity of the credit</param>
        public void AddNewAnalytic(int ownerId, int buyerId, int contentId, int credit)
        {
            var newAnalytic = new ANALYTICS()
            {
                ownerID = ownerId,
                buyerID = buyerId,
                contentID = contentId,
                credit = credit,
                timestamp = DateTime.Now
            };
            this.entities.ANALYTICS.Add(newAnalytic);
            this.entities.SaveChanges();
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
