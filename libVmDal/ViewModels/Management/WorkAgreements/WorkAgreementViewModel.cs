using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM.DataAccessLayer.ViewModels.Management.WorkAgreements {
    public class WorkAgreementViewModel {
        public int Id { get; set; }
        public string AgreeementType { get; set; }
        public Nullable<int> Cost { get; set; }
        public string PerTime { get; set; }
        public Nullable<System.DateTime> AgreementTimeFrom { get; set; }
        public Nullable<System.DateTime> AgreementTimeTo { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

    }
}
