using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Base.Exceptions.Config
{
    public class ParentasiConfigException : Exception
    {
        public ParentasiConfigException()
        {
        }

        public ParentasiConfigException(string message)
            : base(message)
        {
        }

        public ParentasiConfigException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
