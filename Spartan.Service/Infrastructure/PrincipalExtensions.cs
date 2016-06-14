using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

using System.Security.Claims;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using Spartan.Domain;

namespace Spartan.Service
{
    public static class PrincipalExtended
    {
        public static int GetGuidUserId(this IIdentity identity)
        {
            return GetUserId(identity);
        }

        public static int GetUserId(this IIdentity _identity)
        {
            int _retVal = 0;
            try
            {
                if (_identity != null && _identity.IsAuthenticated)
                {
                    var ci = _identity as ClaimsIdentity;
                    string _userId = ci != null ? ci.FindFirstValue(ClaimTypes.NameIdentifier) : null;

                    if (!string.IsNullOrEmpty(_userId))
                    {
                        _retVal = int.Parse(_userId);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return _retVal;
        }

        public static bool HasPermission(this IPrincipal _principal, string _requiredPermission)
        {
            bool _retVal = false;
            try
            {
                if (_principal != null && _principal.Identity.IsAuthenticated)
                {
                    var ci = _principal.Identity as ClaimsIdentity;
                    string _userId = ci != null ? ci.FindFirstValue(ClaimTypes.NameIdentifier) : null;

                    if (!string.IsNullOrEmpty(_userId))
                    {
                        ApplicationUser _authenticatedUser = ApplicationUserManager.GetUser(int.Parse(_userId));
                        _retVal = _authenticatedUser.IsPermissionInUserRoles(_requiredPermission);
                    }
                }
            }
            catch (Exception)
            {
            }
            return _retVal;
        }

        public static bool IsSysAdmin(this IPrincipal _principal)
        {
            bool _retVal = false;
            try
            {
                if (_principal != null && _principal.Identity.IsAuthenticated)
                {
                    var ci = _principal.Identity as ClaimsIdentity;
                    string _userId = ci != null ? ci.FindFirstValue(ClaimTypes.NameIdentifier) : null;

                    if (!string.IsNullOrEmpty(_userId))
                    {
                        ApplicationUser _authenticatedUser = ApplicationUserManager.GetUser(int.Parse(_userId));
                        _retVal = _authenticatedUser.IsSysAdmin();
                    }
                }
            }
            catch (Exception)
            {
            }
            return _retVal;
        }


        public static string GetFirstValue(this ClaimsIdentity identity, string claimType)
        {
            return FindFirstValue(identity, claimType);
        }

        public static string FindFirstValue(this ClaimsIdentity identity, string claimType)
        {
            string _retVal = string.Empty;
            try
            {
                if (identity != null)
                {
                    var claim = identity.FindFirst(claimType);
                    _retVal = claim != null ? claim.Value : null;
                }
            }
            catch (Exception)
            {
            }
            return _retVal;
        }
    }
}
