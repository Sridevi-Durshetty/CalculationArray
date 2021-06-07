using CalculationArrayAPI.Common;
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
        public IHttpActionResult ArrayReverse([FromUri] string[] productIds = null)
        {
            if (productIds == null || (productIds != null && productIds.Count() == 0))
                throw new ArrayBadException("Please provide productsIds");
            return Ok(productIds);
        }

        [HttpGet]
        [Route("deletepart")]
        public IHttpActionResult DeletePart([FromUri] string position, [FromUri] string[] productIds)
        {
            if (productIds == null || position == null || (productIds != null && productIds.Count() == 0))
                throw new ArrayBadException("Please provide productsIds and position");
            return Ok(productIds);
        }
    }
}
