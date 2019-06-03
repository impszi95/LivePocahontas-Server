// <copyright file="IRepoAnalytics.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Database.DataLayer
{
    using System.Collections.Generic;
    using Structures;

    /// <summary>
    /// Interface for the analytic repository
    /// </summary>
    public interface IRepoAnalytics
    {
        /// <summary>
        /// Get all analytics
        /// </summary>
        /// <returns>All of the analytics</returns>
        IEnumerable<Analytic> GetAllAnalytics();

        /// <summary>
        /// Get one analytic by id
        /// </summary>
        /// <param name="id">ID of the analytic</param>
        /// <returns>Analytic object</returns>
        Analytic GetAnalyticByID(int id);

        /// <summary>
        /// Get analytics for a user
        /// </summary>
        /// <param name="ownerId">ID of the owner</param>
        /// <returns>Analytics for the user</returns>
        IEnumerable<Analytic> GetAnalyticsByOwnerID(int ownerId);

        /// <summary>
        /// Add a new analytic
        /// </summary>
        /// <param name="ownerId">ID of the owner</param>
        /// <param name="buyerId">ID of the buyer</param>
        /// <param name="contentId">ID of the content</param>
        /// <param name="credit">Quantity if the credit</param>
        void AddNewAnalytic(int ownerId, int buyerId, int contentId, int credit);
    }
}
