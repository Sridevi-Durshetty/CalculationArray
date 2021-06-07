using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalculationArrayAPI.Models
{
    public class ProductService : IProductService
    {
        public string[] DeletePart(int position, string[] prod)
        {
            throw new NotImplementedException();
        }

        public string[] ReverseArray(string[] prod)
        {
            for (int i = 0; i < prod.Length / 2; i++)
            {
                string temp = prod[i];
                prod[i] = prod[prod.Length - i - 1];
                prod[prod.Length - i - 1] = temp;
            }
            return prod;
        }
    }
}