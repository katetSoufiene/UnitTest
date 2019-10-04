using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductLibrary;
using System;
using System.Collections.Generic;

namespace ProductLib.MsTest.UnitTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        [TestCategory("Increase")]
        public void Increase_ValidQuantity_IncrementQuantity()
        {
            // Arrange
            var sut = new Product("Laptop", 1000);
            var expected = 1100;

            // Act
            sut.Increase(100);
            var actual = sut.Quantity;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("Decrease")]
        public void Decrease_ValidQuantity_DecrementQuantity()
        {
            // Arrange
            var sut = new Product("Laptop", 1000);
            var expected = 900;

            // Act
            sut.Decrease(100);

            // Assert
            Assert.AreEqual(expected, sut.Quantity, "Check Decrease method impl");
        }

        /// <summary>
        /// Should the code just return when the Quantity = 0 ?
        /// It depends on the use case.
        /// </summary>
        [TestMethod]
        [TestCategory("Increase")]
        public void Increase_QuantityZero_NotChangeQuantity()
        {
            // Arrange
            var sut = new Product("Laptop", 1000);
            var expected = 1000;

            // Act
            sut.Increase(0);
            var actual = sut.Quantity;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Ignore("Bad test case to catch Exception inside the test method")]
        [TestCategory("Decrease")]
        public void Decrease_QuantityBiggerThanQuantity_ThrowsException_()
        {
            // Arrange
            var sut = new Product("Laptop", 1000);
            var expected = 1000;
            var actual = 0.0;

            // Act
            try
            {
                sut.Decrease(2000);
            }
            catch (ArgumentOutOfRangeException e)
            {
                actual = sut.Quantity;
                // Assert
                Assert.AreEqual("quantity", e.ParamName);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        [TestCategory("Increase")]
        public void Increase_MaxQuantity_ThrowsException()
        {
            // Arrange
            var sut = new Product("Laptop", 1000);

            // Act
            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => sut.Increase(int.MaxValue));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestCategory("Decrease")]
        public void Decrease_QuantityBiggerThanQuantity_ThrowsException()
        {
            // Arrange
            var sut = new Product("Laptop", 1000);

            // Act
            sut.Decrease(2000);

            // Assert
            // the attribute [ExpectedException(typeof(ArgumentOutOfRangeException))]
        }

        [DataRow(1000, 100, 1100)]
        [DataRow(1000, 200, 1200)]
        [DataRow(1000, 300, 1300)]
        [DataTestMethod]
        [TestCategory("Increase")]
        public void Increase_ValidQuantity_IncrementQuantity_DataRow(int quantity, int quantityToAdd, int expected)
        {
            // Arrange
            var sut = new Product("Laptop", quantity);

            // Act
            sut.Increase(quantityToAdd);
            var actual = sut.Quantity;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        [TestCategory("Increase")]
        public void Increase_ValidQuantity_IncrementQuantity_DynamicData(int quantity, int quantityToAdd, int expected)
        {
            // Arrange
            var sut = new Product("Laptop", quantity);

            // Act
            sut.Increase(quantityToAdd);
            var actual = sut.Quantity;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        private static IEnumerable<object[]> GetData()
        {
            return new List<object[]>
            {
                new object[] { 1, 1, 2 },
                new object[] { 14, 1, 15 },
                new object[] { 14, 1, 15 }
            };
        }

        [TestInitialize]
        public void RunBeforeTest()
        {
        }

        [TestCleanup]
        public void RunAfterTest()
        {
        }
    }
}
