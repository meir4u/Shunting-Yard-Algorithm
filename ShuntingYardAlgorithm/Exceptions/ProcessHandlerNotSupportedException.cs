using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Exceptions
{
    internal class ProcessHandlerNotSupportedException : Exception
    {
        public ProcessHandlerNotSupportedException()
        {
        }

        public ProcessHandlerNotSupportedException(string message)
            : base(message)
        {
        }

        public ProcessHandlerNotSupportedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
