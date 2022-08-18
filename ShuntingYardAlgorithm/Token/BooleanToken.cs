using ShuntingYardAlgorithm.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Token
{
    public class BooleanToken : IBooleanToken
    {
        public EOperator.BooleanType Type { get; set; }
        public bool Value { get; set; }
        public object RawValue { get; set; }
    }
}
