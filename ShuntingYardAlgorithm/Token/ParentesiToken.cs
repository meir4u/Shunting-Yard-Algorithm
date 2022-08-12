using ShuntingYardAlgorithm.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Token
{
    public class ParentesiToken : IParentesiToken
    {
        public int Precedence { get; set; }
        public EShYAlgorithm.ParentesiType Type { get; set; }
        public char RawValue { get; set; }
    }
}
