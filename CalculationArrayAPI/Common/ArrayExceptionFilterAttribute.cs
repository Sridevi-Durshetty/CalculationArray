using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace CalculationArrayAPI.Common
{
    public class ArrayExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            
            //Check the Exception Type
            if (context.Exception is ArrayException)
            {
                //The Response Message Set by the Action During Ececution
                var res = context.Exception as ArrayException; ;

                //Define the Response Message
                HttpResponseMessage response = new HttpResponseMessage(res.StatusCode)
                {
                    Content = new StringContent(res.Message),
                    ReasonPhrase = res.Message
                };

                //Create the Error Response
                context.Response = response;
            }
        }
    }
}