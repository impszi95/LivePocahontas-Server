// <copyright file="IRepo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Database.DataLayer.Interfaces
{
    /// <summary>
    /// Interface for repository class
    /// </summary>
    public interface IRepo
    {
        /// <summary>
        /// Gets the user repository
        /// </summary>
        IRepoUser UserRepo { get; }

        /// <summary>
        /// Gets the content repository
        /// </summary>
        IRepoContent ContentRepo { get; }

        /// <summary>
        /// Gets the analytic repository
        /// </summary>
        IRepoAnalytics AnalyticsRepo { get; }
    }
}
