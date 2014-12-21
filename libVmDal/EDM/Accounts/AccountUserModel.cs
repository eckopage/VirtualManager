using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace VM.DataAccessLayer.EDM {
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public partial class AccountUserModel : IdentityUser {
        #region Constructors

        public AccountUserModel()
            : base() {

        }

        public AccountUserModel(string username)
            : this() {
            this.UserName = username;
            this.Email = username;
        } 

        #endregion Constructors

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AccountUserModel> manager) {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}