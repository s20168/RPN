using System;
using System.Text.RegularExpressions;
using RPN.Handlers.BaseHandler;
using RPNCalulator;

namespace RPN.Handlers.NumSystemHandlers
{
    public class DecimalHandler : Handler
    {
        public override void dispatch(string input, RPNCalulator.Stack<int> op)
        {
            if (Regex.IsMatch(input, @"^\bD\d+"))
            {
                op.Push(Convert.ToInt32(input.Remove(0, 1), 10));
            }
            else
            {
                rpnHandler.dispatch(input, op);
            }
        }
    }
}