using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Exceptions.Token
{
    internal class ParentesiStateNotSupportedException : Exception
    {
        public ParentesiStateNotSupportedException()
        {
        }

        public ParentesiStateNotSupportedException(string message)
            : base(message)
        {
        }

        public ParentesiStateNotSupportedException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
