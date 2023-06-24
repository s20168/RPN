using RPN.Handlers.BaseHandler;
using RPNCalulator;

namespace RPN.Handlers.OperationHandlers
{
    public class FactorialHandler : Handler
    {
        public override void dispatch(string input, RPNCalulator.Stack<int> op)
        {
            if (input.Equals("!"))
            {
                op.Push(calculalateFactorial(op.Pop()));
            }
            else
            {
                rpnHandler.dispatch(input, op);
            }
        }
        
        private int calculalateFactorial(int input)
        {
            if (input == 1)
                return 1;
            return input * calculalateFactorial(input - 1);
        }
    }
}