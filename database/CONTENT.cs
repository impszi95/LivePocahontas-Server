//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Database
{
    using System;
    using System.Collections.Generic;

    /// \f[
    /// T_{max}&lt;
    /// \f]
    public partial class CONTENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]

        public CONTENT()
        {
            this.ANALYTICS = new HashSet<ANALYTICS>();
        }
        /// <summary>
        /// UniqeID
        /// </summary>
        public decimal uniqueID { get; set; }

        /// <summary>
        /// userID
        /// </summary>
        public decimal userID { get; set; }

        /// <summary>
        /// name
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// file
        /// </summary>
        public string file { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        /// <summary>
        /// ANALYTICS s
        /// </summary>
        public virtual ICollection<ANALYTICS> ANALYTICS { get; set; }

        /// <summary>
        /// USER
        /// </summary>
        public virtual USER USER { get; set; }
    }
}