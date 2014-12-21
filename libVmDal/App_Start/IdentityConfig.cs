using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using VM.DataAccessLayer.EDM;
using VM.DataAccessLayer.EDM.Accounts;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System;

namespace VM.DataAccessLayer.EDM.Accounts {
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class ApplicationUserManager : UserManager<AccountUserModel> {
        public ApplicationUserManager(IUserStore<AccountUserModel> store)
            : base(store) { }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context) {
            var manager = new ApplicationUserManager(new UserStore<AccountUserModel>(context.Get<AccountsDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new AccountUserValidator(manager) {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true,
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug in here.
            manager.RegisterTwoFactorProvider("PhoneCode", new PhoneNumberTokenProvider<AccountUserModel> {
                MessageFormat = "Your security code is: {0}"
            });
            manager.RegisterTwoFactorProvider("EmailCode", new EmailTokenProvider<AccountUserModel> {
                Subject = "Security Code",
                BodyFormat = "Your security code is: {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if(dataProtectionProvider != null) {
                manager.UserTokenProvider = new DataProtectorTokenProvider<AccountUserModel>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    public class EmailService : IIdentityMessageService {
        public Task SendAsync(IdentityMessage message) {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService {
        public Task SendAsync(IdentityMessage message) {
            // Plug in your sms service here to send a text message.
            return Task.FromResult(0);
        }
    }

    public class AccountUserValidator : UserValidator<AccountUserModel> {
        public AccountUserValidator(UserManager<AccountUserModel> manager) : base(manager) { }

        public async override Task<IdentityResult> ValidateAsync(AccountUserModel item) {
            var result = await base.ValidateAsync(item);

            // translate error message
            var translatedErrors = new List<string>();
            foreach(var errorItem in result.Errors)
                translatedErrors.Add(this.Translate(errorItem, item));

            if(translatedErrors.Any())
                result = new IdentityResult(translatedErrors);

            return result;
        }

        private string Translate(string text, AccountUserModel item) {
            if(text == string.Format("Name {0} is already taken.", item.Email))
                return string.Format("Nazwa użytkownika '{0}' jest już zajęta.", item.Email);
            else if(text == string.Format("Email '{0}' is already taken.", item.Email))
                return string.Format("Adres email '{0}' jest już zajęty.", item.Email);

            throw new Exception(string.Format("Validation: Unknown error message ({0})", text));
        }
    }
}
