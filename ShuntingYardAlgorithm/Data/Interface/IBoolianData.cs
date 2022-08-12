using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm
{
    public interface IBoolianData : IData
    {
        EShYAlgorithm.BoolianType Type { get; set; }
        bool Value { get; set; }
    }
}
