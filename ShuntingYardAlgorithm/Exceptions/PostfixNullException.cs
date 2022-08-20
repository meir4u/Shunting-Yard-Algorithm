using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Exceptions
{
    internal class PostfixNullException : Exception
    {
        public PostfixNullException()
        {

        }

        public PostfixNullException(string message)
            : base(message)
        {
        }

        public PostfixNullException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
