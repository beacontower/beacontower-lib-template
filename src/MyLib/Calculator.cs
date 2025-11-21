namespace MyLib;

/// <summary>
/// Example calculator class demonstrating library functionality.
/// </summary>
public class Calculator
{
    /// <summary>
    /// Adds two numbers.
    /// </summary>
    /// <param name="a">First number.</param>
    /// <param name="b">Second number.</param>
    /// <returns>Sum of a and b.</returns>
    public int Add(int a, int b) => a + b;

    /// <summary>
    /// Subtracts one number from another.
    /// </summary>
    /// <param name="a">Number to subtract from.</param>
    /// <param name="b">Number to subtract.</param>
    /// <returns>Difference of a and b.</returns>
    public int Subtract(int a, int b) => a - b;

    /// <summary>
    /// Multiplies two numbers.
    /// </summary>
    /// <param name="a">First number.</param>
    /// <param name="b">Second number.</param>
    /// <returns>Product of a and b.</returns>
    public int Multiply(int a, int b) => a * b;

    /// <summary>
    /// Divides one number by another.
    /// </summary>
    /// <param name="a">Dividend.</param>
    /// <param name="b">Divisor.</param>
    /// <returns>Quotient of a divided by b.</returns>
    /// <exception cref="DivideByZeroException">Thrown when b is zero.</exception>
    public double Divide(int a, int b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero");
        }

        return (double)a / b;
    }
}
