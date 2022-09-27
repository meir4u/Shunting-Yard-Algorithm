using ShuntingYardAlgorithm.Base.Enum;
using ShuntingYardAlgorithm.Base.Token.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Base.Token
{
    public class BooleanToken : IBooleanToken
    {
        public EData.Type Type { get; set; }
        public object Value { get; set; }
        public object RawValue { get; set; }
    }
}
