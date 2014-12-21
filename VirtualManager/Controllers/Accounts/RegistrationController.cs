using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using VM.DataAccessLayer.Common;
using VM.DataAccessLayer.EDM;
using VM.DataAccessLayer.EDM.Accounts;
using VM.DataAccessLayer.ViewModels.Accounts.Registration;

namespace VirtualManager.Controllers.Accounts {
    /// <summary>
    /// Represent controller to manage registration views.
    /// <remarks>
    /// Registration is based on 3 steps:
    /// 1. Register email
    /// 2. Confirm account from email link.
    /// 3. Setup password for the user.
    /// </remarks>
    /// </summary>
    [Authorize]
    public class RegistrationController : CommonController {
        #region Constructors

        public RegistrationController() { }

        public RegistrationController(ApplicationUserManager userManager) {
            this.UserManager = userManager;
        }

        #endregion Constructors

        public ApplicationUserManager UserManager {
            get { return _userManager ?? this.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }
        private ApplicationUserManager _userManager;

        /// <summary>
        /// Gets registration page to let user to input email and captcha.
        /// This is the first step of registering the user.
        /// <remarks>
        /// GET: /Registration/Register
        /// </remarks>
        /// </summary>
        /// <returns>Registration page</returns>
        [AllowAnonymous]
        public ActionResult Register() {
            var viewName = "~/Views/Account/Registration/Register.cshtml";
            this.ViewBag.PublicKey = ConfigurationManager.AppSettings["ReCaptchaPublicKey"];
            return this.View(viewName);
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model) {
            var viewName = "~/Views/Account/Registration/Register.cshtml";
            this.ViewBag.Email = null;
            // TODO: this method is unfinished, it needs changes related to other tasks, this commented out code could be helpfull later

            // this two lines are just temporary
           // var context = new VirtualManagerDatabaseContainer();
          //  var users = context.AccountTable.ToList();

            if(this.ModelState.IsValid) {
                var user = new AccountUserModel(model.Email);
                var password = Guid.NewGuid().ToString();
                password = password.Replace("-", string.Empty).Substring(0, 6);
                var result = await this.UserManager.CreateAsync(user, password);

                if(result.Succeeded) {
                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    await UserManager.SendEmailAsync(user.Id, "Aktywacja konta", "Jeśli chcesz dokończyć procedurę rejestracji kliknij ten <a href=\"" + callbackUrl + "\">tutaj</a>");
                    await UserManager.ConfirmEmailAsync(user.Id, callbackUrl);
#if DEBUG
                    this.ViewBag.IsDebug = true;
                    this.ViewBag.CallbackUrl = callbackUrl;
#else
                    this.ViewBag.IsDebug = false;
#endif
                    this.ViewBag.Email = model.Email;
                    return this.View(viewName);
                }
                else {
                    // since at this point email is equal to user name, user name error messages are redundant
                    if(result.Errors.Any(a => a.StartsWith("Nazwa użytkownika"))) {
                        var errors = result.Errors.Where(a => a.StartsWith("Nazwa użytkownika"));
                        result = new IdentityResult(errors);
                    }

                    this.AddErrors(result.Errors);
                }
            }

            // if we got this far, something failed, redisplay form
            return this.View(viewName, model);
        }
    }
}