using System;
using Xunit;
namespace AwesomeService.Tests
{
    public class AwesomeCalculator_Add_Should
    {
        [Fact]
        public void Return_4_Given_Value_Of_1_And_1_And_2()
        {
            ICalculator calculator = new AwesomeCalculator();
            var result = calculator.Add(1, 1, 2);
            Assert.Equal(4, result);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(3, 2, 1)]
        [InlineData(7, 7, 7)]
        public void Return_Sum_Of_Values(int nr1, int nr2, int nr3)
        {
            ICalculator calculator = new AwesomeCalculator();
            var actualResult = calculator.Add(nr1, nr2, nr3);
            var expectedResult = nr1 + nr2 + nr3;
            Assert.Equal(expectedResult, actualResult);
        }
    }
}