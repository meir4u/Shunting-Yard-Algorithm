using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm
{
    public interface IToken
    {
        char RawValue { get; set; }
    }
}
