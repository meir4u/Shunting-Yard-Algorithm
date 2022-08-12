using ShuntingYardAlgorithm.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Token
{
    public class OperatorToken : IOperatorToken
    {
        public int Precedence { get; set; }
        public EShYAlgorithm.OperatorType Type { get; set; }
        public char RawValue { get; set; }
    }
}
