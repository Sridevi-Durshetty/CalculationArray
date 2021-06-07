using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalculationArrayAPI.Models
{
    public interface IProductService
    {
        string[] ReverseArray(string[] prod);

        string[] DeletePart(int position, string[] prod);
    }
}