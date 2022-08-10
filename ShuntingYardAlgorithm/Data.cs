using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm
{
    public class Data : IData
    {
        public EShYAlgorithm.DataType Type { get; set; }
        public int Precedence { get; set; }
        public bool Value { get; set; }
        public char RawValue { get; set; }
    }
}
