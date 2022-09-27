using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Base.Token.Interface
{
    public interface IToken
    {
        object RawValue { get; set; }
    }
}
