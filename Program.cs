using System;

class Program
{
    static void Main()
    {
        Func<double, double> discountCalculator = null;

        discountCalculator += price => price * 0.95; // -5%
        discountCalculator += price => price * 0.90; // -10%
        discountCalculator += price => price - 100;  // -100 грн

        double result = discountCalculator(1000);

        Console.WriteLine(result);
    }
}