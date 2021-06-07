using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalculationArrayAPI.Models
{
    public class ProductService : IProductService
    {
        /// <summary>
        /// Delete one item from array based on position
        /// </summary>
        /// <param name="position"></param>
        /// <param name="prod"></param>
        /// <returns></returns>
        public string[] DeletePart(int position, string[] prod)
        {
            var result = new string[prod.Count() - 1];
            int prevIndex = 0;

            for (int index = 0; index < prod.Count(); index++)
            {
                if (position != (index + 1))
                {
                    result[prevIndex] = prod[index];
                    prevIndex++;
                }
            }
            return result;
        }


        /// <summary>
        /// Reverse the list of array based on input array
        /// </summary>
        /// <param name="prod"></param>
        /// <returns></returns>
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