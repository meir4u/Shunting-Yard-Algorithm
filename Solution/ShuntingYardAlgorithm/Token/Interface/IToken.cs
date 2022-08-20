using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm
{
    public interface IToken
    {
        object RawValue { get; set; }
    }
}
