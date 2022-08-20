using ShuntingYardAlgorithm.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm
{
    public interface IBooleanToken : IToken
    {
        EData.Type Type { get; set; }
        object Value { get; set; }
    }
}
