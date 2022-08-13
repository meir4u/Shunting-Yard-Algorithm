using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Exceptions
{
    internal class TokenNotSupportedException : Exception
    {
        public TokenNotSupportedException()
        {
        }

        public TokenNotSupportedException(string message)
            : base(message)
        {
        }

        public TokenNotSupportedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
