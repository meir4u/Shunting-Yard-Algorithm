using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Base.Exceptions.General
{
    public class OperatorTypeNotSupportedException : Exception
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
