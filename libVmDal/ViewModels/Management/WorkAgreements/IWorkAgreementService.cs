using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.DataAccessLayer.Common;
using VM.DataAccessLayer.ViewModels.Management.HumanResources;

namespace VM.DataAccessLayer.ViewModels.Management.WorkAgreements {
    public interface IWorkAgreementService:IService {

        void CreateAgreement();
        void DeleteAgreement(int id);
        WorkAgreementViewModel UpdateAgreement(WorkAgreementViewModel workAgreementModel);
        IEnumerable<WorkAgreementViewModel> GetAgreements();
        WorkAgreementViewModel GetAgreement(int id);
        void AssignAgreementToUser(int agreementId, string userId);
        void UnAssignAgreementFromUser(int agreementId, string userId);     
    }
}
