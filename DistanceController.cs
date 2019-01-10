using _02_BusinessLogic;
using Gallery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace _03_WEB_API.Controllers
{
    [EnableCors("*","*","*")]
    public class DistanceController : ApiController
    {
        private DistanceLogic logic = new DistanceLogic();
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                logic.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpGet]
        [Route("api/getDistance/{source}/{destination}")]
        public HttpResponseMessage GetDistance([FromUri] string source, [FromUri] string destination)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, logic.GetDistance(source, destination));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet]
        [Route("api/getPopularDistances")]
        public HttpResponseMessage GetPopularDistances()
        {
            try
           {
                return Request.CreateResponse(HttpStatusCode.OK, logic.GetPopularDistances());
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        [Route("api/distance/create")]
        public HttpResponseMessage Create([FromBody]DistanceModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState.GetAllErrors());
                }
                logic.CreateDistance(model);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.GetUserFriendlyMessage());

            }
        }
    }
}
