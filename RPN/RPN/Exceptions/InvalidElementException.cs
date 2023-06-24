using System;

namespace RPN.Exceptions
{
    public class InvalidElementException : Exception
    {
        public InvalidElementException(){}
        
        public InvalidElementException(string element)
            : base($"Unable to handle element in stack: \"{element}\"")
        {}
    }
}