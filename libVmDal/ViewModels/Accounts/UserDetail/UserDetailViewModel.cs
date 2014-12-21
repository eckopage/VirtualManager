using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM.DataAccessLayer.ViewModels.Accounts.UserDetail {
    public class UserDetailViewModel {

        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public Nullable<System.DateTime> BornDate { get; set; }
        public string PESEL { get; set; }
        public string Country { get; set; }
        public Nullable<int> CountryZone { get; set; }
        public string Gmina { get; set; }
        public string Street { get; set; }
        public string NoHome { get; set; }
        public string NoLocal { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string UrzadSkarbowyNazwa { get; set; }
        public string SymbolUs { get; set; }
        public string UserEmailContact { get; set; }
        public string BankBillNo { get; set; }
        public string NFZ_No { get; set; }
        public int WorkersGroup { get; set; }
        public Nullable<int> Department { get; set; }

    }
}
