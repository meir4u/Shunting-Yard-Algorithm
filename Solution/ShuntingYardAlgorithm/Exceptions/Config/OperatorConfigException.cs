using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Exceptions.Config
{
    internal class OperatorConfigException : Exception
    {
        public OperatorConfigException()
        {
        }

        public OperatorConfigException(string message)
            : base(message)
        {
        }

        public OperatorConfigException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
