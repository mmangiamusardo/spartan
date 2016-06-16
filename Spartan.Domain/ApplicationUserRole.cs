using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Spartan.Domain
{
    /// <summary>
    /// The ApplicationUserRole class inherits from IdentityUserRole and 
    /// defines additional methods as IsPermissionInRole and IsSysAdmin
    /// </summary>
    public class ApplicationUserRole : IdentityUserRole<int>
    {
        public ApplicationUserRole() : base() { }

        /// <summary>
        /// Relates to ApplicationRole
        /// </summary>
        public virtual ApplicationRole Role { get; set; }

        /// <summary>
        /// Relates to ApplicationUser
        /// </summary>
        public virtual ApplicationUser User { get; set; }

        public bool IsPermissionInRole(string _permission)
        {
            bool _retVal = false;
            try
            {
                _retVal = this.Role.IsPermissionInRole(_permission);
            }
            catch (Exception)
            {
            }
            return _retVal;
        }
        public bool IsSysAdmin
        {
            get {
                return this.Role.IsSysAdmin;
            }
        }
    }
}
