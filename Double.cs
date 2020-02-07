using System;
using System.Text.RegularExpressions;

namespace calc
{
    public class Double : Expression
    {
        private readonly bool _isNegative;
        private readonly long _leftVal;
        private readonly long _rightVal;

        public Double(bool isNegative, long leftVal, long rightVal)
        {
            _isNegative = isNegative;
            _leftVal = leftVal;
            _rightVal = rightVal;
        }

        public override double Calculate()
        {
            var line = string.Concat(_leftVal, ",", _rightVal);
            var result =  _isNegative ? -double.Parse(line) : double.Parse(line);
            return Math.Round(result, 2);
        }
    }
}