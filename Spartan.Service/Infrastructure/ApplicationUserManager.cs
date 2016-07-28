using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using Spartan.Domain;
using Spartan.Data;
using Microsoft.Owin.Security.DataProtection;

namespace Spartan.Service
{
    /// <summary>
    /// Configure the application user manager used in this application.
    /// UserManager is defined in ASP.NET Identity and is used by the application.
    /// UserManager manages instances of the ApplicationUser
    /// </summary>
    public class ApplicationUserManager : UserManager<ApplicationUser, int>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser,int> store, IDataProtectionProvider dataProtectionProvider)
        : base(store)
        {
       
            // Configure validation logic for usernames
            this.UserValidator = new UserValidator<ApplicationUser, int>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            this.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            
            /*
            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = RBAC_ExtendedMethods.GetConfigSettingAsBool(RBAC_ExtendedMethods.cKey_UserLockoutEnabled);
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(RBAC_ExtendedMethods.GetConfigSettingAsDouble(RBAC_ExtendedMethods.cKey_AccountLockoutTimeSpan));
            manager.MaxFailedAccessAttemptsBeforeLockout = RBAC_ExtendedMethods.GetConfigSettingAsInt(RBAC_ExtendedMethods.cKey_MaxFailedAccessAttemptsBeforeLockout);

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser, int>
            {
                MessageFormat = "Your security code is {0}"
            });

            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser, int>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });

            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            */

            if (dataProtectionProvider != null)
            {
                this.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser, int>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
        }

        public static ApplicationUser GetUser(int _userId)
        {
            // TODO
            return new ApplicationUser();
        }

        public static ApplicationUser GetUser(SpartanEntitiesContext db, int _userId)
        {
            // TODO
            return new ApplicationUser();
        }
    }
}
