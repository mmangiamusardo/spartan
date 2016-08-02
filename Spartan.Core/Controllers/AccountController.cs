using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;

using System.Security.Principal;

using Spartan.Service;
using Spartan.Domain;
using System.Net;

namespace Spartan.Core
{
    [Authorize]
    [RoutePrefix("api/Account")]
    public partial class AccountController : ApiController
    {
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public AccountController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }


        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return ResponseMessage(
                    Request.CreateResponse(
                     HttpStatusCode.BadRequest, ModelState.GetErrorStrings()));
            }

            try {

                var user = new ApplicationUser()
                {
                    UserName = model.Email,
                    Email = model.Email,
                };

                IdentityResult result = await UserManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                    return ResponseMessage(Request.CreateResponse(
                        HttpStatusCode.BadRequest, result.Errors));
                }

                //return Ok();
                //var response = Request.CreateResponse(HttpStatusCode.Created, result);
                var response = Request.CreateResponse(HttpStatusCode.Created, result);
                //var uri = new Uri(Url.Link("DefaultApi", new { Controller = "Account", id = "0" }));
                //response.Headers.Location = uri;
                return ResponseMessage(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }

        public void Dispose()
        {

        }
    }

}
