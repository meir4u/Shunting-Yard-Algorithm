using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm
{
    public interface IData
    {
        EShYAlgorithm.DataType Type { get; set; }
        int Precedence { get; set; }
        bool Value { get; set; }
        char RawValue { get; set; }
    }
}
