using ShuntingYardAlgorithm.Base.Enum;
using ShuntingYardAlgorithm.Base.Token.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm.Base.Token
{
    public class ParentesiToken : IParentesiToken
    {
        public int Precedence { get; set; }
        public EParentesi.ParentesiState Type { get; set; }
        public object RawValue { get; set; }
    }
}
