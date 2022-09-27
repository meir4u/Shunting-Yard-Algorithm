using ShuntingYardAlgorithm.Base.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Base.Token.Interface
{
    public interface IOperatorToken : IToken
    {
        EOperator.OperatorType Type { get; set; }
        int Precedence { get; set; }
    }
}
