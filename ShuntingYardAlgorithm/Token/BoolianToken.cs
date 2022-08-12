using ShuntingYardAlgorithm.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Token
{
    public class BoolianToken : IBoolianToken
    {
        public EShYAlgorithm.BoolianType Type { get; set; }
        public bool Value { get; set; }
        public char RawValue { get; set; }
    }
}
