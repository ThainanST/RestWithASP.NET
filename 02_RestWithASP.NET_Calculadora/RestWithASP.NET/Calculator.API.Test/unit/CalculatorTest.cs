using RestWithASPNET.Model;
using Xunit;

namespace CalculatorAPITest.unit
{
    public class CalculatorTest
    {
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(1.6, 2.5, 4.1)]
        [InlineData(-1.1, -2.0, -3.1)]
        public void Should_Do_Sum_Correctly(
            decimal firstNumber, decimal secondNumber, decimal result)
        {
            decimal sum = RestWithASPNET.Model.Calculator.Sum(firstNumber, secondNumber);

            // Assert
            Assert.Equal(result, sum);
        }

        [Theory]
        [InlineData(1, 2, -1)]
        [InlineData(1.6, 2.5, -0.9)]
        [InlineData(-1.1, -2.0, 0.9)]
        public void Should_Do_Subtraction_Correctly(
            decimal firstNumber, decimal secondNumber, decimal result)
        {
            decimal subtraction = RestWithASPNET.Model.Calculator.Subtraction(firstNumber, secondNumber);

            // Assert
            Assert.Equal(result, subtraction);
        }

        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(1.6, 2.5, 4.0)]
        [InlineData(-1.1, -2.0, 2.2)]
        public void Should_Do_Multiplication_Correctly(
            decimal firstNumber, decimal secondNumber, decimal result)
        {
            decimal multiplication = RestWithASPNET.Model.Calculator.Multiplication(firstNumber, secondNumber);

            // Assert
            Assert.Equal(result, multiplication);
        }

        [Theory]
        [InlineData(1, 2, 0.5)]
        [InlineData(1.6, 2.5, 0.64)]
        [InlineData(-1.1, -2.0, 0.55)]
        public void Should_Do_Division_Correctly(
            decimal firstNumber, decimal secondNumber, decimal result)
        {
            decimal division = RestWithASPNET.Model.Calculator.Division(firstNumber, secondNumber);

            // Assert
            Assert.Equal(result, division);
        }

        [Theory]
        [InlineData(1, 2, 1.5)]
        [InlineData(1.6, 2.5, 2.05)]
        [InlineData(-1.1, -2.0, -1.55)]
        public void Should_Do_Mean_Correctly(
            decimal firstNumber, decimal secondNumber, decimal result)
        {
            decimal mean = RestWithASPNET.Model.Calculator.Mean(firstNumber, secondNumber);

            // Assert
            Assert.Equal(result, mean);
        }

        [Theory]
        [InlineData(4, 2)]
        [InlineData(2.5, 1.58113883008419)]
        public void Should_Do_SquareRoot_Correctly(
            decimal firstNumber, decimal result)
        {
            decimal squareRoot = RestWithASPNET.Model.Calculator.SquareRoot(firstNumber);

            // Assert
            Assert.Equal(result, squareRoot);
        }

    }
}