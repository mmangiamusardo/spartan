using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Spartan.Domain
{
    /// <summary>
    /// ApplicationUser inherits from IdentityUser
    /// EF builds a new table adding new fields and those one from default IdentityUser.
    /// Primary Key is an integer. It hides defaults GUID (string) PK used by IdentityUser
    /// </summary>
    public class ApplicationUser : IdentityUser<int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public DateTime LastModified { get; set; }

        public bool Inactive { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public ApplicationUser()
        {
            LastModified = DateTime.Now;
            Inactive = false;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="authenticationType"></param>
        /// <returns></returns>
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, int> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_permission"></param>
        /// <returns></returns>
        public bool IsPermissionInUserRoles(string _permission)
        {
            bool _retVal = false;
            try
            {
                foreach (ApplicationUserRole _role in this.Roles)
                {
                    if (_role.IsPermissionInRole(_permission))
                    {
                        _retVal = true;
                        break;
                    }
                }
            }
            catch (Exception)
            {
            }
            return _retVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsSysAdmin()
        {
            bool _retVal = false;
            try
            {
                foreach (ApplicationUserRole _role in this.Roles)
                {
                    if (_role.IsSysAdmin)
                    {
                        _retVal = true;
                        break;
                    }
                }
            }
            catch (Exception)
            {
            }
            return _retVal;
        }
    }
}