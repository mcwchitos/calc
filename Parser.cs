using System;
using System.Text.RegularExpressions;

namespace calc
{
    public class Parser
    {
        private readonly string _inpStr;
        private int _counter;
        private readonly int _len;
        private readonly int _round;

        public Parser(string inpStr, int round)
        {
            _inpStr = inpStr;
            _len = inpStr.Length;
            _round = round;
        }

        public Expression Parse()
        {
            var a = abc();
            if (!a)
                return null;
            var result = ParseFactor();
            return result;
        }

        private bool abc()
        {
            const string pattern = @"[-+]?[0-9]+(\.[0-9]+)?[\+\-\*\/][-+]?[0-9]+(\.[0-9]+)?";
            var regular = new Regex(pattern);
            var can = regular.IsMatch(_inpStr);
            return can;
        }

        private Expression ParseFactor()
        {
            Expression result = ParseDouble();
            while(true)
            {
                var op = ParseFacOpcode();
                if (op != Operations.None)
                {
                    var right = ParseDouble();
                    result = new Factor(op, _round, right, result);
                }
                else
                    break;
            }
            return result;
        }
        
        private Double ParseDouble()
        {
            long value = 0;
            long leftValue = 0;
            var isNegative = false;
            if (CurrentChar() == '-')
            {
                isNegative = true;
                ++_counter;
            }
            
            while (char.IsDigit(CurrentChar()))
            {
                value = value * 10 + (long)char.GetNumericValue(CurrentChar());
                ++_counter;
            }

            if (CurrentChar() != '.') return new Double(isNegative, value, 0, _round);
            leftValue = value;
            value = 0;
            ++_counter;
            
            while (char.IsDigit(CurrentChar()))
            {
                value = value * 10 + (long)char.GetNumericValue(CurrentChar());
                ++_counter;
            }
            return new Double(isNegative, leftValue, value, _round);
        }
        
        private Operations ParseFacOpcode()
        {
            var possibleOperators = new[] {Operations.Multiplication, Operations.Division, Operations.Addition, Operations.Subtraction};
            foreach (var op in possibleOperators)
            {
                var size = op.GetOp().Length;
                var limit = _counter + size;
                if (limit >= _len || !_inpStr.Substring(_counter, limit - _counter).Equals(op.GetOp())) continue;
                _counter += size;
                return op;
            }
            return Operations.None;
        }
        
        private char CurrentChar() { return _counter < _len ? _inpStr[_counter] : ' '; }
    }
}