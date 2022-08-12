using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm
{
    public class ParentesiData : IParentesiData
    {
        public int Precedence { get; set; }
        public EShYAlgorithm.ParentesiType Type { get; set; }
        public char RawValue { get; set; }
    }
}
