using System;
using System.Linq.Expressions;

namespace calc
{
    public class Factor : Expression
    {
        private readonly Operations _node;
        private readonly Expression _left, _right;
        private readonly int _round;

        public Factor(Operations node, int round, Expression right = null, Expression left = null)
        {
            _node = node;
            _left = left;
            _right = right;
            _round = round;
        }

        public override double Calculate()
        {
            double tmpLeft = _left.Calculate(), tmpRight = _right.Calculate();
            double result = 0;
            IOps op;
            switch (_node)
            {
                case Operations.Addition:
                    op = new Add();
                    break;
                case Operations.Division:
                    op = new Div();
                    break;
                case Operations.Multiplication:
                    op = new Mult();
                    break;
                case Operations.Subtraction:
                    op = new Sub();
                    break;
                default:
                    return 0;
            }
            return Math.Round(op.Apply(tmpLeft, tmpRight), _round);
        }
    }
}