using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Exceptions
{
    internal class CalculateException : Exception
    {
        public CalculateException()
        {
        }

        public CalculateException(string message)
            : base(message)
        {
        }

        public CalculateException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
