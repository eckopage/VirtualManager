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
    
    public partial class PaymentTable
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string UserId { get; set; }
        public int WorkAgreementId { get; set; }
    
        public virtual AccountTable AccountTable { get; set; }
        public virtual ProjectTable ProjectTable { get; set; }
        public virtual WorkAgreementTable WorkAgreementTable { get; set; }
    }
}
