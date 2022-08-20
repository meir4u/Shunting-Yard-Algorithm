using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Exceptions.Handler
{
    internal class ProcessHandlerNotSupportedException : System.Exception
    {
        public ProcessHandlerNotSupportedException()
        {
        }

        public ProcessHandlerNotSupportedException(string message)
            : base(message)
        {
        }

        public ProcessHandlerNotSupportedException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
