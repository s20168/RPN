using System;
using RPN.Handlers.BaseHandler;
using RPNCalulator;

namespace RPN.Handlers.OperationHandlers
{
    public class SquareHandler : Handler
    {
        public override void dispatch(string input, RPNCalulator.Stack<int> op)
        {
            if (input.Equals("^"))
            {
                op.Push((int)Math.Pow(op.Pop(), 2));
            }
            else
            {
                rpnHandler.dispatch(input, op);
            }
        }
    }
}