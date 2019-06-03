// <copyright file="User.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Database.DataLayer.Structures
{
    /// <summary>
    /// Structure for the user
    /// </summary>
    public class User
    {
        /// <summary>
        /// Structure s
        /// </summary>
        private string name;

        /// <summary>
        /// Structure s
        /// </summary>
        private decimal id;

        /// <summary>
        /// Structure s
        /// </summary>
        private int credit;

        /// <summary>
        /// Gets or sets name of the user
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        /// <summary>
        /// Gets or sets id of the user
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
        /// Gets or sets credit of the user
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
