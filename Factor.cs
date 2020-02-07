using System;
using System.Linq.Expressions;

namespace calc
{
    public class Factor : Expression
    {
        private readonly Operations _node;
        private readonly Expression _left, _right;

        public Factor(Operations node, Expression left = null, Expression right = null)
        {
            _node = node;
            _left = left;
            _right = right;
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
            return Math.Round(op.Apply(tmpLeft, tmpRight), 2);
        }
    }
}