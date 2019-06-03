// <copyright file="ILogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Database.DataLayer
{
    using Logic.LogicLayer.Interfaces;

    /// <summary>
    /// Interface for the logic class
    /// </summary>
    public interface ILogic
    {
        /// <summary>
        /// Gets a user management class
        /// </summary>
        IUserManagement UserManagement { get; }

        /// <summary>
        /// Gets a content management class
        /// </summary>
        IContentManagement ContentManagement { get; }

        /// <summary>
        /// Gets a analytic management class
        /// </summary>
        IAnalyticsManagement AnalyticsManagement { get; }
    }
}
