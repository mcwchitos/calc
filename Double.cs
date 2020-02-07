using System;
using System.Text.RegularExpressions;

namespace calc
{
    public class Double : Expression
    {
        private readonly bool _isNegative;
        private readonly long _leftVal;
        private readonly long _rightVal;
        private readonly int _round;

        public Double(bool isNegative, long leftVal, long rightVal, int round)
        {
            _isNegative = isNegative;
            _leftVal = leftVal;
            _rightVal = rightVal;
            _round = round;
        }

        public override double Calculate()
        {
            var line = string.Concat(_leftVal, ",", _rightVal);
            var result =  _isNegative ? -double.Parse(line) : double.Parse(line);
            return Math.Round(result, _round);
        }
    }
}