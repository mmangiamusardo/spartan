using System;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Spartan.Domain;
using Spartan.Service;

namespace Spartan.Core.Controllers
{
    [Authorize]
    public class GymsController : ApiController
    {
        private IGymService gymService;

        public GymsController(IGymService gymService)
        {
            this.gymService = gymService;
        }

        public IHttpActionResult PostGym(Gym gym)
        {
            if (!ModelState.IsValid)
            {
                return ResponseMessage(Request.CreateResponse(
                     HttpStatusCode.BadRequest, ModelState.GetErrorStrings()));
            }

            try
            {
                gymService.CreateGym(gym);

                //return CreatedAtRoute("DefaultApi", new { id = order.OrderID }, order);
                return Ok(gym);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }

        }
    }
}
