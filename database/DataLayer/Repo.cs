// <copyright file="Repo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Database.DataLayer
{
    using System;
    using Interfaces;

    /// <summary>
    /// Contains all repositories
    /// </summary>
    public class Repo : IRepo, IDisposable
    {
        /// <summary>
        /// User Repo
        /// </summary>
        private UserRepo userRepo;

        /// <summary>
        /// Content Repo
        /// </summary>
        private ContentRepo contentRepo;

        /// <summary>
        /// Analytcs Repo
        /// </summary>
        private AnalyticsRepo analyticsRepo;

        /// <summary>
        /// disposed Value
        /// </summary>
        private bool disposedValue = false; // To detect redundant calls

        /// <summary>
        /// Initializes a new instance of the <see cref="Repo"/> class.
        /// </summary>
        public Repo()
        {
            this.userRepo = new UserRepo();
            this.contentRepo = new ContentRepo();
            this.analyticsRepo = new AnalyticsRepo();
        }

        /// <summary>
        /// Gets analytic repo
        /// </summary>
        public IRepoAnalytics AnalyticsRepo
        {
            get
            {
                return this.analyticsRepo;
            }
        }

        /// <summary>
        /// Gets content repo
        /// </summary>
        public IRepoContent ContentRepo
        {
            get
            {
                return this.contentRepo;
            }
        }

        /// <summary>
        /// Gets user repo
        /// </summary>
        public IRepoUser UserRepo
        {
            get
            {
                return this.userRepo;
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
                    this.userRepo.Dispose();
                    this.contentRepo.Dispose();
                    this.analyticsRepo.Dispose();
                }

                this.disposedValue = true;
            }
        }
    }
}
