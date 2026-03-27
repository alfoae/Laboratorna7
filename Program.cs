using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Func<double, double> discountCalculator = null;

        discountCalculator += price => price * 0.95;
        discountCalculator += price => price * 0.90;
        discountCalculator += price => price - 100;

        double result = discountCalculator(1000);

        foreach (Func<double, double> func in discountCalculator.GetInvocationList())
        {
            result = func(result);
        }

        Console.WriteLine(result);
    }
}