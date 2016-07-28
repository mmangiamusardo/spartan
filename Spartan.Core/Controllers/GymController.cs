using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Spartan.Domain;
using Spartan.Service;

namespace Spartan.Core
{
    //[Authorize]
    public class GymsController : ApiController
    {
        private readonly IGymService _gymService;

        public GymsController(IGymService gymService)
        {
            this._gymService = gymService;
        }

        public PagedCollection<Gym> GetPaged()
        {
            return _gymService.GetPagedGyms(0, 0);
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
                _gymService.CreateGym(gym);

                //return CreatedAtRoute("DefaultApi", new { id = order.OrderID }, order);
                return Ok(gym);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }

        }

        /// <summary>
        /// Dispose all objects
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && _gymService != null)
            {
                _gymService.Dispose();
                //_gymService = null;
            }

            base.Dispose(disposing);
        }
    }
}
