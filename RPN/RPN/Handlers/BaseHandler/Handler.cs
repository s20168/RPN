using RPNCalulator;

namespace RPN.Handlers.BaseHandler
{
    public abstract class Handler
    {
        public Handler rpnHandler;
        
        public abstract void dispatch(string input, RPNCalulator.Stack<int> op);
        
        public void nextHandler(Handler rpnHandler)
        {
            this.rpnHandler = rpnHandler;
        }
    }
}