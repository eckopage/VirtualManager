//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VM.DataAccessLayer.EDM
{
    using System;
    using System.Collections.Generic;
    
    public partial class CountryZoneTable
    {
        public CountryZoneTable()
        {
            this.UserDetails = new HashSet<UserDetails>();
        }
    
        public int Id { get; set; }
        public string CountryZoneName { get; set; }
    
        public virtual ICollection<UserDetails> UserDetails { get; set; }
    }
}
