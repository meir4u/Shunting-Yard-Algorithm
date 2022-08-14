using ShuntingYardAlgorithm.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm
{
    public interface IBooleanToken : IToken
    {
        EShYAlgorithm.BooleanType Type { get; set; }
        bool Value { get; set; }
    }
}
