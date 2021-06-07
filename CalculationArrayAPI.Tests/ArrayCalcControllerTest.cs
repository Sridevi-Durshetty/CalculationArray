using System;
using System.Linq;
using System.Web.Http.Results;
using CalculationArrayAPI.Common;
using CalculationArrayAPI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculationArrayAPI.Tests
{
    [TestClass]
    public class ArrayCalcControllerTest
    {
        [TestMethod]
       // [ExpectedException(typeof(ArrayBadException))]
        public void ReverseArray__InputNullProductIds_ThrowBadRequest()
        {
            string[] inputLst = null;
            var controller = new ArrayCalcController();
            var ex = Assert.ThrowsException<ArrayBadException>(() => controller.ArrayReverse(inputLst));
            Assert.AreEqual("Please provide productsIds", ex.Message);
        }

        [TestMethod]       
        public void Deletepart__InputNullProductIds_ThrowBadRequest()
        {
            string[] inputLst = null;
            string position = "1";
            var controller = new ArrayCalcController();
            var ex = Assert.ThrowsException<ArrayBadException>(() => controller.DeletePart(position, inputLst));
            Assert.AreEqual("Please provide productsIds and position", ex.Message);
        }

        [TestMethod]
        public void Deletepart__InputNullPosition_ThrowBadRequest()
        {
            string[] inputLst = new[] { "1", "2", "3", "4", "5", "6" };
            string position = null;
            var controller = new ArrayCalcController();
            var ex = Assert.ThrowsException<ArrayBadException>(() => controller.DeletePart(position, inputLst));
            Assert.AreEqual("Please provide productsIds and position", ex.Message);
        }


        [TestMethod]
        public void Deletepart__InputNullPositionProductIds_ThrowBadRequest()
        {
            string[] inputLst = null;
            string position = null;
            var controller = new ArrayCalcController();
            var ex = Assert.ThrowsException<ArrayBadException>(() => controller.DeletePart(position, inputLst));
            Assert.AreEqual("Please provide productsIds and position", ex.Message);
        }
    }
}
