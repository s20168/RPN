using System;
using RPN.Handlers.BaseHandler;
using RPNCalulator;

namespace RPN.Handlers.OperationHandlers
{
    public class SquareRootHandler : Handler
    {
        public override void dispatch(string input, RPNCalulator.Stack<int> op)
        {
            if (input.Equals("sqrt"))
            {
                op.Push((int)Math.Sqrt(op.Pop()));
            }
            else
            {
                rpnHandler.dispatch(input, op);
            }
        }
    }
}