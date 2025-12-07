using FluentAssertions;
using Xunit;

namespace MyLib.Tests;

public class CalculatorTests
{
    [Theory]
    [InlineData(2, 3, 5)]
    [InlineData(0, 0, 0)]
    [InlineData(-1, 1, 0)]
    [InlineData(100, 200, 300)]
    public void Add_Should_Return_Correct_Sum(int a, int b, int expected)
    {
        // Act
        var result = Calculator.Add(a, b);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(5, 3, 2)]
    [InlineData(0, 0, 0)]
    [InlineData(1, -1, 2)]
    [InlineData(100, 50, 50)]
    public void Subtract_Should_Return_Correct_Difference(int a, int b, int expected)
    {
        // Act
        var result = Calculator.Subtract(a, b);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(2, 3, 6)]
    [InlineData(0, 5, 0)]
    [InlineData(-2, 3, -6)]
    [InlineData(10, 10, 100)]
    public void Multiply_Should_Return_Correct_Product(int a, int b, int expected)
    {
        // Act
        var result = Calculator.Multiply(a, b);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(6, 3, 2.0)]
    [InlineData(5, 2, 2.5)]
    [InlineData(0, 1, 0.0)]
    [InlineData(-6, 3, -2.0)]
    public void Divide_Should_Return_Correct_Quotient(int a, int b, double expected)
    {
        // Act
        var result = Calculator.Divide(a, b);

        // Assert
        result.Should().BeApproximately(expected, 0.0001);
    }

    [Fact]
    public void Divide_Should_Throw_DivideByZeroException_When_Divisor_Is_Zero()
    {
        // Act
        Action act = () => Calculator.Divide(10, 0);

        // Assert
        act.Should().Throw<DivideByZeroException>()
            .WithMessage("Cannot divide by zero");
    }
}
