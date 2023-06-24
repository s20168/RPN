using RPN.Handlers.BaseHandler;
using RPNCalulator;

namespace RPN.Handlers.OperationHandlers
{
    public class MultiplicationHandler : Handler
    {
        public override void dispatch(string input, RPNCalulator.Stack<int> op)
        {
            if (input.Equals("*"))
            {
                var num1 = op.Pop();
                var num2 = op.Pop();
                op.Push(num1 * num2);
            }
            else
            {
                rpnHandler.dispatch(input, op);
            }
        }
    }
}