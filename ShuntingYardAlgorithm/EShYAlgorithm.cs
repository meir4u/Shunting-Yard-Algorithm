using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm
{
    public class EShYAlgorithm
    {
        public enum OperatorType
        {
            Or = 1,
            And = 2
        }

        public enum ParentesiType
        {
            Open = 0,
            Close
        }

        public enum BoolianType
        {
            Positive,
            Negative
        }
    }
}
