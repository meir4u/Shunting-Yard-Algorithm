using ShuntingYardAlgorithm.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm
{
    public interface IOperatorToken : IToken
    {
        EShYAlgorithm.OperatorType Type { get; set; }
        int Precedence { get; set; }
    }
}
