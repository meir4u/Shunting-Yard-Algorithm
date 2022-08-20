using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Exceptions.General
{
    internal class OperatorTypeNotSupportedException : Exception
    {
        public OperatorTypeNotSupportedException()
        {
        }

        public OperatorTypeNotSupportedException(string message)
            : base(message)
        {
        }

        public OperatorTypeNotSupportedException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
