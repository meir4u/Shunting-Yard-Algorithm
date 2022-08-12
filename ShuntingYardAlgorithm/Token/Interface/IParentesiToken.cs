using ShuntingYardAlgorithm.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm
{
    public interface IParentesiToken : IToken
    {
        EShYAlgorithm.ParentesiType Type { get; set; }
        int Precedence { get; set; }
    }
}
