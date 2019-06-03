// <copyright file="IAnalyticsManagement.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Logic.LogicLayer.Interfaces
{
    using System.Collections.Generic;
    using Database.DataLayer.Structures;

    /// <summary>
    /// Interface for the analytic management class
    /// </summary>
    public interface IAnalyticsManagement
    {
        /// <summary>
        /// Return all analytics for a user
        /// </summary>
        /// <param name="id">ID of the user</param>
        /// <returns>All analytics of the user</returns>
        IEnumerable<Analytic> GetAnalyticsForUser(int id);

        /// <summary>
        /// Create a new analytic if gift sent
        /// </summary>
        /// <param name="ownerId">ID of the owner</param>
        /// <param name="buyerId">ID of the sender</param>
        /// <param name="contentId">ID of the content</param>
        /// <param name="credit">Quantity of credit</param>
        void SendGift(int ownerId, int buyerId, int contentId, int credit);
    }
}
