using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Base.Exceptions.Config
{
    public class OperatorConfigException : Exception
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
