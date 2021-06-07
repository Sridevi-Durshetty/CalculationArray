using System;
using System.Linq;
using System.Web.Http.Results;
using CalculationArrayAPI.Common;
using CalculationArrayAPI.Controllers;
using CalculationArrayAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculationArrayAPI.Tests
{
    [TestClass]
    public class ArrayCalcControllerTest
    {
        private IProductService _productService = new ProductService();
        ArrayCalcController _arrayCalcController = null; 
        public ArrayCalcControllerTest()
        {
            _arrayCalcController = new ArrayCalcController(_productService); 
        }

        [TestMethod]
       // [ExpectedException(typeof(ArrayBadException))]
        public void ReverseArray__InputNullProductIds_ThrowBadRequest()
        {
            string[] inputLst = null;
            var ex = Assert.ThrowsException<ArrayBadException>(() => _arrayCalcController.ArrayReverse(inputLst));
            Assert.AreEqual("Please provide productsIds", ex.Message);
        }

        [TestMethod]       
        public void Deletepart__InputNullProductIds_ThrowBadRequest()
        {
            string[] inputLst = null;
            string position = "1";
            var ex = Assert.ThrowsException<ArrayBadException>(() => _arrayCalcController.DeletePart(position, inputLst));
            Assert.AreEqual("Please provide productsIds and position", ex.Message);
        }

        [TestMethod]
        public void Deletepart__InputNullPosition_ThrowBadRequest()
        {
            string[] inputLst = new[] { "1", "2", "3", "4", "5", "6" };
            string position = null;
            var ex = Assert.ThrowsException<ArrayBadException>(() => _arrayCalcController.DeletePart(position, inputLst));
            Assert.AreEqual("Please provide productsIds and position", ex.Message);
        }


        [TestMethod]
        public void Deletepart__InputNullPositionProductIds_ThrowBadRequest()
        {
            string[] inputLst = null;
            string position = null;
            var ex = Assert.ThrowsException<ArrayBadException>(() => _arrayCalcController.DeletePart(position, inputLst));
            Assert.AreEqual("Please provide productsIds and position", ex.Message);
        }

        [TestMethod]
        public void Deletepart__InputStringPosition_ThrowBadRequest()
        {
            string[] inputLst = new[] { "1", "2", "3", "4", "5", "6" };
            string position = "ab";
            var ex = Assert.ThrowsException<ArrayBadException>(() => _arrayCalcController.DeletePart(position, inputLst));
            Assert.AreEqual("position should be numeric", ex.Message);
        }

        [TestMethod]
        public void Deletepart__InputNegativePositon_ThrowBadRequest()
        {
            string[] inputLst = new[] { "1", "2", "3", "4", "5", "6" };
            string position = "-2";
            var ex = Assert.ThrowsException<ArrayBadException>(() => _arrayCalcController.DeletePart(position, inputLst));
            Assert.AreEqual("Position is out of range", ex.Message);
        }
    }
}
