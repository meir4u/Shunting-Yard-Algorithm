using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Enum
{
    public class EOperator
    {
        public enum OperatorType
        {
            None = 0,
            Or = 1,
            And = 2
        }

        public enum Associative
        {
            None = 0,
            Left,
            Right
        }

        public enum BooleanType
        {
            None = 0,
            Positive,
            Negative
        }
    }
}
