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
    
    public partial class AccountTable
    {
        public AccountTable()
        {
            this.AccountClaimsTable = new HashSet<AccountClaimsTable>();
            this.AccountLoginTable = new HashSet<AccountLoginTable>();
            this.AccountUserRoleTable = new HashSet<AccountUserRoleTable>();
            this.PaymentTable = new HashSet<PaymentTable>();
            this.ProjectUserAssociateTable = new HashSet<ProjectUserAssociateTable>();
        }
    
        public string Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public string Discriminator { get; set; }
    
        public virtual ICollection<AccountClaimsTable> AccountClaimsTable { get; set; }
        public virtual ICollection<AccountLoginTable> AccountLoginTable { get; set; }
        public virtual ICollection<AccountUserRoleTable> AccountUserRoleTable { get; set; }
        public virtual ICollection<PaymentTable> PaymentTable { get; set; }
        public virtual ICollection<ProjectUserAssociateTable> ProjectUserAssociateTable { get; set; }
        public virtual UserDetails UserDetails { get; set; }
    }
}
