using System;
using System.Text.RegularExpressions;
using RPN.Handlers.BaseHandler;
using RPNCalulator;

namespace RPN.Handlers.NumSystemHandlers
{
    public class HexadecimalHandler : Handler
    {
        public override void dispatch(string input, RPNCalulator.Stack<int> op)
        {
            if (Regex.IsMatch(input, @"^\B#[a-fA-F0-9]+$"))
            {
                op.Push(Convert.ToInt32(input.Remove(0, 1), 16));
            }
            else
            {
                rpnHandler.dispatch(input, op);
            }
        }
    }
}