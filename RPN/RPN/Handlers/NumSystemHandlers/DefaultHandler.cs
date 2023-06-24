using System;
using System.Text.RegularExpressions;
using RPN.Handlers.BaseHandler;
using RPNCalulator;

namespace RPN.Handlers.NumSystemHandlers
{
    public class DefaultHandler : Handler
    {
        public override void dispatch(string input, RPNCalulator.Stack<int> op)
        {
            if (Regex.IsMatch(input, @"^\d+$"))
            {
                op.Push(Int32.Parse(input));
            }
            else
            {
                rpnHandler.dispatch(input, op);
            }
        }
    }
}