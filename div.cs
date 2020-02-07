using System;

namespace calc
{
    public class Div : IOps
    {
        public double Apply(double a, double b)
        {
            if (b != 0)
                return a / b;
            Console.WriteLine("? means Inf");
            return double.PositiveInfinity;
        }
    }
}