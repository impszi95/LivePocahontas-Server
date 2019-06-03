// <copyright file="Content.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Database.DataLayer.Structures
{
    /// <summary>
    /// Structure for the content
    /// </summary>
    public class Content
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
        private string file;

        /// <summary>
        /// Structure s
        /// </summary>
        private USER user;

        /// <summary>
        /// Gets or sets name of the content
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
        /// Gets or sets id of the content
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
        /// Gets or sets file of the content
        /// </summary>
        public string File
        {
            get
            {
                return this.file;
            }

            set
            {
                this.file = value;
            }
        }

        /// <summary>
        /// Gets or sets user of the content
        /// </summary>
        public USER User
        {
            get
            {
                return this.user;
            }

            set
            {
                this.user = value;
            }
        }
    }
}
