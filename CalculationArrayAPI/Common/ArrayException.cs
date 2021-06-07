using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace CalculationArrayAPI.Common
{
    public class ArrayException : Exception
    {
        public HttpStatusCode StatusCode { get; }
        public ArrayException(HttpStatusCode statusCode, string errorDescription) : base(errorDescription)
        {
            StatusCode = statusCode;
        }
    }

    public class ArrayBadException : ArrayException
    {
        public ArrayBadException(string errorDescription) : base(HttpStatusCode.BadRequest, errorDescription)
        {
        }
    }
}