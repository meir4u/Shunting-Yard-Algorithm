using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Base.Exceptions.Token
{
    public class ParentesiStateNotSupportedException : Exception
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
