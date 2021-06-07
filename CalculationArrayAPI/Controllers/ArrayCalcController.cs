using CalculationArrayAPI.Common;
using CalculationArrayAPI.Models;
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
        private IProductService _productService;
        public ArrayCalcController(IProductService productService)
        { 
            _productService = productService;
        }

        [HttpGet]
        [ArrayExceptionFilterAttribute]
        [Route("reverse")]
        public IHttpActionResult ArrayReverse([FromUri] string[] productIds = null)
        {
            if (productIds == null || (productIds != null && productIds.Count() == 0))
                throw new ArrayBadException("Please provide productsIds");
            return Ok(_productService.ReverseArray(productIds));
        }

        [HttpGet]
        [Route("deletepart")]
        public IHttpActionResult DeletePart([FromUri] string position, [FromUri] string[] productIds)
        {
            if (productIds == null || position == null || (productIds != null && productIds.Count() == 0))
                throw new ArrayBadException("Please provide productsIds and position");
            int correctPostion;
            if (!int.TryParse(position, out correctPostion))
                throw new ArrayBadException("position should be numeric");
            else if (correctPostion <= 0 || correctPostion > productIds.Count())
            {
                throw new ArrayBadException("Position is out of range");
            }
            return Ok(productIds);
        }
    }
}
