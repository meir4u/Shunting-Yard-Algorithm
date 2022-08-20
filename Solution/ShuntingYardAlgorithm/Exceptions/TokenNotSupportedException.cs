using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Exceptions
{
    internal class TokenNotSupportedException : System.Exception
    {
        public TokenNotSupportedException()
        {
        }

        public TokenNotSupportedException(string message)
            : base(message)
        {
        }

        public TokenNotSupportedException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
