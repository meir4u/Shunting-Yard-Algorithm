using ShuntingYardAlgorithm.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm
{
    public interface IBooleanToken : IToken
    {
        EOperator.BooleanType Type { get; set; }
        bool Value { get; set; }
    }
}
