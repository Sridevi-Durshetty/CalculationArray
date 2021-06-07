using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CalculationArrayAPI.Controllers
{
    [RoutePrefix("api/arraycalc")]
    public class ArrayCalcController : ApiController
    {
        [HttpGet]
        [Route("reverse")]
        public IHttpActionResult ArrayReverse([FromUri] string[] productIds)
        {
            return Ok(productIds);
        }

        [HttpGet]
        [Route("deletepart")]
        public IHttpActionResult DeletePart([FromUri] string position, [FromUri] string[] productIds)
        {           
             return Ok(productIds);
        }
    }
}
