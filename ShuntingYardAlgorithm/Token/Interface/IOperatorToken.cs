using ShuntingYardAlgorithm.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm
{
    public interface IOperatorToken : IToken
    {
        EOperator.OperatorType Type { get; set; }
        int Precedence { get; set; }
    }
}
