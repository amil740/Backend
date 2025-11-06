using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Temprature;

/// <summary>
/// Represents temperature in Kelvin scale.
/// </summary>
public class Kelvin
{
    public double Degree { get; set; }

    public Kelvin() { }

    public Kelvin(double degree) => Degree = degree;

    /// <summary>
    /// Implicit conversion from Kelvin to Celsius.
    /// Formula: °C = K - 273.15
    /// </summary>
    public static implicit operator Celsius(Kelvin kelvin)
    {
        return new Celsius(kelvin.Degree - 273.15);
    }

    /// <summary>
    /// Explicit conversion from Kelvin to Fahrenheit.
    /// Formula: °F = (K - 273.15) × 9/5 + 32
    /// </summary>
    public static explicit operator Fahrenheit(Kelvin kelvin)
    {
        return new Fahrenheit((kelvin.Degree - 273.15) * 9 / 5 + 32);
    }

    public override string ToString() => $"{Degree:F2}K";
}
