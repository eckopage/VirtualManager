using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.DataAccessLayer.Common;

namespace VM.DataAccessLayer.ViewModels.Accounts.UserDetail {
    public class UserDetailService: IUserDetailService {
        private IAppDatabaseContext _context;

        public UserDetailService(IAppDatabaseContext context) { 
            _context = context;
        }

        public UserDetailViewModel GetUserDetali(string userId) {
            var db = _context.CreateNewMainContext();
            try {
                if (userId != null) {
                   var result = db.UserDetails.FirstOrDefault(u => u.UserId == userId);
                   var userDetailModel = new UserDetailViewModel {
                       UserId = result.UserId,
                       BankBillNo = result.BankBillNo,
                       BornDate = result.BornDate,
                       City = result.City,
                       Country = result.Country,
                       CountryZone = result.CountryZone,
                       Department = result.Department,
                       Gmina = result.Gmina,
                       NFZ_No = result.NFZ_No,
                       NoHome = result.NoHome,
                       NoLocal = result.NoLocal,
                       PESEL = result.PESEL,
                       PostalCode = result.PostalCode,
                       Street = result.Street,
                       SymbolUs = result.SymbolUs,
                       UrzadSkarbowyNazwa = result.UrzadSkarbowyNazwa,
                       UserEmailContact = result.UserEmailContact,
                       UserName = result.UserName,
                       UserSurname = result.UserSurname,
                       WorkersGroup = result.WorkersGroup
                   };

                   return userDetailModel;
                }
                return null;
            }
            catch (Exception ex) {              
                throw new Exception(ex.Message);
            }
        }

        public void UpdateUserDetails(UserDetailViewModel userModel) {
            var db = _context.CreateNewMainContext();
            try {
                var result = db.UserDetails.Find(userModel.UserId);
                db.Entry(result).CurrentValues.SetValues(userModel);
                db.SaveChanges();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteUserDetailForSpecifiedUserId(string userId) {
            throw new NotImplementedException();
        }
    }
}
