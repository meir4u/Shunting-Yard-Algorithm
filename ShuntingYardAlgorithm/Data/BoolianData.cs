using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm
{
    public class BoolianData : IBoolianData
    {
        public EShYAlgorithm.BoolianType Type { get; set; }
        public bool Value { get; set; }
        public char RawValue { get; set; }
    }
}
