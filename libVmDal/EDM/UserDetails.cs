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
    using System.ComponentModel;
    
    public partial class UserDetails
    {
        public string UserId { get; set; }
        
        [DisplayName("Imi�")]
        public string UserName { get; set; }
        [DisplayName("Nazwisko")]
        public string UserSurname { get; set; }

        [DisplayName("Data urodzenia")]
        public Nullable<System.DateTime> BornDate { get; set; }

        public string PESEL { get; set; }

        [DisplayName("Pa�stwo")]
        public string Country { get; set; }

        [DisplayName("Wojew�dzto")]
        public Nullable<int> CountryZone { get; set; }
        public string Gmina { get; set; }

        [DisplayName("Ulica")]
        public string Street { get; set; }

        [DisplayName("Numer domu")]
        public string NoHome { get; set; }

        [DisplayName("Numer mieszkania")]
        public string NoLocal { get; set; }

        [DisplayName("Miasto")]
        public string City { get; set; }

        [DisplayName("Kod pocztowy")]
        public string PostalCode { get; set; }

        [DisplayName("Urz�d skarbowy")]
        public string UrzadSkarbowyNazwa { get; set; }
        public string SymbolUs { get; set; }

        [DisplayName("Email")]
        public string UserEmailContact { get; set; }

        [DisplayName("Nr konta bankowego")]
        public string BankBillNo { get; set; }

        [DisplayName("Oddzie� NFZ nr")]
        public string NFZ_No { get; set; }

        [DisplayName("Stanowisko")]
        public int WorkersGroup { get; set; }

        [DisplayName("Oddzia�")]
        public Nullable<int> Department { get; set; }
    
        public virtual AccountTable AccountTable { get; set; }
        public virtual DepartmentTable DepartmentTable { get; set; }
        public virtual WorkerGroupTable WorkerGroupTable { get; set; }
        public virtual CountryZoneTable CountryZoneTable { get; set; }
    }
}