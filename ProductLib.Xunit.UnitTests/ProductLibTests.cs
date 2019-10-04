using ProductLibrary;
using System;
using System.Collections.Generic;
using Xunit;

namespace ProductLib.Xunit.UnitTests
{
    public class ProductLibTests
    {
        [Fact]
        [Trait("Method", "Increase")]
        public void Increase_ValidQuantity_IncrementQuantity()
        {
            // Arrange
            var sut = new Product("Laptop", 1000);
            var expected = 1100;

            // Act
            sut.Increase(100);
            var actual = sut.Quantity;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        [Trait("Method", "Decrease")]
        public void Debit_ValidQuantity_DecrementQuantity()
        {
            // Arrange
            var sut = new Product("Laptop", 1000);
            var expected = 900;

            // Act
            sut.Decrease(100);
            var actual = sut.Quantity;

            // Assert
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Should the code just return when the Quantity = 0 ?
        /// It depends on the use case.
        /// </summary>
        [Fact]
        [Trait("Method", "Increase")]
        public void Increase_QuantityZero_NotChangeQuantity()
        {
            // Arrange
            var sut = new Product("Laptop", 1000);
            var expected = 1000;

            // Act
            sut.Increase(0);
            var actual = sut.Quantity;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact(Skip = "Bad test case to catch Exception inside the test")]
        [Trait("Method", "Decrease")]
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
                Assert.Equal("Quantity", e.ParamName);
                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        [Trait("Method", "Increase")]
        public void Increase_MaxQuantity_ThrowsException()
        {
            // Arrange
            var sut = new Product("Laptop", 1000);

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(
                () => sut.Increase(int.MaxValue));
        }

        [Fact]
        [Trait("Method", "Decrease")]
        public void Debit_QuantityBiggerThanQuantity_ThrowsException()
        {
            // Arrange
            var sut = new Product("Laptop", 1000);
            var expected = 1000;

            // Act
            var exception = Assert.Throws<ArgumentOutOfRangeException>(
                () => sut.Decrease(2000));
            var actual = sut.Quantity;

            // Assert
            Assert.Equal(expected, actual);
        }

        [InlineData(1000, 100, 1100)]
        [InlineData(1000, 200, 1200)]
        [InlineData(1000, 300, 1300)]
        [Theory]
        [Trait("Method", "Increase")]
        public void Increase_ValidQuantity_IncrementQuantity_DataRow(int quantity, int quantityToAdd, int expected)
        {
            // Arrange
            var sut = new Product("Laptop", quantity);

            // Act
            sut.Increase(quantityToAdd);
            var actual = sut.Quantity;

            // Assert
            Assert.Equal(expected, actual);
        }

        [MemberData(nameof(GetData))]
        [Theory]
        [Trait("Method", "Increase")]
        public void Increase_ValidQuantity_IncrementQuantity_MemberData(int quantity, int quantityToAdd, int expected)
        {
            // Arrange
            var sut = new Product("Laptop", quantity);

            // Act
            sut.Increase(quantityToAdd);
            var actual = sut.Quantity;

            // Assert
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> GetData()
        {
            return new List<object[]>
            {
                new object[] { 1, 1, 2 },
                new object[] { 14, 1, 15 },
                new object[] { 14, 1, 15 }
            };
        }

        /// <summary>
        /// The equivalent to [TestInitialize] is the constructor.
        /// </summary>
        public ProductLibTests()
        {
        }
    }
}
