using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm
{
    public interface IOperatorData : IData
    {
        EShYAlgorithm.OperatorType Type { get; set; }
        int Precedence { get; set; }
    }
}
