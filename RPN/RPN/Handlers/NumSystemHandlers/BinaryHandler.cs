using System;
using System.Text.RegularExpressions;
using RPN.Handlers.BaseHandler;
using RPNCalulator;

namespace RPN.Handlers.NumSystemHandlers
{
    public class BinaryHandler : Handler
    {
        public override void dispatch(string input, RPNCalulator.Stack<int> op)
        {
            if (Regex.IsMatch(input, @"^\bB\d+"))
            {
                op.Push(Convert.ToInt32(input.Remove(0, 1), 2));
            }
            else
            {
                rpnHandler.dispatch(input, op);
            }
        }
    }
}