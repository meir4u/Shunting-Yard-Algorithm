using ShuntingYardAlgorithm.Base.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Base.Token.Interface
{
    public interface IBooleanToken : IToken
    {
        EData.Type Type { get; set; }
        object Value { get; set; }
    }
}
