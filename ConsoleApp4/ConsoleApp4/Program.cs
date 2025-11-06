using System;
using ConsoleApp4.Temprature;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Example conversions
            var celsius = new Celsius(25);
            Kelvin kelvin = celsius; // Implicit conversion
            Fahrenheit fahrenheit = (Fahrenheit)celsius; // Explicit conversion

            Console.WriteLine($"Original:     {celsius}");
            Console.WriteLine($"To Kelvin:    {kelvin}");
            Console.WriteLine($"To Fahrenheit: {fahrenheit}");
            Console.WriteLine();

            // Reverse conversions
            var kelvin2 = new Kelvin(298.15);
            Celsius celsius2 = kelvin2; // Implicit conversion back
            Fahrenheit fahrenheit2 = (Fahrenheit)kelvin2; // Explicit conversion

            Console.WriteLine($"Original:      {kelvin2}");
            Console.WriteLine($"To Celsius:    {celsius2}");
            Console.WriteLine($"To Fahrenheit: {fahrenheit2}");
        }
    }
}
