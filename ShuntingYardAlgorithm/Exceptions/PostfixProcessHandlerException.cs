using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Exceptions
{
    internal class PostfixProcessHandlerException : System.Exception
    {
        public PostfixProcessHandlerException()
        {
        }

        public PostfixProcessHandlerException(string message)
            : base(message)
        {
        }

        public PostfixProcessHandlerException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
