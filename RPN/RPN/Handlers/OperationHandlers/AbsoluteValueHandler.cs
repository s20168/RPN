using System;
using System.Text.RegularExpressions;
using RPN.Exceptions;
using RPN.Handlers.BaseHandler;
using RPNCalulator;

namespace RPN.Handlers.OperationHandlers
{
    public class AbsoluteValueHandler : Handler
    {
        public override void dispatch(string input, RPNCalulator.Stack<int> op)
        {
            if (Regex.IsMatch(input, @"^\|\d+\|$|-\d+\|$"))
            {
                op.Push(Math.Abs(Convert.ToInt32(input.Substring(1, input.Length - 2))));
            }
            else
            {
                throw new InvalidElementException(input);
            }
        }
    }
}