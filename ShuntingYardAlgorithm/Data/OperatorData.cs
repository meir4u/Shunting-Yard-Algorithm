using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm
{
    public class OperatorData : IOperatorData
    {
        public int Precedence { get; set; }
        public EShYAlgorithm.OperatorType Type { get; set; }
        public char RawValue { get; set; }
    }
}
