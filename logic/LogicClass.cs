// <copyright file="LogicClass.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Logic
{
    using System;
    using Database.DataLayer;
    using LogicLayer.Classes;
    using LogicLayer.Interfaces;

    /// <summary>
    /// Contains all the logic
    /// </summary>
    public class LogicClass : ILogic, IDisposable
    {
        /// <summary>
        /// Structure s
        /// </summary>
        private UserManagement userManagement;

        /// <summary>
        /// Structure s
        /// </summary>
        private ContentManagement contentManagement;

        /// <summary>
        /// Structure s
        /// </summary>
        private AnalyticsManagement analyticsManagement;

        /// <summary>
        /// Structure s
        /// </summary>
        private bool disposedValue = false; // To detect redundant calls

        /// <summary>
        /// Initializes a new instance of the <see cref="LogicClass"/> class.
        /// </summary>
        public LogicClass()
        {
            this.userManagement = new UserManagement();
            this.contentManagement = new ContentManagement();
            this.analyticsManagement = new AnalyticsManagement();
        }

        /// <summary>
        /// Gets user management class
        /// </summary>
        public IUserManagement UserManagement
        {
            get
            {
                return this.userManagement;
            }
        }

        /// <summary>
        /// Gets content management class
        /// </summary>
        public IContentManagement ContentManagement
        {
            get
            {
                return this.contentManagement;
            }
        }

        /// <summary>
        /// Gets analytic management class
        /// </summary>
        public IAnalyticsManagement AnalyticsManagement
        {
            get
            {
                return this.analyticsManagement;
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
                    this.userManagement.Dispose();
                    this.contentManagement.Dispose();
                    this.analyticsManagement.Dispose();
                }

                this.disposedValue = true;
            }
        }
    }
}
