using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Temprature;

/// <summary>
/// Represents temperature in Celsius scale.
/// </summary>
public class Celsius
{
    public double Degree { get; set; }

    public Celsius() { }

    public Celsius(double degree) => Degree = degree;

    /// <summary>
    /// Implicit conversion from Celsius to Kelvin.
 /// Formula: K = °C + 273.15
    /// </summary>
    public static implicit operator Kelvin(Celsius celsius)
    {
  return new Kelvin(celsius.Degree + 273.15);
    }

    /// <summary>
    /// Explicit conversion from Celsius to Fahrenheit.
    /// Formula: °F = (°C × 9/5) + 32
    /// </summary>
public static explicit operator Fahrenheit(Celsius celsius)
    {
      return new Fahrenheit((celsius.Degree * 9 / 5) + 32);
    }

    public override string ToString() => $"{Degree:F2}°C";
}
