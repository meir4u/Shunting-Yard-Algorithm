using ShuntingYardAlgorithm.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm
{
    public interface IBoolianToken : IToken
    {
        EShYAlgorithm.BoolianType Type { get; set; }
        bool Value { get; set; }
    }
}
