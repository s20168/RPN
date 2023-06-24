using System;
using RPN.Handlers.NumSystemHandlers;
using RPN.Handlers.OperationHandlers;
using RPNCalulator;

namespace RPN
{
    public class RPN
    {
        private RPNCalulator.Stack<int> _operators;
        
        private readonly DefaultHandler _defaultHandler = new DefaultHandler();
        private readonly BinaryHandler _binaryHandler = new BinaryHandler();
        private readonly DecimalHandler _decimalHandler = new DecimalHandler();
        private readonly HexadecimalHandler _hexadecimalHandler = new HexadecimalHandler();

        private readonly AdditionHandler _additionHandler = new AdditionHandler();
        private readonly SubtractionHandler _subtractionHandler = new SubtractionHandler();
        private readonly MultiplicationHandler _multiplicationHandler = new MultiplicationHandler();
        private readonly DivisionHandler _divisionHandler = new DivisionHandler();
        private readonly FactorialHandler _factorialHandler = new FactorialHandler();
        private readonly SquareRootHandler _squareRootHandler = new SquareRootHandler();
        private readonly SquareHandler _squareHandler = new SquareHandler();
        private readonly AbsoluteValueHandler _absoluteValueHandler = new AbsoluteValueHandler();

        public RPN()
        {
            _defaultHandler.nextHandler(_binaryHandler);
            _binaryHandler.nextHandler(_decimalHandler);
            _decimalHandler.nextHandler(_hexadecimalHandler);
            _hexadecimalHandler.nextHandler(_additionHandler);
            _additionHandler.nextHandler(_subtractionHandler);
            _subtractionHandler.nextHandler(_multiplicationHandler);
            _multiplicationHandler.nextHandler(_divisionHandler);
            _divisionHandler.nextHandler(_factorialHandler);
            _factorialHandler.nextHandler(_squareRootHandler);
            _squareRootHandler.nextHandler(_squareHandler);
            _squareHandler.nextHandler(_absoluteValueHandler);
        }

        public int EvalRPN(string input)
        {
            _operators = new RPNCalulator.Stack<int>();
            var splitInput = input.Split(' ');
            foreach (var op in splitInput)
            {
                _defaultHandler.dispatch(op, _operators);
            }

            var result = _operators.Pop();
            if (_operators.IsEmpty)
                return result;
            throw new InvalidOperationException();
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var rpn = new RPN();
            Console.WriteLine(rpn.EvalRPN("B101 #AB @"));
        }
    }
}