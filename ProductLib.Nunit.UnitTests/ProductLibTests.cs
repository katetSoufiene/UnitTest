using NUnit.Framework;
using ProductLibrary;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class ProductLibTests
    {
        [Test]
        [Category("Increase")]
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

        [Test]
        [Category("Decrease")]
        public void Debit_ValidQuantity_DecrementQuantity()
        {
            // Arrange
            var sut = new Product("Laptop", 1000);
            var expected = 900;

            // Act
            sut.Decrease(100);
            var actual = sut.Quantity;

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
            // the same as :
            // Assert.AreEqual(expected, actual, "Check Decrease method impl");
        }

        /// <summary>
        /// Should the code just return when the Quantity = 0 ?
        /// It depends on the use case.
        /// </summary>
        [Test]
        [Category("Increase")]
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

        [Test]
        [Category("Increase")]
        public void Increase_MaxQuantity_ThrowsException()
        {
            // Arrange
            var sut = new Product("Laptop", 1000);

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(
                () => sut.Increase(int.MaxValue));
        }

        [Test]
        [Ignore("Bad test case to catch Exception inside the test method")]
        [Category("Decrease")]
        public void Debit_QuantityBiggerThanQuantity_ThrowsException_()
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
                Assert.AreEqual("Quantity", e.ParamName);
                Assert.AreEqual(expected, actual);
            }
        }

        /// <summary>
        /// No equivalent to [ExpectedException(typeof(ArgumentOutOfRangeException))]
        /// </summary>
        [Test]
        [Category("Decrease")]
        public void Debit_QuantityBiggerThanQuantity_ThrowsException()
        {
            // Arrange
            var sut = new Product("Laptop", 1000);

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(
                () => sut.Decrease(2000));
        }

        [TestCase(1000, 100, 1100)]
        [TestCase(1000, 200, 1200)]
        [TestCase(1000, 300, 1300)]
        [Test]
        [Category("Increase")]
        public void Increase_ValidQuantity_IncrementQuantity_TestCase(int quantity, int quantityToAdd, int expected)
        {
            // Arrange
            var sut = new Product("Laptop", quantity);

            // Act
            sut.Increase(quantityToAdd);
            var actual = sut.Quantity;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(nameof(GetData))]
        [Category("Increase")]
        public void Increase_ValidQuantity_IncrementQuantity_TestCaseSource(int quantity, int quantityToAdd, int expected)
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

        [SetUp]
        public void RunBeforeTest()
        {
        }

        [TearDown]
        public void RunAfterTest()
        {
        }

        [OneTimeSetUp]
        public void RunOnceBeforeTest()
        {
        }

        [OneTimeTearDown]
        public void RunOnceAfterTest()
        {
        }
    }
}