using ShuntingYardAlgorithm.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Token
{
    public class OperatorToken : IOperatorToken
    {
        public EOperator.OperatorType Type { get; set; }
        public EOperator.Associative Associative { get; set; }
        public int Precedence { get; set; }
        public object RawValue { get; set; }
    }
}
