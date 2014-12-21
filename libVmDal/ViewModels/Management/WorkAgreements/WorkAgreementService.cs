using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.DataAccessLayer.Common;

namespace VM.DataAccessLayer.ViewModels.Management.WorkAgreements {
    public class WorkAgreementService: IWorkAgreementService {
        private IAppDatabaseContext _context;


        public WorkAgreementService(IAppDatabaseContext context) {
            _context = context;
        }

        /// <summary>
        /// Create agreement
        /// </summary>
        /// <param name="agreementModel">Agreement database model</param>
        public void CreateAgreement(WorkAgreementViewModel agreementModel) {
            using (var db = _context.CreateNewMainContext()) {
                var obj = db.WorkAgreementTable.Create();
                obj.Id = agreementModel.Id;
                obj.AgreeementType = agreementModel.AgreeementType;
                obj.AgreementTimeFrom = agreementModel.AgreementTimeFrom;
                obj.AgreementTimeTo = agreementModel.AgreementTimeTo;
                obj.Cost = agreementModel.Cost;
                obj.Description = agreementModel.Description;
                obj.IsActive = agreementModel.IsActive;
                obj.PerTime = agreementModel.PerTime;
                db.WorkAgreementTable.Add(obj);             
            }
        }

        /// <summary>
        /// Delete agreement by Id
        /// </summary>
        /// <param name="id">Agreement Id</param>
        public void DeleteAgreement(int id) {
            using (var db = _context.CreateNewMainContext()) {
                var res = db.WorkAgreementTable.FirstOrDefault(w => w.Id == id);
                if (res != null) {
                    db.WorkAgreementTable.Remove(res);
                }
            }
        }

        /// <summary>
        /// Update agreement
        /// </summary>
        /// <param name="workAgreementModel">agreement model</param>
        /// <returns>Agreement model</returns>
        public WorkAgreementViewModel UpdateAgreement(WorkAgreementViewModel workAgreementModel) {
            using (var db = _context.CreateNewMainContext()) {
                var result = db.WorkAgreementTable.Find(workAgreementModel.Id);
                if (result != null) {
                    db.Entry(result).CurrentValues.SetValues(workAgreementModel);
                    db.SaveChanges();
                    return workAgreementModel;
                }
                else {
                    return null;
                }
            }
        }

        public IEnumerable<WorkAgreementViewModel> GetAgreements() {
            var agrList = new List<WorkAgreementViewModel>();
            using (var db = _context.CreateNewMainContext()) {
                var res = db.WorkAgreementTable.OrderBy(x => x.Id).AsEnumerable();
                foreach (var item in res) {
                    var arg = new WorkAgreementViewModel {
                        Id = item.Id,
                        AgreeementType = item.AgreeementType,
                        AgreementTimeFrom = item.AgreementTimeFrom,
                        AgreementTimeTo = item.AgreementTimeFrom,
                        Cost = item.Cost,
                        Description = item.Description,
                        IsActive = item.IsActive,
                        PerTime = item.PerTime
                    };
                    agrList.Add(arg);
                }

                return agrList;
            }
        }

        public WorkAgreementViewModel GetAgreement(int id) {
            using (var db = _context.CreateNewMainContext()) {
                var res = db.WorkAgreementTable.FirstOrDefault(agr => agr.Id == id);
                if (res != null) {
                    var newModel = new WorkAgreementViewModel {
                        Id = res.Id,
                        AgreeementType = res.AgreeementType,
                        AgreementTimeFrom = res.AgreementTimeFrom,
                        AgreementTimeTo = res.AgreementTimeTo,
                        Cost = res.Cost,
                        Description = res.Description,
                        IsActive = res.IsActive,
                        PerTime = res.PerTime
                    };
                    return newModel;
                }
                else {
                    return null;    
                }
            }
        }

        public void AssignAgreementToUser(int agreementId, string userId) {
            throw new NotImplementedException();
        }

        public void UnAssignAgreementFromUser(int agreementId, string userId) {
            throw new NotImplementedException();
        }

        public void CreateAgreement() {
            throw new NotImplementedException();
        }
    }
}
