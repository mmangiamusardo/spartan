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
    /// ApplicationRole inherits from IdentityRole
    /// </summary>
    public class ApplicationRole : IdentityRole<int, ApplicationUserRole>
    {
        public ApplicationRole()
        {
            //this.Id = Guid.NewGuid().ToString();
            //ApplicationUserRoles = new List<ApplicationUserRole>();
        }

        public ApplicationRole(string name)
            : this()
        {
            this.Name = name;
        }

        public ApplicationRole(string name, string description) : this(name)
        {
            this.RoleDescription = description;
        }

        public DateTime LastModified { get; set; }

        /// <summary>
        /// A Role associates to many UserRoles
        /// </summary>
        //public int ApplicationUserRoleId { get; set; }
        //public virtual ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }

        /// <summary>
        /// IsSysAdmin is mandatory requirement in order to determine resource authorizations
        /// </summary>
        public bool IsSysAdmin { get; set; }

        /// <summary>
        /// Description of Role
        /// </summary>
        public string RoleDescription { get; set; }

        /// <summary>
        /// A role contains a list of permission
        /// </summary>
        public virtual ICollection<Permission> Permissions { get; set; }

        /// <summary>
        /// Checks if Roles has Permission
        /// </summary>
        /// <param name="permDescr">Description of Permission</param>
        /// <returns></returns>
        public bool IsPermissionInRole(string permDescr)
        {
            bool _retVal = false;
            try
            {
                foreach (var p in this.Permissions)
                {
                    if (p.Descr == permDescr)
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
