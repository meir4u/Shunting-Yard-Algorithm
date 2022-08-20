using ShuntingYardAlgorithm.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Token
{
    public class BooleanToken : IBooleanToken
    {
        public EData.Type Type { get; set; }
        public object Value { get; set; }
        public object RawValue { get; set; }
    }
}
