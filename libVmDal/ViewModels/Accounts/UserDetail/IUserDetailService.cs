using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.DataAccessLayer.Common;

namespace VM.DataAccessLayer.ViewModels.Accounts.UserDetail {
    public interface IUserDetailService: IService {

        /// <summary>
        /// Get User detail by user ID
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns>UserDetail Model</returns>
        UserDetail.UserDetailViewModel GetUserDetali(string userId);

        /// <summary>
        /// Update User Details
        /// </summary>
        /// <param name="userId"></param>
        void UpdateUserDetails(UserDetailViewModel userModel);

        /// <summary>
        /// Delete details
        /// </summary>
        /// <param name="userId"></param>
        void DeleteUserDetailForSpecifiedUserId(string userId);
    }
}
