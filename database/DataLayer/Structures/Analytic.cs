// <copyright file="Analytic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Database.DataLayer.Structures
{
    using System;

    /// <summary>
    /// Structure for the analytic
    /// </summary>
    public class Analytic
    {
        /// <summary>
        ///  id s
        /// </summary>
        private decimal id;

        /// <summary>
        ///  owner s
        /// </summary>
        private USER owner;

        /// <summary>
        ///  buyer s
        /// </summary>
        private USER buyer;

        /// <summary>
        ///  content s
        /// </summary>
        private CONTENT content;

        /// <summary>
        ///  timestamp s
        /// </summary>
        private DateTime timestamp;

        /// <summary>
        ///  credit s
        /// </summary>
        private int credit;

        /// <summary>
        /// Gets or sets ID of the analytic
        /// </summary>
        public decimal Id
        {
            get
            {
                return this.id;
            }

            set
            {
                this.id = value;
            }
        }

        /// <summary>
        /// Gets or sets ownerID of the analytic
        /// </summary>
        public USER Owner
        {
            get
            {
                return this.owner;
            }

            set
            {
                this.owner = value;
            }
        }

        /// <summary>
        /// Gets or sets buyerID of the analytic
        /// </summary>
        public USER Buyer
        {
            get
            {
                return this.buyer;
            }

            set
            {
                this.buyer = value;
            }
        }

        /// <summary>
        /// Gets or sets contentID of the analytic
        /// </summary>
        public CONTENT Content
        {
            get
            {
                return this.content;
            }

            set
            {
                this.content = value;
            }
        }

        /// <summary>
        /// Gets or sets timestamp of the analytic
        /// </summary>
        public DateTime Timestamp
        {
            get
            {
                return this.timestamp;
            }

            set
            {
                this.timestamp = value;
            }
        }

        /// <summary>
        /// Gets or sets credit of the analytic
        /// </summary>
        public int Credit
        {
            get
            {
                return this.credit;
            }

            set
            {
                this.credit = value;
            }
        }
    }
}
