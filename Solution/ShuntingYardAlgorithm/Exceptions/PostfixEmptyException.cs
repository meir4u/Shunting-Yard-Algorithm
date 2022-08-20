using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Exceptions
{
    internal class PostfixEmptyException : Exception
    {
        public PostfixEmptyException()
        {

        }

        public PostfixEmptyException(string message)
            : base(message)
        {
        }

        public PostfixEmptyException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
