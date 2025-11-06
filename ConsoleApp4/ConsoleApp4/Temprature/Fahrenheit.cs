namespace ConsoleApp4.Temprature;

/// <summary>
/// Represents temperature in Fahrenheit scale.
/// </summary>
public class Fahrenheit
{
    public double Degree { get; set; }

    public Fahrenheit() { }

 public Fahrenheit(double degree) => Degree = degree;

    /// <summary>
    /// Implicit conversion from Fahrenheit to Celsius.
    /// Formula: °C = (°F - 32) × 5/9
    /// </summary>
    public static implicit operator Celsius(Fahrenheit fahrenheit)
    {
   return new Celsius((fahrenheit.Degree - 32) * 5 / 9);
    }

    /// <summary>
    /// Implicit conversion from Fahrenheit to Kelvin.
    /// Formula: K = (°F - 32) × 5/9 + 273.15
    /// </summary>
 public static implicit operator Kelvin(Fahrenheit fahrenheit)
    {
        return new Kelvin((fahrenheit.Degree - 32) * 5 / 9 + 273.15);
    }

    public override string ToString() => $"{Degree:F2}°F";
}
