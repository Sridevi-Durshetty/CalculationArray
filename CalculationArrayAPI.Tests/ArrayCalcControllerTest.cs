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
        public void ReverseArray__InputNumericProductIds_ShouldReverse()
        {
            string[] inputLst = new[] { "1", "2", "3", "4", "5", "6" };
            string[] outputLst = new[] { "6", "5", "4", "3", "2", "1" };
            var result = _arrayCalcController.ArrayReverse(inputLst) as OkNegotiatedContentResult<string[]>;
            Assert.IsTrue(outputLst.SequenceEqual(result.Content));           
        }

        [TestMethod]
        public void ReverseArray__InputStringProductIds_ShouldReverse()
        {
            string[] inputLst = new[] { "A", "B", "C", "D", "E", "F" };
            string[] outputLst = new[] { "F", "E", "D", "C", "B", "A" };
            var result = _arrayCalcController.ArrayReverse(inputLst) as OkNegotiatedContentResult<string[]>;
            Assert.AreEqual(inputLst, result.Content);
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

        [TestMethod]
        public void Deletepart__ShouldLessCountOfArray()
        {
            string[] inputLst = new[] { "1", "2", "3", "4", "5", "6" };
            var result = _arrayCalcController.DeletePart("4",inputLst) as OkNegotiatedContentResult<string[]>;
            Assert.AreEqual(5, result.Content.Count());
        }

        [TestMethod]
        public void Deletepart_NumericProductIds_ShouldDeletePositionItem()
        {
            string[] inputLst = new[] { "1", "2", "3", "4", "5", "6" };
            string[] outputLst = new[] { "1", "2", "4", "5", "6" };
            var result = _arrayCalcController.DeletePart("3", inputLst) as OkNegotiatedContentResult<string[]>;
            Assert.IsTrue(outputLst.SequenceEqual(result.Content));
        }


        [TestMethod]
        public void Deletepart_StringProductIds_ShouldDeletePositionItem()
        {
            string[] inputLst = new[] { "A", "B", "C", "D", "E", "F" };
            string[] outputLst = new[] { "A", "B", "C", "E", "F" };
            var result = _arrayCalcController.DeletePart("4", inputLst) as OkNegotiatedContentResult<string[]>;
            Assert.IsTrue(outputLst.SequenceEqual(result.Content));
        }
    }
}
